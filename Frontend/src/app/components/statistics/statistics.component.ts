import {Component, OnInit} from '@angular/core';
import {StatisticsService} from "../../shared/statistics.service";
import {IHistory, IPosts, IProblems, IRatings} from "../../models/statistics";

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {
	problems?: IProblems[] = [];
	ratings?: IRatings[] = [];
	posts?: IPosts[] = [];
	history?: IHistory[] = [];
	count?: number
	userName?: string
	tooltipOptions = {
		'placement': 'bottom',
		'hide-delay': 0,
		'theme': "light"
	};

  	constructor(private statisticsService: StatisticsService) {}

  	ngOnInit(): void {
  		this.getStatistics();
  	}

	getStatistics() {
		this.statisticsService.getStatistics()
			.subscribe(data => {
				this.problems = data.problems;
				this.ratings = this.getRatings(data.ratings).reverse();
				this.posts = this.getPosts(data.posts);
				this.history = data.history;
				this.count = data.info
				this.userName = data.userName
			}
			);
  	}

  	getRatings(data: any): IRatings[] {
		let holder: any = {available: {}, solved: {}};
		for(let i = 5; i <= 100; i += 5) {
			holder.available[i] = 0;
			holder.solved[i] = 0;
		}
		data.forEach(function(d: any) {
			holder.solved[d.difficulty] += d.solved ? 1 : 0;
			holder.available[d.difficulty]++;
		});
		let ret = [];
		for (let i = 5; i <= 100; i += 5) {
			ret.push({difficulty: i,
				available: holder.available[i],
				solved: holder.solved[i],
				progress: holder.available[i] == 0 ? 0 : holder.solved[i] / holder.available[i]})
		}
		return ret;
	}

	getPosts(data: any): IPosts[] {
		let result = data.reduce(function (r: any, a: any) {
			r[a.problemId] = r[a.problemId] || [];
			r[a.problemId].push(a);
			return r;
		}, Object.create(null));

		var resultArray = Object.keys(result).map(function(personNamedIndex){
			let person = result[personNamedIndex];
			// do something with person
			return person;
		});

		return resultArray;
	}

	getColor(weight: string) {
  		const colorFrom = [0, 97, 255]
		const colorTo = [96, 239, 255]
		const w1 = parseInt(weight,10) / 100;
		const w2 = 1 - w1;

		return [Math.round(colorFrom[0] * w1 + colorTo[0] * w2),
			Math.round(colorFrom[1] * w1 + colorTo[1] * w2),
			Math.round(colorFrom[2] * w1 + colorTo[2] * w2)];
	}
}

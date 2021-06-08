import { Component, OnInit } from '@angular/core';
import {ProblemService} from "../../shared/problem.service";
import {StatisticsService} from "../../shared/statistics.service";
import {IProblems, IRatings, IStatistics} from "../../models/statistics";
import {IProblem} from "../../models/problem";

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {
	problems?: IProblems[] = [];
	ratings?: IRatings[] = [];
	tooltipOptions = {
		'placement': 'bottom',
		'hide-delay': 0,
		'theme': "light"
	};

  	constructor(private statisticsService: StatisticsService) { }

  	ngOnInit(): void {
  		this.getStatistics();
  	}

	getStatistics() {
		this.statisticsService.getStatistics()
			.subscribe(data => {
				this.problems = data.problems;
				this.ratings = this.getRatings(data.ratings).reverse();
				console.log(this.ratings);
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
}

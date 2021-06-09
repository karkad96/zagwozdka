import { Component, OnInit } from '@angular/core';
import {IProblem, ITag} from "../../models/problem";
import {ProblemService} from "../../shared/problem.service";

@Component({
  selector: 'app-problem-list',
  templateUrl: './problem-list.component.html',
  styleUrls: ['./problem-list.component.scss']
})
export class ProblemListComponent implements OnInit {

	public problems: IProblem[] = []
	private allProblems: IProblem[] = []
	public tags: ITag[] = []
	public defaultTag: number = 0;

	constructor(private problemService: ProblemService) {
	}

	ngOnInit() {
		this.problemService.getProblems().subscribe(data => {
			this.problems = data.problems;
			this.allProblems = data.problems;
			this.tags = data.tags;
		});
	}

	onCategoryChange(event: any) {
		if(event == 0){
			this.problems = this.allProblems;
			return;
		}
		this.problems = [];
		this.allProblems.forEach(p => {
			if(p.tags.some( t => t.tagId == event))
				this.problems.push(p);
		});
	}
}

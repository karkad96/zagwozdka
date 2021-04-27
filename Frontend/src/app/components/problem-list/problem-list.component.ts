import { Component, OnInit } from '@angular/core';
import {IProblem} from "../../models/problem";
import {ProblemService} from "../../shared/problem.service";

@Component({
  selector: 'app-problem-list',
  templateUrl: './problem-list.component.html',
  styleUrls: ['./problem-list.component.scss']
})
export class ProblemListComponent implements OnInit {

	public problems: IProblem[] = []

	constructor(private problemService: ProblemService) { }

	ngOnInit() {
		this.problemService.getProblems().subscribe(data => this.problems = data);
	}
}

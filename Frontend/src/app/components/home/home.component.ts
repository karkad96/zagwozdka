import { Component, OnInit } from '@angular/core';
import {ProblemService} from "../../shared/problem.service";
import {IProblem} from "../../models/problem";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
	public problems: IProblem[] = []

	constructor(private problemService: ProblemService) { }

	ngOnInit() {
		this.problemService.getProblems().subscribe(data => this.problems = data);
	}
}

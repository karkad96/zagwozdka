import { Component, OnInit } from '@angular/core';
import {IProblem} from "../../models/problem";
import {ActivatedRoute} from "@angular/router";
import {ProblemService} from "../../shared/problem.service";

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss']
})
export class ProblemComponent implements OnInit {
	problem!: IProblem;

	constructor(
		private route: ActivatedRoute,
		private problemService: ProblemService
	) {}

  	ngOnInit(): void {
		this.getProblem();
  	}

	getProblem(): void {
		const id = Number(this.route.snapshot.paramMap.get('id'));
		this.problemService.getProblem(id)
			.subscribe(data => this.problem = data);
	}

}

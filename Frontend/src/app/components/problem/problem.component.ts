import { Component, OnInit } from '@angular/core';
import {IProblem} from "../../models/problem";
import {ActivatedRoute} from "@angular/router";
import {ProblemService} from "../../shared/problem.service";
import { Location } from '@angular/common';
import {Observable} from "rxjs";
import {LoginService} from "../../shared/login.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss']
})
export class ProblemComponent implements OnInit {
	problem?: IProblem
	LoginStatus$! : Observable<boolean>;
	formModel = new FormGroup({
		Answer: new FormControl()
	});
	constructor(
		private route: ActivatedRoute,
		private problemService: ProblemService,
		private location: Location,
		private loginService: LoginService,
		private formBuilder: FormBuilder
	) {}

  	ngOnInit(): void {
		this.getProblem();
		this.LoginStatus$ = this.loginService.isLoggedIn;
  	}

	getProblem(): void {
		const id = Number(this.route.snapshot.paramMap.get('id'));
		this.problemService.getProblem(id)
			.subscribe(data => this.problem = data);
	}

	onSubmit() {
		console.log(this.formModel.value.Answer);
	}

	goBack(): void {
		this.location.back();
	}
}

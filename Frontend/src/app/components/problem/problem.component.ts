import { Component, OnInit } from '@angular/core';
import {IAnswer, IProblem} from "../../models/problem";
import {ActivatedRoute} from "@angular/router";
import {ProblemService} from "../../shared/problem.service";
import { Location } from '@angular/common';
import {Observable} from "rxjs";
import {LoginService} from "../../shared/login.service";
import {FormControl, FormGroup} from "@angular/forms";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-problem',
  templateUrl: './problem.component.html',
  styleUrls: ['./problem.component.scss']
})
export class ProblemComponent implements OnInit {
	problem?: IProblem
	answer?: IAnswer
	LoginStatus$! : Observable<boolean>;
	formModel = new FormGroup({
		Answer: new FormControl()
	});

	private readonly id: number;

	constructor(
		private route: ActivatedRoute,
		private problemService: ProblemService,
		private location: Location,
		private loginService: LoginService,
		private toastrService: ToastrService
	) {
		this.id = Number(this.route.snapshot.paramMap.get('id'));
	}

  	ngOnInit() {
		this.getProblem();
		this.getAnswer();
		this.LoginStatus$ = this.loginService.isLoggedIn;
  	}

	getProblem() {
		this.problemService.getProblem(this.id)
			.subscribe(data => this.problem = data);
	}

	getAnswer() {
		this.problemService.getAnswer(this.id)
			.subscribe(data => this.answer = data);
	}

	onSubmit() {
		this.problemService.postAnswer(this.id, {Answer: this.formModel.value.Answer})
			.subscribe(
			(res: any) => {
				if(res.response) {
					this.toastrService.success(
						'Brawo! Udało Ci się rozwiązać zagwozdke!', 'Zagwozdka rozwiązana!');
					this.problem!.isSolved = true;
					this.getAnswer();
				}
				else {
					this.toastrService.error(
						'Niestety. Podana odpowiedź nie jest prawidłowa', 'Coś poszło nie tak...');
				}
			}
		)
	}

	goBack(): void {
		this.location.back();
	}
}

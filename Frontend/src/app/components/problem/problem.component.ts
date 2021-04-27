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
		this.LoginStatus$ = this.loginService.isLoggedIn;
  	}

	getProblem() {
		this.problemService.getProblem(this.id)
			.subscribe(data => this.problem = data);
	}

	onSubmit() {
		this.problemService.postAnswer(this.id, {Answer: this.formModel.value.Answer})
			.subscribe(
			(res: any) => {
				console.log(res);
				if(res) {
					this.toastrService.success(
						'Brawo! Udało Ci się rozwiązać zagwozdke!', 'Zagwozdka rozwiązana!');
					this.problem!.isSolved = true;
					this.problem!.result = {answer: res.answer, solvedDate: res.solvedDate}
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

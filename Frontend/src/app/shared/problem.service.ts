import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable, of} from "rxjs";
import {IAnswer, IProblem, IProblemsAndTags, ITag} from "../models/problem";

@Injectable({
	providedIn: 'root'
})
export class ProblemService {
	private url: string = environment.baseUrl + '/Problem';

	constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) { }

	formModel = this.formBuilder.group({
		Title: ['', Validators.required],
		Description: ['', Validators.required],
		Answer: ['', Validators.required],
		Difficulty: ['', Validators.required],
	});

	getProblems(): Observable<IProblemsAndTags> {
		return this.httpClient.get<IProblemsAndTags>(this.url);
	}

	getProblem(id: number): Observable<IProblem> {
		return this.httpClient.get<IProblem>(this.url + '/' + id);
	}

	postAnswer(id: number, body: any) {
		return this.httpClient.post(this.url + '/' + id, body);
	}

	addproblem() {
		const body = {
			Title: this.formModel.value.Title,
			Description: this.formModel.value.Description,
			Answer: this.formModel.value.Answer,
			Difficulty: this.formModel.value.Difficulty
		};
		return this.httpClient.post(environment.baseUrl + '/Problem/Add', body)
	}
}

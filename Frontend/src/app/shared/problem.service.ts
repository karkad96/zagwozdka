import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable, of} from "rxjs";
import {IAnswer, IProblem, IProblemsAndTags, ITag} from "../models/problem";

@Injectable({
	providedIn: 'root'
})
export class ProblemService {
	private url: string = environment.baseUrl + '/Problem';

	constructor(private httpClient: HttpClient) { }

	getProblems(): Observable<IProblemsAndTags> {
		return this.httpClient.get<IProblemsAndTags>(this.url);
	}

	getProblem(id: number): Observable<IProblem> {
		return this.httpClient.get<IProblem>(this.url + '/' + id);
	}

	postAnswer(id: number, body: any) {
		return this.httpClient.post(this.url + '/' + id, body);
	}
}

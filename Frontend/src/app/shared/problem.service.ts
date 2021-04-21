import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable, of} from "rxjs";
import {IProblem} from "../models/problem";

@Injectable({
	providedIn: 'root'
})
export class ProblemService {
	constructor(private httpClient: HttpClient) { }

	getProblems(): Observable<IProblem[]> {
		return this.httpClient.get<IProblem[]>(environment.baseUrl + '/Home');
	}

	getProblem(id: number): Observable<IProblem> {
		return this.httpClient.get<IProblem>(environment.baseUrl + '/Home/' + id);
	}
}

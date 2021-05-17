import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable, of} from "rxjs";
import {IAnswer, IProblem} from "../models/problem";
import {IAccount} from "../models/account";
import {IPost} from "../models/post";

@Injectable({
	providedIn: 'root'
})
export class ThreadService {
	private url: string = environment.baseUrl + '/Thread';

	constructor(private httpClient: HttpClient) { }

	getPosts(id: number): Observable<IPost[]> {
		return this.httpClient.get<IPost[]>(this.url + '/' + id);
	}

	postLike(id: number, body: any) {
		return this.httpClient.post(this.url + '/' + id, body);
	}

	postPost(id: number, body: any): Observable<IPost[]>  {
		return this.httpClient.post<IPost[]>(this.url + '/' + id + '/Post', body);
	}
}

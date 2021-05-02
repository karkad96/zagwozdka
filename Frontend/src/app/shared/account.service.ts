import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {BehaviorSubject, Observable, of} from "rxjs";
import {IAnswer, IProblem} from "../models/problem";
import {IAccount} from "../models/account";

@Injectable({
	providedIn: 'root'
})
export class AccountService {
	private url: string = environment.baseUrl + '/Account';

	constructor(private httpClient: HttpClient) { }

	getAccount(): Observable<IAccount> {
		return this.httpClient.get<IAccount>(this.url);
	}

	getLanguages(): Observable<any> {
		return this.httpClient.get('assets/languages.json');
	}
}

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

	postImage(body: any): Observable<any> {
		return this.httpClient.post(this.url, body);
	}

	putBasicInfo(body: any): Observable<any> {
		return this.httpClient.put(this.url + '/BasicInfo', body);
	}

	putPassword(body: any): Observable<any> {
		return this.httpClient.put(this.url + '/Password', body);
	}

	putExtraInfo(body: any): Observable<any> {
		return this.httpClient.put(this.url + '/ExtraInfo', body);
	}

	deleteUser(): Observable<any> {
		return this.httpClient.delete(this.url + '/DeleteUser');
	}

	deleteProgress(): Observable<any> {
		return this.httpClient.delete(this.url + '/DeleteProgress');
	}
}

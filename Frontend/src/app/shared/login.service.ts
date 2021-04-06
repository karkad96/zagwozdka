import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Router} from "@angular/router";
import {BehaviorSubject} from "rxjs";

@Injectable({
	providedIn: 'root'
})
export class LoginService {
	constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private router: Router) { }

	private loginStatus = new BehaviorSubject<boolean>(this.checkLoginStatus());

	formModel = this.formBuilder.group({
		UserName: ['', Validators.required],
		Password: ['', Validators.required],
	});

	login() {
		const body = {
			UserName: this.formModel.value.UserName,
			Password: this.formModel.value.Password
		};
		return this.httpClient.post(environment.baseUrl + '/ApplicationUser/Login', body);
	}

	logout() {
		localStorage.removeItem('token');
		this.router.navigate(['/login']);
	}

	checkLoginStatus() : boolean {
		return !(localStorage.getItem('token') === null || localStorage.getItem('token') === undefined);
	}

	getAuthTest() {
		return this.httpClient.get(environment.baseUrl + '/AuthTest');
	}

	get isLoggedIn() {
		return this.loginStatus.asObservable();
	}

}

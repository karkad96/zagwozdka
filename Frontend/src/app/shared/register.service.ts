import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";

@Injectable({
	providedIn: 'root'
})
export class RegisterService {
	constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) { }

	formModel = this.formBuilder.group({
		UserName: ['', Validators.required],
		Email: ['', [Validators.email, Validators.required]],
		Passwords: this.formBuilder.group({
			Password: ['', [Validators.required, Validators.minLength(6)]],
			ConfirmPassword: ['', Validators.required]
		}, {validators: this.comparePasswords})
	});

	comparePasswords(fb: FormGroup) {
		let confirmPswrdCtrl = fb.get('ConfirmPassword');
		if (confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
			if (fb.get('Password')?.value != confirmPswrdCtrl?.value)
				confirmPswrdCtrl?.setErrors({ passwordMismatch: true });
			else
				confirmPswrdCtrl?.setErrors(null);
		}
	}

	register() {
		const body = {
			UserName: this.formModel.value.UserName,
			Email: this.formModel.value.Email,
			Password: this.formModel.value.Passwords.Password
		};
		return this.httpClient.post(environment.baseUrl + '/ApplicationUser/Register', body);
	}
}

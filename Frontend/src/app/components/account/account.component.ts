import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../shared/account.service";
import {
	FormBuilder,
	FormControl,
	FormGroup,
	FormGroupDirective,
	NgForm,
	Validators
} from "@angular/forms";
import {ErrorStateMatcher} from "@angular/material/core";

export class MyErrorStateMatcher implements ErrorStateMatcher {
	isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
		const isSubmitted = form && form.submitted;
		return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
	}
}

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
	detailsFormModel = new FormGroup({
		UserName: new FormControl('', [
			Validators.required,
		]),
		Email: new FormControl('', [
			Validators.required,
			Validators.email,
		])
	});

	passwordFormModel = this.formBuilder.group({
		Password: new FormControl('', [
			Validators.required
		]),
		ConfirmPassword: new FormControl('')
	}, { validators: this.comparePasswords });

	optionsFormModel = new FormGroup({
		options: new FormControl(''),
	});

	languageFormControl = new FormGroup({
		language: new FormControl(''),
	});
	languages?: string[];
	matcher = new MyErrorStateMatcher();

	constructor(private accountService: AccountService, private formBuilder: FormBuilder) { }

	ngOnInit(): void {
		this.getAccount();
		this.getLanguages();
	}

	getAccount() {
		this.accountService.getAccount()
			.subscribe(data => {
				this.detailsFormModel.controls.UserName.setValue(data.userName);
				this.detailsFormModel.controls.Email.setValue(data.email);
			});
	}

	getLanguages() {
		this.accountService.getLanguages()
			.subscribe(data => this.languages = data.languages);
	}

	comparePasswords(fb: FormGroup) {
		let confirmPswrdCtrl = fb.get('ConfirmPassword');
		if (confirmPswrdCtrl?.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
			if (fb.get('Password')?.value != confirmPswrdCtrl?.value)
				confirmPswrdCtrl?.setErrors({ passwordMismatch: true });
			else
				confirmPswrdCtrl?.setErrors(null);
		}
	}

	onSubmit() {
		this.accountService.getLanguages();
	}
}

import {Component, Input, OnInit} from '@angular/core';
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
import {ToastrService} from "ngx-toastr";
import {LoginService} from "../../shared/login.service";

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
			Validators.required
		]),
		Email: new FormControl('', [
			Validators.required,
			Validators.email
		])
	});

	passwordFormModel = this.formBuilder.group({
		Password: new FormControl('', [
			Validators.required
		]),
		ConfirmPassword: new FormControl('')
	}, { validators: this.comparePasswords });

	extraDetailsFormControl = new FormGroup({
		Language: new FormControl(''),
		ExtraInfo: new FormControl(''),
	});

	optionsFormModel = new FormGroup({
		Options: new FormControl(''),
	});

	@Input()
	maxlength?: string | number

	languages?: string[];
	matcher = new MyErrorStateMatcher();
	image?: any
	private base64textString: string = "";
	isShown: boolean = false;

	constructor(private accountService: AccountService,
				private formBuilder: FormBuilder,
				private toastrService: ToastrService,
				private loginService: LoginService
	) {
	}

	ngOnInit(): void {
		this.getAccount();
		this.getLanguages();
	}

	onShow() {
		this.isShown = !this.isShown;
	}

	getAccount() {
		this.accountService.getAccount()
			.subscribe(data => {
				this.detailsFormModel.controls.UserName.setValue(data.userName);
				this.detailsFormModel.controls.Email.setValue(data.email);
				this.extraDetailsFormControl.controls.Language.setValue(data.programmingLanguage);
				this.extraDetailsFormControl.controls.ExtraInfo.setValue(data.extraInfo);
				this.image = 'data:image/png;base64,' + data.image;
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

	onFileSelected(event: any) {
		const file = event.target.files[0];

		if (file) {
			const reader = new FileReader();
			reader.onload = this._handleReaderLoaded.bind(this);
			reader.readAsBinaryString(file);
		}
	}

	_handleReaderLoaded(readerEvt: any) {
		this.base64textString = btoa(readerEvt.target.result);
	}

	onImagePost() {
		this.image = 'data:image/png;base64,' + this.base64textString;

		this.accountService.postImage({Base64Image: this.base64textString})
			.subscribe((res: any) => {
				if(res == 200) {
					this.toastrService.success(
						'Aktualizacja danych powiod??a si??!', 'Aktualizacja pomy??lna!');
				}
				else {
					this.toastrService.error(
						'Co?? posz??o nie tak...', 'Aktualizacja danych niepomy??la');
				}
			});
	}

	onBasicUpdate() {
		this.accountService.putBasicInfo({UserName: this.detailsFormModel.get('UserName')?.value,
			Email: this.detailsFormModel.get('Email')?.value})
			.subscribe((res: any) => {
				if(res == 200) {
					this.toastrService.success(
						'Aktualizacja danych powiod??a si??!', 'Aktualizacja pomy??lna!');
				}
				else {
					this.toastrService.error(
						'Co?? posz??o nie tak...', 'Aktualizacja danych niepomy??la');
				}
			});
	}

	onPasswordUpdate() {
		this.accountService.putPassword({Password: this.passwordFormModel.get('Password')?.value})
			.subscribe((res: any) => {
				if(res == 200) {
					this.toastrService.success(
						 'Aktualizacja has??a powiod??a si??!', 'Aktualizacja pomy??lna!');
				}
				else {
					this.toastrService.error(
						'Co?? posz??o nie tak...', 'Aktualizacja has??a niepomy??la');
				}
				this.passwordFormModel.reset();
			});
	}

	onExtraUpdate() {
		let extrInfo = this.extraDetailsFormControl.get('ExtraInfo')?.value;
		extrInfo = (extrInfo == null || extrInfo == undefined) ? "" : extrInfo;

		let lang = this.extraDetailsFormControl.get('Language')?.value;
		lang = (lang == null || lang == undefined) ? "" : lang;


		this.accountService.putExtraInfo({
			ProgrammingLanguage: lang,
			ExtraInfo: extrInfo
		}).subscribe((res: any) => {
				if(res == 200) {
					this.toastrService.success(
						 'Aktualizacja dodatkowych danych powiod??a si??!', 'Aktualizacja pomy??lna!');
				}
				else {
					this.toastrService.error(
						 'Co?? posz??o nie tak...', 'Aktualizacja dodatkowych danych niepomy??la');
				}
			});
	}

	onOptionsUpdate() {
		const option = this.optionsFormModel.get('Options')?.value;
		switch (option) {
			case '1':
				this.deleteProgress();
				break;
			case '2':
				this.deleteUser();
				break;
		}
	}

	deleteUser() {
		this.accountService.deleteUser().subscribe((res: any) => {
			if(res == 200) {
				this.toastrService.success(
					'Usuni??cie konta powiod??a si??!', 'Usuni??cie konta pomy??lne!');
			}
			else {
				this.toastrService.error(
					'Co?? posz??o nie tak...', 'Usuni??cie konta niepomy??la');
			}
			this.loginService.logout();
		});
	}

	deleteProgress() {
		this.accountService.deleteProgress().subscribe((res: any) => {
			if(res == 200) {
				this.toastrService.success(
					 'Reset powiod?? si??!', 'Reset progresu pomy??lny!');
			}
			else {
				this.toastrService.error(
					 'Co?? posz??o nie tak...', 'Reset niepomy??lny');
			}
		});
	}
}

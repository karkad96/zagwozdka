import { ToastrService } from 'ngx-toastr';
import { LoginService } from '../../shared/login.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styles: []
})
export class LoginComponent implements OnInit {
	constructor(public loginService: LoginService, private router: Router, private toastr: ToastrService) { }

	ngOnInit() {
		if (localStorage.getItem('token') != null)
			this.router.navigateByUrl('/problem-list');
	}

	onSubmit() {
		this.loginService.login().subscribe(
			(res: any) => {
				localStorage.setItem('token', res.token);
				this.router.navigateByUrl('/problem-list');
			},
			err => {
				if (err.status == 400) {
					this.toastr.error('Nieprawidłowe hasło lub nazwa użytkownika.', 'Logowanie nie powiodło się.');
				}
				else {
					console.log(err);
				}
			}
		);
	}
}

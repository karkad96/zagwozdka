import {Component, OnInit} from '@angular/core';
import {LoginService} from "../../shared/login.service";
import {Observable} from "rxjs";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
	constructor(private loginService : LoginService) { }

	LoginStatus$! : Observable<boolean>;

	ngOnInit() {
		this.LoginStatus$ = this.loginService.isLoggedIn;
	}

	onLogout() {
		this.loginService.logout();
	}

}

import { Component, OnInit } from '@angular/core';
import { LoginService } from "../../shared/login.service";
import { Observable } from "rxjs";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {

	constructor(private loginService : LoginService) { }

	LoginStatus$! : Observable<boolean>;

	ngOnInit() {
		this.LoginStatus$ = this.loginService.isLoggedIn;
	}

	onLogout() {
		this.loginService.logout();
	}
}

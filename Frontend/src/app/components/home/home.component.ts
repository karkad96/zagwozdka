import { Component, OnInit } from '@angular/core';
import {LoginService} from "../../shared/login.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

	constructor(private service: LoginService) { }

	ngOnInit() {
		this.service.getAuthTest().subscribe(
			() => {
			},
			err => {
				console.log(err);
			},
		);
	}

}

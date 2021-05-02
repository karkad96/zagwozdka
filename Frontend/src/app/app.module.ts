import {CUSTOM_ELEMENTS_SCHEMA, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { AngularMaterialModule } from './angular-material.module';
import { LoginComponent } from './components/login/login.component';
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { RegisterService } from "./shared/register.service";
import { ToastrModule } from 'ngx-toastr';
import { LoginService } from "./shared/login.service";
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import {ProblemService} from "./shared/problem.service";
import {CdkTableModule} from "@angular/cdk/table";
import { NavComponent } from './components/nav/nav.component';
import { ProblemComponent } from './components/problem/problem.component';
import { ProblemListComponent } from './components/problem-list/problem-list.component';
import { AccountComponent } from './components/account/account.component';
import {AccountService} from "./shared/account.service";

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
	  LoginComponent,
	  NavMenuComponent,
	  NavComponent,
	  ProblemComponent,
	  ProblemListComponent,
	  AccountComponent,
  ],
	imports: [
		BrowserModule,
		AppRoutingModule,
		AngularMaterialModule,
		FlexLayoutModule,
		FormsModule,
		ReactiveFormsModule,
		BrowserAnimationsModule,
		HttpClientModule,
		ToastrModule.forRoot({
			progressBar: true
		}),
		CdkTableModule
	],
  providers: [
  	ProblemService,
	  AccountService,
  	RegisterService,
	  LoginService,
	  {
		  provide: HTTP_INTERCEPTORS,
		  useClass: AuthInterceptor,
		  multi: true
	  }
  ],
  bootstrap: [AppComponent],
	schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
}

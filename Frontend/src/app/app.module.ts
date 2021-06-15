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
import {MatInputModule} from "@angular/material/input";
import { ProblemThreadComponent } from './components/problem-thread/problem-thread.component';
import {ThreadService} from "./shared/thread.service";
import {DeletePostComponent} from "./components/problem-thread/dialog/delete-post.component";
import {ReportPostComponent} from "./components/problem-thread/dialog/report-post.component";
import { StatisticsComponent } from './components/statistics/statistics.component';
import {StatisticsService} from "./shared/statistics.service";
import { TooltipModule } from 'ng2-tooltip-directive';
import {MatProgressBarModule} from "@angular/material/progress-bar";
import { AddProblemComponent } from './components/add-problem/add-problem.component';

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
	  ProblemThreadComponent,
	  DeletePostComponent,
	  ReportPostComponent,
	  StatisticsComponent,
	  AddProblemComponent
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
		MatInputModule,
		TooltipModule,
		MatProgressBarModule,
		ToastrModule.forRoot({
			progressBar: true
		}),
		CdkTableModule
	],
	entryComponents: [
		DeletePostComponent,
		ReportPostComponent
	],
  providers: [
  	ProblemService,
	  AccountService,
	  ThreadService,
	  StatisticsService,
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

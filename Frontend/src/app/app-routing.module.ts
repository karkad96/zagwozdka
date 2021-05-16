import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import {AuthGuard} from "./auth/auth.guard";
import {ProblemComponent} from "./components/problem/problem.component";
import {ProblemListComponent} from "./components/problem-list/problem-list.component";
import {AccountComponent} from "./components/account/account.component";
import {ProblemThreadComponent} from "./components/problem-thread/problem-thread.component";

const routes: Routes = [
	{ path: '', pathMatch: 'full', redirectTo: 'login' },
	{ path: 'login', component: LoginComponent },
	{ path: 'register', component: RegisterComponent },
	{ path: 'problem-list', component: ProblemListComponent },
	{ path: 'problem/:id', component: ProblemComponent },
	{ path: 'account', component: AccountComponent, canActivate: [AuthGuard] },
	{ path: 'problem-thread/:id', component: ProblemThreadComponent, canActivate: [AuthGuard] }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})

export class AppRoutingModule { }

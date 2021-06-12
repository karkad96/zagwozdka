import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {IStatistics} from "../models/statistics";

@Injectable({
	providedIn: 'root'
})
export class StatisticsService {
	private url: string = environment.baseUrl + '/Statistics';

	constructor(private httpClient: HttpClient) { }

	getStatistics(): Observable<IStatistics> {
		return this.httpClient.get<IStatistics>(this.url);
	}
}

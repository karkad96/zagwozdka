import {Component, Inject} from "@angular/core";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";

@Component({
	selector: 'report-post',
	templateUrl: './report-post.component.html',
})
export class ReportPostComponent {
	constructor(@Inject(MAT_DIALOG_DATA) public data: {report: string}) {}
}

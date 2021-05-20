import {Component, Inject} from "@angular/core";
import {MAT_DIALOG_DATA} from "@angular/material/dialog";

@Component({
	selector: 'delete-post',
	templateUrl: './delete-post.component.html',
})
export class DeletePostComponent {
	constructor(@Inject(MAT_DIALOG_DATA) public data: {name: string}) {}
}

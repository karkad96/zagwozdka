import { Component, OnInit } from '@angular/core';
import {ThreadService} from "../../shared/thread.service";
import {IPost} from "../../models/post";
import {ActivatedRoute} from "@angular/router";
import {FormControl, FormGroup} from "@angular/forms";
import {ToastrService} from "ngx-toastr";
import {MatDialog} from "@angular/material/dialog";
import {DeletePostComponent} from "./dialog/delete-post.component";
import {ReportPostComponent} from "./dialog/report-post.component";

@Component({
  selector: 'app-problem-thread',
  templateUrl: './problem-thread.component.html',
  styleUrls: ['./problem-thread.component.scss']
})
export class ProblemThreadComponent implements OnInit {
  	posts?: IPost[];
	id: number;
	report?: string;

	postFormModel = new FormGroup({
		Content: new FormControl()
	});

	editPostFormModel = new FormGroup({
		Content: new FormControl()
	});

	constructor(private threadService: ThreadService,
				private route: ActivatedRoute,
				private toastrService: ToastrService,
				public dialog: MatDialog
	) {
		this.id = Number(this.route.snapshot.paramMap.get('id'));
	}

  	ngOnInit(): void {
  		this.getPosts();
  	}

  	getPosts() {
  		this.threadService.getPosts(this.id).subscribe(data => this.posts = data);
  	}

  	onLike(postId: number) {
		const post = this.posts?.find(x => x.postId === postId)
		this.threadService.postLike(this.id, {postId: postId, liked: !post!.isLiked})
			.subscribe(
				(res: any) => {
					post!.isLiked = !post!.isLiked;
					post!.likes = post!.isLiked ? post!.likes + 1 : post!.likes - 1;
				}
				);
	}

	onAddPost() {
		let content = this.postFormModel.get('Content')?.value;
		if(content == undefined || content == "") {
			this.toastrService.error(
				'Nie można dodać pustego komentarza!', 'Nipomyślne przesłanie komentarza!');
		} else {
			this.threadService
				.postPost(this.id, {Content: content})
				.subscribe((res: any) => {
					this.posts = res;
					this.toastrService.success(
						'Komentarz został dodany!', 'Pomyślne przesłanie komentarza!');
					this.postFormModel.reset();
				});
		}
	}

	onEdit(postId: number) {
		let post = this.posts!.find(x => x.postId === postId);
		post!.isEditable = !post!.isEditable;
		this.editPostFormModel.get('Content')!.setValue(post!.content);
	}

	onEditPost(postId: number) {
		this.threadService.putPost(this.id,
			{PostId: postId, Content: this.editPostFormModel.get('Content')!.value})
			.subscribe(
				(res: any) => {
					this.posts = res;
					this.toastrService.success(
						'Komentarz zaktualizowany!', 'Pomyślne zaktualizowałeś komentarz!');
				});
	}

	onDelete(postId: number) {
		const dialogRef = this.dialog.open(DeletePostComponent);
		dialogRef.afterClosed().subscribe(result => {
			if(result==true) {
				this.threadService.deletePost(this.id, postId).subscribe(
					(res: any) => {
						this.posts = res;
						this.toastrService.success(
							'Komentarz usunięty!', 'Pomyślne usunięto komentarz!');
					});
			}
		});
	}

	onReport(postId: number) {
		const dialogRef = this.dialog.open(ReportPostComponent, {
			width: '500px',
			data: {report: this.report}
		});

		dialogRef.afterClosed().subscribe(result => {
			if(result != undefined || result != null || result!= "") {
				console.log(result);
			}
			else {

			}
		});
	}
}

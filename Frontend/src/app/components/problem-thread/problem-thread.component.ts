import { Component, OnInit } from '@angular/core';
import {ThreadService} from "../../shared/thread.service";
import {IPost} from "../../models/post";
import {ActivatedRoute} from "@angular/router";
import {FormControl, FormGroup} from "@angular/forms";
import {ToastrService} from "ngx-toastr";
import {HttpHeaders} from "@angular/common/http";

@Component({
  selector: 'app-problem-thread',
  templateUrl: './problem-thread.component.html',
  styleUrls: ['./problem-thread.component.scss']
})
export class ProblemThreadComponent implements OnInit {
  	posts?: IPost[];
	id: number;
	postFormModel = new FormGroup({
		Content: new FormControl()
	});

	editPostFormModel = new FormGroup({
		Content: new FormControl()
	});

	constructor(private threadService: ThreadService,
				private route: ActivatedRoute,
				private toastrService: ToastrService
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
		this.threadService.deletePost(this.id, postId).subscribe(
			(res: any) => {
				this.posts = res;
				this.toastrService.success(
					'Komentarz usunuęty!', 'Pomyślne usunięto komentarz!');
			});
	}
}

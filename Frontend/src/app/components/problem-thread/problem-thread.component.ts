import { Component, OnInit } from '@angular/core';
import {ThreadService} from "../../shared/thread.service";
import {IPost} from "../../models/post";
import {ActivatedRoute} from "@angular/router";
import {FormControl, FormGroup} from "@angular/forms";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-problem-thread',
  templateUrl: './problem-thread.component.html',
  styleUrls: ['./problem-thread.component.scss']
})
export class ProblemThreadComponent implements OnInit {
  	posts?: IPost[]
	id: number;
	postFormModel = new FormGroup({
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
		this.threadService
			.postPost(this.id, {Content: this.postFormModel.get('Content')?.value})
			.subscribe((res: any) => {
				this.posts = res;
				this.toastrService.success(
					'Komentarz został dodany!', 'Pomyślne przesłanie komentarza!');
				this.postFormModel.reset();
			});
	}
}

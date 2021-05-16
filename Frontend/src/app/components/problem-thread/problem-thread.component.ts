import { Component, OnInit } from '@angular/core';
import {ThreadService} from "../../shared/thread.service";
import {IPost} from "../../models/post";
import {ActivatedRoute} from "@angular/router";
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-problem-thread',
  templateUrl: './problem-thread.component.html',
  styleUrls: ['./problem-thread.component.scss']
})
export class ProblemThreadComponent implements OnInit {
  	posts?: IPost[]
	id: number;

	constructor(private threadService: ThreadService,
				private route: ActivatedRoute
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
		this.threadService.postLike(this.id, {postId: postId})
			.subscribe(
				(res: any) => {
					post!.isLiked = true;
					post!.likes++;
				}
			);
	}
}

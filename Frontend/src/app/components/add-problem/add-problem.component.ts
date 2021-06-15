import { Component, OnInit } from '@angular/core';
import { ProblemService } from '../../shared/problem.service';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-add-problem',
	templateUrl: './add-problem.component.html',
	styleUrls: ['./add-problem.component.scss']
})
export class AddProblemComponent implements OnInit {

	constructor(public problemService: ProblemService, private toastrService: ToastrService) { }

	ngOnInit(): void {
		this.problemService.formModel.reset();
	}

	onSubmit() {
		this.problemService.addproblem().subscribe(
			(res: any) => {
				if (res.succeeded) {
					this.problemService.formModel.reset();
					this.toastrService.success('Dodano nową zagwozdkę!', 'Dodawanie pomyślne');
				} else {
					res.errors.forEach((element: any) => {
						switch (element.code) {
							default:
								this.toastrService.error(element.description, 'Add new problem failed');
								break;
						}
					});
				}
			}
		);
	}

}

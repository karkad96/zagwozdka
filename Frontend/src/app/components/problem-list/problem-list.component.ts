import {Component, OnInit, ViewChild} from '@angular/core';
import {IProblem, ITag} from "../../models/problem";
import {ProblemService} from "../../shared/problem.service";
import {MatTableDataSource} from "@angular/material/table";
import {MatPaginator} from "@angular/material/paginator";
import {MatSort} from "@angular/material/sort";

@Component({
  selector: 'app-problem-list',
  templateUrl: './problem-list.component.html',
  styleUrls: ['./problem-list.component.scss']
})
export class ProblemListComponent implements OnInit {
	public problems: IProblem[] = []
	private allProblems: IProblem[] = []
	public tags: ITag[] = []
	public defaultTag: number = 0;
	public dataSource!: MatTableDataSource<IProblem>;

	@ViewChild(MatSort) sort!: MatSort;
	@ViewChild(MatPaginator) paginator!: MatPaginator;

	constructor(private problemService: ProblemService) {
	}

	ngOnInit() {
		this.problemService.getProblems().subscribe(data => {
			this.problems = data.problems;
			this.allProblems = data.problems;
			this.tags = data.tags;
			this.dataSource = new MatTableDataSource<IProblem>(this.problems);
			this.dataSource.paginator = this.paginator;
			this.dataSource.sort = this.sort;
		});
	}

	onCategoryChange(event: any) {
		if(event == 0){
			this.problems = this.allProblems;
			this.dataSource.data = this.allProblems;
			return;
		}
		this.problems = [];
		this.allProblems.forEach(p => {
			if(p.tags.some( t => t.tagId == event))
				this.problems.push(p);
		});
		this.dataSource.data = this.problems;
	}
}

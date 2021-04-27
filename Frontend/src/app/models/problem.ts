export interface IProblem {
	problemId: number
	title: string
	description: string
	solvedBy: number
	difficulty: string
	releaseDate: string
	tags: Array<ITag>
	isSolved: boolean
	result: IAnswer
}

export interface ITag {
	tagId: number
	tagName: string
}

export interface IAnswer {
	answer: string
	solvedDate: string
}

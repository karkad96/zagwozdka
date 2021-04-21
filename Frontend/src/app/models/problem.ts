export interface IProblem {
	problemId: number
	title: string
	description: string
	answer: string
	solvedBy: number
	difficulty: string
	releaseDate: string
	tags: Array<ITag>
}

export interface ITag {
	tagId: number
	tagName: string
	problemId: number
}

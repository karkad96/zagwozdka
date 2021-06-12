
export interface IStatistics {
	problems: IProblems[]
	ratings: IRatings[]
	posts: IPosts[]
	history: IHistory[]
	info: number
	userName: string
}

export interface IProblems {
	problemId: number
	title: string
	solvedBy: number
	difficulty: string
	solvedDate: string
	isSolved: boolean
}

export interface IRatings {
	difficulty: number,
	available: number,
	solved: number,
	progress: number
}

export interface IPosts {
	problemId: number
	postId: number,
	likes: number,
	reports: number
}

export interface IHistory {
	problemId: number
	solvedDate: string
}


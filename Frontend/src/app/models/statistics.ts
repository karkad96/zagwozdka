
export interface IStatistics {
	problems: IProblems[]
	ratings: IRatings[]
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

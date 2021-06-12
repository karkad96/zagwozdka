
export interface IStatistics {
	problems: IProblems[]
	ratings: IRatings[]
	history: IHistory[]
	ranking: IRanking[]
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

export interface IHistory {
	problemId: number
	solvedDate: string
}

export interface IRanking {
	userName: string,
	solved: number,
	extraInfo: string,
	programmingLanguage: string
}

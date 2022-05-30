import { Candidate } from "./candidate.model";

export interface Pagination {
    currentPage: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
    items: Candidate[]
}
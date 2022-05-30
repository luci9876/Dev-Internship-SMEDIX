import { Candidate } from "./candidate.model";
import { StageStatus } from "./stageStatus.model";

export interface CandidateHistory {
    id?: number,
    entryDateTime?: Date,
    plannedDate?: Date,
    notes?: string,
    manager?: string,
    issuer?: string,
    stageStatus?: StageStatus,
    candidateId?:number
}
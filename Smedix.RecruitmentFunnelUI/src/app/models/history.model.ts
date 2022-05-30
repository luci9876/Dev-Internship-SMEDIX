import { Candidate } from "./candidate.model";
import { StageStatusIds } from "./stage-status.model-id";

export interface HistoryModel {
    id?: number,
    entryDateTime?: Date,
    plannedDate?: Date,
    notes?: string,
    manager?: string,
    issuer?: string,
    candidate?: Candidate,
    stageStatus?: StageStatusIds
}
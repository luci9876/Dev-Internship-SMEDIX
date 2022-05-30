import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { CandidateHistory } from "../models/candidateHistory.model";
import { HistoryModel } from "../models/history.model";
import { StageStatusDto } from "../models/stage-status-dto.model";

@Injectable({ providedIn: 'root' })
export class HistoryService {
    private url = `${environment.apiUrl}`

    constructor(private http: HttpClient) { }

    getStageAndStatuses() {
        return this.http.get<StageStatusDto[]>(`${this.url}getStageStatuses`);
    }
    updateHistory(history: HistoryModel) {
        return this.http.put<any>(`${this.url}candidate-history`, history);
    }
    getHistorySteps(id: number) {
        return this.http.get<CandidateHistory[]>(`${this.url}getHistorySteps?candidateId=${id}`);
    }
    deleteHistoryStep(id: number) {
        return this.http.delete<string>(`${this.url}CandidateHistory?id=${id}`);
    }
}
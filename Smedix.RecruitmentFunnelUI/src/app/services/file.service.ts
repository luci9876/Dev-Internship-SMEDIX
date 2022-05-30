import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { CandidateFile } from "../models/candidate-file.model";
import { FileDetails } from "../models/file-details.model";

@Injectable({ providedIn: 'root' })
export class FileService {
  private url = `${environment.apiUrl}CandidateFile/`;

  constructor(private http: HttpClient) { }

  getFilesForCandidate(id: number) {
    return this.http.get<CandidateFile[]>(`${this.url}${id}`);
  }
  
  createFile(file: FormData) {
    return this.http.post<any>(`${this.url}`, file);
  }

  getFile(fileDetails: FileDetails) {
    return this.http.get<CandidateFile>(`${this.url}?candidateId=${fileDetails.candidateId}&fileName=${fileDetails.fileName}`);
  }
}
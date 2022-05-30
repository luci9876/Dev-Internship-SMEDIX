import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { delay, map, Observable } from 'rxjs';
import { CandidateModel } from '../models/candidate-model.model';
import { Candidate } from '../models/candidate.model';
import { Role } from '../models/role.model';
import { Status } from '../models/status.model';
import { Technology } from '../models/technology.model';
import { CandidateParams } from '../models/candidateParams.model';
import { Pagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  private httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  private baseUrl = `${environment.apiUrl}`;

  constructor(private http: HttpClient) { }

  getCandidate(id: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}getById?id=${id}`);
  }

  addCandidate(candidate: Candidate): Observable<number> {
    return this.http.post<number>(`${this.baseUrl}Candidate`, candidate, this.httpOptions);
  }

  getCandidateStatuses() {
    return this.http.get<Status[]>(`${this.baseUrl}getCandidateStatuses`);
  }

  getCandidateTechnologies() {
    return this.http.get<Technology[]>(`${this.baseUrl}getTechnologies`);
  }

  getCandidateRoles() {
    return this.http.get<Role[]>(`${this.baseUrl}getRoles`);
  }

  search(candidateParams: CandidateParams, queryParams: String): Observable<Pagination> {
    let params = this.getParams(candidateParams.pageNumber, candidateParams.pageSize);
    return this.http.get<Pagination>(`${this.baseUrl}Candidate?searchName=${candidateParams.searchName}&orderBy=${queryParams}`, { params }).pipe(delay(1000));
  }

  getCandidateDto(id: Number, candidateParams: CandidateParams): Observable<any> {
    let params = this.getParams(candidateParams.pageNumber, candidateParams.pageSize);
    return this.http.get<Pagination>(`${this.baseUrl}Candidate?searchName=${""}`, { params }).pipe(map(list => {
      for (const c of list.items) {
        if (c.id == id)
          return c;
      }
      return null;
    }));
  }

  public deleteCandidate(id: number) {
    return this.http
      .delete(`${this.baseUrl}Candidate?id=${id}`, { responseType: 'text' });
  }

  public saveCandidate(details: CandidateModel): Observable<any> {
    var info = {
      id: details.id,
      name: details.name,
      email: details.email,
      phone: details.phone,
      address: details.address,
      company: details.company,
      yearsOfExperience: details.yearsOfExperience,
      linkedIn: details.linkedIn,
      notes: details.notes,
      referredBy: details.referredBy,
      lastUpdated: details.lastUpdated,
      source: details.source
    } as CandidateModel;

    var candidate = {
      id: details.id,
      name: details.name,
      lastStatus: details.candidateStatus,
      role: details.role,
      technology: details.candidateTechnologies?.[0]?.technology
    } as Candidate;

    this.updateCandidate(candidate);
    return this.http.put<CandidateModel>(`${this.baseUrl}candidate-details/`, info, this.httpOptions);
  }

  public updateCandidate(candidate: Candidate) {
    this.http.put<Candidate>(`${this.baseUrl}Candidate/`, candidate, this.httpOptions).subscribe();
  }

  addCandidateHistory(candidateId: number): Observable<number> {
    return this.http.post<number>(`${this.baseUrl}CandidateHistory?candidateId=${candidateId}`, candidateId);
  }

  private getParams(page: number, itemsPerPage: number) {
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }
    return params;
  }
}

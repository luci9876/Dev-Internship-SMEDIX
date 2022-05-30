import { FileService } from '../services/file.service';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Candidate } from '../models/candidate.model';
import { CandidateService } from '../services/candidate.service';
import { Status } from '../models/status.model';
import { Role } from '../models/role.model';
import { Technology } from '../models/technology.model';
import { Pagination } from '../models/pagination';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { CandidateParams } from '../models/candidateParams.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.scss']
})

export class CandidateListComponent implements OnInit {
  private file!: File;
  private filesName = 'files';
  private id = 'candidateId';
  candidates: Candidate[] = [];
  statusList: Status[] = [];
  roleList: Role[] = [];
  technologyList: Technology[] = [];
  searchCriteria: string = "";
  candidateParams: CandidateParams = new CandidateParams();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  candidatesPaged!: Pagination;
  nameCriteria = "arrow_downward";
  dateCriteria = "arrow_downward";
  nameQuery = "name";
  dateQuery = "lastUpdated";
  isNameCriteria:boolean=true;

  constructor(private candidateService: CandidateService, private fileService: FileService) { }

  ngOnInit(): void {
    this.candidateParams.pageSize = JSON.parse(localStorage.getItem('pageSize') || this.candidateParams.pageSize.toString());
    this.search(this.candidateParams);
    this.getCandidateStatuses();
    this.getCandidateRoles();
    this.getCandidateTechnologies();
  }

  getDeletedCandidate(candidateId: any) {
    this.candidatesPaged.items.forEach((value, index) => {
      if (value.id === candidateId)
        this.candidatesPaged.items.splice(index, 1);
    })
  }

  getCandidateStatuses() {
    this.candidateService.getCandidateStatuses().subscribe(statusList => this.statusList = statusList);
  }

  getCandidateTechnologies() {
    this.candidateService.getCandidateTechnologies().subscribe(techList => this.technologyList = techList);
  }

  getCandidateRoles() {
    this.candidateService.getCandidateRoles().subscribe(roleList => this.roleList = roleList);
  }

  import(): void {

  }

  export(): void {

  }

  onFileChanged(event: Event) {
    const target = event.target as HTMLInputElement;
    this.file = (target.files as FileList)[0];
    this.uploadFile();
  }

  uploadFile() {
    let candidate: Candidate = {
      name: '',
      candidateFiles: []
    };

    const uploadFile = new FormData();
    uploadFile.append(this.filesName, this.file);
    this.candidateService.addCandidate(candidate).subscribe(id => {
      candidate.id = id;
      this.updateTotalPages().subscribe(() => {
        this.candidateParams.pageNumber = this.candidatesPaged.totalPages;
        this.candidateService.getCandidateDto(id, this.candidateParams).subscribe(c => {
          candidate = c;
          uploadFile.append(this.id, id.toString());
          this.candidatesPaged.items.unshift(candidate);
          this.fileService.createFile(uploadFile).subscribe();
        });
      });
    }
    );
  }

  search(candidateParams: CandidateParams) {
    candidateParams.searchName = this.searchCriteria;
    return this.candidateService.search(candidateParams, this.nameQuery).subscribe(response => {
      this.candidatesPaged = response;
    })
  }

  updateTotalPages(): Observable<any> {
    this.candidateParams.searchName = this.searchCriteria;
    return this.candidateService.search(this.candidateParams, this.nameQuery).pipe(map(response => {
      this.candidatesPaged.totalPages = response.totalPages;
    }));
  }

  pageChanged(event: PageEvent) {
    localStorage.setItem('pageSize', (event.pageSize).toString());
    localStorage.setItem('pageNumber', (event.pageIndex + 1).toString());
    this.candidateParams.pageSize = JSON.parse(localStorage.getItem('pageSize') || '{}');
    this.candidateParams.pageNumber = JSON.parse(localStorage.getItem('pageNumber') || '{}');
    this.search(this.candidateParams);
  }

  onKey(event: any) {
    this.searchCriteria = event.target.value;
    this.search(this.candidateParams);
    this.paginator.firstPage();
  }

  nameSort() {
    this.isNameCriteria=true;
    if (this.nameCriteria == "arrow_upward") {
      this.nameCriteria = "arrow_downward";
      this.nameQuery = "name";
      this.candidateService.search(this.candidateParams, this.nameQuery).subscribe(response => {
        this.candidatesPaged = response;
      })
    }
    else {
      this.nameCriteria = "arrow_upward";
      this.nameQuery = "name desc";
      this.candidateService.search(this.candidateParams, this.nameQuery).subscribe(response => {
        this.candidatesPaged = response;
      })
    }
  }

  dateSort() {
    this.isNameCriteria=false;
    if (this.dateCriteria == "arrow_upward") {
      this.dateCriteria = "arrow_downward";
      this.dateQuery = "lastUpdated";
      this.candidateService.search(this.candidateParams, this.dateQuery).subscribe(response => {
        this.candidatesPaged = response;
      })
    }
    else {
      this.dateCriteria = "arrow_upward";
      this.dateQuery = "lastUpdated desc";
      this.candidateService.search(this.candidateParams, this.dateQuery).subscribe(response => {
        this.candidatesPaged = response;
      })
    }
  }
}

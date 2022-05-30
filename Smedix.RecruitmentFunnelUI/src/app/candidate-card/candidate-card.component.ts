import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Candidate } from '../models/candidate.model';
import { Role } from '../models/role.model';
import { Status } from '../models/status.model';
import { Technology } from '../models/technology.model';
import { CandidateService } from '../services/candidate.service';

@Component({
  selector: 'app-candidate-card',
  templateUrl: './candidate-card.component.html',
  styleUrls: ['./candidate-card.component.scss']
})
export class CandidateCardComponent implements OnInit {
  @Input() candidate!: Candidate;
  @Input() statusList: Status[] = [];
  @Input() roleList: Role[] = [];
  @Input() technologyList: Technology[] = [];
  @Output() deletedCandidate: EventEmitter<number> = new EventEmitter();
  deletedId: any;
  candidateControl: FormGroup;

  ngOnInit() {

  }

  constructor(private candidateService: CandidateService) {
    this.candidateControl = new FormGroup(
      {
        "status": new FormControl(Validators.required),
        "role": new FormControl(null),
        "technology": new FormControl(null)
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

  delete() {
    if (window.confirm(`You are about to permanently delete candidate ${this.candidate.name} from the application.`)) {
      this.candidateService.deleteCandidate(this.candidate.id!).subscribe(
        (resp) => {
          this.deletedCandidate.emit(this.candidate.id);
        }, (error) => {
          console.error(error);
        });
    };
  }

  update() {
    for (let status of this.statusList) {
      if (status.id == this.candidate.lastStatus?.id) {
        this.candidate.lastStatus = {
          id: status.id,
          name: status.name,
          colorHex: status.colorHex
        };
        break;
      }
    }

    for (let role of this.roleList) {
      if (role.id == this.candidate.role?.id) {
        this.candidate.role = {
          id: role.id,
          name: role.name
        };
        break;
      }
    }

    for (let tech of this.technologyList) {
      if (tech.id == this.candidate.technology?.id) {
        this.candidate.technology = {
          id: tech.id,
          name: tech.name
        };
        break;
      }
    }

    this.candidateService.updateCandidate(this.candidate);
  }
}

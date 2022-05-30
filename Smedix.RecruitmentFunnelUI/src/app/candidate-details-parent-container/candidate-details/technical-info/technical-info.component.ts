import { Component, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { CandidateModel } from 'src/app/models/candidate-model.model';
import { EventEmitter } from '@angular/core';
import { Status } from 'src/app/models/status.model';
import { Role } from 'src/app/models/role.model';
import { Technology } from 'src/app/models/technology.model';
import { CandidateService } from 'src/app/services/candidate.service';
import { CandidateTechnology } from 'src/app/models/candidateTechnology.model';

@Component({
  selector: 'app-technical-info',
  templateUrl: './technical-info.component.html',
  styleUrls: ['./technical-info.component.scss']
})
export class TechnicalInfoComponent implements OnInit {
  candidate!: CandidateModel;
  public technicalInformationForm: FormGroup;
  isValueModified: boolean = false;

  statusList: Status[] = [];
  roleList: Role[] = [];
  technologyList: Technology[] = [];

  @Input() candidateLoad!: Observable<CandidateModel>;
  @Output() updateTechincalInfo = new EventEmitter<CandidateModel>();

  constructor(public candidateService: CandidateService) {
    this.technicalInformationForm = new FormGroup(
      {
        "status": new FormControl(),
        "role": new FormControl(),
        "technology": new FormControl(),
        "yearsExperience": new FormControl()

      }, { updateOn: 'change' }
    );

    this.technicalInformationForm.valueChanges.subscribe((val: any) => {
      this.onChanges();

    });

  }

  ngOnInit(): void {
    this.candidateLoad.subscribe(val => {
      this.candidate = val;
      this.updateInputFormValues();
    });

    this.getCandidateTechnologies();
    this.getCandidateStatuses();
    this.getCandidateRoles();
  }

  onChanges(): boolean {
    this.technicalInformationForm.valueChanges.subscribe((val: any) => {
      this.isValueModified = true;
    });

    this.candidate.candidateStatus = this.findStatus(this.technicalInformationForm.get("status")?.value);
    this.candidate.role = this.findRole(this.technicalInformationForm.get("role")?.value);
    if (this.candidate.candidateTechnologies) {
      this.candidate.candidateTechnologies[0].technology = this.findTechnology(this.technicalInformationForm.get("technology")?.value);
    }
    this.candidate.yearsOfExperience = this.technicalInformationForm.get("yearsExperience")?.value;

    this.updateTechincalInfo.emit(this.candidate);

    return this.isValueModified;
  }

  findStatus(name: string): Status | undefined {
    for (var status of this.statusList) {
      if (status.name == name)
        return status;
    }

    //execution should not reach here since status name is taken from the list of statuses
    //update: actually execution reaches here when there is still no status selected(same for role and technology)
    //we do not have a default value, so better set it as undefined
    //todo we will have a default value, update it here and in findRole() and findTechnology()
    return undefined;
  }

  findTechnology(name: string): Technology | undefined {
    for (var tech of this.technologyList) {
      if (tech.name == name)
        return tech;
    }

    return undefined;
  }

  findRole(name: string): Role | undefined {
    for (var role of this.roleList) {
      if (role.name == name)
        return role;
    }

    return undefined;
  }

  updateInputFormValues() {
    this.technicalInformationForm.patchValue({
      "status": this.candidate?.candidateStatus?.name,
      "role": this.candidate?.role?.name,
      "technology": this.candidate?.candidateTechnologies?.[0]?.technology?.name,
      "yearsExperience": this.candidate?.yearsOfExperience
    });
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
}



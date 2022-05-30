import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Candidate } from 'src/app/models/candidate.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CandidateInfo } from 'src/app/models/candidate-info.model';
import { Observable } from 'rxjs';
import { CandidateModel } from 'src/app/models/candidate-model.model';
import { environment } from 'src/environments/environment.prod';

@Component({
  selector: 'app-contact-info',
  templateUrl: './contact-info.component.html',
  styleUrls: ['./contact-info.component.scss']
})

export class ContactInfoComponent implements OnInit {
  name = new FormControl();
  candidate!: CandidateModel;
  isValueModified: boolean = false;
  @Input() candidateLoad!: Observable<CandidateModel>;
  @Output() updateCandidateInfo = new EventEmitter<CandidateModel>();
  @Output() formValidity = new EventEmitter<boolean>();

  contactInformationForm: any;
  constructor() { }

  ngOnInit(): void {
    this.contactInformationForm = new FormGroup(
      {
        "name": new FormControl(null),
        "company": new FormControl(null),
        "email": new FormControl(null, Validators.email),
        "phone": new FormControl(null, Validators.pattern(environment.phoneRegex)),
        "address": new FormControl(null),
        "referredBy": new FormControl(null),
        "source": new FormControl(null),
        "linkedIn": new FormControl(null)

      }, { updateOn: 'change' }
    );

    this.candidateLoad.subscribe(val => {
      this.candidate = val;
      this.updateInputFormValues();
    });


    this.contactInformationForm.valueChanges.subscribe((val: any) => {
      this.candidate = val;
      this.onChanges();
      this.formValidity.emit(this.contactInformationForm.valid);
      this.updateCandidateInfo.emit(this.candidate);
    });
  }

  onChanges(): boolean {
    this.contactInformationForm.valueChanges.subscribe((val: any) => {
      this.isValueModified = true;
    });
    return this.isValueModified;
  }

  updateInputFormValues() {
    this.contactInformationForm.patchValue({
      name: this.candidate?.name,
      company: this.candidate?.company,
      email: this.candidate?.email,
      phone: this.candidate?.phone,
      address: this.candidate?.address,
      referredBy: this.candidate?.referredBy,
      source: this.candidate?.source,
      linkedIn: this.candidate?.linkedIn,
    });
  }

}

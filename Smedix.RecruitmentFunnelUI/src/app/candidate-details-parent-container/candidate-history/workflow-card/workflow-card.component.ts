import { Component, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import * as moment from 'moment';
import { Subscription } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { Candidate } from 'src/app/models/candidate.model';
import { CandidateHistory } from 'src/app/models/candidateHistory.model';
import { HistoryModel } from 'src/app/models/history.model';
import { StageStatusDto } from 'src/app/models/stage-status-dto.model';
import { StageStatusIds } from 'src/app/models/stage-status.model-id';
import { Stage } from 'src/app/models/stage.model';
import { Status } from 'src/app/models/status.model';
import { HistoryService } from 'src/app/services/history.service';
import {  EventEmitter } from '@angular/core';


@Component({
  selector: 'app-workflow-card',
  templateUrl: './workflow-card.component.html',
  styleUrls: ['./workflow-card.component.scss']
})
export class WorkflowCardComponent implements OnInit {

  @Input() candidate!: Candidate;
  stepList: Stage[] = [];
  interviewSteps: Stage[] = [];
  statusDict: Map<string, Status[]> = new Map();
  @Input() stagesAndStatusesDto: StageStatusDto[] = [];
  @Input() history!: CandidateHistory;

  workflowCardGroup: FormGroup;
  private eventsSubscription!: Subscription;

  @Input() events!: Observable<void>;
  @Output() cardEvent = new EventEmitter<boolean>();
  @Output() onChanges: EventEmitter<null> = new EventEmitter<null>();

  constructor(private historyService: HistoryService) {
    this.workflowCardGroup = new FormGroup({
      step: new FormControl(null),
      status: new FormControl(null),
      entryDate: new FormControl(null),
      entryTime: new FormControl(null),
      userName: new FormControl(null),
      interviewDate: new FormControl(null),
      interviewer: new FormControl(null),
      notes: new FormControl(null)
    });
  }

  setCardValues() {
    this.workflowCardGroup.patchValue({ interviewer: this.history!.manager });
    if (this.history.plannedDate) {
      let planned = new Date(this.history.plannedDate);
      let formattedDate = moment(planned).format("YYYY-MM-DD");
      this.workflowCardGroup.patchValue({ interviewDate: formattedDate });
    };
    this.workflowCardGroup.patchValue({ userName: this.history!.issuer });
    this.workflowCardGroup.patchValue({ notes: this.history!.notes });
    if (this.history.entryDateTime) this.workflowCardGroup.patchValue({ entryDate: this.getFormattedDate(new Date(this.history!.entryDateTime!)) });
    else { this.workflowCardGroup.patchValue({ entryDate: this.getFormattedDate(new Date()) }) };
    if (this.history.entryDateTime) this.workflowCardGroup.patchValue({ entryTime: this.getFormattedTime(new Date(this.history!.entryDateTime!)) });
    else { this.workflowCardGroup.patchValue({ entryTime: this.getFormattedTime(new Date()) }) };
    if (this.history.stageStatus) { this.workflowCardGroup.patchValue({ step: this.history!.stageStatus!.stage.name }); }
    if (this.history.stageStatus) { this.workflowCardGroup.patchValue({ status: this.history!.stageStatus!.status.name }) }
  }

  getFormattedDate(date: Date) {
    let year = date.getFullYear();
    let month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
    let day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;
    return month + '/' + day + '/' + year;
  }

  getFormattedTime(date: Date) {
    let hour = date.getHours().toString();
    hour = hour.length > 1 ? hour : '0' + hour;
    let min = date.getMinutes().toString();
    min = min.length > 1 ? min : '0' + min;
    return hour + ':' + min;
  }

  ngOnInit(): void {
    this.stagesMapping();
    this.setCardValues();
    this.workflowCardGroup.valueChanges.subscribe(() => {
      this.onChanges.emit();
    });
    this.eventsSubscription = this.events.subscribe(() => {
      let stageAndStatus = {
        stageId: this.getStageIdByName(this.workflowCardGroup.get('step')!.value),
        statusId: this.getStatusIdByName(this.workflowCardGroup.get('status')!.value, this.workflowCardGroup.get('step')!.value)
      } as StageStatusIds;
      let history =
        {
          id: this.history.id,
          interviewer: this.workflowCardGroup.get('interviewer')!.value,
          notes: this.workflowCardGroup.get('notes')!.value,
          interviewDate: this.workflowCardGroup.get('interviewDate')!.value,
          issuer: this.workflowCardGroup.get('userName')!.value,
          stageStatus: stageAndStatus,
          manager: this.workflowCardGroup.get('interviewer')!.value,
          plannedDate: this.workflowCardGroup.get('interviewDate')!.value
        } as HistoryModel;
      this.historyService.updateHistory(history).subscribe({ error: console.error });
    });
  }

  stagesMapping() {
    this.stagesAndStatusesDto.forEach(element => this.stepList.push({ id: element.id, name: element.name } as Stage));
    this.workflowCardGroup.patchValue({ step: this.stepList[0]!.name });
    this.interviewSteps = [
      this.stepList[2], this.stepList[3]
    ];
    this.stagesAndStatusesDto.forEach(element => this.statusDict.set(element.name, element.statuses));
  }

  getStatusIdByName(status: string, stage: string) {
    let result = 0;
    this.statusDict.forEach(function (value, key) {
      if (key == stage) {
        for (let i = 0; i < value.length; i++) {
          if (status == value[i].name) {
            result = value[i].id;
            break;
          }
        }
      }
    })
    return result;
  }

  getStageIdByName(stage: string) {
    for (let i = 0; i < this.stepList.length; i++) {
      if (this.stepList[i].name == stage) {
        return this.stepList[i].id;
      }
    }
    return 0;
  }

  getStageByName(stage: string) {
    for (let i = 0; i < this.stepList.length; i++) {
      if (this.stepList[i].name == stage) return this.stepList[i];
    }
    return {} as Stage;
  }

  deleteClicked() {
    this.historyService.deleteHistoryStep(this.history.id!).subscribe({ error: console.error });
    window.location.reload();
  }

  ngOnDestroy() {
    this.eventsSubscription.unsubscribe();
  }

  validateSaveOnStep(selected: string) {
    if (selected != this.stepList[0].name) {
      if (this.getStatusIdByName(this.workflowCardGroup.get('status')!.value, selected) == 0) {
        this.cardEvent.emit(true);
      }
    }
    else { this.cardEvent.emit(false); }
  }

  validateSaveOnStatus() {
    this.cardEvent.emit(false);
  }
}


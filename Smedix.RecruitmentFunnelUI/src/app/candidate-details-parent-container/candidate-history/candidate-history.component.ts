import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs/internal/Subject';
import { CandidateHistory } from 'src/app/models/candidateHistory.model';
import { CandidateService } from 'src/app/services/candidate.service';
import { HistoryService } from 'src/app/services/history.service';
import { Stage } from 'src/app/models/stage.model';
import { WorkflowCardComponent } from './workflow-card/workflow-card.component';
import { StageStatusDto } from 'src/app/models/stage-status-dto.model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { PopupMessageComponent } from 'src/app/utility/popup-message/popup-message.component';

@Component({
  selector: 'app-candidate-history',
  templateUrl: './candidate-history.component.html',
  styleUrls: ['./candidate-history.component.scss']
})
export class CandidateHistoryComponent implements OnInit {
  @Input() stepList: Stage[] = []
  @Input() candidateId!: number;
  @ViewChild(WorkflowCardComponent) historyCards: WorkflowCardComponent[] = [];
  filter: boolean = false;
  candidateHistories: CandidateHistory[] = [];
  change: boolean = false;
  isDisabled: boolean = true;
  candidateFilteredHistories: CandidateHistory[] = [];
  stageAndStatuses: StageStatusDto[] = [];
  eventsSubject: Subject<void> = new Subject<void>();
  dialogRef!: MatDialogRef<PopupMessageComponent>;

  constructor(private router: Router, private candidateService: CandidateService, private route: ActivatedRoute, private historyService: HistoryService,
    private dialog: MatDialog) {
    this.getStages();
    let id: number = Number(this.route.snapshot.paramMap.get('id'));
    this.getHistorySteps(id);
  }

  ngOnInit(): void {
  }

  getHistorySteps(id: number) {
    this.historyService.getHistorySteps(id).subscribe(steps => { this.candidateHistories = steps; })
  }

  getStages() {
    this.historyService.getStageAndStatuses().subscribe(results => {
      this.stageAndStatuses = results;
      this.stageAndStatuses.forEach(element => this.stepList.push({ id: element.id, name: element.name } as Stage));
    });
  }

  emitEventToCard() {
    this.eventsSubject.next();
  }

  search(events: any) {
    if (events.value.length == 0 || events.value.length == 6) {
      this.candidateFilteredHistories = [];
      this.filter = false;
    } else {
      this.filter = true;
      this.candidateFilteredHistories = [];
      let eventsVal: String[] = ["", "", "", "", "", ""];
      for (var i = 0; i < events.value.length; i++) {
        eventsVal[i] = events.value[i].name;
      }
      for (let history of this.candidateHistories) {
        for (var i = 0; i < eventsVal.length; i++) {
          if (history.stageStatus?.stage.name == eventsVal[i]) {
            this.candidateFilteredHistories.push(history);
          }
        }
      }
    }
  }

  onKey(event: any) {
    this.search(event);
  }

  public createHistory() {
    const candidateId = Number(this.route.snapshot.paramMap.get('id'));
    let history: CandidateHistory = {};
    this.candidateService.addCandidateHistory(candidateId).subscribe(id => { history.id = id; this.candidateHistories.unshift(history); });
  }

  cancel() {
    if (this.change) {
      this.dialogRef = this.dialog.open(PopupMessageComponent, {
        data: {
          message: "Are you sure you want to leave the page?"
        }
      });

      this.dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.router.navigateByUrl("");
        }
      });
    } else {
      this.router.navigateByUrl("");
    }
  }

  save() {
    this.dialogRef = this.dialog.open(PopupMessageComponent, {
      data: {
        message: "Are you sure you want to save the changes?"
      }
    });
    this.dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.emitEventToCard();
        this.change = false;
        this.isDisabled = true;
        window.location.reload();
      }
    });
  }

  validateSave(valueEmitted: boolean) {
    this.isDisabled = valueEmitted;
  }

  public onCardChanges() {
    this.change = true;
  }

  public cardsHaveChanged(): boolean {
    return this.change;
  }
}

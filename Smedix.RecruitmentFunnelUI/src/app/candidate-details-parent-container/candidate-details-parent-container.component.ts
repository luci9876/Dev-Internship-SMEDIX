import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CandidateModel } from '../models/candidate-model.model';
import { CandidateService } from '../services/candidate.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { PopupMessageComponent } from '../utility/popup-message/popup-message.component';
import { CandidateDetailsComponent } from './candidate-details/candidate-details.component';
import { CandidateHistoryComponent } from './candidate-history/candidate-history.component';
import { CandidateParams } from '../models/candidateParams.model';

@Component({
  selector: 'app-candidate-details-parent-container',
  templateUrl: './candidate-details-parent-container.component.html',
  styleUrls: ['./candidate-details-parent-container.component.scss']
})
export class CandidateDetailsParentContainerComponent implements OnInit {
  candidate!: CandidateModel;
  filesToUpload!: FileList;
  id = Number(this.route.snapshot.paramMap.get('id'));
  @ViewChild(CandidateDetailsComponent) detailsComponent!: CandidateDetailsComponent
  @ViewChild(CandidateHistoryComponent) historyComponent!: CandidateHistoryComponent
  candidateParams: CandidateParams = new CandidateParams();
  dialogRef!: MatDialogRef<PopupMessageComponent>;

  constructor(private _router: Router, public candidateService: CandidateService,
    private route: ActivatedRoute, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadCandidate();
  }

  public hasRoute(route: string) {
    return this._router.url.includes(route);
  }

  public candidatedetails() {
    this._router.navigate(["candidate-details/" + this.route.snapshot.paramMap.get('id')]);
  }

  public candidatehistory() {
    this._router.navigate(["candidate-details/" + this.route.snapshot.paramMap.get('id') + "/history/" + this.route.snapshot.paramMap.get('id')]);
  }

  public backToFirstPage() {
    if ((!this.hasRoute('history') && this.detailsComponent.onChanges()) || (this.hasRoute('history') && this.historyComponent.cardsHaveChanged())) {
      this.dialogRef = this.dialog.open(PopupMessageComponent, {
        data: {
          message: "Are you sure you want to leave the page?"
        }
      });

      this.dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this._router.navigateByUrl("");
        }
      });
    } else {
      this._router.navigateByUrl("");
    }
  }

  public import(): void {
    alert("Import Button was pressed");
  }

  public saveCandidate(candidate: CandidateModel) {
    //call to candidateService to save details about candidate
    this.candidateService.saveCandidate(candidate).subscribe();
  }

  public loadCandidate(): Observable<CandidateModel> {
    //todo call to candidate Service
    //receive an id on ngOnInit()
    //todo call to candidate Service
    //receive an id on ngOnInit()
    const id = Number(this.route.snapshot.paramMap.get('id'));
    return this.candidateService.getCandidate(id);
  }

  public getCandidate(): CandidateModel {
    return this.candidate;
  }
}
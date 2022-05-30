import { Component, OnInit, Output, EventEmitter, Input, ViewChild } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CandidateModel } from 'src/app/models/candidate-model.model';
import { ContactInfoComponent } from './contact-info/contact-info.component';
import { Injectable } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { PopupMessageComponent } from 'src/app/utility/popup-message/popup-message.component';
import { TechnicalInfoComponent } from './technical-info/technical-info.component';
import { NotesComponent } from './notes/notes.component';
import { FileService } from 'src/app/services/file.service';
import { CandidateFile } from 'src/app/models/candidate-file.model';
import { FileDetails } from 'src/app/models/file-details.model';

@Component({
  selector: 'app-candidate-details',
  templateUrl: './candidate-details.component.html',
  styleUrls: ['./candidate-details.component.scss']
})
@Injectable({
  providedIn: 'root',
})
export class CandidateDetailsComponent implements OnInit {
  filesList!: CandidateFile[];
  candidate!: CandidateModel;
  contactInfoValid: boolean = false;
  @ViewChild(ContactInfoComponent) contactInfo: any;
  @ViewChild(TechnicalInfoComponent) techInfo: any;
  @ViewChild(NotesComponent) noteInfo: any;
  change: boolean = false;
  @Input() candidateLoad!: Observable<CandidateModel>;
  @Output() saveCandidate = new EventEmitter<CandidateModel>();
  filesToUpload!: FileList;
  id = Number(this.route.snapshot.paramMap.get('id'));
  dialogRef!: MatDialogRef<PopupMessageComponent>;

  constructor(private dialog: MatDialog,
    private fileService: FileService, private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.candidateLoad.subscribe((val) => {
      this.candidate = val;
      this.initFilesList();
    });
    this.initFilesList();
  }

  handleFileInput(files: FileList) {
    this.filesToUpload = files;
    this.uploadFiles();
    this.refreshFct()
  }

  uploadFile(file: File) {
    const formData = new FormData();
    formData.append('files', file, file.name);
    formData.append('candidateId', this.id.toString());
    this.fileService.createFile(formData).subscribe();
  }

  uploadFiles() {
    if (this.filesToUpload) {
      for (let i = 0; i < this.filesToUpload.length; i++) {
        this.uploadFile(this.filesToUpload[i]);
      }
    }
  }

  onChanges(): boolean {
    if (this.contactInfo.onChanges() || this.techInfo.onChanges() || this.noteInfo.onChanges()) {
      this.change = true;
    } else {
      this.change = false;
    }
    return this.change;
  }

  initFilesList() {
    this.fileService.getFilesForCandidate(this.id).subscribe(
      files => this.filesList = files
    );
  }

  cancel() {
    if (this.contactInfo.onChanges() || this.techInfo.onChanges() || this.noteInfo.onChanges()) {
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
    if (this.candidate == null) {
      alert("Error: Nothing to save, there is no candidate!");
      return;
    }
    if (!this.contactInfoValid) {
      alert("Form contains invalid data. Try again with valid input!");
      return;
    }
    this.saveCandidate.emit(this.candidate);
    this.router.navigateByUrl("").then(() => { window.location.reload() });
  }

  updateCandidateInfo(candidateInfo: CandidateModel) {
    //update only the info of the candidate field using the received CandidateInfo object

    this.candidate!.name = candidateInfo?.name;
    this.candidate!.email = candidateInfo?.email;
    this.candidate!.address = candidateInfo?.address;
    this.candidate!.company = candidateInfo?.company;
    this.candidate!.phone = candidateInfo?.phone;
    this.candidate!.referredBy = candidateInfo?.referredBy;
    this.candidate!.source = candidateInfo?.source;
    this.candidate!.linkedIn = candidateInfo?.linkedIn;
  }

  updateTechnicalInfo(candidateInfo: CandidateModel) {
    this.candidate!.role = candidateInfo.role;
    this.candidate!.candidateStatus = candidateInfo.candidateStatus;
    if (this.candidate.candidateTechnologies) {
      this.candidate!.candidateTechnologies[0]!.technology = candidateInfo?.candidateTechnologies?.[0].technology;
    }
    this.candidate!.yearsOfExperience = candidateInfo.yearsOfExperience;
  }

  updateNotes(candidateInfo: CandidateModel) {
    this.candidate!.notes = candidateInfo.notes;
  }

  loadCandidate(): Observable<CandidateModel> {
    return this.candidateLoad.pipe(map(x => {
      return x;
    }))
  }

  downloadFile(index: number) {
    let fileDetails: FileDetails = {
      candidateId: this.candidate.id,
      fileName: this.filesList[index].fileName!
    }
    this.fileService.getFile(fileDetails).subscribe(response => {
      let fileName = response.fileName!;
      let fileContent = response.content!;
      let type = response.contentType!;
      const linkSource = 'data:' + type + ';base64,' + fileContent;
      const downloadLink = document.createElement("a");
      downloadLink.href = linkSource;
      downloadLink.download = fileName;
      downloadLink.click();
      downloadLink.remove();
    })
  }

  editFileName(fileName: string) {
    if (!fileName.includes(".")) return fileName;
    return fileName.substring(0, fileName.lastIndexOf('.'));
  }

  refreshFct() {
    this.router.navigate([this.router.url])
      .then(() => {
        window.location.reload();
      });
  }

  setValidity(valid: boolean) {
    this.contactInfoValid = valid;
  }
}

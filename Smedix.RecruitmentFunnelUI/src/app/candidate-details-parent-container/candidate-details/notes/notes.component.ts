import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { CandidateModel } from 'src/app/models/candidate-model.model';
import { Candidate } from 'src/app/models/candidate.model';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  @Input() candidate!: CandidateModel;
  notesForm: FormGroup;
  isValueModified: boolean = false;

  @Input() candidateLoad!: Observable<CandidateModel>;
  @Output() updateNotes = new EventEmitter<CandidateModel>();

  constructor() {
    this.notesForm = new FormGroup(
      {
        "notes": new FormControl(null),
      }
    );
   }

  ngOnInit(): void {
    this.notesForm.valueChanges.subscribe((val: any) => {
      this.onChanges();
    });

    this.candidateLoad.subscribe((val) => {
      this.candidate = val;
        this.notesForm.patchValue({
          notes: val.notes
        });
    });
  }

  onChanges(): boolean {
    this.notesForm.valueChanges.subscribe((val: any) => {
      this.isValueModified = true;
    });
    
    this.candidate.notes = this.notesForm.get('notes')?.value;
    this.updateNotes.emit(this.candidate);
    return this.isValueModified;
  }

}

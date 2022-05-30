import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-popup-message',
  templateUrl: './popup-message.component.html',
  styleUrls: ['./popup-message.component.scss']
})
export class PopupMessageComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<PopupMessageComponent>, private _router: Router, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  public onDismiss() {
    this.dialogRef.close(false);
  }

  public onConfirm() {
    this.dialogRef.close(true);
  }

}

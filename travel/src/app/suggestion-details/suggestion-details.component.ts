import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Suggestion } from '../models/Suggestion';
import { HostService } from '../services/host.service';
import { Host } from '../models/Host';
import { DialogOverviewExampleDialogComponent } from '../dialog-overview-example-dialog/dialog-overview-example-dialog.component';
import { stringify } from 'querystring';

@Component({
  selector: 'app-suggestion-details',
  templateUrl: './suggestion-details.component.html',
  styleUrls: ['./suggestion-details.component.scss']
})

export class SuggestionDetailsComponent implements OnInit {

  suggestion: Suggestion;
  host: Host;
  constructor(public dialog: MatDialog, private hostService: HostService, private dialogRef: MatDialogRef<SuggestionDetailsComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
    this.suggestion = data.sug;
    console.log('dialog-component', this.suggestion)
  }

  ngOnInit(): void {
    this.hostService.getId(this.suggestion.HostId).subscribe((h: Host) => { this.host = h, console.log("succes!!") });

  }

  close() {
    this.dialogRef.close();
  }

  call() {
    document.location.href = `tel:${this.host.HostTel}`;
  }

  email() {
    document.location.href = `mailto:${this.host.HostEmail}`;
  }
  openDialog(): void {
    let st: String;
    st = `${this.host.HostName}
    Age :${this.host.BirthDate}
  ${this.host.gender}
    ${this.host.HostTextDetails}
    Tel :${this.host.HostTel}
    Email :${this.host.HostEmail}
    `;
    const dialogRef = this.dialog.open(DialogOverviewExampleDialogComponent, {
      width: '400px',
      data: this.host
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

}


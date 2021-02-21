import { Component, Host, OnInit } from '@angular/core';
import { Suggestion } from '../models/Suggestion';
import { SuggestionService } from '../services/suggestion.service';
import { User } from '../models/User';
import { Router } from '@angular/router';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { DialogOverviewExampleDialogComponent } from '../dialog-overview-example-dialog/dialog-overview-example-dialog.component';
import { Traveler } from '../models/Traveler';
import { DialogOverviewExampleDialogTravelerComponent } from '../dialog-overview-example-dialog-traveler/dialog-overview-example-dialog-traveler.component';

@Component({
  selector: 'app-home-host',
  templateUrl: './home-host.component.html',
  styleUrls: ['./home-host.component.scss']
})
export class HomeHostComponent implements OnInit {

  suggestions: Suggestion[] = [];
  currentUser: User;

  constructor(public suggestionService: SuggestionService,
    public router: Router, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.currentUser = JSON.parse(localStorage.getItem("currentUser"));
    console.log( this.currentUser)
    this.suggestionService.getAll(this.currentUser.UserID).subscribe((res: Suggestion[]) => {
      this.suggestions = res;
      console.log(this.suggestions)
    })
  }

  add() {
    this.router.navigate(["upload-post"]);
  }

  edit(s: Suggestion) {
    localStorage.setItem("suggestionEdit", JSON.stringify(s));
    this.router.navigate(["edit-post"]);
  }
  delete(s: Suggestion) {
    this.suggestionService.delete(s.SuggestionID).subscribe((res: Suggestion[]) =>this.suggestions = res)
  }
  openDialog(traveler: Traveler): void {
    // let st: String;
  //   st = `${this.currentUser.HostName}
  //   Age :${this.currentUser.BirthDate}
  // ${this.currentUser.gender}
  //   ${this.currentUser.HostTextDetails}
  //   Tel :${this.currentUser.HostTel}
  //   Email :${this.currentUser.HostEmail}
  //   `;
    const dialogRef = this.dialog.open(DialogOverviewExampleDialogTravelerComponent, {
      width: '400px',
      data: traveler
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}

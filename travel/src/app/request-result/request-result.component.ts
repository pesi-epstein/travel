import { Component, OnInit } from '@angular/core';
import { Suggestion } from '../models/Suggestion';
import { Router } from '@angular/router';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { SuggestionDetailsComponent } from '../suggestion-details/suggestion-details.component';
import { SuggestionService } from '../services/suggestion.service';
import { User } from '../models/User';

@Component({
  selector: 'app-request-result',
  templateUrl: './request-result.component.html',
  styleUrls: ['./request-result.component.scss']
})
export class RequestResultComponent implements OnInit {

  suggestions: Suggestion[] = [];
  currentUser: User;
  
  constructor(public router: Router,
    private dialog: MatDialog,
    public suggestionService: SuggestionService) { }

  ngOnInit(): void {
    this.currentUser = JSON.parse(localStorage.getItem("currentUser"));
    this.suggestions = JSON.parse(localStorage.getItem("result"));
  }

  detail(sug: Suggestion) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = {
      id: sug.SuggestionID,
      sug: sug
    };

    this.dialog.open(SuggestionDetailsComponent, dialogConfig);

  }

  search() {
    this.router.navigate(["traveler-request"])
  }

  all() {
    this.router.navigate(["home"])
  }
  onStatusChanged(item: Suggestion) {

    this.suggestionService.AddOrUpdateSuggestionStatus({ SuggestionId: item.SuggestionID, TravelerId: this.currentUser.UserID, Status: item.Status }).subscribe((res: any) => { });

  }
}

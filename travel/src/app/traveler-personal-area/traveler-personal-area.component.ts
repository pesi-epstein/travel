import { Component, OnInit, Host } from '@angular/core';
import { User, Status } from '../models/User';
import { Suggestion } from '../models/Suggestion';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { SuggestionService } from '../services/suggestion.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { SuggestionDetailsComponent } from '../suggestion-details/suggestion-details.component';

@Component({
  selector: 'app-traveler-personal-area',
  templateUrl: './traveler-personal-area.component.html',
  styleUrls: ['./traveler-personal-area.component.scss']
})
export class TravelerPersonalAreaComponent implements OnInit {

  currentUser: User;
  suggestions: Suggestion[] = [];

  constructor(public authService: AuthService, public router: Router,
    public suggestionService: SuggestionService,
    private dialog: MatDialog) { }
  users: Host[] = [];

  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem("currentUser"));
    if (!this.currentUser)
      this.router.navigate(['/login']);
    if (this.currentUser.UserStaus == Status.Host)
      this.router.navigate(['/home-host']);
      // this.suggestionService.getAllTravel(this.currentUser.UserID).subscribe((res: any) => {
    this.suggestionService.getAllTravel().subscribe((res: any) => {
      this.suggestions = res.filter(p => p.HostId == this.currentUser.UserID)
      //this.suggestions = res;
    })
  }

  call() {

  }

  req() {
    this.router.navigate(["traveler-request"]);
  }

  detail(sug: Suggestion) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      id: sug.SuggestionID,
      sug: sug
    };

    this.dialog.open(SuggestionDetailsComponent, dialogConfig);

  }
  delete(id: number) {
    this.authService.delete(id).subscribe((users: any[]) => this.users = users);
  }

}

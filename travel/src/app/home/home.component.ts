import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Host } from '../models/Host';
import { User, Status } from '../models/User';
import { Router } from '@angular/router';
import { SuggestionService } from '../services/suggestion.service';
import { Suggestion } from '../models/Suggestion';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { SuggestionDetailsComponent } from '../suggestion-details/suggestion-details.component';
import { SuggestionTraveler } from '../models/SuggestionTraveler';
import { HostService } from '../services/host.service';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  currentUser: User;
  suggestions: Suggestion[] = [];
  approveSuggestions: Suggestion[] = [];
  events: any[];
  showCalendar: boolean = false;
  isReady: boolean = false;
  expanding: boolean = false;

  constructor(
    public authService: AuthService,
    public router: Router,
    public suggestionService: SuggestionService,
    private dialog: MatDialog,
    private hostService: HostService) { }
  users: Host[] = [];
  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem("currentUser"));

    if (!this.currentUser)
      this.router.navigate(['/login']);
    if (this.currentUser.UserStaus == Status.Host)
      this.router.navigate(['/home-host']);
    //  this.suggestionService.getAllTravel(this.currentUser.UserID).subscribe((res: any) => {
    this.suggestionService.getSuggestionsToTraveler(this.currentUser.UserID).subscribe((res: any) => {
      this.suggestions = res.filter(p => p.HostId != this.currentUser.UserID);
      this.approveSuggestions = this.suggestions.filter(s => s.Status == 3);
      this.events = [];
      this.suggestions.filter(ss => ss.Status == 3)?.forEach(s => {
        this.hostService.getId(s.HostId).subscribe((h: Host) => {
          s.bookedDates.forEach(d => {
            this.events.push({
              id: s.SuggestionID,
              title: `address: ${s.Country} ${s.City} ${s.Street} ${h.HostTel}`,
              start: d.dateStart,
              end: d.dateEnd
            })
          });
        });
      });
      this.isReady = true;
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

  onStatusChanged(item: Suggestion) {

    this.suggestionService.AddOrUpdateSuggestionStatus({ SuggestionId: item.SuggestionID, TravelerId: this.currentUser.UserID, Status: item.Status }).subscribe((res: any) => { });
    if (item.Status == 3) {
      this.hostService.getId(item.HostId).subscribe((h: Host) => {
        this.isReady = false;
        item.bookedDates.forEach(d => {
          this.events.push({
            id: item.SuggestionID,
            title: `address: ${item.Country} ${item.City} ${item.Street} ${h.HostTel}`,
            start: d.dateStart,
            end: d.dateEnd
          })
        });
        setTimeout(() => {
          this.isReady = true;
        }, 100);
      });
    }
    else {
      let eventToFilter = this.events.find(e => e.id == item.SuggestionID);
      if (eventToFilter) {
        this.isReady = false;
        let events = this.events;
        this.events = [];
        events.forEach(element => {
          if (element != eventToFilter) {
            this.events.push(element);
          }
        });
        setTimeout(() => {
          this.isReady = true;
        }, 100);
      }

    }

  }
}




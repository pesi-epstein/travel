import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Host } from '../models/Host';
import { User, Status } from '../models/User';
import { Router } from '@angular/router';
import { SuggestionService } from '../services/suggestion.service';
import { Suggestion } from '../models/Suggestion';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { SuggestionDetailsComponent } from '../suggestion-details/suggestion-details.component';
import {FullCalendar} from 'primeng/fullcalendar';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';

@Component({
  selector: 'app-traveler-calendar',
  templateUrl: './traveler-calendar.component.html',
  styleUrls: ['./traveler-calendar.component.scss']
})
export class TravelerCalendarComponent implements OnInit {

  currentUser: User;
  suggestions: Suggestion[] = [];
  options: any;
   events: any[]=  [ 
    {
        "id": 1,
    "title": "address: Israel Ashdod Chermesh 2, phone: 0583452105",
    "start": "2021-02-07",
    "end": "2021-02-10"
    }
 ];
@ViewChild('calendar') private calendar: FullCalendar;
  constructor(public authService: AuthService, public router: Router,
    public suggestionService: SuggestionService,
    private dialog: MatDialog) {const name = FullCalendar.name; }
  users: Host[] = [];
  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem("currentUser"));

    this.options = {
      plugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
      defaultDate: '2017-02-01',
      header: {
          left: 'prev,next',
          center: 'title',
          right: 'dayGridMonth,timeGridWeek,timeGridDay'
      }
  }
  }
}




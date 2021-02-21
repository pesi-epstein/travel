import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Traveler } from '../models/Traveler';

@Component({
  selector: 'app-dialog-overview-example-dialog-traveler',
  templateUrl: './dialog-overview-example-dialog-traveler.component.html',
  styleUrls: ['./dialog-overview-example-dialog-traveler.component.scss']
})
export class DialogOverviewExampleDialogTravelerComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogOverviewExampleDialogTravelerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Traveler) {


  }

  close() {
    this.dialogRef.close();
  }
  getAge() {
    var dob = this.data.BirthDate;
    console.log(dob)
    var today = new Date();
    var birthDate = new Date(dob);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  }
  ngOnInit(): void {
  }

}

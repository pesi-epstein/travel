import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogOverviewExampleDialogTravelerComponent } from './dialog-overview-example-dialog-traveler.component';

describe('DialogOverviewExampleDialogComponent', () => {
  let component: DialogOverviewExampleDialogTravelerComponent;
  let fixture: ComponentFixture<DialogOverviewExampleDialogTravelerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogOverviewExampleDialogTravelerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogOverviewExampleDialogTravelerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

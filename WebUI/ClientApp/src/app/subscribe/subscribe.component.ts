import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { ModalSubscriptionComponent } from '../modal-subscription/modal-subscription.component';
import { SubscriptionRequest } from '../model/subscription-request';
import { SubscriptionService } from '../service/subscription-service/subscription.service';
import { SnackBarTemplateComponent } from '../snack-bar-template/snack-bar-template.component';

@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})
export class SubscribeComponent implements OnInit {

  constructor(private dialog: MatDialog
    , private snackBar: MatSnackBar
    , private _subscriptionService: SubscriptionService) { }



  ngOnInit() {
  }

  openSnackBar() {
    this.snackBar.openFromComponent(SnackBarTemplateComponent, {
      duration: 2000,
      panelClass: ['blue-snackbar']
    });
  }

  showModal(): void {
    let dialogRef = this.dialog.open(ModalSubscriptionComponent, {
      maxWidth: '100%',
      //height: '500px',
      width: '420px',
      //data: { type: "photo", url: url }
    });

    dialogRef.afterClosed().subscribe(
      data => {
        if (data) {
          //console.log(data);

          this._subscriptionService.PostAddSubscriber(data).subscribe(
            data => {
              console.log(data);
              if (data) {
              }
              else {
              }
            },
            error => {
              console.log(error);
            }
          );

          this.openSnackBar();
        }
      }
    );
  }







}

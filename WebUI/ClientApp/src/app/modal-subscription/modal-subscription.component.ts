import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { SubscriptionRequest } from '../model/subscription-request';

@Component({
  selector: 'app-modal-subscription',
  templateUrl: './modal-subscription.component.html',
  styleUrls: ['./modal-subscription.component.css']
})
export class ModalSubscriptionComponent implements OnInit {

  public isBusy: boolean;

  subscriptionRequestModel: SubscriptionRequest =
    new SubscriptionRequest('', '');

  constructor(public dialogRef: MatDialogRef<ModalSubscriptionComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }


  ngOnInit() {
  }

  Subscribe() {
    this.isBusy = true;
    let copy = Object.assign({}, this.subscriptionRequestModel); //superficial copying
    this.dialogRef.close(copy);
  }

  Cancel() {
    this.dialogRef.close();
  }

}

import { Component, OnInit } from '@angular/core';
import { ContactRequest } from '../model/contact-request';
import { ContactService } from '../service/contact-service/contact.service';
import { Router } from "@angular/router"


@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {

  public isBusy: boolean;
  public verified: boolean;

  contactRequestModel = new ContactRequest("","","","", "");

  constructor(private _contactService : ContactService, private _router : Router) { }

  ngOnInit() {
    this.isBusy = false;
    this.verified = false;
  }

  onSubmit() {
    this.isBusy = true;
    let successMsg = "Message was sent successfully\nWe will contact you ASAP.";
    let failMsg = "There was an error sending the message please try again.";

    let copy = Object.assign({}, this.contactRequestModel); //superficial copying
    copy.subject = "From contact form: " + copy.subject;

    this._contactService.PostContactRequest(copy).subscribe(
      data => {
        if (data) {
          alert(successMsg);
          this._router.navigate(['/']);
        }
        else {
          alert(failMsg);
        }
        this.isBusy = false;
      },
      error => {
        alert(failMsg);
        this.isBusy = false;
      }
    );
  }

  onResolved(captchaResponse: string) {
    if (!captchaResponse)
    {
      this.verified = false;
    }
    else
    {
      this.verified = true;

      this.contactRequestModel.captchaRequest = captchaResponse;
    }
    //console.log(`Resolved captcha with response: ${captchaResponse}`);
  }

}

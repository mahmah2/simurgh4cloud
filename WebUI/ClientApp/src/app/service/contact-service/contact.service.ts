import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContactRequest } from '../../model/contact-request';
import { DecodeRequest } from '../../model/decode-request';


@Injectable()
export class ContactService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  PostContactRequest(model: ContactRequest) {
    return this.http.post<any>(this.baseUrl + 'api/contact/sendmail', model);
  }

}


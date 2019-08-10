import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SubscriptionRequest } from '../../model/subscription-request';

@Injectable()
export class SubscriptionService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  PostAddSubscriber(model: SubscriptionRequest) {
    return this.http.post<any>(this.baseUrl + 'api/subscriber/add', model);
  }
}

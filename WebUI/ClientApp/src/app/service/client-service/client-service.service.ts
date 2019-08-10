import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientModel } from '../../model/client-model';

@Injectable()
export class ClientService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetAll() {
    return this.http.get<ClientModel[]>(this.baseUrl + 'api/client');
  }


  GetClient(id: string) {
    return this.http.get<ClientModel>(this.baseUrl + 'api/client/getbyid',
      {
        params: { id: id },
      }
    );
  }

  UpdateClient(client: ClientModel) {
    return this.http.put<ClientModel>(this.baseUrl + 'api/client', client);
  }

  AddNewClientByName(clientName: string) {
    return this.http.get<ClientModel>(this.baseUrl + 'api/client/createbyname',
      {
        params: { name: clientName },
      }
    );
  }


}

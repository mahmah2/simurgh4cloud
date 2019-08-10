import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProjectModel } from '../../model/project-model';

@Injectable()
export class ProjectService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }


  GetClientProjects(_clientId: string) {
    return this.http.get<ProjectModel[]>(this.baseUrl + 'api/project/GetClientProjects',
      {
        params: { clientId: _clientId },
      }
    );
  }

  GetProject(id: string) {
    return this.http.get<ProjectModel>(this.baseUrl + 'api/project/getbyid',
      {
        params: { id: id },
      }
    );
  }

}

import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class FileSystemService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetClientFiles(id: string) {
    return this.http.get<string []>(this.baseUrl + 'api/filesystem/clientfiles',
      {
        params: { id: id },
      }
    );
  }

  UploadClientFile(formData) {
    return this.http.post(this.baseUrl + 'api/filesystem/postclientfile',
      formData
    );
  }

}

import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { ClientService } from '../../service/client-service/client-service.service';
import { ClientModel } from '../../model/client-model';
import { PictureModel } from '../../model/picture-model';
import { FileSystemService } from '../../service/file-system-service/file-system.service';


@Component({
  selector: 'app-admin-client-detail',
  templateUrl: './admin-client-detail.component.html',
  styleUrls: ['./admin-client-detail.component.css']
})
export class AdminClientDetailComponent implements OnInit {

  public id: string;

  public clientInfo: ClientModel;
  public newPicture: PictureModel;

  public selectedFile: File = null;

  options = [];

  constructor(private route: ActivatedRoute,
    private _router: Router,
    private _clientService: ClientService,
    private _fileSystem: FileSystemService,
    private snackBar: MatSnackBar,
  )  {  }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.resetNewPicture();

    this.fillSiblingFiles(this.id);

    this._clientService.GetClient(this.id).subscribe(
      data => {
        this.clientInfo = data;
        console.log(data);
        console.log(this.clientInfo);
      },
      error => { console.log(error); }
    );
  }

  private fillSiblingFiles(id :string) {
    this._fileSystem.GetClientFiles(id).subscribe(
      data => { this.options = data },
      error => { console.log(error); }
    );
  }


  private resetNewPicture() {
    this.newPicture = { id: 0, type: "", url: "" };
  }

  Save() {
    this._clientService.UpdateClient(this.clientInfo).subscribe(
      data => { console.log(data); },
      error => { console.log(error); }
    );
    console.log("Saved :" + JSON.stringify(this.clientInfo));
  }


  Cancel() {
    this._router.navigate(['/admin/clients']);
  }

  AddNewPicture() {
    this.clientInfo.pictures.push(this.newPicture);
    this.resetNewPicture();
  }

  RemovePicture(pic) {
    this.clientInfo.pictures = this.clientInfo.pictures.filter(item => item !== pic);
  }

  public OnChange(event) {
    this.selectedFile = <File>event.target.files[0];
  }

  public DoUpload() :any {
    const fd = new FormData();

    fd.append("file", this.selectedFile, this.selectedFile.name);
    fd.append("id", this.id);


    this._fileSystem.UploadClientFile(fd).subscribe(

      data => {
        this.snackBar.open(`File ${this.selectedFile.name} was uploaded successfully`
          , 'OK',
          { duration: 3000 }
        );

        console.log(data);

        this.fillSiblingFiles(this.id);
      }
      , error => {
        console.log(error);
      }
    );
  }

}

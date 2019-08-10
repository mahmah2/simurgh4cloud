import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProjectService } from '../../service/project-service/project.service';
import { FileSystemService } from '../../service/file-system-service/file-system.service';
import { MatSnackBar } from '@angular/material';
import { ProjectModel } from '../../model/project-model';
import { PictureModel } from '../../model/picture-model';

@Component({
  selector: 'app-admin-project-detail',
  templateUrl: './admin-project-detail.component.html',
  styleUrls: ['./admin-project-detail.component.css']
})
export class AdminProjectDetailComponent implements OnInit {
  public id: string;
  public projectInfo: ProjectModel;
  public newPicture: PictureModel;

  public selectedFile: File = null;

  options = [];

  constructor(private route: ActivatedRoute,
    private _router: Router,
    private _projectService: ProjectService,
    private _fileSystem: FileSystemService,
    private snackBar: MatSnackBar, )
  {
    this.id = this.route.snapshot.paramMap.get('id');
    this.resetNewPicture();
  }

  ngOnInit() {
  }

  private resetNewPicture() {
    this.newPicture = { id: 0, type: "", url: "" };
  }

  public OnChange(event) {
    this.selectedFile = <File>event.target.files[0];
  }


  public DoUpload(): any {
    //const fd = new FormData();

    //fd.append("file", this.selectedFile, this.selectedFile.name);
    //fd.append("id", this.id);


    //this._fileSystem.UploadClientFile(fd).subscribe(

    //  data => {
    //    this.snackBar.open(`File ${this.selectedFile.name} was uploaded successfully`
    //      , 'OK',
    //      { duration: 3000 }
    //    );

    //    console.log(data);

    //    this.fillSiblingFiles(this.id);
    //  }
    //  , error => {
    //    console.log(error);
    //  }
    //);
  }


  Save() {
    //this._clientService.UpdateClient(this.clientInfo).subscribe(
    //  data => { console.log(data); },
    //  error => { console.log(error); }
    //);
    //console.log("Saved :" + JSON.stringify(this.clientInfo));
  }


  Cancel() {
    this._router.navigate(['/admin/clients']);
  }

}

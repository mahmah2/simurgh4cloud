import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { ProjectService } from '../../service/project-service/project.service'
import { ProjectModel } from '../../model/project-model';
import { MatTableDataSource } from '@angular/material';


@Component({
  selector: 'app-admin-client-projects-list',
  templateUrl: './admin-client-projects-list.component.html',
  styleUrls: ['./admin-client-projects-list.component.css']
})
export class AdminClientProjectsListComponent implements OnInit {

  public id: string;

  displayedColumns = ['id', 'name', 'operations'];
  project_list: ProjectModel[];
  dataSource = new MatTableDataSource(this.project_list);

  constructor(private route: ActivatedRoute,
          private _projectService: ProjectService) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');

    this.RefreshProjectList();
  }

  private RefreshProjectList() {
    this._projectService.GetClientProjects(this.id).subscribe(
      data => {
        this.project_list = data;
        this.dataSource = new MatTableDataSource(this.project_list);
      },
      error => { console.log(error); }
    );
  }


  addNewProject() {
    var projectName = prompt("Whats the new projects's name?", "New Project");
    if (projectName == null || projectName == "") {
      //txt = "User cancelled the prompt.";
    }
    else {
      //this._clientService.AddNewClientByName(projectName).subscribe(
      //  data => { this.RefreshClientList(); },
      //  error => { console.log(error); }
      //);
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { ClientService } from "../../service/client-service/client-service.service";
import { ClientModel } from '../../model/client-model';


@Component({
  selector: 'app-admin-clients-list',
  templateUrl: './admin-clients-list.component.html',
  styleUrls: ['./admin-clients-list.component.css']
})
export class AdminClientsListComponent implements OnInit {

  displayedColumns = ['id', 'name', 'operations'];
  client_list : ClientModel[];
  dataSource = new MatTableDataSource(this.client_list);
  //dataSource = new MatTableDataSource(ELEMENT_DATA);

  constructor(private _clientService: ClientService) { }

  ngOnInit() {
    this.RefreshClientList();
  }

  private RefreshClientList() {
    this._clientService.GetAll().subscribe(
      data => {
        this.client_list = data;
        this.dataSource = new MatTableDataSource(this.client_list);
      },
      error => { console.log(error); }
    );
  }



  addNewClient() {
    var clientName = prompt("Whats the new client's name?", "New Family");
    if (clientName == null || clientName == "")
    {
      //txt = "User cancelled the prompt.";
    }
    else
    {
      this._clientService.AddNewClientByName(clientName).subscribe(
        data => { this.RefreshClientList(); },
        error => { console.log(error); }
      );
    }
  }

}

//export interface Element {
//  id: number;
//  name: string;
//}

//const ELEMENT_DATA: Element[] = [
//  { id: 1, name: 'Lorikeet Family'},
//  { id: 2, name: 'Kookaburra Family'},
//  { id: 3, name: 'Magpie Family' },
//];

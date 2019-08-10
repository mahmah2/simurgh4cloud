import { Component, OnInit } from '@angular/core';
import { PictureModel } from '../model/picture-model';

@Component({
  selector: 'app-project3',
  templateUrl: './project3.component.html',
  styleUrls: ['./project3.component.css']
})
export class Project3Component implements OnInit {

  constructor() { }

  family2pictures: PictureModel[] = [
    { id: 30, type: 'video', url: 'https://www.youtube.com/embed/N4ySoMtOgUo?rel=0&cc_load_policy=1' },
  ];

  project2pictures: PictureModel[] = [
    { id: 31, type: 'video', url: 'https://www.youtube.com/embed/N4ySoMtOgUo?rel=0&cc_load_policy=1' },
  ];

  ngOnInit() {
  }

}

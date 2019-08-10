import { Component, OnInit } from '@angular/core';
import { PictureModel } from '../model/picture-model';

@Component({
  selector: 'app-project2',
  templateUrl: './project2.component.html',
  styleUrls: ['./project2.component.css']
})
export class Project2Component implements OnInit {

  constructor() { }

  family2pictures: PictureModel[] = [
    { id: 20, type: 'video', url: 'https://www.youtube.com/embed/76oLzM_KItY?rel=0&cc_load_policy=1' },
  ];

  project2pictures: PictureModel[] = [
    { id: 21, type: 'video', url: 'https://www.youtube.com/embed/xK4reZLycdM?rel=0&cc_load_policy=1' },
    { id: 22, type: 'image', url: 'images/projects/2/bathroom01.jpeg' },
    { id: 23, type: 'image', url: 'images/projects/2/bathroom02.jpeg' },
    { id: 24, type: 'image', url: 'images/projects/2/bathroom03.jpeg' },

  ];

  ngOnInit() {
  }

}

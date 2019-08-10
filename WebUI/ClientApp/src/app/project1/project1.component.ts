import { Component, OnInit } from '@angular/core';

import { PictureModel } from '../model/picture-model'

@Component({
  selector: 'app-project1',
  templateUrl: './project1.component.html',
  styleUrls: ['./project1.component.css']
})
export class Project1Component implements OnInit {

  constructor() { }

  family1pictures: PictureModel[] = [
    { id:1, type: 'video', url: 'https://www.youtube.com/embed/QMmZtIEZ05c?rel=0&cc_load_policy=1' },
  ];

  project1pictures: PictureModel[] = [
      {id:2   ,type:'image', url:'images/projects/1/location00.jpeg'},
      {id:3   ,type:'image', url: 'images/projects/1/location01.jpeg' },
      {id:4   ,type:'video', url:'https://www.youtube.com/embed/y11XYVF6yfE?rel=0&cc_load_policy=1'},
      {id:5   ,type:'image', url:'images/projects/1/location02.jpeg'},
      {id:6   ,type:'image', url:'images/projects/1/location03.jpeg'},
      {id:7   ,type:'image', url:'images/projects/1/location04.jpeg'},
      {id:8   ,type:'image', url:'images/projects/1/location05.jpeg'},
      {id:9   ,type:'image', url:'images/projects/1/location06.jpeg'},
      {id:10  ,type:'image', url:'images/projects/1/location07.jfif'},
      {id:11  ,type:'image', url:'images/projects/1/location08.jfif'},
      {id:12  ,type:'image', url:'images/projects/1/location09.jpeg'},
      {id:13  ,type:'image', url:'images/projects/1/location10.jpeg'},
    { id: 14, type: 'image', url:'images/projects/1/location11.jpeg'},
    ];

  ngOnInit() {
  }


}

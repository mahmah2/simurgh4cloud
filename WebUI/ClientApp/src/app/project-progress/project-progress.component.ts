import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-project-progress',
  templateUrl: './project-progress.component.html',
  styleUrls: ['./project-progress.component.css']
})
export class ProjectProgressComponent implements OnInit {

  @Input()
  stage: number; //1: Evaluation - 2:Money Raising- 3:Execution

  constructor() { }

  ngOnInit() {
  }

}

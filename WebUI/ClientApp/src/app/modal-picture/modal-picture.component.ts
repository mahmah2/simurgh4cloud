import { Component, OnInit , Inject} from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';


@Component({
  selector: 'app-modal-picture',
  templateUrl: './modal-picture.component.html',
  styleUrls: ['./modal-picture.component.css']
})
export class ModalPictureComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ModalPictureComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
  }

}

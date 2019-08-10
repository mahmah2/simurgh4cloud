import { Component, OnInit, Input } from '@angular/core';
import { PictureModel } from '../model/picture-model';
import { SafePipe } from '../safe-pipe/safe.pipe';
import { ModalPictureComponent } from '../modal-picture/modal-picture.component';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-picture-gallery',
  templateUrl: './picture-gallery.component.html',
  styleUrls: ['./picture-gallery.component.css']
})
export class PictureGalleryComponent implements OnInit {

  @Input()
  pictures: PictureModel[];

  constructor(public dialog: MatDialog) { }


  ngOnInit() {

  }

  onResize(event) {

  }


  showModal(url: string): void {
    let dialogRef = this.dialog.open(ModalPictureComponent, {
      maxWidth: '100%',
      height: '100vh',
      width: '100%',
      data: { type: "photo", url: url }
    });
  }

}

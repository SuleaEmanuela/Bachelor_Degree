import { Component, OnInit ,Inject} from '@angular/core';
import { MAT_DIALOG_DATA,MatDialogRef } from '@angular/material/dialog';
import { QrCode } from 'src/app/_interfaces/qrcode.model';


@Component({
  selector: 'app-update-qr-code',
  templateUrl: './update-qr-code.component.html',
  styleUrls: ['./update-qr-code.component.css']
})
export class UpdateQrCodeComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<UpdateQrCodeComponent>,@Inject (MAT_DIALOG_DATA)public data:QrCode)  {
    
   }

  ngOnInit(): void {
  }

  onNoClick(): void {
   this.dialogRef.close();
  }

}

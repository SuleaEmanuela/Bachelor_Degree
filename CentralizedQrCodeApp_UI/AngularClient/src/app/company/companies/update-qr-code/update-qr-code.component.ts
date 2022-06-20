import { Component, OnInit ,Inject, Input} from '@angular/core';
import { MAT_DIALOG_DATA,MatDialogRef } from '@angular/material/dialog';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { QrCode } from 'src/app/_interfaces/qrcode.model';
import { NgModule } from '@angular/core';
import { QRCodeModule } from 'angular2-qrcode';



@Component({
  selector: 'app-update-qr-code',
  templateUrl: './update-qr-code.component.html',
  styleUrls: ['./update-qr-code.component.css']
})
export class UpdateQrCodeComponent implements OnInit {
  @Input () name :string;
  @Input () url :string;

  constructor(private repository: RepositoryService,public dialogRef: MatDialogRef<UpdateQrCodeComponent>,@Inject (MAT_DIALOG_DATA)public data:QrCode)  {
    this.name=data.name;
    this.url=data.url;
    
   }

  ngOnInit(): void {
  }

  onNoClick(): void {
   this.dialogRef.close();
  }

  onClick(qrcode:QrCode){
    const apiAddress: string = "api/qrcode";
     this.repository.updateQrCode(apiAddress,qrcode)
     .subscribe(
       response =>{
        console.log(response);
        this.dialogRef.close();
        //this.repository.getData(apiAddress);
       }
     )
  }

}

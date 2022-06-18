import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { QrCode } from 'src/app/_interfaces/qrcode.model';

@Component({
  selector: 'app-create-qr-code',
  templateUrl: './create-qr-code.component.html',
  styleUrls: ['./create-qr-code.component.css']
})

export class CreateQrCodeComponent implements OnInit {
  qrcode:QrCode={
    id: 0 ,
    name:' ',
    url:' ',
    status:' ',

  }

  constructor(private repository: RepositoryService,public dialogRef: MatDialogRef<CreateQrCodeComponent>) { }

  ngOnInit(): void {
  }

  onNoClick(): void {
    this.dialogRef.close();
   }

  onSubmit(){
    const apiAddress: string = "api/qrcode";
    this.repository.createQrCode(apiAddress,this.qrcode)
    .subscribe(
      response =>{
       console.log(response);
    this.dialogRef.close();
     });
  }

} 

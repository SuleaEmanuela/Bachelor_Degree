import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { QrCode } from 'src/app/_interfaces/qrcode.model';

@Component({
  selector: 'app-create-qr-code',
  templateUrl: './create-qr-code.component.html',
  styleUrls: ['./create-qr-code.component.css']
})

export class CreateQrCodeComponent implements OnInit {
  value:string;
  qrcode:QrCode={
    id: 0 ,
    name:' ',
    url:' ',
    status:' ',

  }
  
  @ViewChild('generator') qrcodeGenerator; 

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
        this.qrcodeGenerator.nativeElement.value=this.qrcode.url;
       console.log(response);
    this.dialogRef.close();
     });
     
  }

  genarateQrCode(){
      const value=(document.getElementById('generator')as HTMLInputElement).value=this.qrcode.url;
      this.value=this.qrcode.url;
      

  }

} 

import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { QrCode } from 'src/app/_interfaces/qrcode.model';
import { Router } from '@angular/router';



@Component({
  selector: 'app-create-qr-code',
  templateUrl: './create-qr-code.component.html',
  styleUrls: ['./create-qr-code.component.css']
})

export class CreateQrCodeComponent implements OnInit {
  value:string;
  public qrcodes: QrCode[];
  qrcode:QrCode={
    id: 0 ,
    name:' ',
    url:' ',
    status:' ',

  }
  
  @ViewChild('generator') qrcodeGenerator; 
  @ViewChild('parent', { read: ElementRef }) parent:ElementRef<HTMLElement>;

  constructor(private repository: RepositoryService,public dialogRef: MatDialogRef<CreateQrCodeComponent>,private router: Router) { }
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
       //this.repository.getData("api/qrcode");
     });
     
  }

  genarateQrCode(){
      const value=(document.getElementById('generator')as HTMLInputElement).value=this.qrcode.url;
      this.value=this.qrcode.url;
      
  }
  
  private convertBase64ToBlob(Base64Image: any) {
    // SPLIT INTO TWO PARTS
    const parts = Base64Image.split(';base64,');
    // HOLD THE CONTENT TYPE
    const imageType = parts[0].split(':')[1];
    // DECODE BASE64 STRING
    const decodedData = window.atob(parts[1]);
    // CREATE UNIT8ARRAY OF SIZE SAME AS ROW DATA LENGTH
    const uInt8Array = new Uint8Array(decodedData.length);
    // INSERT ALL CHARACTER CODE INTO UINT8ARRAY
    for (let i = 0; i < decodedData.length; ++i) {
      uInt8Array[i] = decodedData.charCodeAt(i);
    }
    // RETURN BLOB IMAGE AFTER CONVERSION
    return new Blob([uInt8Array], { type: imageType });
  }

  saveAsImage(parent){
    const parentElement=this.parent.nativeElement.querySelector("img").src;
    let blobData = this.convertBase64ToBlob(parentElement);
        const blob = new Blob([blobData], { type: "image/png" });
        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = this.qrcode.name;
        link.click();
      
  }

  


} 

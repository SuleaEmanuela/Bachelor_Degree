import { QrCode } from './../../_interfaces/qrcode.model';
import { RepositoryService } from './../../shared/services/repository.service';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';


import { UpdateQrCodeComponent } from './update-qr-code/update-qr-code.component';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { CreateQrCodeComponent } from './create-qr-code/create-qr-code.component';





@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})

export class CompaniesComponent implements OnInit {
  public qrcodes: QrCode[];

  qrcode:QrCode={
    id: 0 ,
    name:' ',
    url:' ',
    status:''
    
  }

  constructor(private repository: RepositoryService,public dialogRef:MatDialog) { }

  ngOnInit(): void {
    this.getQrCodes();
  }

  getQrCodes = () => {
    const apiAddress: string = "api/qrcode";
    this.repository.getData(apiAddress)
    .subscribe({
      next: (com: QrCode[]) => this.qrcodes = com,
      error: (err: HttpErrorResponse) => console.log(err)
    })
  }

  deleteQrCode = (id:number) =>{
    const apiAddress: string = "api/qrcode";
    this.repository.deleteQrCode(apiAddress,id)
    .subscribe({
      next:(com:QrCode[])=>this.getQrCodes(),
      error:(err:HttpErrorResponse)=>console.log(err)
    })

  }

  openDialog(qrcode:QrCode) :void{
    const ref=this.dialogRef.open(UpdateQrCodeComponent,
      {
        width: '1200px',
        height: '700px',
        data:qrcode
      });
    ref.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      
    });
  }

  createQrCode(){
    const ref=this.dialogRef.open(CreateQrCodeComponent,
      {
        width: '1200px',
        height: '700px'
        
      });
      ref.afterClosed().subscribe(result=>{this.getQrCodes()});
  }



 
   
  }

  



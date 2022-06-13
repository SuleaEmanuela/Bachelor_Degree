import { QrCode } from './../../_interfaces/qrcode.model';
import { RepositoryService } from './../../shared/services/repository.service';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { UpdateQrCodeComponent } from './update-qr-code/update-qr-code.component';




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
    
  }

  constructor(private repository: RepositoryService) { }

  ngOnInit(): void {
    this.getCompanies();
  }

  getCompanies = () => {
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
      next:(com:QrCode[])=>this.getCompanies(),
      error:(err:HttpErrorResponse)=>console.log(err)
    })

  }

 
   
  }

  



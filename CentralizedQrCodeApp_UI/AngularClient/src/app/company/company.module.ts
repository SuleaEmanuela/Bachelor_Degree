import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompaniesComponent } from './companies/companies.component';
import { RouterModule } from '@angular/router';
import { UpdateQrCodeComponent } from './companies/update-qr-code/update-qr-code.component';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';





@NgModule({
  declarations:
 
   [CompaniesComponent, UpdateQrCodeComponent],
 
  imports: [
    CommonModule,
    MatDialogModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'companies', component: CompaniesComponent }
    ])
  ]
})
export class CompanyModule { }

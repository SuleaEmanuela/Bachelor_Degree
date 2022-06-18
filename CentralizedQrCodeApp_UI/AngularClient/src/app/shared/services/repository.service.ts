
import { QrCode } from 'src/app/_interfaces/qrcode.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { EnvironmentUrlService } from './environment-url.service';


@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getData = (route: string) => {
    return this.http.get<QrCode[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public updateQrCode =(route:string,qrcode:QrCode ) => {
    return this.http.put<QrCode>(this.createCompleteRoute(route,this.envUrl.urlAddress),qrcode);
  }
  
  public deleteQrCode=(route :string,id:number)=>{
    return this.http.delete<QrCode[]>(this.createCompleteRoute(route,this.envUrl.urlAddress)+"/"+id);
  }

  public createQrCode=(route :string,qrcode:QrCode) =>{
    return this.http.post<QrCode>(this.createCompleteRoute(route,this.envUrl.urlAddress),qrcode);
  }
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
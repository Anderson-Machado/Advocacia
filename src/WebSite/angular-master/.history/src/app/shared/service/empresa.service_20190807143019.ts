import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Empresa } from 'model/empresa';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {
  api = environment.ApiUrl;
  constructor(private http: HttpClient) { }
  createEmpresa(empresa: Empresa){
    debugger;
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    return this.http.post(this.api + 'api/Empresa/CreateEmpresa', empresa, {headers});
  }
  getListEmpresa(){
    return this.http.get( this.api + 'api/Empresa/GetEmpresa');
  }

}

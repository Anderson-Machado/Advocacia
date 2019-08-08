import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Empresa } from 'model/empresa';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

  constructor(private http: HttpClient) { }
  createEmpresa(empresa: Empresa){
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    return this.http.post('api/Empresa/CreateEmpresa', empresa, {headers});
  }
  getListEmpresa(){
    return this.http.get('api/Empresa/GetEmpresa');
  }

}

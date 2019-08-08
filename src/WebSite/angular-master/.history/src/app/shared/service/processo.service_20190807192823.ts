import { Injectable } from '@angular/core';
import { Processos } from 'model/processo';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ProcessoService {
  api = environment.ApiUrl;
  constructor(private http: HttpClient) { }

  createProcesso(processos: Processos){
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    return this.http.post(this.api +'api/processo/CreateProcesso', processos, {headers});
  }

  getProcessosAtivos()
  {
    return this.http.get( this.api + 'api/processo/GetProcessosAtivo');
  }

  getMedia(){
    return this.http.get( this.api + 'api/processo/GetMedia');
  }
  
  getCalculoNumeroDeProcesso()
  {
    return this.http.get( this.api + 'api/processo/GetCalculoNumeroDeProcesso');
  }

  getListProcessosMaior(){
    return this.http.get( this.api + 'api/processo/GetListProcessosMaior');

  }
}

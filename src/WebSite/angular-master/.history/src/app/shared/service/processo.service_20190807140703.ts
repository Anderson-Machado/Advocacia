import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http/http';
import { Processos } from 'model/processo';


@Injectable({
  providedIn: 'root'
})
export class ProcessoService {
  constructor(private http: HttpClient) { }
  createProcesso(processos: Processos){
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    return this.http.post('api/processo/CreateProcesso', processos, {headers});
  }
}

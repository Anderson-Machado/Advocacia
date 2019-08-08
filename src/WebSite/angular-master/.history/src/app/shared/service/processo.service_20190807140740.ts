import { Injectable } from '@angular/core';
import { Processos } from 'model/processo';
import { HttpClient, HttpHeaders } from '@angular/common/http';


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

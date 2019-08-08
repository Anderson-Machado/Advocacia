import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';
import { ProcessoService } from 'app/shared/service/processo.service';
import { Processos } from 'model/processo';


@Component({
    selector: 'dashboard-cmp',
    moduleId: module.id,
    templateUrl: 'dashboard.component.html'
})

export class DashboardComponent implements OnInit{
  constructor(private service: ProcessoService) {
      
  }
  somaProcessosAtivos:number;
  mediaProcessos:number;
  listaProcessos:Array<Processos> = new Array<Processos>();
  listaProcessosMaior2017:Array<Processos> = new Array<Processos>();
  listProcessTrab:Array<Processos> = new Array<Processos>();  
  ngOnInit(){
      
      this.getSomaAtivo(); 
      this.getMedia();
      this.getCalculoNumeroDeProcesso();
      this.getListProcessosMaior();
      this.getProcessTrab();
    }

    getSomaAtivo(){
      this.service.getProcessosAtivos().subscribe((data:number) => {
        this.somaProcessosAtivos = data;
      });
    }
      getMedia(){
      this.service.getMedia().subscribe((data:number)=>{
      this.mediaProcessos = data;
      });
    }

    getCalculoNumeroDeProcesso(){
     this.service.getCalculoNumeroDeProcesso().subscribe((data:Processos[])=>{
     this.listaProcessos = data;
     });
    }

    getListProcessosMaior(){
      this.service.getListProcessosMaior().subscribe((data:Processos[])=>{
        this.listaProcessosMaior2017 = data;
      });
    }
    getProcessTrab(){
      this.service.getProcessTrab().subscribe((data:Processos[])=>{
        this.listProcessTrab = data;
      
    });
  }
    
}

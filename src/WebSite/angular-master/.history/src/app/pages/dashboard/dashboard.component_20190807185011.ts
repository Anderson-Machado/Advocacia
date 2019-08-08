import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';
import { ProcessoService } from 'app/shared/service/processo.service';


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

    ngOnInit(){
      
      this.getSomaAtivo(); 
    }

    getSomaAtivo(){
      this.service.getProcessosAtivos().subscribe((data:number) => {
        this.somaProcessosAtivos = data;
      });
    }
}

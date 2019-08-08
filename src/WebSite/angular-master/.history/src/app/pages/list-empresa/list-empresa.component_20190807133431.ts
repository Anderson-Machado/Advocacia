import { Component, OnInit } from '@angular/core';
import { Empresa } from 'model/empresa';
import { EmpresaService } from 'app/shared/service/empresa.service';

@Component({
  selector: 'app-list-empresa',
  templateUrl: './list-empresa.component.html',
  styleUrls: ['./list-empresa.component.scss']
})
export class ListEmpresaComponent implements OnInit {
  showPleaseWait = false;
  empresas: Array<Empresa> = new Array<Empresa>();
  constructor(private service: EmpresaService) {}

  ngOnInit() {
      this.showPleaseWait = true;
      this.getListEmpresa();
}

  getListEmpresa() {
    this.service.getListEmpresa().subscribe((res: any[]) => {
    this.empresas = res;
    this.showPleaseWait = false;
  }, error => {
      alert('Erro de conexão com o servidor, informe ao suporte');
  });
}


reciverFeedback() {
    //this.getListContas();
}

}

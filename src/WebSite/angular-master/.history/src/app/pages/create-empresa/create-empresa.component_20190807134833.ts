import { Component, OnInit } from '@angular/core';
import { Empresa } from 'model/empresa';
import { EmpresaService } from 'app/shared/service/empresa.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'create-empresa',
  templateUrl: './create-empresa.component.html',
  styleUrls: ['./create-empresa.component.scss']
})
export class CreateEmpresaComponent {
  modalReference = null;
  empresa: Empresa = new Empresa();
    constructor(private modalService: NgbModal,
                private toastr: ToastrService,
        private service: EmpresaService) { }
  open(content) {
   this.modalReference = this.modalService.open(content, { centered: true });
}

save() {

    this.service.createEmpresa(this.empresa).subscribe((res: Response) => {
     if (res.type) {
      this.toastr.success('' + res.text, 'Cadastro de Contas');
     // EventEmitterService.get('carregaEvent').emit(null);
      this.modalReference.close();
     } else {
      this.toastr.error('' + res.text, 'Cadastro de Contas');
     }
     }, erro => this.toastr.error('Erro de conexção com o servidor, por favor informe ao suporte', 'Erro Geral'));
  }

}

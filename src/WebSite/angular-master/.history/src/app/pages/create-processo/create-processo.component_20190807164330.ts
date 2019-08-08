import { Component, OnInit, Input } from '@angular/core';
import { Processos } from 'model/processo';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ProcessoService } from 'app/shared/service/processo.service';

@Component({
  selector: 'create-processo',
  templateUrl: './create-processo.component.html',
  styleUrls: ['./create-processo.component.scss']
})
export class CreateProcessoComponent {
  @Input() idEmpresa:number;
  modalReference = null;
  processo: Processos = new Processos();

    constructor(private modalService: NgbModal,
                private toastr: ToastrService,
        private service: ProcessoService) { }
  open(content) {
   this.modalReference = this.modalService.open(content, { centered: true });
}

save() {
    this.processo.idEmpresa = this.idEmpresa;
    this.service.createProcesso(this.processo).subscribe((res: Response) => {
     if (res.type) {
      this.toastr.success('' + res.text, 'Cadastro de processos');
     // EventEmitterService.get('carregaEvent').emit(null);
      this.modalReference.close();
     } else {
      this.toastr.error('' + res.text, 'Cadastro de processos');
     }
     }, erro => this.toastr.error('Erro de conexção com o servidor.', 'Erro Geral'));
  }


}

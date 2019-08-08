import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AdminLayoutRoutes } from './admin-layout.routing';

import { DashboardComponent }       from '../../pages/dashboard/dashboard.component';
import { UserComponent }            from '../../pages/user/user.component';
import { MapsComponent }            from '../../pages/maps/maps.component';
import { ListEmpresaComponent } from 'app/pages/list-empresa/list-empresa.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CreateEmpresaComponent } from 'app/pages/create-empresa/create-empresa.component';
import { EmpresaService } from 'app/shared/service/empresa.service';
import { ProcessoService } from 'app/shared/service/processo.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    NgbModule
  ],
  providers: [EmpresaService, ProcessoService],
  declarations: [
    DashboardComponent,
    UserComponent,
    MapsComponent,
    ListEmpresaComponent,
    CreateEmpresaComponent
  ]
})

export class AdminLayoutModule {}

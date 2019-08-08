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
import { CreateProcessoComponent } from 'app/pages/create-processo/create-processo.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    NgbModule
  ],
  declarations: [
    DashboardComponent,
    UserComponent,
    MapsComponent,
    ListEmpresaComponent,
    CreateEmpresaComponent,
    CreateProcessoComponent
    
  ]
})

export class AdminLayoutModule {}

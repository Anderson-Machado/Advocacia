import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { UserComponent } from '../../pages/user/user.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { ListEmpresaComponent } from 'app/pages/list-empresa/list-empresa.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user',           component: UserComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'empresa',        component: ListEmpresaComponent }
];

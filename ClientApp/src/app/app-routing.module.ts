import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CustomerComponent } from './customer/customer.component';
import { DispatcherComponent } from './dispatcher/dispatcher.component';
import { AuthGuard } from './guards/auth-guard.service';
import { HomeComponent } from './home/home.component';
import { Role } from './login/interfaces/Role';
import { LoginComponent } from './login/login.component';
import { PilotComponent } from './pilot/pilot.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: {roles: [Role.Admin] }
    },
    {
        path: 'dispatcher',
        component: DispatcherComponent,
        canActivate: [AuthGuard],
        data: {roles: [Role.Admin, Role.Dispatcher]}
    },
    {
        path: 'pilot',
        component: PilotComponent,
        canActivate: [AuthGuard],
        data: {roles: [Role.Admin, Role.Pilot]}
    },
    {
        path: 'customer',
        component: CustomerComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'checkout',
        component: CheckoutComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'login',
        component: LoginComponent
    },
    { path: '**', redirectTo: ''}
];
@NgModule ({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}

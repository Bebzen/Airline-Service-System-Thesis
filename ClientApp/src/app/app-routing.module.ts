import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './guards/auth-guard.service';
import { HomeComponent } from './home/home.component';
import { Role } from './login/interfaces/Role';
import { LoginComponent } from './login/login.component';

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

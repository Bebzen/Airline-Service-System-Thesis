import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { JwtInterceptor } from '@auth0/angular-jwt';
import { AppRoutingModule } from '../app-routing.module';
import { AppModule } from '../app.module';
import { AuthGuard } from '../guards/auth-guard.service';
import { ErrorInterceptor } from '../services/error.interceptor';
import { SharedModule } from '../shared/shared.module';
import { AdminComponent } from './admin.component';
import { AdministratorService } from './services/administrator.service';
import { UserEditDialogComponent } from './user-edit-dialog/user-edit-dialog.component';

@NgModule({
    declarations: [AdminComponent, UserEditDialogComponent],
    imports: [
        SharedModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule
    ],
    exports: [
        UserEditDialogComponent
    ],
    providers: [AdministratorService],
    entryComponents: [UserEditDialogComponent]
})
export class AdminModule { }

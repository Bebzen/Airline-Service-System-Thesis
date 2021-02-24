import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
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

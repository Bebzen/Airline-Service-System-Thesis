import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CustomerComponent } from './customer.component';
import { CustomerService } from './services/customer.service';

@NgModule({
    declarations: [
        CustomerComponent
    ],
    imports: [
        SharedModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule
    ],
    providers: [CustomerService]
})
export class CustomerModule { }

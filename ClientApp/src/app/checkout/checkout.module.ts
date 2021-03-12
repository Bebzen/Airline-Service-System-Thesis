import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CheckoutComponent } from './checkout.component';
import { PaymentDialogComponent } from './payment-dialog/payment-dialog.component';
import { CheckoutService } from './services/checkout.service';

@NgModule({
    declarations: [
        CheckoutComponent,
        PaymentDialogComponent
    ],
    imports: [
        SharedModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule
    ],
    providers: [CheckoutService],
    entryComponents: [
        PaymentDialogComponent
    ]
})
export class CheckoutModule { }

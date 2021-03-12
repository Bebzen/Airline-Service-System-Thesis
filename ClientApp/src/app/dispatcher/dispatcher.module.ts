import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CrewEditDialogComponent } from './crew-edit-dialog/crew-edit-dialog.component';
import { DispatcherComponent } from './dispatcher.component';
import { EditReservationsDialogComponent } from './edit-reservations-dialog/edit-reservations-dialog.component';
import { FlightEditDialogComponent } from './flight-edit-dialog/flight-edit-dialog.component';
import { DispatcherService } from './services/dispatcher.service';

@NgModule({
    declarations: [
        DispatcherComponent,
        CrewEditDialogComponent,
        FlightEditDialogComponent,
        EditReservationsDialogComponent
    ],
    imports: [
        SharedModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule
    ],
    providers: [DispatcherService],
    entryComponents: [
        CrewEditDialogComponent,
        FlightEditDialogComponent,
        EditReservationsDialogComponent
    ]
})
export class DispatcherModule { }

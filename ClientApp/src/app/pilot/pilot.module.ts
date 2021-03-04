import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';
import { PilotComponent } from './pilot.component';
import { PilotService } from './services/pilot.service';

@NgModule({
    declarations: [
        PilotComponent
    ],
    imports: [
        SharedModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserModule
    ],
    providers: [PilotService]

})
export class PilotModule {}

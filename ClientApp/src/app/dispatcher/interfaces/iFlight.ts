import { Time } from '@angular/common';
import { Moment } from 'moment';
import { ICrew } from './iCrew';
import { PlaneType } from './PlaneType';

export interface IFlight {
    id: number;
    crew: ICrew;
    flightNumber: string;
    startingAirportName: string;
    destinationAirportName: string;
    flightDate: Moment;
    takeoffHour: Time;
    landingHour: Time;
    planeType: PlaneType;
    totalSeats: number;
    isApproved: boolean;
    isCompleted: boolean;
}
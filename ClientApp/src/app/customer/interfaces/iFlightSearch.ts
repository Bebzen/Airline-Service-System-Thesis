import { Moment } from 'moment';

export interface IFlightSearch {
    originAirport: string;
    destinationAirport: string;
    departureDate: Moment;
}

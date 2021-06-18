import { IFlight } from 'src/app/dispatcher/interfaces/iFlight';

export interface IReservationCreationRequest {
    id: number;
    flight: IFlight;
    userId: number;
    price: number;
    seatNumber: string;
    transactionId: string;
    isValid: boolean;
}

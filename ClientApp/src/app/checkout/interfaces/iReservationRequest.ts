import { IUser } from 'src/app/login/interfaces/iUser';

export interface IReservationRequest {
    id: number;
    flightId: number;
    user: IUser;
    price: number;
    seatNumber: string;
    transactionId: string;
    isValid: boolean;
}

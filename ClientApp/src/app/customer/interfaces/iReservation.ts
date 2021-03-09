import { IFlight } from 'src/app/dispatcher/interfaces/iFlight';
import { IUser } from 'src/app/login/interfaces/iUser';

export interface IReservation {
    id: number;
    flight: IFlight;
    user: IUser;
    price: number;
    seatNumber: string;
    isPaid: boolean;
}
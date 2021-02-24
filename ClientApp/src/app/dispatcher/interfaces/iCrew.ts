import { IUser } from 'src/app/login/interfaces/iUser';

export interface ICrew {
    id: number;
    crewName: string;
    captain: IUser;
    firstOfficer: IUser;
    secondOfficer: IUser;
}

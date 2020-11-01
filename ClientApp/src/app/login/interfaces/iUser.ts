import { Role } from './Role';

export interface IUser {
    id: number;
    username: string;
    password: string;
    role: Role;
    firstName: string;
    lastName: string;
    token?: string;
}

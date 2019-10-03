import { Photo } from "./Photo";

export interface User {
    city: string;
    country: string;
    created: Date;
    dateOfBirth: Date;
    gender: string;
    id: number;
    interests: string;
    introduction: string;
    knownAs: string;
    lastActive: Date;
    lookingFor: string;
    name: string;
    profileUrl: string;
    photo?: Photo[];

}

import { City } from "./city.model";

export interface TripItemSummary {
    id: string;
    city: City;
    date: Date;
}
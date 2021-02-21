import { AgeRange } from './AgeRange';
import { HoursRange } from './HoursRange';
import { bookedDate } from './bookedDate';
import { ServiceTypeMapper } from './ServiceTypeMapper';
import { Traveler } from './Traveler';

export class Suggestion {
    SuggestionID: number;
    HostId: number;
    Title: number;
    Description: string;
    RangeAge?: AgeRange;
    RangeHours?: HoursRange;
    Gender?: string;
    Country?: string;
    Street?: string;
    City?: string;
    Status?: number;
    // servicesType: number[];
    //  ServicesTypeName:string[]=[];
    mapperServices: ServiceTypeMapper[];
    bookedDates: bookedDate[];
    Travelers: Traveler[];
    
    public Suggestion() {
        this.bookedDates = []

    }
}


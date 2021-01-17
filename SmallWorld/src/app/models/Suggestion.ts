import { AgeRange } from './AgeRange';
import { HoursRange } from './HoursRange';
import { bookedDate } from './bookedDate';
import { ServiceTypeMapper } from './ServiceTypeMapper';

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
    // servicesType: number[];
    //  ServicesTypeName:string[]=[];
    mapperServices: ServiceTypeMapper[];
    bookedDates: bookedDate[];
    public Suggestion() {
        this.bookedDates = []

    }
}


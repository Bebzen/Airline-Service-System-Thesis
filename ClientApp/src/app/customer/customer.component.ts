import { ConstantPool } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { IFlight } from '../dispatcher/interfaces/iFlight';
import { IFlightSearch } from './interfaces/iFlightSearch';
import { CustomerService } from './services/customer.service';

@Component({
    templateUrl: 'customer.component.html',
    styleUrls: ['./customer.component.scss']
})

export class CustomerComponent implements OnInit {

    newFlightSearch: IFlightSearch;
    foundFlights: IFlight[];
    constructor(
        private customerService: CustomerService
    ) {
        this.foundFlights = {} as IFlight[];
        this.newFlightSearch = {} as IFlightSearch;
    }
    ngOnInit(): void {
    }

    onClickFindFlights() {
        console.log(this.newFlightSearch.departureDate);
        this.customerService.searchFlights(this.newFlightSearch).subscribe(flights=>
            {
                this.foundFlights = flights;
            },
            error => {
                console.log(error);
            });

    }

}

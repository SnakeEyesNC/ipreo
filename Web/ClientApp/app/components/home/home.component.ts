import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/toPromise';

import { SubwayStopService } from '../../services/subway-stop.service';

import { SubwayStop } from '../../models/subway-stop';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent {
    subwayStops: SubwayStop[] = [];

    selectedStopOne: SubwayStop;
    selectedStopTwo: SubwayStop;
    distanceBetweenStops: number = 0;

    constructor(private subwayStopService: SubwayStopService) { }

    ngOnInit() {
        this.getSubwayStops();
    }

    getSubwayStops(): void {
        this.subwayStopService.getSubwayStops()
            .subscribe(stops => {
                this.subwayStops = stops.sort(this.subwayStopSort);
                this.selectedStopOne = this.subwayStops[0];
                this.selectedStopTwo = this.subwayStops[0];
                this.calculateDistance();
            });
    }

    subwayStopSort(x: SubwayStop, y: SubwayStop) {
        if (x.name < y.name) return -1;
        if (x.name > y.name) return 1;
        return 0;
    }

    calculateDistance() {
        this.distanceBetweenStops = this.subwayStopService.getDistanceFromLatLonInKm(this.selectedStopOne.latitude,
                                                                                        this.selectedStopOne.longitude,
                                                                                        this.selectedStopTwo.latitude,
                                                                                        this.selectedStopTwo.longitude);
    }
}

import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { SubwayStop } from '../models/subway-stop';

@Injectable()
export class SubwayStopService {
    private subwayStopsUrl = "http://localhost:7770/api/SubwayStop";

    constructor(private http: Http) { }

    getSubwayStops() : Observable<SubwayStop[]> {
        return this.http.get(this.subwayStopsUrl).map((response: Response) => <SubwayStop[]>response.json());
    }


    getDistanceFromLatLonInKm(lat1: any, lon1: any, lat2: any, lon2: any) {
        var R = 6371; // Radius of the earth in km
        var dLat = this.deg2rad(lat2 - lat1);  // deg2rad below
        var dLon = this.deg2rad(lon2 - lon1);
        var a =
                Math.sin(dLat / 2) * Math.sin(dLat / 2) +
            Math.cos(this.deg2rad(lat1)) * Math.cos(this.deg2rad(lat2)) *
                    Math.sin(dLon / 2) * Math.sin(dLon / 2)
            ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c; // Distance in km
        return d;
    }

    deg2rad(deg: number) {
        return deg * (Math.PI / 180);
    }
}
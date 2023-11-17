import { Injectable } from '@angular/core';
import { BackService } from './back.service';
import { Observable, Subject, map, mergeMap } from 'rxjs';
import { TripDetail } from '../models/trip-detail.model';

@Injectable({
  providedIn: 'root'
})
export class TripSelectionService {

  private selectedTripIdSubject = new Subject<string>();

  constructor(private backService: BackService) {     
  }

  getSelectedTrip(): Observable<TripDetail>{
    return this.selectedTripIdSubject.pipe(
      mergeMap(id => this.backService.get<TripDetail>(`trip/${id}`))
    );
  }

  updateSelectedTrip(tripId: string) : void{
    this.selectedTripIdSubject.next(tripId);  
  }
}
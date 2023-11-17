import { Component, OnInit } from '@angular/core';
import { TripSelectionService } from '../../../services/trip-selection.service';
import { TripDetail } from '../../../models/trip-detail.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-trip-detail',
  templateUrl: './trip-detail.component.html',
  styleUrl: './trip-detail.component.scss',
  host: {'class' : 'trip-detail'}
})
export class TripDetailComponent implements OnInit {
  selectedTrip$: Observable<TripDetail> | undefined;

  constructor(private tripSelectionService: TripSelectionService){
  }

  ngOnInit(): void {
    this.selectedTrip$ = this.tripSelectionService.getSelectedTrip();  
  }
}
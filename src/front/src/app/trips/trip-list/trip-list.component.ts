import { Component, OnInit } from '@angular/core';
import { BackService } from '../../../services/back.service';
import { Observable } from 'rxjs';
import { TripItemSummary } from '../../../models/trip-item-summary.model';
import { MatSelectionListChange } from '@angular/material/list';
import { TripSelectionService } from '../../../services/trip-selection.service';

@Component({
  selector: 'app-trip-list',
  templateUrl: './trip-list.component.html',
  styleUrl: './trip-list.component.scss',
  host: {'class' : 'trip-list'}
})
export class TripListComponent implements OnInit{  
  tripItems$!: Observable<TripItemSummary[]>;


  constructor(private backService:BackService, 
              private tripSelectionService: TripSelectionService) {    
  }

  ngOnInit(): void {
    this.tripItems$ = this.backService.get<TripItemSummary[]>("trip");
  }

  onTripSelectedChange(event: MatSelectionListChange){
    const tripSelectedId = event.options[0].value;
    this.tripSelectionService.updateSelectedTrip(tripSelectedId);
  }
}
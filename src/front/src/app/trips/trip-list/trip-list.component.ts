import { Component, OnInit } from '@angular/core';
import { BackService } from '../../../services/back.service';
import { Observable } from 'rxjs';
import { TripItemSummary } from '../../../models/trip-item-summary.model';

@Component({
  selector: 'app-trip-list',
  templateUrl: './trip-list.component.html',
  styleUrl: './trip-list.component.scss'
})
export class TripListComponent implements OnInit{  
  tripItems$!: Observable<TripItemSummary[]>;


  constructor(private backService:BackService) {    
  }

  ngOnInit(): void {
    this.tripItems$ = this.backService.get<TripItemSummary[]>("trip");
  }

}
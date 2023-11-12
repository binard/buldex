import { Routes } from '@angular/router';
import { TripListComponent } from './trips/trip-list/trip-list.component';

export const routes: Routes = [
    { path: 'trips', component: TripListComponent },
    { path: '', redirectTo: '/trips', pathMatch: 'full' },
];
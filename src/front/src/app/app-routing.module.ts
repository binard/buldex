import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TripListComponent } from './trips/trip-list/trip-list.component';
import { BuldexBrowserComponent } from './buldex-browser/buldex-browser.component';

const routes: Routes = [
  { path: 'trips', component: BuldexBrowserComponent },
  { path: '', redirectTo: '/trips', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

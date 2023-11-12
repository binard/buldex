import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, of, tap } from 'rxjs';
import { AzFunctionResult } from '../models/az-function-result.model';

@Injectable({
  providedIn: 'root'
})
export class BackService {

  private BASE_URL = "https://buldexbackapp.azurewebsites.net/api";
  private DEFAULT_HEADERS = new HttpHeaders({ 'x-functions-key': 'sxxMvTokPTrXyMTSPMP_ZplZan_LcxGYOym-F1eCa42NAzFuDlD_JQ==' });


  constructor(private httpClient: HttpClient) {

  }

  get<T>(uri: string): Observable<T> {
    const url = `${this.BASE_URL}/${uri}`;
    return this.httpClient
      .get<AzFunctionResult<T>>(url, { headers: this.DEFAULT_HEADERS })
      .pipe(
        tap(t => console.log(t)),
        map(r => {          
          if (r.statusCode === 200) {
            return r.value;
          }
          throw new Error(`An error is occured when call ${url} : Error ${r.statusCode} - ${r.value}`)
        })
      );
  }
}
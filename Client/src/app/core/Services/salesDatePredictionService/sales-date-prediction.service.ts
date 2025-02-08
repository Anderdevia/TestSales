import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, signal, WritableSignal } from '@angular/core';
import { SalesDatePrediction } from '../../interfaces/salesDatePrediction/salesDatePrediction';
import { getSalesDatePredictionendpoints } from './sales-date-prediction.endpoint.service';
import { environment } from '../../../environment';
import { firstValueFrom } from 'rxjs';
import { SingleResponseModel } from '../../../shared/utils/response.interfaces';

@Injectable({
  providedIn: 'root',
})
export class SalesDatePredictionService {
  private httpClient: HttpClient = inject(HttpClient);
  private salesDatePrediction: WritableSignal<SalesDatePrediction[]> = signal<SalesDatePrediction[]>([]);

   public get $salesDatePrediction(): SalesDatePrediction[]{
      return this.salesDatePrediction();
    }
    public set $salesDatePrediction(value: SalesDatePrediction[]){
      this.salesDatePrediction.set(value);
    }
  
    public async getSalesDatePredictionr() {
      try {
        return await firstValueFrom(
          this.httpClient.get<SingleResponseModel<SalesDatePrediction[]>>(`${environment.apiUrlSales_Date_Prediction}${getSalesDatePredictionendpoints.getSalesDatePrediction}`,{ observe: 'response' })
        ).then(success => {
          console.log('success: ', success);
          this.$salesDatePrediction = success.body?.data as SalesDatePrediction[]
        }).catch((err: HttpErrorResponse) => {
          console.log('err: ', err);
        })
      } catch (error: any) {}
    }
}

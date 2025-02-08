import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, signal, WritableSignal } from '@angular/core';
import { Customers } from '../../interfaces/customers/customes';
import { firstValueFrom } from 'rxjs';
import { SingleResponseModel } from '../../../shared/utils/response.interfaces';
import { environment } from '../../../environment';
import { getcustomerendpoints } from './customers.service.endpoint';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {

  private httpClient: HttpClient = inject(HttpClient)
  private customer: WritableSignal<Customers[]>= signal<Customers[]>([])

  public get $customer(): Customers[]{
    return this.customer();
  }
  public set $customer(value: Customers[]){
    this.customer.set(value);
  }

  public async getCustomer() {
    try {

      return await firstValueFrom(
        this.httpClient.get<SingleResponseModel<Customers[]>>(`${environment.apiUrlSales_Date_Prediction}${getcustomerendpoints.getcustomer}`,{ observe: 'response' })
      ).then(success => {
        console.log('success: ', success);
        this.$customer = success.body?.data as Customers[]
      }).catch((err: HttpErrorResponse) => {
        console.log('err: ', err);
      })
    } catch (error: any) {
    }
  }
}

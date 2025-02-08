import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { inject, Injectable, signal, WritableSignal } from '@angular/core';
import { OrdersByCustomer } from '../../interfaces/orders/ordersByCustomer';
import { environment } from '../../../environment';
import { getordersbycustomerendpoints } from './orders-endpoint';
import { firstValueFrom, Observable } from 'rxjs';
import { SingleResponseModel } from '../../../shared/utils/response.interfaces';
import {
  NewOrderWithProduct,
  OrderWithProduct,
  ResponseOrderWithProduct,
} from '../../interfaces/orders/newOrder';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  private httpClient: HttpClient = inject(HttpClient);
  private ordersByCustomer: WritableSignal<OrdersByCustomer[]> = signal<
    OrdersByCustomer[]
  >([]);

  //#region getOrdersByCustomer
  public get $ordersByCustomer(): OrdersByCustomer[] {
    return this.ordersByCustomer();
  }
  public set $ordersByCustomer(value: OrdersByCustomer[]) {
    this.ordersByCustomer.set(value);
  }

  public async getOrdersByCustomer(custid: number) {
    try {
      return await firstValueFrom(
        this.httpClient.get<SingleResponseModel<OrdersByCustomer[]>>(
          `${environment.apiUrlSales_Date_Prediction}${getordersbycustomerendpoints.getOrdersByCustomer}/${custid}`,
          { observe: 'response' }
        )
      )
        .then((success) => {
          console.log('success: ', success);
          this.$ordersByCustomer = success.body?.data as OrdersByCustomer[];
        })
        .catch((err: HttpErrorResponse) => {
          console.log('err: ', err);
        });
    } catch (error: any) {}
  }
  //#endregion getOrdersByCustomer

  //#region NewOrder
  public async postNewOrderWithProduct(
    data: OrderWithProduct
  ): Promise<Observable<HttpResponse<ResponseOrderWithProduct>>> {
    return this.httpClient.post<ResponseOrderWithProduct>(
      `${environment.apiUrlSales_Date_Prediction}${getordersbycustomerendpoints.postNewOrder}`,
      data,
      { observe: 'response' }
    );
  }
  //#endregion NewOrder
}

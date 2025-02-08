import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, signal, WritableSignal } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../../environment';
import { SingleResponseModel } from '../../../shared/utils/response.interfaces';
import { Product } from '../../interfaces/product/product';
import { getproductendpoints } from './product.endpoints';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private httpClient: HttpClient = inject(HttpClient);
  private product: WritableSignal<Product[]> = signal<Product[]>([]);

  public get $product(): Product[] {
    return this.product();
  }
  public set $product(value: Product[]) {
    this.product.set(value);
  }
  public async getProduct() {
    try {
      return await firstValueFrom(
        this.httpClient.get<SingleResponseModel<Product[]>>(
          `${environment.apiUrlSales_Date_Prediction}${getproductendpoints.getProduct}`,
          { observe: 'response' }
        )
      )
        .then((success) => {
          console.log('success: ', success);
          this.$product = success.body?.data as Product[];
        })
        .catch((err: HttpErrorResponse) => {
          console.log('err: ', err);
        });
    } catch (error: any) {}
  }
}

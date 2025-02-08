import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable, signal, WritableSignal } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { environment } from '../../../environment';
import { SingleResponseModel } from '../../../shared/utils/response.interfaces';
import { Shippers } from '../../interfaces/shippers/shippers';
import { getshipperendpoints } from './shippers.endpoint';

@Injectable({
  providedIn: 'root',
})
export class ShippersService {
  private httpClient: HttpClient = inject(HttpClient);
  private shippers: WritableSignal<Shippers[]> = signal<Shippers[]>([]);

  public get $shippers(): Shippers[] {
    return this.shippers();
  }
  public set $shippers(value: Shippers[]) {
    this.shippers.set(value);
  }

  public async getShippers() {
    try {
      return await firstValueFrom(
        this.httpClient.get<SingleResponseModel<Shippers[]>>(
          `${environment.apiUrlSales_Date_Prediction}${getshipperendpoints.getShipper}`,
          { observe: 'response' }
        )
      )
        .then((success) => {
          console.log('success: ', success);
          this.$shippers = success.body?.data as Shippers[];
        })
        .catch((err: HttpErrorResponse) => {
          console.log('err: ', err);
        });
    } catch (error: any) {}
  }
}

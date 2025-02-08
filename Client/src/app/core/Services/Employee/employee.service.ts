import { inject, Injectable, signal, WritableSignal } from '@angular/core';
import { environment } from '../../../environment';
import { getemployeeendpoints } from './employee.endpoint';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { firstValueFrom } from 'rxjs';
import { SingleResponseModel } from '../../../shared/utils/response.interfaces';
import { Employee } from '../../interfaces/employee/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private httpClient: HttpClient = inject(HttpClient);
    private employee: WritableSignal<Employee[]> = signal<Employee[]>([]);
  
    public get $employee(): Employee[]{
          return this.employee();
        }
        public set $employee(value: Employee[]){
          this.employee.set(value);
        }
      
        public async getEmployee() {
          try {
      
            return await firstValueFrom(
              this.httpClient.get<SingleResponseModel<Employee[]>>(`${environment.apiUrlSales_Date_Prediction}${getemployeeendpoints.getEmployee}`,{ observe: 'response' })
            ).then(success => {
              console.log('success: ', success);
              this.$employee = success.body?.data as Employee[]
            }).catch((err: HttpErrorResponse) => {
              console.log('err: ', err);
            })
          } catch (error: any) {}
        }
}

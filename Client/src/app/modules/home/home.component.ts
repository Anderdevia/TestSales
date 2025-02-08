import { Component, inject } from '@angular/core';
import { CustomersService } from '../../core/Services/customersService/customers.service';
import { Customers } from '../../core/interfaces/customers/customes';
import { SalesDatePredictionService } from '../../core/Services/salesDatePredictionService/sales-date-prediction.service';
import { SalesDatePrediction } from '../../core/interfaces/salesDatePrediction/salesDatePrediction';
import { OrdersService } from '../../core/Services/orders/orders.service';
import { OrdersByCustomer } from '../../core/interfaces/orders/ordersByCustomer';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../core/Services/Employee/employee.service';
import { Employee } from '../../core/interfaces/employee/employee';
import { ShippersService } from '../../core/Services/shippers/shippers.service';
import { Shippers } from '../../core/interfaces/shippers/shippers';
import { ProductService } from '../../core/Services/product/product.service';
import { Product } from '../../core/interfaces/product/product';
import { TitleStrategy } from '@angular/router';
import { MessageService } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { OrderWithProduct } from '../../core/interfaces/orders/newOrder';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  private salesDatePredictionService: SalesDatePredictionService = inject(
    SalesDatePredictionService
  );
  private customersService: CustomersService = inject(CustomersService);
  private ordersService: OrdersService = inject(OrdersService);
  private employeeService: EmployeeService = inject(EmployeeService);
  private shippersService: ShippersService = inject(ShippersService);
  private productService: ProductService = inject(ProductService);

  salesDatePrediction!: SalesDatePrediction[];
  customer!: Customers[];
  ordersByCustomer!: OrdersByCustomer[];
  allSalesData: SalesDatePrediction[] = [];
  employee!: Employee[];
  shippers!: Shippers[];
  product!: Product[];
  displayModalviewOrders: boolean = false;
  displayModalNewOrder: boolean = false;
  selectedCustomer: string | null = null;
  orderForm: FormGroup;

  constructor(private fb: FormBuilder, private messageService: MessageService) {
    this.orderForm = this.fb.group({
      custid: [null, Validators.required],
      empid: [null, Validators.required],
      orderDate: [null, Validators.required],
      requiredDate: [null, Validators.required],
      shippedDate: [null, Validators.required],
      shipperid: [null, Validators.required],
      freight: [null, Validators.required],
      shipname: [null, Validators.required],
      shipaddress: [null, Validators.required],
      shipcity: [null, Validators.required],
      shipcountry: [null, Validators.required],
      productid: [null, Validators.required],
      unitPrice: [null, Validators.required],
      qty: [null, Validators.required],
      discount: [null, Validators.required],
    });
  }

  ngOnInit() {
    this.getSalesDatePrediction();
    this.getCustomer();
    this.salesDatePrediction = [...this.allSalesData];
  }

  private getSalesDatePrediction() {
    try {
      this.salesDatePredictionService
        .getSalesDatePredictionr()
        .then((succes) => {
          this.salesDatePrediction =
            this.salesDatePredictionService.$salesDatePrediction;
        });
    } catch (error) {}
  }
  private getCustomer() {
    try {
      this.customersService.getCustomer().then((succes) => {
        this.customer = this.customersService.$customer;
      });
    } catch (error) {}
  }
  private getShippers() {
    try {
      this.shippersService.getShippers().then((succes) => {
        this.shippers = this.shippersService.$shippers;
      });
    } catch (error) {}
  }
  private getProduct() {
    try {
      this.productService.getProduct().then((succes) => {
        this.product = this.productService.$product;
      });
    } catch (error) {}
  }
  private getEmployee() {
    try {
      this.employeeService.getEmployee().then((succes) => {
        this.employee = this.employeeService.$employee;
      });
    } catch (error) {}
  }
  private getOrdersByCustomer(custid: number) {
    try {
      this.ordersService.getOrdersByCustomer(custid).then((succes) => {
        this.ordersByCustomer = this.ordersService.$ordersByCustomer;
      });
    } catch (error) {}
  }

  viewOrders(item: any): void {
    this.selectedCustomer = item.customerName;
    this.displayModalviewOrders = true;
    let custid = this.customer.find((x) => x.companyname == item.customerName);
    this.getOrdersByCustomer(custid?.custid ?? 0);
  }

  newOrder(item: any): void {
    this.selectedCustomer = item.customerName;
    this.displayModalNewOrder = true;
    this.getEmployee();
    this.getShippers();
    this.getProduct();
  }

  CloseViewOrders() {
    this.displayModalviewOrders = false;
    this.selectedCustomer = null;
  }

  onSubmit() {
    let custid = this.customer.find((x) => x.companyname == this.selectedCustomer);
    this.orderForm.get('custid')?.setValue(custid?.custid);

    if (this.customer?.length > 0 && this.selectedCustomer) {
      let custid = this.customer.find((x) => x.companyname == this.selectedCustomer);
      this.orderForm.get('custid')?.setValue(custid ? custid.custid : null);
    } else {
      console.warn("Customer list is empty or selectedCustomer is undefined");
    }


    const formValues = this.orderForm.value;
  let missingFields: string[] = [];

  if (!formValues.custid) missingFields.push("Customer");
  if (!formValues.empid) missingFields.push("Employee");
  if (!formValues.shipperid) missingFields.push("Shipper");
  if (!formValues.shipname) missingFields.push("Ship Name");
  if (!formValues.shipaddress) missingFields.push("Ship Address");
  if (!formValues.shipcity) missingFields.push("Ship City");
  if (!formValues.orderDate) missingFields.push("Order Date");
  if (!formValues.requiredDate) missingFields.push("Required Date");
  if (!formValues.freight) missingFields.push("Freight");
  if (!formValues.shipcountry) missingFields.push("Ship Country");
  if (!formValues.productid) missingFields.push("Product");
  if (!formValues.unitPrice) missingFields.push("Unit Price");
  if (!formValues.qty) missingFields.push("Quantity");
  if (formValues.discount === null || formValues.discount === undefined) missingFields.push("Discount");


  if (missingFields.length > 0) {
    this.messageService.add({
      severity: "error",
      detail: `Please fill in the following required fields: ${missingFields.join(", ")}`,
      life: 5000,
    });
    return;
  }



    if (this.orderForm.valid) {

      let discountValue = this.orderForm.value.discount;

  // Verificar si el descuento está fuera del rango permitido
  if (discountValue < 0 || discountValue > 1 || discountValue == null) {
    alert("Invalid discount! The discount must be between 0 and 1.");
    return; // Detener la ejecución si el descuento es inválido
  }


      this.ordersService
        .postNewOrderWithProduct(this.orderForm.value)
        .then((succes) => {
          succes.subscribe({
            next: (v) => {
              if (v.body?.responseCode == 200) {
                this.messageService.add({
                  severity: 'success',
                  detail: `The Order was successfully created`,
                  life: 5000,
                });
                this.orderForm.reset();
                this.CloseOrderModal();
                setTimeout(() => {
                  window.location.reload();
                }, 2000);
              } else {
                throw new Error('Error creating');
              }
            },
            error: (e) => {
              this.messageService.add({
                severity: 'error',
                detail: `There was an error creating the order`,
                life: 5000,
              });
            },
          });
        })
        .catch((err) => {});
    }
  }

  CloseOrderModal() {
    this.displayModalNewOrder = false;
    this.selectedCustomer = null;
    this.orderForm.reset();
  }
}

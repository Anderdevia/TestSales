export interface OrderWithProduct {
  orderWithProduct: NewOrderWithProduct | null;
}

export interface NewOrderWithProduct {
  custid: number;
  empid: number;
  orderdate: string;
  requireddate: string;
  shippeddate: string;
  shipperid: number;
  freight: number;
  shipname: string;
  shipaddress: string;
  shipcity: string;
  shipregion: string;
  shippostalcode: number;
  shipcountry: number;
  productid: number;
  unitprice: number;
  qty: number;
  discount: number;
}

export interface ResponseOrderWithProduct {
  isSuccessful: boolean;
  responseCode: number;
  message: string;
  responseDate: string;
  data: NewOrderWithProduct;
}

export interface Orders {
  orderid: number;
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
  shippostalcode: string;
  shipcountry: string;
}
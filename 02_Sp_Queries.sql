USE [StoreSample]
GO
IF OBJECT_ID('dbo.Sp_Queries', 'P') IS NOT NULL 
    DROP PROCEDURE dbo.Sp_Queries
GO
CREATE PROCEDURE [dbo].[Sp_Queries]
	@Option INT,
	@custid INT = 0,
    @EmpID INT = NULL,
    @ShipperID INT = NULL,
    @ShipName NVARCHAR(255) = '',
    @ShipAddress NVARCHAR(255) = '',
    @ShipCity NVARCHAR(100) = '',
    @OrderDate DATE = NULL,
    @RequiredDate DATE = NULL,
    @ShippedDate DATE = NULL,
    @Freight MONEY = 0.00,
    @ShipCountry NVARCHAR(100) = '',
    @ProductID INT = NULL,
    @UnitPrice MONEY = 0.00,
    @Qty INT = 1,
    @Discount NUMERIC(4, 3) = 0.00

AS
BEGIN

	SET NOCOUNT ON


	--======================================
	--SALES DATE PREDICTION
	--======================================
	IF @Option = 1
	BEGIN 
	WITH CTE AS (
		SELECT ord.custid,
			   ord.orderdate,
			   ISNULL(LAG(ord.orderdate) OVER (PARTITION BY ord.custid ORDER BY ord.orderdate),orderdate) AS PreviousDate
		  FROM Sales.Orders ord
		),
		Averages AS (
			SELECT custid, 
				   AVG(DATEDIFF(DAY, PreviousDate, orderdate)) AS AverageDays
			  FROM CTE
			 WHERE PreviousDate IS NOT NULL  
			 GROUP BY custid
		),
		LastOrder AS (
			SELECT custid, 
				   MAX(orderdate) AS LastDateOrder
			  FROM Sales.Orders
			 GROUP BY custid
		)
		SELECT cust.companyname AS CustomerName,
			   lo.LastDateOrder AS LastOrderDate,
			   DATEADD(DAY, avgs.AverageDays, lo.LastDateOrder)  AS NextPredictedOrder
		  FROM LastOrder lo
		 INNER JOIN Averages avgs ON lo.custid = avgs.custid
		 INNER JOIN Sales.Customers cust ON lo.custid = cust.custid
		 ORDER BY cust.companyname;  
	END
	--======================================
	--GET CLIENT ORDERS
	--======================================
	ELSE IF @Option = 2
	BEGIN 
		SELECT orderid,
		       requireddate,
			   shippeddate,
			   shipname,
			   shipaddress,
			   shipcity
		FROM Sales.Orders
		WHERE custid =  @custid
		
	END
	ELSE IF @Option = 3
	BEGIN 
		SELECT empid,
		       CONCAT(firstname,' ',lastname) AS fullName
		  FROM HR.Employees
	END
	--======================================
	--GET SHIPPERS
	--======================================
	ELSE IF @Option = 4
	BEGIN 
		SELECT shipperid,
		       companyname
		  FROM Sales.Shippers
	END
	--======================================
	--GET PRODUCTS
	--======================================
	ELSE IF @Option = 5
	BEGIN
		SELECT productid,
		       productname
		  FROM Production.Products
	END
    --======================================
	--GET CUSTOMERS
	--======================================
	ELSE IF @Option = 6
	BEGIN 
		SELECT custid,
		       companyname,
			   contactname,
			   contacttitle,
			   address,
			   city,
			   region,
			   postalcode,
			   country,
			   phone,
			   fax
		  FROM Sales.Customers
	END
	--======================================
	--GET EMPLOYEES
	--======================================
	ELSE IF @Option = 7
	BEGIN 
		  SELECT empid,	
		         concat(firstname,' ',lastname) as EmployeeName,
		         title,
		         titleofcourtesy,
		         birthdate,
		         hiredate,
		         address,
		         city,
		         region,
		         postalcode,
		         country,
		         phone,
		         mgrid
		    FROM HR.Employees
	END
	--======================================
	--GET ORDERS
	--======================================
	ELSE IF @Option = 8
	BEGIN 
		SELECT orderid,
			   custid,
			   empid,
			   orderdate,
			   requireddate,
			   shippeddate,
			   shipperid,
			   freight,
			   shipname,
			   shipaddress,
			   shipcity,
			   shipregion,
			   shippostalcode,
			   shipcountry
		  FROM Sales.Orders
		  ORDER BY custid ASC
	END
	--======================================
	--INSERT ORDERS
	--======================================
	ELSE IF @Option = 9
	BEGIN
	   	DECLARE @OrderID INT
			--
			INSERT INTO Sales.Orders
					   (custid
					   ,empid
					   ,orderdate
					   ,requireddate
					   ,shippeddate
					   ,shipperid
					   ,freight
					   ,shipname
					   ,shipaddress
					   ,shipcity
					   ,shipcountry)
				 VALUES
					   (@custid
					   ,@EmpID
					   ,@OrderDate
					   ,@RequiredDate
					   ,@ShippedDate
					   ,@ShipperID
					   ,@Freight
					   ,@ShipName
					   ,@ShipAddress
					   ,@ShipCity
					   ,@ShipCountry)

			SET @OrderID = SCOPE_IDENTITY()

			INSERT INTO Sales.OrderDetails
					   (orderid
					   ,productid
					   ,unitprice
					   ,qty
					   ,discount)
				 VALUES
					   (@OrderID
					   ,@ProductID
					   ,@UnitPrice
					   ,@Qty
					   ,@Discount)
	END
END

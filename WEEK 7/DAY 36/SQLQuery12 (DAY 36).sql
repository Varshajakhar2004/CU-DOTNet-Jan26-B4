-- 1. Product Names with Category Names
SELECT p.ProductName, c.CategoryName
FROM Products p
INNER JOIN Categories c
    ON p.CategoryID = c.CategoryID;


-- 2. Order ID with Customer Company Name
SELECT o.OrderID, c.CompanyName
FROM Orders o
INNER JOIN Customers c
    ON o.CustomerID = c.CustomerID;


-- 3. Product Names with Supplier Company Name
SELECT p.ProductName, s.CompanyName
FROM Products p
INNER JOIN Suppliers s
    ON p.SupplierID = s.SupplierID;


-- 4. Orders with Employee Name
SELECT o.OrderID, o.OrderDate, e.FirstName, e.LastName
FROM Orders o
INNER JOIN Employees e
    ON o.EmployeeID = e.EmployeeID;


-- 5. Orders shipped to France with Shipper Name
SELECT o.OrderID, s.CompanyName AS ShipperName
FROM Orders o
INNER JOIN Shippers s
    ON o.ShipVia = s.ShipperID
WHERE o.ShipCountry = 'France';

-- 6. Category total units in stock
SELECT c.CategoryName, SUM(p.UnitsInStock) AS TotalUnits
FROM Products p
INNER JOIN Categories c
    ON p.CategoryID = c.CategoryID
GROUP BY c.CategoryName;


-- 7. Customer total spend
SELECT c.CompanyName,
       SUM(od.UnitPrice * od.Quantity) AS TotalSpent
FROM Customers c
INNER JOIN Orders o
    ON c.CustomerID = o.CustomerID
INNER JOIN [Order Details] od
    ON o.OrderID = od.OrderID
GROUP BY c.CompanyName;


-- 8. Employee total orders taken
SELECT e.LastName, COUNT(o.OrderID) AS TotalOrders
FROM Employees e
INNER JOIN Orders o
    ON e.EmployeeID = o.EmployeeID
GROUP BY e.LastName;


-- 9. Total Freight per Shipper
SELECT s.CompanyName,
       SUM(o.Freight) AS TotalFreight
FROM Shippers s
INNER JOIN Orders o
    ON s.ShipperID = o.ShipVia
GROUP BY s.CompanyName;


-- 10. Top 5 Products by Quantity Sold
SELECT TOP 5 p.ProductName,
       SUM(od.Quantity) AS TotalSold
FROM Products p
INNER JOIN [Order Details] od
    ON p.ProductID = od.ProductID
GROUP BY p.ProductName
ORDER BY TotalSold DESC;

-- 11. Products above average price
SELECT ProductName
FROM Products
WHERE UnitPrice > (
    SELECT AVG(UnitPrice)
    FROM Products
);


-- 12. Employee and their Manager (Self Join)
SELECT e.FirstName + ' ' + e.LastName AS Employee,
       m.FirstName + ' ' + m.LastName AS Manager
FROM Employees e
LEFT JOIN Employees m
    ON e.ReportsTo = m.EmployeeID;


-- 13. Customers with no orders
SELECT CompanyName
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
);


-- 14. Orders above average order value
SELECT o.OrderID
FROM Orders o
JOIN [Order Details] od
    ON o.OrderID = od.OrderID
GROUP BY o.OrderID
HAVING SUM(od.UnitPrice * od.Quantity) >
(
    SELECT AVG(OrderTotal)
    FROM (
        SELECT SUM(UnitPrice * Quantity) AS OrderTotal
        FROM [Order Details]
        GROUP BY OrderID
    ) AS OrderTotals
);


-- 15. Products never ordered after 1997
SELECT p.ProductName
FROM Products p
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    JOIN [Order Details] od
        ON o.OrderID = od.OrderID
    WHERE od.ProductID = p.ProductID
      AND YEAR(o.OrderDate) > 1997
);

-- 16. Employees and Regions they cover
SELECT e.FirstName, e.LastName, r.RegionDescription
FROM Employees e
JOIN EmployeeTerritories et
    ON e.EmployeeID = et.EmployeeID
JOIN Territories t
    ON et.TerritoryID = t.TerritoryID
JOIN Region r
    ON t.RegionID = r.RegionID;


-- 17. Customers and Suppliers in same city
SELECT c.CompanyName AS Customer,
       s.CompanyName AS Supplier,
       c.City
FROM Customers c
JOIN Suppliers s
    ON c.City = s.City;


-- 18. Customers purchasing from more than 3 categories
SELECT c.CompanyName
FROM Customers c
JOIN Orders o
    ON c.CustomerID = o.CustomerID
JOIN [Order Details] od
    ON o.OrderID = od.OrderID
JOIN Products p
    ON od.ProductID = p.ProductID
GROUP BY c.CompanyName
HAVING COUNT(DISTINCT p.CategoryID) > 3;


-- 19. Revenue from discontinued products
SELECT SUM(od.UnitPrice * od.Quantity) AS DiscontinuedRevenue
FROM Products p
JOIN [Order Details] od
    ON p.ProductID = od.ProductID
WHERE p.Discontinued = 1;


-- 20. Most expensive product per category (Correlated Subquery)
SELECT p.CategoryID, p.ProductName, p.UnitPrice
FROM Products p
WHERE p.UnitPrice =
(
    SELECT MAX(UnitPrice)
    FROM Products
    WHERE CategoryID = p.CategoryID
);


-- ADDRESS CONFIGURATION

--SELECT COLUMN_NAME, IS_NULLABLE
--FROM INFORMATION_SCHEMA.COLUMNS
--WHERE TABLE_NAME = 'Orders';

--SELECT *
--FROM Orders
--WHERE Address IS NULL; 

--ALTER TABLE Orders
--ADD CONSTRAINT DF_Orders_Address DEFAULT 'Sin dirección' FOR Address;


--UPDATE Orders
--SET Address = 'Sin dirección'
--WHERE Address IS NULL;

--------------------------------------------------------------------------------

--	OrderDetails CONFIG

-- Ejemplo de cómo agregar una columna
ALTER TABLE OrderDetails ADD Id INT IDENTITY(1,1) PRIMARY KEY;

SELECT *
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME = 'Orders';

DROP TABLE Orders;

DROP TABLE OrderDetails; -- o cualquier otra tabla relacionada


-- IDENTIFICADOR DE LLAVE FORANEA
SELECT
    fk.name AS ForeignKey,
    tp.name AS ParentTable,
    cp.name AS ParentColumn,
    tr.name AS ReferencedTable,
    cr.name AS ReferencedColumn
FROM
    sys.foreign_keys AS fk
INNER JOIN
    sys.foreign_key_columns AS fkc ON fk.object_id = fkc.constraint_object_id
INNER JOIN
    sys.tables AS tp ON fkc.parent_object_id = tp.object_id
INNER JOIN
    sys.columns AS cp ON fkc.parent_object_id = cp.object_id AND fkc.parent_column_id = cp.column_id
INNER JOIN
    sys.tables AS tr ON fkc.referenced_object_id = tr.object_id
INNER JOIN
    sys.columns AS cr ON fkc.referenced_object_id = cr.object_id AND fkc.referenced_column_id = cr.column_id
WHERE
    tr.name = 'Orders';

--ALTER TABLE OrderDetails
--DROP CONSTRAINT FK__OrderDeta__IdOrd__4BAC3F29;

select * from  dbo.Orders

SELECT COUNT(*) 
FROM Orders 
WHERE Id = IdOrder;

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY,
    ProductIds NVARCHAR(100), -- Para almacenar los IDs de productos, separados por comas
    Quantities NVARCHAR(100) -- Para almacenar las cantidades correspondientes, separadas por comas
);

select * from products

drop table Orders;
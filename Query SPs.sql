/*
Create Procedure spListarArticulos As
Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.Precio
From ARTICULOS A Left Join CATEGORIAS C on A.IdCategoria = C.Id Left Join MARCAS M on A.IdMarca = M.Id
*/

--PRUEBAS
SELECT * FROM ARTICULOS

SELECT * FROM IMAGENES

SELECT * FROM Clientes

SELECT * FROM Vouchers

INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)
VALUES ('41550873', 'Santiago', 'Giussani', 'santi.giussani@gmail.com', 'Miguel Cane 2355', 'San Fernando', 1646)

SELECT Documento FROM Clientes WHERE Documento = 32333222

INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)
VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @Cp)
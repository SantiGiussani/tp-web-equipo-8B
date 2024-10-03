/*
Create Procedure spListarArticulos As
Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.Precio
From ARTICULOS A Left Join CATEGORIAS C on A.IdCategoria = C.Id Left Join MARCAS M on A.IdMarca = M.Id
*/


using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TiendaApi.Conexion;
using TiendaApi.Models;

namespace TiendaApi.Data
{
    public class ProductsData
    {
        ConexionDB cn = new ConexionDB();

        // Show
        public async Task <List<ProductsModel>> ShowProducts()
        {   
            var list = new List<ProductsModel>();
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("showProducts", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType= CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync())
                        {
                            var productModel = new ProductsModel();
                            productModel.id = (int)item["id"];
                            productModel.price = (decimal)item["price"];
                            productModel.description = (string)item["description"];
                            list.Add(productModel);
                        }
                    }
                }
            }
            return list;

        }

        //Insert
        public async Task InsertProducts(ProductsModel paramss)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertProducts", sql))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@description", paramss.description);
                    cmd.Parameters.AddWithValue("@price", paramss.price);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Edit
        public async Task EditProducts(ProductsModel paramss)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("editProducts", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", paramss.id);
                    cmd.Parameters.AddWithValue("@price", paramss.price);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // Delete
        public async Task DeleteProducts(ProductsModel paramss)
        {
            using (var sql = new SqlConnection(cn.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("deleteProducts", sql))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", paramss.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

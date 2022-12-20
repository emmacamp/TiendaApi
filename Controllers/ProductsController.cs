using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using TiendaApi.Data;
using TiendaApi.Models;

namespace TiendaApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController:ControllerBase   
    {
        // Read
        [HttpGet]
        public async Task<ActionResult<List<ProductsModel>>> Get()
        {
            var function = new ProductsData();
            var list = await function.ShowProducts();
            return list;
        }

        // Create
        [HttpPost]
        public async Task Post([FromBody] ProductsModel paramss)
        {
            var function = new ProductsData();
            await function.InsertProducts(paramss);
        }

        // Edit
        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] ProductsModel paramss)
        {
            var function = new ProductsData();
            paramss.id= id;
            await function.EditProducts(paramss);
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var function = new ProductsData();
            var paramss = new ProductsModel();
            paramss.id=id;
            await function.DeleteProducts(paramss);
            return NoContent();
        }


    }

}

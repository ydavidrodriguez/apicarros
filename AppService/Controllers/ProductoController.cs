using Data.Interface;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto ProductoService;

        public ProductoController(IProducto Product)
        {
            ProductoService = Product;
        }

        [HttpGet]
        [Route("Listproduct")]
        public List<MProducto> Listproduct()
        {
            try
            {
                var Response = ProductoService.Listproduct();

                if (Response == null)
                    throw new Exception();

                return Response;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("CreateShop")]
        public bool CreateShop(MMovimientoS mMovimiento)
        {
            try
            {
                var Response = ProductoService.CreateShop(mMovimiento);

                if (Response == null)
                    throw new Exception();

                return Response;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}

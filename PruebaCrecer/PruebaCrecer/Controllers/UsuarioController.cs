using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Servicios;
using AccesoDatos.Models;

namespace PruebaCrecer.Controllers
{
    [ApiController]
    [Route("APIUsuarios")]
    public class UsuarioController : Controller
    {
        ServiciosUsuario Service = new ServiciosUsuario();
        List<Afiliado> lAfiliado = new List<Afiliado>();

        [HttpGet]
        [Route("ObtenerDatos")]
        public dynamic GetData()
        {
            lAfiliado = Service.LlenarDatos();
            return lAfiliado;
        }

        [HttpGet]
        [Route("AñadirDatos")]
        public dynamic AddData(string NUP, string Nombres, string Apellidos, int Edad, string NIT, string DUI)
        {
            var message = Service.ADatos(NUP, Nombres, Apellidos, Edad, NIT, DUI);
            return message;
        }
    }
}

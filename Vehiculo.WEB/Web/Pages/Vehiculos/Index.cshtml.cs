using System.Text.Json;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Web.Pages.Vehiculos
{
    public class IndexModel : PageModel
    {
        public IList<VehiculoResponse> vehiculos { get; set; } = default!;
        private readonly IConfiguracion _configuracion;
        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerVehiculos");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, endpoint);

            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            vehiculos = JsonSerializer.Deserialize<List<VehiculoResponse>>(resultado, opciones);
        }
    }
}

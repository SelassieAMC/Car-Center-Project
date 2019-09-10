using System.Collections.Generic;
using System.Threading.Tasks;
using car_center_project.Core.Models;

namespace car_center_project.Core
{
    public interface IMecanicosRepository
    {
        Task<IEnumerable<Mecanicos>> ObtenerMecanicosAsync();
        Task<Mecanicos> ObtenerMecanicoByDocTipoDoc(int doc,string tipoDoc);
        Task<Mecanicos> CrearMecanicoByModelAsync(Mecanicos mecanico);
        Task<Mecanicos> ActualizarMecanicoByModel(Mecanicos mecanico);
        Task EliminarMecanicoByDocTipoDocAsync(int doc, string tipoDoc);
    }
}
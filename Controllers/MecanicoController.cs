using System.Threading.Tasks;
using car_center_project.Core;
using car_center_project.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_center_project.Controllers {
    [Route ("/api/mecanicos/")]
    public class MecanicoController : Controller {
        private readonly IMecanicosRepository repository;
        public MecanicoController (IMecanicosRepository repository) {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerMecanicos () {
            return Ok(await this.repository.ObtenerMecanicosAsync());
        }
        [HttpGet("getmecanico/{doc}/{tipoDoc}")]
        public async Task<IActionResult> obtenerMecanicoByDocTipoDoc (int doc, string tipoDoc) {
            var mecanico = await this.repository.ObtenerMecanicoByDocTipoDoc(doc,tipoDoc);
            if(mecanico==null)
                return NotFound();
            return Ok(mecanico);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarMecanicoAsync ([FromBody] Mecanicos mecanico) {
            var result= new Mecanicos();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var mecanicoObj = await this.repository.ObtenerMecanicoByDocTipoDoc(mecanico.Documento,mecanico.TipoDocumento);
            if(mecanicoObj==null){
                result = await this.repository.CrearMecanicoByModelAsync(mecanico);
                if(result==null)
                    return BadRequest();
            }else{
                result = await this.repository.ActualizarMecanicoByModel(mecanico);
                if(result==null)
                    return BadRequest();
            }
            return Ok(result);      
        }
        [HttpDelete("{doc}/{tipoDoc}")]
        public async Task<IActionResult> EliminarMecanico (int doc, string tipoDoc) {
            await this.repository.EliminarMecanicoByDocTipoDocAsync(doc,tipoDoc);
            return Ok();
        }
    }
}
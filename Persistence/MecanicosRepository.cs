using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using car_center_project.Core;
using car_center_project.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace car_center_project.Persistence {
    public class MecanicosRepository : IMecanicosRepository {
        private readonly Test_CCenterContext context;
        public MecanicosRepository (Test_CCenterContext context) {
            this.context = context;
        }
        public async Task<Mecanicos> ActualizarMecanicoByModel (Mecanicos mecanico) {
            var parameters = new SqlParameter[]{ 
                new SqlParameter("@tipo_documento",mecanico.TipoDocumento),
                new SqlParameter("@documento",mecanico.Documento),
                new SqlParameter("@primer_nombre",mecanico.PrimerNombre),
                new SqlParameter("@segundo_nombre", (object) mecanico.SegundoNombre ?? DBNull.Value),
                new SqlParameter("@primer_apellido",mecanico.PrimerApellido),
                new SqlParameter("@segundo_apellido",(object)mecanico.SegundoApellido?? DBNull.Value),
                new SqlParameter("@celular",(object)mecanico.Celular?? DBNull.Value),
                new SqlParameter("@direccion",(object)mecanico.Direccion?? DBNull.Value),
                new SqlParameter("@email",(object)mecanico.Email?? DBNull.Value),
                new SqlParameter("@estado",mecanico.Estado)};

                var dato = await this.context.Database.ExecuteSqlCommandAsync(@"ActualizarMecanico 
                @tipo_documento,@documento,@primer_nombre,@segundo_nombre,@primer_apellido,@segundo_apellido,@celular,
                @direccion,@email,@estado", parameters);

                return mecanico;
        }

        public async Task<Mecanicos> CrearMecanicoByModelAsync(Mecanicos mecanico) {
            try
            {
                var parameters = new SqlParameter[]{ 
                new SqlParameter("@tipo_documento",mecanico.TipoDocumento),
                new SqlParameter("@documento",mecanico.Documento),
                new SqlParameter("@primer_nombre",mecanico.PrimerNombre),
                new SqlParameter("@segundo_nombre", (object) mecanico.SegundoNombre ?? DBNull.Value),
                new SqlParameter("@primer_apellido",mecanico.PrimerApellido),
                new SqlParameter("@segundo_apellido",(object)mecanico.SegundoApellido?? DBNull.Value),
                new SqlParameter("@celular",(object)mecanico.Celular?? DBNull.Value),
                new SqlParameter("@direccion",(object)mecanico.Direccion?? DBNull.Value),
                new SqlParameter("@email",(object)mecanico.Email?? DBNull.Value),
                new SqlParameter("@estado",mecanico.Estado)};

                var dato = await this.context.Database.ExecuteSqlCommandAsync(@"CrearMecanico 
                @tipo_documento,@documento,@primer_nombre,@segundo_nombre,@primer_apellido,@segundo_apellido,@celular,
                @direccion,@email,@estado", parameters);

                return mecanico;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task EliminarMecanicoByDocTipoDocAsync (int doc,string tipoDoc) {
            var parameters = new SqlParameter[]{ 
                new SqlParameter("@tipo_documento",tipoDoc),
                new SqlParameter("@documento",doc)};
            var dato = await this.context.Database.ExecuteSqlCommandAsync(@"BorrarMecanico 
                @tipo_documento,@documento", parameters);
        }

        public async Task<Mecanicos> ObtenerMecanicoByDocTipoDoc (int doc, string tipoDoc) {
            try
            {
                return await this.context.Mecanicos.FindAsync(tipoDoc,doc);
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async  Task<IEnumerable<Mecanicos>> ObtenerMecanicosAsync() {
            return await this.context.Mecanicos.ToListAsync();
        }
    }
}
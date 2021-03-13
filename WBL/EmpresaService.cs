using DataAccess;
using Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{

    public interface IEmpresaService : IDisposable
    {
        List<EmpresaEntity> ObtenerLista(int? IdEmpresa);

        List<EmpresaEntity> Obtenerddl();
        DBEntity Insertar(EmpresaEntity entity);
        DBEntity Actualizar(EmpresaEntity entity);
        DBEntity Eliminar(EmpresaEntity entity);
    }
    public class EmpresaService: IEmpresaService
    {
        public IBD sql = new BD("Conn");

        public void Dispose()
        {
            sql = null;
        }

        public List<EmpresaEntity> ObtenerLista(int? IdEmpresa)
        {
            try
            {
                var result = sql.Query<EmpresaEntity>("EmpresasObtener", new{ IdEmpresa
                });
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        
        }

        public List<EmpresaEntity> Obtenerddl()
        {
            try
            {
                var result = sql.Query<EmpresaEntity>("EmpresaLista");
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }





        public DBEntity Insertar(EmpresaEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("EmpresaInsertar", new
                {
                    NombreEmpresa = entity.NombreEmpresa,
                    entity.Estado

                }) ;

                return result;

            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

        public DBEntity Actualizar(EmpresaEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("EmpresaActualizar", new
                {
                    entity.IdEmpresa,
                    entity.NombreEmpresa,
                    entity.Estado

                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        public DBEntity Eliminar(EmpresaEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("EmpresaEliminar", new
                {
                    entity.IdEmpresa


                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

    }
}

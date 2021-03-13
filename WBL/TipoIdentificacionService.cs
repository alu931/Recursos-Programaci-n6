using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITipoIdentificacionService : IDisposable
    {
        List<TipoIdentificacionEntity> ObtenerLista(int? IdTipoIdentificacion);

        List<TipoIdentificacionEntity> Obtenerddl();
        DBEntity Insertar(TipoIdentificacionEntity entity);
        DBEntity Actualizar(TipoIdentificacionEntity entity);
        DBEntity Eliminar(TipoIdentificacionEntity entity);

    }
    public class TipoIdentificacionService : ITipoIdentificacionService
    {
        public IBD sql = new BD("Conn");
        public void Dispose()
        {
            sql = null;
        }


        public List<TipoIdentificacionEntity> ObtenerLista(int? IdTipoIdentificacion)
        {
            try
            {
                var result = sql.Query<TipoIdentificacionEntity>("TiposIdentificacionObtener", new
                {
                    IdTipoIdentificacion
                });
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<TipoIdentificacionEntity> Obtenerddl()
        {
            try
            {
                var result = sql.Query<TipoIdentificacionEntity>("TipoIdentificacionLista");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public DBEntity Insertar(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("TiposIdentificacionInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado

                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        public DBEntity Actualizar(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("TipoIdentificacionActualizar", new
                {
                    entity.IdTipoIdentificacion,
                    entity.Descripcion,
                    entity.Estado

                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        public DBEntity Eliminar(TipoIdentificacionEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("TipoIdentificacionEliminar", new
                {
                    entity.IdTipoIdentificacion


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

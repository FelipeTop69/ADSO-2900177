using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Entity.Context.ApplicationDbContext;

namespace Data
{
    ///<summary>
    ///Repositorio encargador de la gestion de la entidad Rol en la base de datos
    ///</summary>
    public  class RolData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        ///<summary>
        ///Constructor que recibe el contexto de la base de datos
        ///</summary>
        ///<param name="context">Instancia de <see cref="ApplicationDbContext"/> Para la conexion con la base de datos.</param>
        public RolData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        ///<summary>
        ///Obtiene todos los Rol almacenados en la base de datos SQL
        ///</summary>
        ///<returns>Lista de roles</returns>
        public async Task<IEnumerable<Rol>> GetAllAsyncSQL()
        {
            String query = @"SELECT * FROM Rol";
            return (IEnumerable<Rol>) await _context.QueryAsync<IEnumerable<Rol>>(query);
            //return await _context.Set<Rol>().ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los Roles almacenados en la base de datos LINQ
        /// </summary>
        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await _context.Set<Rol>().ToListAsync();
        }




        ///<summary>
        ///Obtiene un Rol especifico por su identificacion SQL
        ///</summary> 
        public async Task<Rol?> GetByIdAsyncSQL(int id)
        {
            try
            {
                String query = @"SELECT * FROM Rol WHERE Id = @Id";
                return await _context.QueryFirstOrDefaultAsync<Rol>(query, new { Id = id });
                //return await _context.Set<Rol>().FindAsync(id);
            }
            catch (Exception ex) 
            { 
                _logger.LogError(ex, $"Error al obtener rol con ID {id}");
                throw; ///Re-lanza la exepcion para que sea manejada en capas superiores
            }
        }

        /// <summary>
        /// Obtiene un Rol específico por su identificación LINQ
        /// </summary>
        public async Task<Rol?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Rol>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un Rol con ID {RolId}", id);
                throw;
            }
        }




        ///<summary>
        ///Crear un nuevo Rol en la base de datos SQL
        ///</summary>
        ///<param name="rol">Instancia del rol al crear</param>
        ///<returns>El rol creado</returns>
        public async Task<Rol> CreateAsyncSQL(Rol rol)
        {
            try
            {
                string query = @"
                    INSERT INTO Rol (Name, Active, Description) 
                    VALUES (@Name, @Active, @Description);
                    SELECT CAST(SCOPE_IDENTITY() as int);"; 

                int newId = await _context.QuerySingleAsync<int>(query, new
                {
                    rol.Name,
                    rol.Active,
                    rol.Description
                });

                rol.Id = newId; 
                return rol; 

                //await _context.Set<Rol>().AddAsync(rol);
                //await _context.SaveChangesAsync();
                //return rol;
            }
            catch (Exception ex) {
                _logger.LogError($"Error al crear el rol: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo Rol en la base de datos LINQ
        /// </summary>
        public async Task<Rol> CreateAsync(Rol rol)
        {
            try
            {
                await _context.Set<Rol>().AddAsync(rol);
                await _context.SaveChangesAsync();
                return rol;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el Rol: {ex.Message}");
                throw;
            }
        }




        /// <summary>
        /// Actualiza un Rol existente en la base de datos SQL
        /// </summary>
        /// <param name="rol">Objeto con la información actualizada.</param>
        /// <returns>True si la o eración fue exitosa, False en caso contrario.</returns>
        public async Task<bool> UpdateAsyncSQL(Rol rol)
        {
            try
            {
                var query = @"
                    UPDATE Rol 
                    SET Name = @Name, Active = @Active, Description = @Description
                    WHERE Id = @Id;
            
                    SELECT CAST(@@ROWCOUNT AS int);"; 

                int rowsAffected = await _context.QueryFirstOrDefaultAsync<int>(query, new
                {
                    rol.Id,
                    rol.Name,
                    rol.Active,
                    rol.Description
                });

                return rowsAffected > 0;

                //_context.Set<Rol>().Update(rol);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Error al actualizar el rol : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un Rol existente en la base de datos LINQ
        /// </summary>
        public async Task<bool> UpdateAsync(Rol rol)
        {
            try
            {
                _context.Set<Rol>().Update(rol);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el Rol: {ex.Message}");
                return false;
            }
        }




        /// <summary>
        /// Elimina un Rol de la base de datos SQL
        /// </summary>
        /// <param name="id">Identificador unico del rol a eliminar </param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario.
        public async Task<bool> DeleteAsyncSQL(int id)
        {
            try
            {
                var query = @"
                    DELETE FROM Rol WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);"; 

                int rowsAffected = await _context.QueryFirstOrDefaultAsync<int>(query, new { Id = id });

                return rowsAffected > 0; 

                //var rol = await _context.Set<Rol>().FindAsync(id);
                //if (rol == null)
                //    return false;
                //_context.Set<Rol>().Remove(rol);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el rol {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un Rol de la base de datos LINQ
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var rol = await _context.Set<Rol>().FindAsync(id);
                if (rol == null)
                    return false;

                _context.Set<Rol>().Remove(rol);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el Rol: {ex.Message}");
                return false;
            }
        }



    }
}

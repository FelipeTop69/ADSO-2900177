using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class ModuleData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ModuleData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los Module almacenados en la base de datos SQL
        /// </summary>
        public async Task<IEnumerable<Module>> GetAllAsyncSQL()
        {
            String query = @"SELECT * FROM Module";
            return (IEnumerable<Module>) await _context.QueryAsync<IEnumerable<Module>>(query);
            //return await _context.Set<Module>().ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los Module almacenados en la base de datos LINQ
        /// </summary>
        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            return await _context.Set<Module>().ToListAsync();
        }




        /// <summary>
        /// Obtiene un Module especifico por su identificacion SQL
        /// </summary
        public async Task<Module?> GetByIdAsyncSQL(int id)
        {
            try
            {
                String query = @"SELECT * FROM Module WHERE Id = @Id";
                return await _context.QueryFirstOrDefaultAsync<Module>(query, new { Id = id });
                //return await _context.Set<Module>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el modulo con ID {ModuleId}", id);
                throw;
            }

        }

        /// <summary>
        /// Obtiene un Module específico por su identificación LINQ
        /// </summary>
        public async Task<Module?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Module>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un Module con ID {ModuleId}", id);
                throw;
            }
        }




        /// <summary>
        /// Crear un nuevo Module en la base de datos SQL
        /// </summary>
        public async Task<Module> CreateAsyncSQL(Module module)
        {
            try
            {
                string query = @"
                    INSERT INTO Module (Name, Description) 
                    VALUES (@Name, @Description);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

                int newId = await _context.QuerySingleAsync<int>(query, new
                {
                    module.Name,
                    module.Description
                });

                module.Id = newId;
                return module;

                //await _context.Set<Module>().AddAsync(module);
                //await _context.SaveChangesAsync();
                //return module;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el modulo: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo Module en la base de datos LINQ
        /// </summary>
        public async Task<Module> CreateAsync(Module module)
        {
            try
            {
                await _context.Set<Module>().AddAsync(module);
                await _context.SaveChangesAsync();
                return module;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el Module: {ex.Message}");
                throw;
            }
        }




        /// <summary>
        /// Actualiza un Module existente en la base de datos SQL
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(Module module)
        {
            try
            {
                var query = @"
                    UPDATE Module 
                    SET Name = @Name, Description = @Description
                    WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new
                {
                    module.Id,
                    module.Name,
                    module.Description
                });

                return rowsAffected > 0;

                //_context.Set<Module>().Update(module);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el modulo : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un Module existente en la base de datos LINQ
        /// </summary>
        public async Task<bool> UpdateAsync(Module module)
        {
            try
            {
                _context.Set<Module>().Update(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el Module: {ex.Message}");
                return false;
            }
        }




        /// <summary>
        /// Elimina un Module de la base de datos SQL
        /// </summary>
        public async Task<bool> DeleteAsyncSQL(int id)
        {
            try
            {
                var query = @"
                    DELETE FROM Module WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new { Id = id });

                return rowsAffected > 0;

                //var module = await _context.Set<Module>().FindAsync(id);
                //if (module == null)
                //    return false;
                //_context.Set<Module>().Remove(module);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el modulo {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un Module de la base de datos LINQ
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var module = await _context.Set<Module>().FindAsync(id);
                if (module == null)
                    return false;

                _context.Set<Module>().Remove(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el Module: {ex.Message}");
                return false;
            }
        }



    }
}

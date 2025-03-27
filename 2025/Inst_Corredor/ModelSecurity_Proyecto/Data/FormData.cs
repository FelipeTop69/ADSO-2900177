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
    public class FormData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public FormData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los FormData almacenados en la base de datos SQL
        /// </summary>
        public async Task<IEnumerable<Form>> GetAllAsyncSQL()
        {
            String query = @"SELECT * FROM FormData";
            return (IEnumerable<Form>)await _context.QueryAsync<IEnumerable<Form>>(query);

            //return await _context.Set<Form>().ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los Form almacenados en la base de datos LINQ
        /// </summary>
        public async Task<IEnumerable<Form>> GetAllAsync()
        {
            return await _context.Set<Form>().ToListAsync();
        }




        /// <summary>
        /// Obtiene un FormData especifico por su identificacion SQL
        /// </summary
        public async Task<Form?> GetByIdAsyncSQL(int id)
        {
            try
            {
                String query = @"SELECT * FROM FormData WHERE Id = @Id";
                return await _context.QueryFirstOrDefaultAsync<Form>(query, new { Id = id });

                //return await _context.Set<Form>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el formulario con ID {FormId}", id);
                throw;
            }

        }

        /// <summary>
        /// Obtiene un Form específico por su identificación LINQ
        /// </summary>
        public async Task<Form?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Form>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un Form con ID {FormId}", id);
                throw;
            }
        }




        /// <summary>
        /// Crear un nuevo FormData en la base de datos SQL
        /// </summary>
        public async Task<Form> CreateAsyncSQL(Form form)
        {
            try
            {
                string query = @"
                    INSERT INTO Form (Name, Description) 
                    VALUES (@Name, @Description);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

                int newId = await _context.QuerySingleAsync<int>(query, new
                {
                    form.Name,
                    form.Description
                });

                form.Id = newId;
                return form;

                //await _context.Set<Form>().AddAsync(form);
                //await _context.SaveChangesAsync();
                //return form;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el formulario: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo Form en la base de datos LINQ
        /// </summary>
        public async Task<Form> CreateAsync(Form form)
        {
            try
            {
                await _context.Set<Form>().AddAsync(form);
                await _context.SaveChangesAsync();
                return form;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el Form: {ex.Message}");
                throw;
            }
        }




        /// <summary>
        /// Actualiza un FormData existente en la base de datos SQL
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(Form form)
        {
            try
            {
                var query = @"
                    UPDATE Form 
                    SET Name = @Name, Description = @Description
                    WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new
                {
                    form.Id,
                    form.Name,
                    form.Description
                });

                return rowsAffected > 0;

                //_context.Set<Form>().Update(form);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el formulario : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un Form existente en la base de datos LINQ
        /// </summary>
        public async Task<bool> UpdateAsync(Form form)
        {
            try
            {
                _context.Set<Form>().Update(form);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el Form: {ex.Message}");
                return false;
            }
        }




        /// <summary>
        /// Elimina un FormData de la base de datos SQL
        /// </summary>
        public async Task<bool> DeleteAsyncSQL(int id)
        {
            try
            {
                var query = @"
                    DELETE FROM Form WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new { Id = id });

                return rowsAffected > 0;

                //var form = await _context.Set<Form>().FindAsync(id);
                //if (form == null)
                //    return false;
                //_context.Set<Form>().Remove(form);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el formulario {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un Form de la base de datos LINQ
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var form = await _context.Set<Form>().FindAsync(id);
                if (form == null)
                    return false;

                _context.Set<Form>().Remove(form);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el Form: {ex.Message}");
                return false;
            }
        }
    }
}

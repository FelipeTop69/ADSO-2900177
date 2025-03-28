﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Entity.DTOs;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class FormModuleData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public FormModuleData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los FormModule almacenados en la base de datos SQL
        /// </summary>
        public async Task<IEnumerable<FormModule>> GetAllAsyncSQL()
        {
            string query = @"
                SELECT 
                    fm.Id, 
                    fm.FormId, 
                    f.Name as FormName, 
                    fm.ModuleId, 
                    m.Name as ModuleName
                FROM FormModule fm
                INNER JOIN Form f 
                ON fm.FormId = f.Id
                INNER JOIN Module m 
                ON fm.ModuleId = m.Id";

            return (IEnumerable<FormModule>) await _context.QueryAsync<IEnumerable<FormModule>>(query);
            //return await _context.Set<FormModule>().ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los FormModule almacenados en la base de datos LINQ
        /// </summary>
        public async Task<IEnumerable<FormModule>> GetAllAsync()
        {
            return await _context.Set<FormModule>().ToListAsync();
        }



        /// <summary>
        /// Obtiene un FormModule especifico por su identificacion SQL
        /// </summary
        public async Task<FormModule?> GetByIdAsyncSQL(int id)
        {
            try
            {
                string query = @"
                    SELECT 
                        fm.Id, 
                        fm.FormId, 
                        f.Name as FormName, 
                        fm.ModuleId, 
                        m.Name as ModuleName
                    FROM FormModule fm
                    INNER JOIN Form f 
                    ON fm.FormId = f.Id
                    INNER JOIN Module m 
                    ON fm.ModuleId = m.Id
                    WHERE fm.Id = @Id";

                return await _context.QueryFirstOrDefaultAsync<FormModule>(query, new { Id = id });
                //return await _context.Set<FormModule>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el FormModule con ID {id}");
                throw;
            }

        }

        /// <summary>
        /// Obtiene un FormModule específico por su identificación LINQ
        /// </summary>
        public async Task<FormModule?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<FormModule>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un FormModule con ID {FormModuleId}", id);
                throw;
            }
        }



        /// <summary>
        /// Crear un nuevo FormModule en la base de datos SQL
        /// </summary>
        public async Task<FormModule> CreateAsyncSQL(FormModule formModule)
        {
            try
            {
                string query = @"
                    INSERT INTO FormModule (FormId, ModuleId) 
                    VALUES (@FormId, @ModuleId);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

                int newId = await _context.QuerySingleAsync<int>(query, new
                {
                    formModule.FormId,
                    formModule.ModuleId
                });

                formModule.Id = newId;
                return formModule;

                //await _context.Set<FormModule>().AddAsync(formModule);
                //await _context.SaveChangesAsync();
                //return formModule;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el FormModule: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo FormModule en la base de datos LINQ
        /// </summary>
        public async Task<FormModule> CreateAsync(FormModule formModule)
        {
            try
            {
                await _context.Set<FormModule>().AddAsync(formModule);
                await _context.SaveChangesAsync();
                return formModule;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el FormModule: {ex.Message}");
                throw;
            }
        }



        /// <summary>
        /// Actualiza un FormModule existente en la base de datos SQL
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(FormModule formModule)
        {
            try
            {
                string query = @"
                    UPDATE FormModule 
                    SET FormId = @FormId, ModuleId = @ModuleId
                    WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new
                {
                    formModule.Id,
                    formModule.FormId,
                    formModule.ModuleId
                });

                return rowsAffected > 0;

                //_context.Set<FormModule>().Update(formModule);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el FormModule : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un FormModule existente en la base de datos LINQ
        /// </summary>
        public async Task<bool> UpdateAsync(FormModule formModule)
        {
            try
            {
                _context.Set<FormModule>().Update(formModule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el FormModule: {ex.Message}");
                return false;
            }
        }



        /// <summary>
        /// Elimina un FormModule de la base de datos SQL
        /// </summary>
        public async Task<bool> DeleteAsyncSQL(int id)
        {
            try
            {
                string query = @"
                    DELETE FROM FormModule WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new { Id = id });

                return rowsAffected > 0;

                //var formModule = await _context.Set<FormModule>().FindAsync(id);
                //if (formModule == null)
                //    return false;
                //_context.Set<FormModule>().Remove(formModule);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el FormModule {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un FormModule de la base de datos LINQ
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var formModule = await _context.Set<FormModule>().FindAsync(id);
                if (formModule == null)
                    return false;

                _context.Set<FormModule>().Remove(formModule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el FormModule: {ex.Message}");
                return false;
            }
        }
    }
}

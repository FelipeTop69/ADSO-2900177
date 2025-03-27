using System;
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

        public async Task<IEnumerable<FormModule>> GetAllAsync()
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

        public async Task<FormModule?> GetByIdAsync(int id)
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
                _logger.LogError($"Error al actualizar el FormModule : {ex.Message}");
                return false;
            }
        }

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
                _logger.LogError($"Error al eliminar el FormModule {ex.Message}");
                return false;
            }
        }
    }
}

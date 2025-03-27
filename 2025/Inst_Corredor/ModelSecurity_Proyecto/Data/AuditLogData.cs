using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class AuditLogData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public AuditLogData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<AuditLogData>> GetAllAsync()
        {
            return await _context.Set<AuditLogData>().ToListAsync();
        }

        public async Task<AuditLogData?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<AuditLogData>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la auditoria con ID {AuditLogId}", id);
                throw;
            }

        }

        public async Task<AuditLogData> CreateAsync(AuditLogData auditLog)
        {
            try
            {
                await _context.Set<AuditLogData>().AddAsync(auditLog);
                await _context.SaveChangesAsync();
                return auditLog;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear la auditoria: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(AuditLogData auditLog)
        {
            try
            {
                _context.Set<AuditLogData>().Update(auditLog);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la auditoria : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var auditLog = await _context.Set<AuditLogData>().FindAsync(id);
                if (auditLog == null)
                    return false;
                _context.Set<AuditLogData>().Remove(auditLog);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la auditoria {ex.Message}");
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Contexts;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class AccessPointData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public AccessPointData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<AccessPoint>> GetAllAsync()
        {
            return await _context.Set<AccessPoint>().ToListAsync();
        }

        public async Task<AccessPoint?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<AccessPoint>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el AccessPoint con Id {FormId}", id);
                throw;
            }
        }

        public async Task<AccessPoint> CreateAsync(AccessPoint accessPoint)
        {
            try
            {
                await _context.Set<AccessPoint>().AddAsync(accessPoint);
                await _context.SaveChangesAsync();
                return accessPoint;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el AccessPoint: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(AccessPoint accessPoint)
        {
            try
            {
                _context.Set<AccessPoint>().Update(accessPoint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el AccessPoint: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var accessPoint = await _context.Set<AccessPoint>().FindAsync(id);
                if (accessPoint == null)
                    return false;
                _context.Set<AccessPoint>().Remove(accessPoint);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el AccessPoint: {ex.Message}");
                return false;
            }
        }
    }
}

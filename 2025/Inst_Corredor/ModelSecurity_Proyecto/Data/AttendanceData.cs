using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Contexts;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class AttendanceData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public AttendanceData(ApplicationDbContext context, ILogger logger)
        {
            _context = context; 
            _logger = logger;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Set<Attendance>().ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Attendance>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el Attendace con id {AttendanceId}", id);
                throw;
            }
        }

        public async Task<Attendance> CreateAsync(Attendance attendance)
        {
            try
            {
                await _context.Set<Attendance>().AddAsync(attendance);
                await _context.SaveChangesAsync();
                return attendance;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el Assignament: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Attendance attendance)
        {
            try
            {
                _context.Set<Attendance>().Update(attendance);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al actualizar el Assignament: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var attendance = await _context.Set<Attendance>().FindAsync(id);
                if (attendance == null)
                    return false;
                _context.Set<Attendance>().Remove(attendance);
                await _context.SaveChangesAsync ();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al eliminar el Assignament: {ex.Message}");
                return false;
            }
        }
    }
}

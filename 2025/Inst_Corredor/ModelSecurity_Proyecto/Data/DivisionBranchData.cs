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
    public class DivisionBranchData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public DivisionBranchData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<DivisionBranch>> GetAllAsync()
        {
            return await _context.Set<DivisionBranch>().ToListAsync();
        }

        public async Task<DivisionBranch?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<DivisionBranch>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el DivisionBranch con id {DivisionBranchId}", id);
                throw;
            }
        }

        public async Task<DivisionBranch> CreateAsync(DivisionBranch divisionBranch)
        {
            try
            {
                await _context.Set<DivisionBranch>().AddAsync(divisionBranch);
                await _context.SaveChangesAsync();
                return divisionBranch;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el DivisionBranch: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(DivisionBranch divisionBranch)
        {
            try
            {
                _context.Set<DivisionBranch>().Update(divisionBranch);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al actualizar el DivisionBranch: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var divisionBranch = await _context.Set<DivisionBranch>().FindAsync(id);
                if (divisionBranch == null)
                    return false;
                _context.Set<DivisionBranch>().Remove(divisionBranch);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al eliminar el DivisionBranch: {ex.Message}");
                return false;
            }
        }
    }
}

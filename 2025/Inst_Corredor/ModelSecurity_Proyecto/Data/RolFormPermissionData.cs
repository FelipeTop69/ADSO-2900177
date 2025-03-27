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
    public class RolFormPermissionData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public RolFormPermissionData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RolFormPermission>> GetAllAsync()
        {
            string query = @"
                SELECT 
                    rfp.Id, 
                    rfp.RoleId, 
                    r.Name as RoleName, 
                    rfp.PermissionId, 
                    p.Name as PermissionName, 
                    rfp.FormId, 
                    f.Name as FormName
                FROM RolFormPermission rfp
                INNER JOIN Rol r 
                ON rfp.RoleId = r.Id
                INNER JOIN Permission p 
                ON rfp.PermissionId = p.Id
                INNER JOIN Form f 
                ON rfp.FormId = f.Id";

            return (IEnumerable<RolFormPermission>) await _context.QueryAsync<IEnumerable<RolFormPermission>>(query);
            //return await _context.Set<RolFormPermission>().ToListAsync();
        }

        public async Task<RolFormPermission?> GetByIdAsync(int id)
        {
            try
            {
                string query = @"
                    SELECT 
                        rfp.Id, 
                        rfp.RoleId, 
                        r.Name AS RoleName, 
                        rfp.PermissionId, 
                        p.Name AS PermissionName, 
                        rfp.FormId, 
                        f.Name AS FormName
                    FROM RolFormPermission rfp
                    INNER JOIN Rol r ON rfp.RoleId = r.Id
                    INNER JOIN Permission p ON rfp.PermissionId = p.Id
                    INNER JOIN Form f ON rfp.FormId = f.Id
                    WHERE rfp.Id = @Id";

                return await _context.QueryFirstOrDefaultAsync<RolFormPermission>(query, new { Id = id });
                //return await _context.Set<RolFormPermission>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el RolFormPermission con ID {id}");
                throw;
            }

        }

        public async Task<RolFormPermission> CreateAsync(RolFormPermission rolFormPermission)
        {
            try
            {
                await _context.Set<RolFormPermission>().AddAsync(rolFormPermission);
                await _context.SaveChangesAsync();
                return rolFormPermission;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el RolFormPermission: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(RolFormPermission rolFormPermission)
        {
            try
            {
                _context.Set<RolFormPermission>().Update(rolFormPermission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el RolFormPermission : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var rolFormPermission = await _context.Set<RolFormPermission>().FindAsync(id);
                if (rolFormPermission == null)
                    return false;
                _context.Set<RolFormPermission>().Remove(rolFormPermission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el RolFormPermission {ex.Message}");
                return false;
            }
        }
    }
}

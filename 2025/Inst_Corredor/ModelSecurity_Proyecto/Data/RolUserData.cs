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
    public class RolUserData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public RolUserData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RolUser>> GetAllAsync()
        {
            string query = @"
                SELECT 
                    ru.Id, 
                    ru.RoleId, 
                    r.Name AS RoleName, 
                    ru.UserId, 
                    u.UserName AS UserName
                FROM RolUser ru
                INNER JOIN Rol r ON ru.RoleId = r.Id
                INNER JOIN [User] u ON ru.UserId = u.Id";

            return (IEnumerable<RolUser>) await _context.QueryAsync<IEnumerable<User>>(query);
            //return await _context.Set<RolUser>().ToListAsync(); 
        }

        public async Task<RolUser?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<RolUser>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el RolUser con ID {id}");
                throw;
            }

        }

        public async Task<RolUser> CreateAsync(RolUser rolUser)
        {
            try
            {
                await _context.Set<RolUser>().AddAsync(rolUser);
                await _context.SaveChangesAsync();
                return rolUser;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el RolUser: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(RolUser rolUser)
        {
            try
            {
                _context.Set<RolUser>().Update(rolUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el RolUser : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var rolUser = await _context.Set<RolUser>().FindAsync(id);
                if (rolUser == null)
                    return false;
                _context.Set<RolUser>().Remove(rolUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el RolUser {ex.Message}");
                return false;
            }
        }
    }
}

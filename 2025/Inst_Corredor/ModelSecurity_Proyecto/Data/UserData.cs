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
    public class UserData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public UserData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            string query = @"
                SELECT 
                    u.Id, 
                    u.Username, 
                    u.State, 
                    u.PersonId, 
                    p.FirstName + ' ' + p.LastName as PersonName
                FROM [User] u
                INNER JOIN Person p ON u.PersonId = p.Id";

            return (IEnumerable<User>) await _context.QueryAsync<IEnumerable<User>>(query);
            //return await _context.Set<User>().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                string query = @"
                    SELECT 
                        u.Id, 
                        u.Username, 
                        u.State, 
                        u.PersonId, 
                        p.FirstName + ' ' + p.LastName as PersonName
                    FROM [User] u
                    INNER JOIN Person p 
                    ON u.PersonId = p.Id
                    WHERE u.Id = @Id";

                return await _context.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
                //return await _context.Set<User>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener una usuario con ID {UserId}", id);
                throw;
            }

        }

        public async Task<User> CreateAsync(User user)
        {
            try
            {
                await _context.Set<User>().AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el usuario: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                _context.Set<User>().Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el usuario : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.Set<User>().FindAsync(id);
                if (user == null)
                    return false;
                _context.Set<User>().Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el usuario {ex.Message}");
                return false;
            }
        }
    }
}

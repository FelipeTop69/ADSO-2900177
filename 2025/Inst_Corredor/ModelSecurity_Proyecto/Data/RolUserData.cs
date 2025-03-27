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

        /// <summary>
        /// Obtiene todos los RolUser almacenados en la base de datos SQL
        /// </summary>
        public async Task<IEnumerable<RolUser>> GetAllAsyncSQL()
        {
            String query = @"
                SELECT 
                    ru.Id, 
                    ru.RoleId, 
                    r.Name AS RoleName, 
                    ru.UserId, 
                    u.UserName AS UserName
                FROM RolUser ru
                INNER JOIN Rol r 
                ON ru.RoleId = r.Id
                INNER JOIN [User] u 
                ON ru.UserId = u.Id";

            return (IEnumerable<RolUser>) await _context.QueryAsync<IEnumerable<User>>(query);
            //return await _context.Set<RolUser>().ToListAsync(); 
        }

        /// <summary>
        /// Obtiene todos los RolUser almacenados en la base de datos LINQ
        /// </summary>
        public async Task<IEnumerable<RolUser>> GetAllAsync()
        {
            return await _context.Set<RolUser>().ToListAsync();
        }


        /// <summary>
        /// Obtiene un RolUser especifico por su identificacion SQL
        /// </summary
        public async Task<RolUser?> GetByIdAsyncSQL(int id)
        {
            try
            {
                String query = @"
                SELECT 
                    ru.Id, 
                    ru.RoleId, 
                    r.Name as RoleName, 
                    ru.UserId, 
                    u.UserName as UserName
                FROM RolUser ru
                INNER JOIN Rol r 
                ON ru.RoleId = r.Id
                INNER JOIN [User] u 
                ON ru.UserId = u.Id";

                return await _context.QueryFirstOrDefaultAsync<RolUser>(query, new { Id = id });
                //return await _context.Set<RolUser>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el RolUser con ID {id}");
                throw;
            }

        }

        /// <summary>
        /// Obtiene un RolUser específico por su identificación LINQ
        /// </summary>
        public async Task<RolUser?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<RolUser>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un RolUser con ID {RolUserId}", id);
                throw;
            }
        }


        /// <summary>
        /// Crear un nuevo RolUser en la base de datos SQL
        /// </summary>
        public async Task<RolUser> CreateAsyncSQL(RolUser rolUser)
        {
            try
            {
                string query = @"
                    INSERT INTO RolUser (UserId, RoleId) 
                    VALUES (@UserId, @RoleId);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

                int newId = await _context.QuerySingleAsync<int>(query, new
                {
                    rolUser.UserId,
                    rolUser.RoleId
                });

                rolUser.Id = newId;
                return rolUser;

                //await _context.Set<RolUser>().AddAsync(rolUser);
                //await _context.SaveChangesAsync();
                //return rolUser;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el RolUser: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo RolUser en la base de datos LINQ
        /// </summary>
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


        /// <summary>
        /// Actualiza un RolUser existente en la base de datos SQL
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(RolUser rolUser)
        {
            try
            {
                var query = @"
                    UPDATE RolUser 
                    SET UserId = @UserId, RoleId = @RoleId
                    WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new
                {
                    rolUser.Id,
                    rolUser.UserId,
                    rolUser.RoleId
                });

                return rowsAffected > 0;

                //_context.Set<RolUser>().Update(rolUser);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el RolUser : {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un RolUser existente en la base de datos LINQ
        /// </summary>
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
                _logger.LogError($"Error al actualizar el RolUser: {ex.Message}");
                return false;
            }
        }



        /// <summary>
        /// Elimina un RolUser de la base de datos SQL
        /// </summary>
        public async Task<bool> DeleteAsyncSQL(int id)
        {
            try
            {
                var query = @"
                    DELETE FROM RolUser WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new { Id = id });

                return rowsAffected > 0;

                //var rolUser = await _context.Set<RolUser>().FindAsync(id);
                //if (rolUser == null)
                //    return false;
                //_context.Set<RolUser>().Remove(rolUser);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el RolUser {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina un RolUser de la base de datos LINQ
        /// </summary>
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
                _logger.LogError($"Error al eliminar el RolUser: {ex.Message}");
                return false;
            }
        }
    }
}
    
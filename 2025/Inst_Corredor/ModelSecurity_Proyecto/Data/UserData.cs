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

        /// <summary>
        /// Obtiene todos los UserData almacenados en la base de datos SQL
        /// </summary>
        public async Task<IEnumerable<User>> GetAllAsyncSQL()
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
                ON u.PersonId = p.Id";

            return (IEnumerable<User>) await _context.QueryAsync<IEnumerable<User>>(query);
            //return await _context.Set<User>().ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los UserData almacenados en la base de datos LINQ
        /// </summary>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }



        /// <summary>
        /// Obtiene un UserData especifico por su identificacion SQL
        /// </summary
        public async Task<User?> GetByIdAsyncSQL(int id)

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

        /// <summary>
        /// Obtiene un UserData especifico por su identificacion LINQ
        /// </summary
        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<User>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener una usuario con ID {UserId}", id);
                throw;
            }

        }



        /// <summary>
        /// Crear un nuevo UserData en la base de datos SQL
        /// </summary>
        public async Task<User> CreateAsyncSQL(User user)
        {
            try
            {
                string query = @"
                    INSERT INTO [User] 
                    (Username, Password, State, PersonId) 
                    VALUES 
                    (@Username, @Password, @State, @PersonId);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

                int newId = await _context.QuerySingleAsync<int>(query, new
                {
                    user.Username,
                    user.Password,
                    user.State,
                    user.PersonId
                });

                user.Id = newId;
                return user;

                //await _context.Set<User>().AddAsync(user);
                //await _context.SaveChangesAsync();
                //return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el usuario: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crear un nuevo UserData en la base de datos LINQ
        /// </summary>
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



        /// <summary>
        /// Actualiza un UserData existente en la base de datos SQL
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(User user)
        {
            try
            {
                string query = @"
                    UPDATE [User] 
                    SET Username = @Username, Password = @Password, State = @State, PersonId = @PersonId
                    WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new
                {
                    user.Id,
                    user.Username,
                    user.Password,
                    user.State,
                    user.PersonId
                });

                return rowsAffected > 0;

                //_context.Set<User>().Update(user);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el usuario : {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Actualiza un UserData existente en la base de datos LINQ
        /// </summary>
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



        /// <summary>
        /// Elimina un UserData de la base de datos SQL
        /// </summary>
        public async Task<bool> DeleteAsyncSQL(int id)
        {
            try { 
                string query = @"
                    DELETE FROM [User] WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new { Id = id });

                return rowsAffected > 0;
                //var user = await _context.Set<User>().FindAsync(id);
                //if (user == null)
                //    return false;
                //_context.Set<User>().Remove(user);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el usuario {ex.Message}");
                return false;
            }
        } 
        
        /// <summary>
        /// Elimina un UserData de la base de datos SQL LINQ
        /// </summary>
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

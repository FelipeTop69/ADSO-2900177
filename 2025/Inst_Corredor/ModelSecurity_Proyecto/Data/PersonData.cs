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
    public class PersonData
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ILogger _looger;

        public PersonData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _looger = logger;
        }

        /// <summary>
        /// Obtiene todos los Person almacenados en la base de datos SQL
        /// </summary>
        public async Task<IEnumerable<Person>> GetAllAsyncSQL()
        {
            string query = @"
                SELECT 
                    p.Id, 
                    CONCAT(p.FirstName, ' ', COALESCE(p.MiddleName, ''), ' ', p.LastName, ' ', COALESCE(p.SecondLastName, '')) AS Name,
                    p.Email, 
                    p.DocumentType, 
                    p.DocumentNumber, 
                    p.Phone, 
                    p.Address, 
                    p.BlodType, 
                    p.Photo, 
                    p.Active,
                    p.CityId as CityInt, 
                    c.Name as CityName, 
                    p.AssignamentId as AssignmentInt, 
                    a.Name AS AssignmentName
                FROM Person p
                INNER JOIN City c 
                ON p.CityId = c.Id
                INNER JOIN Assignment a 
                ON p.AssignamentId = a.Id";

            return (IEnumerable<Person>) await _context.QueryAsync<IEnumerable<Person>>(query);
            //return await _context.Set<Person>().ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los Person almacenados en la base de datos LINQ
        /// </summary>
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Set<Person>().ToListAsync();
        }



        /// <summary>
        /// Obtiene un Person especifico por su identificacion SQL
        /// </summary
        public async Task<Person?> GetBydIdAsyncSQL(int id)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.Id, 
                        CONCAT(p.FirstName, ' ', COALESCE(p.MiddleName, ''), ' ', p.LastName, ' ', COALESCE(p.SecondLastName, '')) AS Name,
                        p.Email, 
                        p.DocumentType, 
                        p.DocumentNumber, 
                        p.Phone, 
                        p.Address, 
                        p.BlodType, 
                        p.Photo, 
                        p.Active, 
                        p.CityId as CityInt, 
                        c.Name as CityName, 
                        p.AssignamentId as AssignmentInt, 
                        a.Name as AssignmentName
                    FROM Person p
                    INNER JOIN City c 
                    ON p.CityId = c.Id
                    INNER JOIN Assignment a 
                    ON p.AssignamentId = a.Id
                    WHERE p.Id = @Id";

                return await _context.QueryFirstOrDefaultAsync<Person>(query, new { Id = id });
                //return await _context.Set<Person>().FindAsync(id);
            }
            catch(Exception ex) {
                _looger.LogError(ex, $"Error al obtener la persona con id {id}");
                throw;
            }
        }
        
        /// <summary>
        /// Obtiene un Person especifico por su identificacion LINQ
        /// </summary
        public async Task<Person?> GetByIdAsync(int id)
        {
            try
            {

                return await _context.Set<Person>().FindAsync(id);
            }
            catch(Exception ex) {
                _looger.LogError(ex, $"Error al obtener la persona con id {id}");
                throw;
            }
        }



        /// <summary>
        /// Crear un nuevo Person en la base de datos SQL
        /// </summary>
        public async Task<Person> CreateAsyncSQL(Person person)
        {
            try
            {
                string query = @"
                    INSERT INTO Person 
                    (FirstName, MiddleName, LastName, SecondLastName, Email, DocumentNumber, Phone, 
                     Address, DocumentType, BlodType, Photo, CityId, AssignamentId) 
                    VALUES 
                    (@FirstName, @MiddleName, @LastName, @SecondLastName, @Email, @DocumentNumber, @Phone, 
                     @Address, @DocumentType, @BlodType, @Photo, @CityId, @AssignamentId);
                    SELECT CAST(SCOPE_IDENTITY() AS int);";

                int newId = await _context.QuerySingleAsync<int>(query, new
                {
                    person.FirstName,
                    person.MiddleName,
                    person.LastName,
                    person.SecondLastName,
                    person.Email,
                    person.DocumentNumber,
                    person.Phone,
                    person.Address,
                    person.DocumentType,
                    person.BlodType,
                    person.Photo,
                    person.CityId,
                    person.AssignamentId
                });

                person.Id = newId;
                return person;

                //await _context.Set<Person>().AddAsync(person);
                //await _context.SaveChangesAsync();
                //return person;
            }
            catch (Exception ex) 
            {
                _looger.LogError($"Error al crear la persona{ex.Message}");
                throw;
            }

        }
        
        /// <summary>
        /// Crear un nuevo Person en la base de datos LINQ
        /// </summary>
        public async Task<Person> CreateAsync(Person person)
        {
            try
            {
                await _context.Set<Person>().AddAsync(person);
                await _context.SaveChangesAsync();
                return person;
            }
            catch (Exception ex) 
            {
                _looger.LogError($"Error al crear la persona{ex.Message}");
                throw;
            }

        }



        /// <summary>
        /// Actualiza un Person existente en la base de datos SQL
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(Person person)
        {
            try
            {
                string query = @"
                    UPDATE Person 
                    SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, 
                        SecondLastName = @SecondLastName, Email = @Email, DocumentNumber = @DocumentNumber, 
                        Phone = @Phone, Address = @Address, DocumentType = @DocumentType, BlodType = @BlodType, 
                        Photo = @Photo, Active = @Active, CityId = @CityId, AssignamentId = @AssignamentId
                    WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new
                {
                    person.Id,
                    person.FirstName,
                    person.MiddleName,
                    person.LastName,
                    person.SecondLastName,
                    person.Email,
                    person.DocumentNumber,
                    person.Phone,
                    person.Address,
                    person.DocumentType,
                    person.BlodType,
                    person.Photo,
                    person.Active,
                    person.CityId,
                    person.AssignamentId
                });

                return rowsAffected > 0;
                //_context.Set<Person>().Update(person);
                //await _context.SaveChangesAsync();
                //return  true;
            }
            catch (Exception ex) {
                _looger.LogError($"Error al actualizar la persona {ex.Message}");
                throw;
            }
            
        } 

        /// <summary>
        /// Actualiza un Person existente en la base de datos LINQ
        /// </summary>
        public async Task<bool> UpdateAsync(Person person)
        {
            try
            {

                _context.Set<Person>().Update(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) {
                _looger.LogError($"Error al actualizar la persona {ex.Message}");
                throw;
            }
            
        }



        /// <summary>
        /// Elimina un Person de la base de datos SQL
        /// </summary>
        public async Task<bool> DeleteAsyncSQL(int id)
        {
            try
            {
                string query = @"
                    DELETE FROM Person WHERE Id = @Id;
                    SELECT CAST(@@ROWCOUNT AS int);";

                int rowsAffected = await _context.QuerySingleAsync<int>(query, new { Id = id });

                return rowsAffected > 0;


                //var person = await _context.Set<Person>().FindAsync(id);
                //if (person == null)
                //    return false;
                //_context.Set<Person>().Remove(person);
                //await _context.SaveChangesAsync();
                //return true;
            }
            catch (Exception ex)
            {
                _looger.LogError($"Error al eliminar la persona {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Elimina un Person de la base de datos LINQ
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var person = await _context.Set<Person>().FindAsync(id);
                if (person == null)
                    return false;
                _context.Set<Person>().Remove(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _looger.LogError($"Error al eliminar la persona {ex.Message}");
                return false;
            }
        }

    }
}

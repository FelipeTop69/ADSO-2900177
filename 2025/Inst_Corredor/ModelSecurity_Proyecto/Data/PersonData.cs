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

        public async Task<IEnumerable<Person>> GetAllAsync()
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

        public async Task<Person?> GetBydIdAsync(int id)
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

        public async Task<bool> UpdateAsync(Person person)
        {
            try
            {
                _context.Set<Person>().Update(person);
                await _context.SaveChangesAsync();
                return  true;
            }
            catch (Exception ex) {
                _looger.LogError($"Error al actualizar la persona {ex.Message}");
                throw;
            }
            
        }

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

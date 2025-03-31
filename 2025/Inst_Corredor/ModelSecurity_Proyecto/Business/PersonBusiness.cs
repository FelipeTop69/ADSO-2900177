using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business
{
    public class PersonBusiness
    {
        private readonly PersonData _personData;
        private readonly ILogger _logger;

        public PersonBusiness(PersonData personData, ILogger logger)
        {
            _personData = personData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las personas como DTOs
        /// </summary>
        public async Task<IEnumerable<PersonDTO>> GetAllPersonsAsync()
        {
            try
            {
                var persons = await _personData.GetAllAsync();
                return MapToDTOList(persons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las personas");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de personas", ex);
            }
        }


        /// <summary>
        /// Obtiene una persona por su ID como DTO
        /// </summary>
        public async Task<PersonDTO> GetPersonByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Se intentó obtener una persona con ID inválido: {PersonId}", id);
                throw new ValidationException("id", "El ID de la persona debe ser mayor que cero");
            }

            try
            {
                var person = await _personData.GetByIdAsync(id);
                if (person == null)
                {
                    _logger.LogInformation("No se encontró ninguna persona con ID: {PersonId}", id);
                    throw new EntityNotFoundException("Person", id);
                }

                return MapToDTO(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la persona con ID: {PersonId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar la persona con ID {id}", ex);
            }
        }


        /// <summary>
        /// Crea una nueva persona desde un DTO
        /// </summary>
        public async Task<PersonDTO> CreatePersonAsync(PersonDTO personDto)
        {
            try
            {
                ValidatePerson(personDto);

                var person = MapToEntity(personDto);

                var createdPerson = await _personData.CreateAsync(person);

                return MapToDTO(createdPerson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear nueva persona: {PersonNombre}", personDto?.Name ?? "null");
                throw new ExternalServiceException("Base de datos", "Error al crear la persona", ex);
            }
        }


        /// <summary>
        /// Actualiza una persona existente
        /// </summary>
        public async Task<bool> UpdatePersonAsync(PersonDTO personDto)
        {
            if (personDto.Id <= 0)
            {
                _logger.LogWarning("Se intentó actualizar una persona con ID inválido: {PersonId}", personDto.Id);
                throw new ValidationException("id", "El ID de la persona debe ser mayor que cero");
            }

            try
            {
                ValidatePerson(personDto);

                var person = await _personData.GetByIdAsync(personDto.Id);
                if (person == null)
                {
                    _logger.LogWarning("No se encontró la persona con ID {PersonId} para actualizar", personDto.Id);
                    throw new EntityNotFoundException("Person", personDto.Id);
                }

                // Actualizar los datos de la persona con la información del DTO
                person.FirstName = personDto.Name;
                person.LastName = personDto.LastName;
                person.Email = personDto.Email;
                person.DocumentType = personDto.DocumentType;
                person.DocumentNumber = personDto.DocumentNumber;
                person.Phone = personDto.Phone;
                person.Address = personDto.Address;
                person.BlodType = personDto.BlodType;
                person.Photo = personDto.Photo;
                person.Active = personDto.Status;
                person.CityId = personDto.CityInt;
                person.AssignamentId = personDto.AssignmentInt;

                return await _personData.UpdateAsync(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la persona con ID: {PersonId}", personDto.Id);
                throw new ExternalServiceException("Base de datos", $"Error al actualizar la persona con ID {personDto.Id}", ex);
            }
        }


        /// <summary>
        /// Elimina una persona por su ID
        /// </summary>
        public async Task<bool> DeletePersonAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Se intentó eliminar una persona con ID inválido: {PersonId}", id);
                throw new ValidationException("id", "El ID de la persona debe ser mayor que cero");
            }

            try
            {
                return await _personData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la persona con ID: {PersonId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al eliminar la persona con ID {id}", ex);
            }
        }


        /// <summary>
        /// Valida un objeto PersonDTO
        /// </summary>
        private void ValidatePerson(PersonDTO personDto)
        {
            if (personDto == null)
            {
                throw new ValidationException("El objeto persona no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(personDto.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar una persona con Name vacío");
                throw new ValidationException("Name", "El nombre de la persona es obligatorio");
            }

            if (string.IsNullOrWhiteSpace(personDto.Email))
            {
                _logger.LogWarning("Se intentó crear/actualizar una persona con Email vacío");
                throw new ValidationException("Email", "El correo electrónico de la persona es obligatorio");
            }
        }


        /// <summary>
        /// Mapea de Person a PersonDTO
        /// </summary>
        private PersonDTO MapToDTO(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                Name = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                DocumentType = person.DocumentType,
                DocumentNumber = person.DocumentNumber,
                Phone = person.Phone,
                Address = person.Address,
                BlodType = person.BlodType,
                Photo = person.Photo,
                Status = person.Active,
                CityInt = person.CityId,
                CityName = person.City?.Name ?? string.Empty,
                AssignmentInt = person.AssignamentId,
                AssignmentName = person.Assignment?.Name ?? string.Empty
            };
        }


        /// <summary>
        /// Mapea de PersonDTO a Person
        /// </summary>
        private Person MapToEntity(PersonDTO personDto)
        {
            return new Person
            {
                Id = personDto.Id,
                FirstName = personDto.Name,
                LastName = personDto.LastName,
                Email = personDto.Email,
                DocumentType = personDto.DocumentType,
                DocumentNumber = personDto.DocumentNumber,
                Phone = personDto.Phone,
                Address = personDto.Address,
                BlodType = personDto.BlodType,
                Photo = personDto.Photo,
                Active = personDto.Status,
                CityId = personDto.CityInt,
                AssignamentId = personDto.AssignmentInt
            };
        }


        /// <summary>
        /// Mapea una lista de Person a una lista de PersonDTO
        /// </summary>
        /// <summary>
        /// Metodo para mapear una lista de Person a una lista de PersonDTO 
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        private IEnumerable<PersonDTO> MapToDTOList(IEnumerable<Person> persons)
        {
            var personsDTO = new List<PersonDTO>();
            foreach (var person in persons)
            {
                personsDTO.Add(MapToDTO(person));
            }
            return personsDTO;
        }
    }
}

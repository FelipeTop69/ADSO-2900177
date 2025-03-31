using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Exceptions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly PersonBusiness _personBusiness;
        private readonly ILogger<PersonController> _logger;

        public PersonController(PersonBusiness personBusiness, ILogger<PersonController> logger)
        {
            _personBusiness = personBusiness;
            _logger = logger;
        }

        ///<summary>
        /// Obtener todos los person del sistema
        ///</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var Persons = await _personBusiness.GetAllPersonsAsync();
                return Ok(Persons);    
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error al obtener los persons");
                return StatusCode(500, new {message = ex.Message});
            }
        }


        ///<summary>
        /// Obtener un person especificio por su ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                var Person = await _personBusiness.GetPersonByIdAsync(id);
                return Ok(Person);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex, "Validacion fallida para person con ID: {PersonId}", id);
                return BadRequest(new {message = ex.Message});
            }
            catch (EntityNotFoundException ex)
            {

                _logger.LogInformation(ex, "Person no encontrado con ID: {PersonId}", id);
                return NotFound(new {message = ex.Message});
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener el person con ID: {PersonId}", id);
                throw;
            }
        }


        /// <summary>
        /// Crea un nuevo person en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(RolDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePersonAsync([FromBody] PersonDTO personDto)
        {
            try
            {
                var createdPerson = await _personBusiness.CreatePersonAsync(personDto);
                return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.Id }, createdPerson);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al crear person");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear person");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Actualiza un person existente en el sistema
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RolDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePersonAsync(int id, [FromBody] PersonDTO personDto)
        {
            try
            {
                if (id != personDto.Id)
                {
                    return BadRequest(new { message = "El ID de la ruta no coincide con el ID del objeto." });
                }

                var updatedPerson = await _personBusiness.UpdatePersonAsync(personDto);

                return Ok(updatedPerson);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el person con ID: {PersonId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "No se encontró el person con ID: {PersonId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el rol con ID: {PersonId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un person del sistema
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            try
            {
                var deleted = await _personBusiness.DeletePersonAsync(id);

                if (!deleted)
                {
                    return NotFound(new { message = "Person no encontrado o ya eliminado" });
                }

                return Ok(new { message = "Person eliminado exitosamente" });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el person con ID: {PersonId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}

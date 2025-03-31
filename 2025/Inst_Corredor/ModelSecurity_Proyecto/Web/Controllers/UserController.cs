using Business;
using Entity.DTOs;
using Entity.Model;
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

    public class UserController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        private readonly ILogger<UserController> _logger;

        public UserController(UserBusiness userBusiness, ILogger<UserController> logger)
        {
            _userBusiness = userBusiness;
            _logger = logger;
        }

        ///<summary>
        /// Obtener todos los users del sistema
        ///</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var Users = await _userBusiness.GetAllUsersAsync();
                return Ok(Users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los users");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        ///<summary>
        /// Obtener un userBusiness especificio por su ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var User = await _userBusiness.GetUserByIdAsync(id);
                return Ok(User);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida para user con ID: {UserId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {

                _logger.LogInformation(ex, "User no encontrado con ID: {UserId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener el user con ID: {UserId}", id);
                throw;
            }
        }


        /// <summary>
        /// Crea un nuevo userBusiness en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                var createdUser = await _userBusiness.CreateUserAsync(userDTO);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al crear el user");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el user");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Actualiza un userBusiness existente en el sistema
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                if (id != userDTO.Id)
                {
                    return BadRequest(new { message = "El ID de la ruta no coincide con el ID del objeto." });
                }

                var updatedUser = await _userBusiness.UpdateUserAsync(userDTO);

                return Ok(updatedUser);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el user con ID: {UserId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "No se encontró el user con ID: {UserId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el user con ID: {UserId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un userBusiness del sistema
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var deleted = await _userBusiness.DeleteUserAsync(id);

                if (!deleted)
                {
                    return NotFound(new { message = "User no encontrado o ya eliminado" });
                }

                return Ok(new { message = "User eliminado exitosamente" });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el user con ID: {UserId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Exceptions;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de permisos en el sistema
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class RolController : ControllerBase
    {
    
        private readonly RolBusiness _rolBusiness;
        private readonly ILogger<RolController> _logger;

        /// <summary>
        /// Constructor del controlador de permisos
        /// </summary>
        /// <param name="RolBusiness">Capa de negocio de rol</param>
        /// <param name="logger">Logger para registro de rol</param>
        public RolController(RolBusiness rolBusiness, ILogger<RolController> logger)
        {
            _rolBusiness = rolBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los rols del sistema
        /// </summary>
        /// <returns>Lista de rols</returns>
        /// <response code="200">Retorna la lista de rols</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RolDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllRols()
        {
            try
            {
                var Rols = await _rolBusiness.GetAllRolesAsync();
                return Ok(Rols);
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener rols");
                return StatusCode(500, new {message = ex.Message});
            }
        }

        /// <summary>
        /// Obtiene un permiso específico por su ID
        /// </summary>
        /// <param name="id">ID del permiso</param>
        /// <returns>Permiso solicitado</returns>
        /// <response code="200">Retorna el permiso solicitado</response>
        /// <response code="400">ID proporcionado no válido</response>
        /// <response code="404">permiso no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RolDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<IActionResult> GetRolById(int id)
        {
            try
            {
                var Rol = await _rolBusiness.GetRolByIdAsync(id);
                return Ok(Rol);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida para el rol con ID: {RolId}", id);
                return BadRequest(new {message = ex.Message});
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Rol no encontrado con ID: {RolId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener el rol con ID: {RolId}", id);
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo rol en el sistema
        /// </summary>
        /// <param name="RolDto">Datos del rol a crear</param>
        /// <returns>rol creado</returns>
        /// <response code="201">Retorna el rol creado</response>
        /// <response code="400">Datos del rol no válidos</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost]
        [ProducesResponseType(typeof(RolDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateRolAsync([FromBody] RolDTO rolDto)
        {
            try
            {
                var createdRol = await _rolBusiness.CreateRolAsync(rolDto);
                return CreatedAtAction(nameof(GetRolById), new { id = createdRol.Id }, createdRol);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al creal el rol");
                return BadRequest(new {message = ex.Message});
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el permios");
                return StatusCode(500, new { message = ex.Message});
            }
        }

        /// <summary>
        /// Actualiza un rol existente en el sistema
        /// </summary>
        /// <param name="id">ID del rol a actualizar</param>
        /// <param name="rolDto">Datos actualizados del rol</param>
        /// <returns>Rol actualizado</returns>
        /// <response code="200">Retorna el rol actualizado</response>
        /// <response code="400">Datos inválidos o ID incorrecto</response>
        /// <response code="404">Rol no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RolDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateRolAsync(int id, [FromBody] RolDTO rolDto)
        {
            try
            {
                if (id != rolDto.Id)
                {
                    return BadRequest(new { message = "El ID de la ruta no coincide con el ID del objeto." });
                }

                var updatedRol = await _rolBusiness.UpdateUserAsync(rolDto);

                return Ok(updatedRol);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el rol con ID: {RolId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "No se encontró el rol con ID: {RolId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el rol con ID: {RolId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un rol del sistema
        /// </summary>
        /// <param name="id">ID del rol a eliminar</param>
        /// <returns>Mensaje de confirmación</returns>
        /// <response code="200">El rol fue eliminado exitosamente</response>
        /// <response code="404">Rol no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteRolAsync(int id)
        {
            try
            {
                var deleted = await _rolBusiness.DeleteRolAsync(id);

                if (!deleted)
                {
                    return NotFound(new { message = "Rol no encontrado o ya eliminado" });
                }

                return Ok(new { message = "Rol eliminado exitosamente" });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el rol con ID: {RolId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }



    }
}

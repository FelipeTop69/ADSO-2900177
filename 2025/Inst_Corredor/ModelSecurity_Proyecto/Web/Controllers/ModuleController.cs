using Business;
using Entity.DTOs;
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

    public class ModuleController : ControllerBase
    {
        private readonly ModuleBusiness _moduleBusiness;
        private readonly ILogger<ModuleController> _logger;

        public ModuleController(ModuleBusiness moduleBusiness, ILogger<ModuleController> logger)
        {
            _moduleBusiness = moduleBusiness;
            _logger = logger;
        }

        ///<summary>
        /// Obtener todos los modules del sistema
        ///</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ModuleDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllModules()
        {
            try
            {
                var Modules = await _moduleBusiness.GetAllModulesAsync();
                return Ok(Modules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los modules");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        ///<summary>
        /// Obtener un module especificio por su ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ModuleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetModuleById(int id)
        {
            try
            {
                var Module = await _moduleBusiness.GetModuleByIdAsync(id);
                return Ok(Module);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida para module con ID: {ModuleId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {

                _logger.LogInformation(ex, "Module no encontrado con ID: {ModuleId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener el module con ID: {ModuleId}", id);
                throw;
            }
        }


        /// <summary>
        /// Crea un nuevo module en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ModuleDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateModule([FromBody] ModuleDTO moduleDTO)
        {
            try
            {
                var createdModule = await _moduleBusiness.CreateModuleAsync(moduleDTO);
                return CreatedAtAction(nameof(GetModuleById), new { id = createdModule.Id }, createdModule);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al crear el module");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el module");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Actualiza un module existente en el sistema
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ModuleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateModule(int id, [FromBody] ModuleDTO moduleDTO)
        {
            try
            {
                if (id != moduleDTO.Id)
                {
                    return BadRequest(new { message = "El ID de la ruta no coincide con el ID del objeto." });
                }

                var updatedModule = await _moduleBusiness.UpdateModuleAsync(moduleDTO);

                return Ok(updatedModule);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el module con ID: {ModuleId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "No se encontró el module con ID: {ModuleId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el module con ID: {ModuleId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un module del sistema
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteModule(int id)
        {
            try
            {
                var deleted = await _moduleBusiness.DeleteModuleAsync(id);

                if (!deleted)
                {
                    return NotFound(new { message = "Module no encontrado o ya eliminado" });
                }

                return Ok(new { message = "Module eliminado exitosamente" });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el module con ID: {ModuleId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

﻿using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Exceptions;

namespace Web.Controllers
{
    /// <summary>
    /// Controllador para la gestión de Modules en el sistema
    /// </summary>
    [Route("api/[controller]/")]
    [ApiController]
    [Produces("application/json")]

    public class ModuleController : ControllerBase
    {
        private readonly ModuleBusiness _moduleBusiness;
        private readonly ILogger<ModuleController> _logger;

        /// <summary>
        /// Constructor del contmoduleador de Module
        /// </summary>
        /// <param name="ModuleBusiness">Capa de negocio de Module</param>
        /// <param name="logger">Logger para registro de Module</param>
        public ModuleController(ModuleBusiness moduleBusiness, ILogger<ModuleController> logger)
        {
            _moduleBusiness = moduleBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los Modules del sistema
        /// </summary>
        /// <returns>Lista de Modulees</returns>
        /// <response code="200">Retorna la lista de Modules</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("GetAll/")]
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


        /// <summary>
        /// Obtiene un Module específico por su ID
        /// </summary>
        /// <param name="id">ID del Module</param>
        /// <returns>Module solicitado</returns>
        /// <response code="200">Retorna el Module solicitado</response>
        /// <response code="400">ID proporcionado no válido</response>
        /// <response code="404">Module no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet("GetById/{id}/")]
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
        /// Crea un nuevo Module en el sistema
        /// </summary>
        /// <param name="ModuleDTO">Datos del Module a crear</param>
        /// <returns>module creado</returns>
        /// <response code="201">Retorna el Module creado</response>
        /// <response code="400">Datos del Module no válidos</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost("Create/")]
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
        /// Actualiza un Module existente en el sistema
        /// </summary>
        /// <param name="id">ID del Module a actualizar</param>
        /// <param name="moduleDto">Datos actualizados del Module</param>
        /// <returns>Module actualizado</returns>
        /// <response code="200">Retorna el Module actualizado</response>
        /// <response code="400">Datos inválidos o ID incorrecto</response>
        /// <response code="404">Module no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPut("Update/")]
        [ProducesResponseType(typeof(ModuleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateModule([FromBody] ModuleDTO moduleDTO)
        {
            try
            { 
                var updatedModule = await _moduleBusiness.UpdateModuleAsync(moduleDTO);

                return Ok(updatedModule);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el module con ID: {ModuleId}",moduleDTO.Id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "No se encontró el module con ID: {ModuleId}", moduleDTO.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el module con ID: {ModuleId}",moduleDTO.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un Module del sistema
        /// </summary>
        /// <param name="id">ID del Module a eliminar</param>
        /// <returns>Mensaje de confirmación</returns>
        /// <response code="200">El Module fue eliminado exitosamente</response>
        /// <response code="400">Parametro Incorrecto</response>
        /// <response code="404">Module no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpDelete("Delete/{id}/")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteModule(int id)
        {
            try
            {
                await _moduleBusiness.DeleteModuleAsync(id);
                return Ok(new { message = "Module eliminado exitosamente" });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "No se encontró el Module con ID: {ModuleId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el module con ID: {ModuleId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un Module de manera logcica del sistema
        /// </summary>
        /// <param name="id">ID del Module a eliminar de manera logica</param>
        /// <returns>Mensaje de confirmación</returns>
        /// <response code="200">El Module fue eliminado de manera logica exitosamente</response>
        /// <response code="400">Parametro Incorrecto</response>
        /// <response code="404">Module no encontrado</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpDelete("Logical/{id}/")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteLogicalModuleAsync(int id)
        {
            try
            {
                await _moduleBusiness.DeleteModuleLogicalAsync(id);
                return Ok(new { message = "Eliminación lógica exitosa." });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "No se encontró el Module con ID: {ModuleId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el Module de manera lógica con ID: {ModuleId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

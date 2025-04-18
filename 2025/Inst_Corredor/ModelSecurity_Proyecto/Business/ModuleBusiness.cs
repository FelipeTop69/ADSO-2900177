﻿using System;
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
    ///<summary>
    ///Clase de negocio encargada de la logica relacionada con Module en el sistema;
    ///</summary>
    public class ModuleBusiness
    {
        private readonly ModuleData _moduleData;
        private readonly ILogger<ModuleBusiness> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ModuleBusiness"/>.
        /// </summary>
        /// <param name="moduleData">Capa de acceso a datos para Module.</param>
        /// <param name="logger">Logger para registro de Module</param>
        public ModuleBusiness(ModuleData moduleData, ILogger<ModuleBusiness> logger)
        {
            _moduleData = moduleData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los Modules y los mapea a objetos <see cref="ModuleDTO"/>.
        /// </summary>
        /// <returns>Una colección de objetos <see cref="ModuleDTO"/> que representan todos los Modules existentes.</returns>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error al intentar recuperar los datos desde la base de datos.
        /// </exception>
        public async Task<IEnumerable<ModuleDTO>> GetAllModulesAsync()
        {
            try
            {
                var modules = await _moduleData.GetAllAsyncSQL();
                return MapToDTOList(modules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los Modules.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de Modules.", ex);
            }
        }


        /// <summary>
        /// Obtiene un Module especifico por su identificador y lo mapea a un objeto <see cref="ModuleDTO"/>.
        /// </summary>
        /// <param name="id">Identificador único del module a buscar. Debe ser mayor que cero.</param>
        /// <returns>Un objeto <see cref="ModuleDTO"/> que representa el module solicitado.</returns>
        /// <exception cref="Utilities.Exceptions.ValidationException">
        /// Se lanza cuando el parámetro <paramref name="id"/> es menor o igual a cero.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza cuando no se encuentra ningún module con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al mapear o recuperar el module desde la base de datos.
        /// </exception>
        public async Task<ModuleDTO> GetModuleByIdAsync(int id)
        {
            var module = await _moduleData.GetByIdAsyncSQL(id);

            if (module == null)
            {
                _logger.LogInformation("No se encontró ningún módulo con ID: {ModuleId}", id);
                throw new EntityNotFoundException("Module", id);
            }

            try
            {
                return MapToDTO(module);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el Module con ID: {ModuleId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el Module con ID {id}.", ex);
            }
        }


        /// <summary>
        /// Crea un nuevo Module en la base de datos a partir de un objeto <see cref="ModuleDTO"/>.
        /// </summary>
        /// <param name="ModuleDto">Objeto <see cref="ModuleDTO"/> que contiene la inmoduleación del module a crear.</param>
        /// <returns>El objeto <see cref="ModuleDTO"/> que representa el Module recién creado, incluyendo su identificador asignado.</returns>
        /// <exception cref="Utilities.Exceptions.ValidationException">
        /// Se lanza si el DTO del module no cumple con las reglas de validación definidas.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error al intentar crear el module en la base de datos.
        /// </exception>
        public async Task<ModuleDTO> CreateModuleAsync(ModuleDTO moduleDTO)
        {
            ValidateModule(moduleDTO);
            try
            {
                var module = MapToEntity(moduleDTO);
                var createdModule = await _moduleData.CreateAsyncSQL(module);

                return MapToDTO(createdModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo Module.");
                throw new ExternalServiceException("Base de datos", "Error al crear el Module.", ex);
            }
        }


        /// <summary>
        /// Actualiza un Module existente en la base de datos con los datos proporcionados en el <see cref="ModuleDTO"/>.
        /// </summary>
        /// <param name="moduleDTO">Objeto <see cref="ModuleDTO"/> con la inmoduleación actualizada del Module. Debe contener un ID válido.</param>
        /// <returns>Un valor booleano que indica si la operación de actualización fue exitosa.</returns>
        /// <exception cref="Utilities.Exceptions.ValidationException">
        /// Se lanza si el DTO del module no cumple con las reglas de validación definidas.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza si no se encuentra ningún module con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al intentar actualizar el module en la base de datos.
        /// </exception>
        public async Task<bool> UpdateModuleAsync(ModuleDTO moduleDTO)
        {
            ValidateModule(moduleDTO);

            var existingModule = await _moduleData.GetByIdAsyncSQL(moduleDTO.Id);
            if (existingModule == null)
            {
                throw new EntityNotFoundException("Module", moduleDTO.Id);
            }

            try
            {
                existingModule.Active = moduleDTO.Status;
                existingModule.Name = moduleDTO.Name;
                existingModule.Description = moduleDTO.Description;

                return await _moduleData.UpdateAsync(existingModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el Module con ID: {ModuleId}", moduleDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el Module.", ex);
            }
        }


        /// <summary>
        /// Elimina un Module existente por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del Module a eliminar.</param>
        /// <returns>Un valor booleano que indica si la eliminación fue exitosa.</returns>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza si no se encuentra ningún Module con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al intentar eliminar el Module desde la base de datos.
        /// </exception>
        public async Task<bool> DeleteModuleAsync(int id)
        {
            var existingModule = await _moduleData.GetByIdAsync(id);
            if (existingModule == null)
            {
                throw new EntityNotFoundException("Module", id);
            }

            try
            {
                return await _moduleData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el Module con ID: {ModuleId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el Module.", ex);
            }
        }


        /// <summary>
        /// Elimina un Module existente de manera logica por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del Module a eliminar de manera logica.</param>
        /// <returns>Un valor booleano que indica si la eliminación logica fue exitosa.</returns>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza si no se encuentra ningún Module con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al intentar eliminar de manera logica el Module desde la base de datos.
        /// </exception>
        public async Task<bool> DeleteModuleLogicalAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("ID", "El ID del Module debe ser mayor que cero.");
            }

            var existingModule = await _moduleData.GetByIdAsyncSQL(id);
            if (existingModule == null)
            {
                throw new EntityNotFoundException("Module", id);
            }

            try
            {
                return await _moduleData.DeleteLogicAsyncSQL(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el Module de manera logica con ID: {FormId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el Module de manera logica.", ex);
            }
        }


        /// <summary>
        /// Valida los datos del módulo.
        /// </summary>
        private void ValidateModule(ModuleDTO moduleDTO)
        {
            if (moduleDTO == null)
            {
                throw new ValidationException("El objeto Module no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(moduleDTO.Name))
            {
                _logger.LogWarning("Intento de crear/actualizar un Module con Name vacío.");
                throw new ValidationException("Name", "El Name del Module es obligatorio.");
            }
        }


        /// <summary>
        /// Mapea un objeto Module a ModuleDTO.
        /// </summary>
        private ModuleDTO MapToDTO(Module module)
        {
            return new ModuleDTO
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                Status = module.Active,
            };
        }


        /// <summary>
        /// Mapea un objeto ModuleDTO a Module.
        /// </summary>
        private Module MapToEntity(ModuleDTO moduleDTO)
        {
            return new Module
            {
                Id = moduleDTO.Id,
                Name = moduleDTO.Name,
                Description = moduleDTO.Description,
                Active = moduleDTO.Status,
            };
        }


        /// <summary>
        /// Metodo para mapear una lista de Module a una lista de ModuleDTO 
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        private IEnumerable<ModuleDTO> MapToDTOList(IEnumerable<Module> modules)
        {
            var modulesDTO = new List<ModuleDTO>();
            foreach (var module in modules)
            {
                modulesDTO.Add(MapToDTO(module));
            }
            return modulesDTO;
        }
    }
}

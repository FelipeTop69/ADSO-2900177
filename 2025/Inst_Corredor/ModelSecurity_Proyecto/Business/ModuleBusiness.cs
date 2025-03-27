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
    public class ModuleBusiness
    {
        private readonly ModuleData _moduleData;
        private readonly ILogger<ModuleBusiness> _logger;

        public ModuleBusiness(ModuleData moduleData, ILogger<ModuleBusiness> logger)
        {
            _moduleData = moduleData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los módulos como DTOs.
        /// </summary>
        public async Task<IEnumerable<ModuleDTO>> GetAllModulesAsync()
        {
            try
            {
                var modules = await _moduleData.GetAllAsync();
                return MapToDTOList(modules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los módulos.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de módulos.", ex);
            }
        }


        /// <summary>
        /// Obtiene un módulo por ID como DTO.
        /// </summary>
        public async Task<ModuleDTO> GetModuleByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Intento de obtener un módulo con ID inválido: {ModuleId}", id);
                throw new ValidationException("id", "El ID del módulo debe ser mayor que cero.");
            }

            try
            {
                var module = await _moduleData.GetByIdAsync(id);
                if (module == null)
                {
                    _logger.LogInformation("No se encontró ningún módulo con ID: {ModuleId}", id);
                    throw new EntityNotFoundException("Module", id);
                }

                return MapToDTO(module);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el módulo con ID: {ModuleId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el módulo con ID {id}.", ex);
            }
        }


        /// <summary>
        /// Crea un nuevo módulo.
        /// </summary>
        public async Task<ModuleDTO> CreateModuleAsync(ModuleDTO moduleDTO)
        {
            try
            {
                ValidateModule(moduleDTO);

                var module = MapToEntity(moduleDTO);
                var createdModule = await _moduleData.CreateAsync(module);

                return MapToDTO(createdModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo módulo.");
                throw new ExternalServiceException("Base de datos", "Error al crear el módulo.", ex);
            }
        }


        /// <summary>
        /// Actualiza un módulo existente.
        /// </summary>
        public async Task<bool> UpdateModuleAsync(ModuleDTO moduleDTO)
        {
            try
            {
                ValidateModule(moduleDTO);

                var existingModule = await _moduleData.GetByIdAsync(moduleDTO.Id);
                if (existingModule == null)
                {
                    throw new EntityNotFoundException("Module", moduleDTO.Id);
                }

                // Actualizar propiedades
                existingModule.Name = moduleDTO.Name;
                existingModule.Description = moduleDTO.Description;

                return await _moduleData.UpdateAsync(existingModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el módulo con ID: {ModuleId}", moduleDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el módulo.", ex);
            }
        }


        /// <summary>
        /// Elimina un módulo por ID.
        /// </summary>
        public async Task<bool> DeleteModuleAsync(int id)
        {
            try
            {
                var existingModule = await _moduleData.GetByIdAsync(id);
                if (existingModule == null)
                {
                    throw new EntityNotFoundException("Module", id);
                }

                return await _moduleData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el módulo con ID: {ModuleId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el módulo.", ex);
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
                _logger.LogWarning("Intento de crear/actualizar un módulo con Name vacío.");
                throw new ValidationException("Name", "El Name del módulo es obligatorio.");
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
                Description = module.Description
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
                Description = moduleDTO.Description
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

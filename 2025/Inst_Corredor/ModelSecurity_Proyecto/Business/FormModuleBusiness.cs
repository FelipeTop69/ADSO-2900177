﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity.DTOs.FormModuleDTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business
{
    public class FormModuleBusiness
    {
        private readonly FormModuleData _formModuleData;
        private readonly ILogger<FormModuleBusiness> _logger;

        public FormModuleBusiness(FormModuleData formModuleData, ILogger<FormModuleBusiness> logger)
        {
            _formModuleData = formModuleData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las relaciones FormModule como DTOs.
        /// </summary>
        public async Task<IEnumerable<FormModuleDTO>> GetAllFormModulesAsync()
        {
            try
            {
                var formModules = await _formModuleData.GetAllAsyncSQL();
                return formModules;
                //return MapToDTOList(formModules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las relaciones FormModule.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de relaciones FormModule.", ex);
            }
        }


        /// <summary>
        /// Obtiene una relación FormModule por ID como DTO.
        /// </summary>
        public async Task<FormModuleDTO> GetFormModuleByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Intento de obtener una relación FormModule con ID inválido: {FormModuleId}", id);
                throw new ValidationException("id", "El ID de la relación FormModule debe ser mayor que cero.");
            }

            var formModule = await _formModuleData.GetByIdAsyncSQL(id);
            if (formModule == null)
            {
                _logger.LogInformation("No se encontró ninguna relación FormModule con ID: {FormModuleId}", id);
                throw new EntityNotFoundException("FormModule", id);
            }

            try
            {
                return formModule;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la relación FormModule con ID: {FormModuleId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar la relación FormModule con ID {id}.", ex);
            }
        }


        /// <summary>
        /// Crea una nueva relación FormModule.
        /// </summary>
        public async Task<FormModuleOptionsDTO> CreateFormModuleAsync(FormModuleOptionsDTO formModuleDTO)
        {
            ValidateFormModule(formModuleDTO);

            try
            {
                var formModule = MapToEntity(formModuleDTO);
                var createdFormModule = await _formModuleData.CreateAsync(formModule);

                return MapToDTO(createdFormModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear una nueva relación FormModule.");
                throw new ExternalServiceException("Base de datos", "Error al crear la relación FormModule.", ex);
            }
        }


        /// <summary>
        /// Actualiza una relación FormModule existente.
        /// </summary>
        public async Task<bool> UpdateFormModuleAsync(FormModuleOptionsDTO formModuleDTO)
        {

            var existingFormModule = await _formModuleData.GetByIdAsync(formModuleDTO.Id);
            if (existingFormModule == null)
            {
                throw new EntityNotFoundException("FormModule", formModuleDTO.Id);
            }

            ValidateFormModule(formModuleDTO);


            try
            {

                existingFormModule.Active = formModuleDTO.Status;
                existingFormModule.FormId = formModuleDTO.FormId;
                existingFormModule.ModuleId = formModuleDTO.ModuleId;

                return await _formModuleData.UpdateAsync(existingFormModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la relación FormModule con ID: {FormModuleId}", formModuleDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar la relación FormModule.", ex);
            }
        }


        /// <summary>
        /// Elimina una relación FormModule por ID.
        /// </summary>
        public async Task<bool> DeleteFormModuleAsync(int id)
        {
            var existingFormModule = await _formModuleData.GetByIdAsyncSQL(id);
            if (existingFormModule == null)
            {
                throw new EntityNotFoundException("FormModule", id);
            }
            try
            {
                return await _formModuleData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la relación FormModule con ID: {FormModuleId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar la relación FormModule.", ex);
            }
        }


        /// <summary>
        /// Elimina un FormModule de manera logica por ID
        /// </summary>
        public async Task<bool> DeleteFormModuleLogicalAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("ID", "El ID del formModule debe ser mayor que cero.");
            }

            var existingUser = await _formModuleData.GetByIdAsyncSQL(id);
            if (existingUser == null)
            {
                throw new EntityNotFoundException("FormModule", id);
            }
            try
            {

                return await _formModuleData.DeleteLogicAsyncSQL(id);

            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error en servicio externo al eliminar el formModule con ID: {FormModuleId}", id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el formModule de manera logica con ID: {FormModuleId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el user de manera logica.", ex);
            }
        }


        /// <summary>
        /// Valida los datos de la relación FormModule.
        /// </summary>
        private void ValidateFormModule(FormModuleOptionsDTO formModuleDTO)
        {
            if (formModuleDTO == null)
            {
                throw new ValidationException("El objeto FormModule no puede ser nulo.");
            }

            if (formModuleDTO.FormId <= 0)
            {
                _logger.LogWarning("Intento de crear/actualizar un FormModule con FormId inválido.");
                throw new ValidationException("FormId", "El FormId es obligatorio y debe ser mayor que cero.");
            }

            if (formModuleDTO.ModuleId <= 0)
            {
                _logger.LogWarning("Intento de crear/actualizar un FormModule con ModuleId inválido.");
                throw new ValidationException("ModuleId", "El ModuleId es obligatorio y debe ser mayor que cero.");
            }
        }


        /// <summary>
        /// Mapea un objeto FormModule a FormModuleDTO.
        /// </summary>
        private FormModuleOptionsDTO MapToDTO(FormModule formModule)
        {
            return new FormModuleOptionsDTO
            {
                Id = formModule.Id,
                Status = formModule.Active,

                FormId = formModule.FormId,

                ModuleId = formModule.ModuleId,
            };
        }


        /// <summary>
        /// Mapea un objeto FormModuleDTO a FormModule.
        /// </summary>
        private FormModule MapToEntity(FormModuleOptionsDTO formModuleOptionsDTO)
        {
            return new FormModule
            {
                Id = formModuleOptionsDTO.Id,
                Active = formModuleOptionsDTO.Status,
                FormId = formModuleOptionsDTO.FormId,
                ModuleId = formModuleOptionsDTO.ModuleId
            };
        }


        /// <summary>
        /// Metodo para mapear una lista de FormModule a una lista de ForModuleDTO 
        /// </summary>
        /// <param name="formModule"></param>
        /// <returns></returns>
        private IEnumerable<FormModuleDTO> MapToDTOList(IEnumerable<FormModule> formModule)
        {
            var formModuleDTO = new List<FormModuleDTO>();
            foreach (var formModule1 in formModule)
            {
                //formModuleDTO.Add(MapToDTO(formModule1));
            }
            return formModuleDTO;
        }

    }
}

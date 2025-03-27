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
    public class PermissionBusiness
    {
        private readonly PermissionData _permissionData;
        private readonly ILogger<PermissionBusiness> _logger;

        public PermissionBusiness(PermissionData permissionData, ILogger<PermissionBusiness> logger)
        {
            _permissionData = permissionData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los permisos como DTOs.
        /// </summary>
        public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync()
        {
            try
            {
                var permissions = await _permissionData.GetAllAsync();
                return permissions.Select(MapToDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los permisos.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de permisos.", ex);
            }
        }

        /// <summary>
        /// Obtiene un permiso por ID como DTO.
        /// </summary>
        public async Task<PermissionDTO> GetPermissionByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Intento de obtener un permiso con ID inválido: {PermissionId}", id);
                throw new ValidationException("id", "El ID del permiso debe ser mayor que cero.");
            }

            try
            {
                var permission = await _permissionData.GetByIdAsync(id);
                if (permission == null)
                {
                    _logger.LogInformation("No se encontró ningún permiso con ID: {PermissionId}", id);
                    throw new EntityNotFoundException("Permission", id);
                }

                return MapToDTO(permission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el permiso con ID: {PermissionId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el permiso con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo permiso.
        /// </summary>
        public async Task<PermissionDTO> CreatePermissionAsync(PermissionDTO permissionDTO)
        {
            try
            {
                ValidatePermission(permissionDTO);

                var permission = MapToEntity(permissionDTO);
                var createdPermission = await _permissionData.CreateAsync(permission);

                return MapToDTO(createdPermission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo permiso.");
                throw new ExternalServiceException("Base de datos", "Error al crear el permiso.", ex);
            }
        }

        /// <summary>
        /// Actualiza un permiso existente.
        /// </summary>
        public async Task<bool> UpdatePermissionAsync(PermissionDTO permissionDTO)
        {
            try
            {
                ValidatePermission(permissionDTO);

                var existingPermission = await _permissionData.GetByIdAsync(permissionDTO.Id);
                if (existingPermission == null)
                {
                    throw new EntityNotFoundException("Permission", permissionDTO.Id);
                }

                // Actualizar propiedades
                existingPermission.Name = permissionDTO.Name;
                existingPermission.Description = permissionDTO.Description;

                return await _permissionData.UpdateAsync(existingPermission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el permiso con ID: {PermissionId}", permissionDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el permiso.", ex);
            }
        }

        /// <summary>
        /// Elimina un permiso por ID.
        /// </summary>
        public async Task<bool> DeletePermissionAsync(int id)
        {
            try
            {
                var existingPermission = await _permissionData.GetByIdAsync(id);
                if (existingPermission == null)
                {
                    throw new EntityNotFoundException("Permission", id);
                }

                return await _permissionData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el permiso con ID: {PermissionId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el permiso.", ex);
            }
        }

        /// <summary>
        /// Valida los datos del permiso.
        /// </summary>
        private void ValidatePermission(PermissionDTO permissionDTO)
        {
            if (permissionDTO == null)
            {
                throw new ValidationException("El objeto permiso no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(permissionDTO.Name))
            {
                _logger.LogWarning("Intento de crear/actualizar un permiso con Name vacío.");
                throw new ValidationException("Name", "El nombre del permiso es obligatorio.");
            }
        }

        /// <summary>
        /// Mapea un objeto Permission a PermissionDTO.
        /// </summary>
        private PermissionDTO MapToDTO(Permission permission)
        {
            return new PermissionDTO
            {
                Id = permission.Id,
                Name = permission.Name,
                Description = permission.Description
            };
        }

        /// <summary>
        /// Mapea un objeto PermissionDTO a Permission.
        /// </summary>
        private Permission MapToEntity(PermissionDTO permissionDTO)
        {
            return new Permission
            {
                Id = permissionDTO.Id,
                Name = permissionDTO.Name,
                Description = permissionDTO.Description
            };
        }
    }
}

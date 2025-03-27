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
    public class RolUserBusiness
    {
        private readonly RolUserData _rolUserData;
        private readonly ILogger<RolUserBusiness> _logger;

        public RolUserBusiness(RolUserData rolUserData, ILogger<RolUserBusiness> logger)
        {
            _rolUserData = rolUserData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los registros de RolUser como DTOs.
        /// </summary>
        public async Task<IEnumerable<RolUserDTO>> GetAllRolUsersAsync()
        {
            try
            {
                var rolUsers = await _rolUserData.GetAllAsync();
                return rolUsers.Select(MapToDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los registros de RolUser.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de RolUser.", ex);
            }
        }

        /// <summary>
        /// Obtiene un RolUser por ID como DTO.
        /// </summary>
        public async Task<RolUserDTO> GetRolUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Intento de obtener un RolUser con ID inválido: {RolUserId}", id);
                throw new ValidationException("id", "El ID de RolUser debe ser mayor que cero.");
            }

            try
            {
                var rolUser = await _rolUserData.GetByIdAsync(id);
                if (rolUser == null)
                {
                    _logger.LogInformation("No se encontró ningún RolUser con ID: {RolUserId}", id);
                    throw new EntityNotFoundException("RolUser", id);
                }

                return MapToDTO(rolUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el RolUser con ID: {RolUserId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el RolUser con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Crea una nueva asignación de RolUser.
        /// </summary>
        public async Task<RolUserDTO> CreateRolUserAsync(RolUserDTO rolUserDTO)
        {
            try
            {
                ValidateRolUser(rolUserDTO);

                var rolUser = MapToEntity(rolUserDTO);
                var createdRolUser = await _rolUserData.CreateAsync(rolUser);

                return MapToDTO(createdRolUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo RolUser.");
                throw new ExternalServiceException("Base de datos", "Error al crear la asignación de RolUser.", ex);
            }
        }

        /// <summary>
        /// Actualiza una asignación existente de RolUser.
        /// </summary>
        public async Task<bool> UpdateRolUserAsync(RolUserDTO rolUserDTO)
        {
            try
            {
                ValidateRolUser(rolUserDTO);

                var existingRolUser = await _rolUserData.GetByIdAsync(rolUserDTO.Id);
                if (existingRolUser == null)
                {
                    throw new EntityNotFoundException("RolUser", rolUserDTO.Id);
                }

                // Actualizar propiedades
                existingRolUser.UserId = rolUserDTO.UserId;
                existingRolUser.RoleId = rolUserDTO.RoleId;

                return await _rolUserData.UpdateAsync(existingRolUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el RolUser con ID: {RolUserId}", rolUserDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el RolUser.", ex);
            }
        }

        /// <summary>
        /// Elimina una asignación de RolUser por ID.
        /// </summary>
        public async Task<bool> DeleteRolUserAsync(int id)
        {
            try
            {
                var existingRolUser = await _rolUserData.GetByIdAsync(id);
                if (existingRolUser == null)
                {
                    throw new EntityNotFoundException("RolUser", id);
                }

                return await _rolUserData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el RolUser con ID: {RolUserId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el RolUser.", ex);
            }
        }

        /// <summary>
        /// Valida los datos de RolUser.
        /// </summary>
        private void ValidateRolUser(RolUserDTO rolUserDTO)
        {
            if (rolUserDTO == null)
            {
                throw new ValidationException("El objeto RolUser no puede ser nulo.");
            }

            if (rolUserDTO.UserId <= 0)
            {
                _logger.LogWarning("Intento de crear/actualizar un RolUser con UserId inválido.");
                throw new ValidationException("UserId", "El ID del usuario debe ser mayor que cero.");
            }

            if (rolUserDTO.RoleId <= 0)
            {
                _logger.LogWarning("Intento de crear/actualizar un RolUser con RoleId inválido.");
                throw new ValidationException("RoleId", "El ID del rol debe ser mayor que cero.");
            }
        }

        /// <summary>
        /// Mapea un objeto RolUser a RolUserDTO.
        /// </summary>
        private RolUserDTO MapToDTO(RolUser rolUser)
        {
            return new RolUserDTO
            {
                Id = rolUser.Id,
                UserId = rolUser.UserId,
                UserName = rolUser.User?.Username,
                RoleId = rolUser.RoleId,
                RoleName = rolUser.Rol?.Name
            };
        }

        /// <summary>
        /// Mapea un objeto RolUserDTO a RolUser.
        /// </summary>
        private RolUser MapToEntity(RolUserDTO rolUserDTO)
        {
            return new RolUser
            {
                Id = rolUserDTO.Id,
                UserId = rolUserDTO.UserId,
                RoleId = rolUserDTO.RoleId
            };
        }


    }
}

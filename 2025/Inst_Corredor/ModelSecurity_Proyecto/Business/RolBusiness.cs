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
    ///<summary>
    ///Clase de negocio encargada de la logica relacionada con lso roles del sistema;
    ///</summary>
    public class RolBusiness
    {
        private readonly RolData _rolData;
        private readonly ILogger _logger;

        public RolBusiness(RolData rolData, ILogger logger)
        {
            _rolData = rolData;
            _logger = logger;
        }

        /// <summary>
        /// Metodo para obtener todos los roles como DTOs
        /// </summary>
        public async Task<IEnumerable<RolDTO>> GetAllRolesAsync()
        {
            try
            {
                var roles = await _rolData.GetAllAsync();
                return MapToDTOList(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los roles");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de roles", ex);
            }
        }


        /// <summary>
        /// Metodo para obtener un rol por ID como DTO 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Utilities.Exceptions.ValidationException"></exception>
        /// <exception cref="ExternalServiceException"></exception>
        public async Task<RolDTO> GetRolByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Se intentó obtener un rol con ID inválido: {RolId}", id);
                throw new Utilities.Exceptions.ValidationException("id", "El ID del rol debe ser mayor que cero");
            }

            try
            {
                var rol = await _rolData.GetByIdAsync(id);
                if (rol == null)
                {
                    _logger.LogInformation("No se encontró ningún rol con ID: {RolId}", id);
                    throw new EntityNotFoundException("Rol", id);
                }

                // Metodo
                return MapToDTO(rol);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el rol con ID: {RolId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el rol con ID {id}", ex);
            }
        }


        /// <summary>
        /// Metodo para crear un rol desde un DTO 
        /// </summary>
        /// <param name="RolDto"></param>
        /// <returns></returns>
        /// <exception cref="ExternalServiceException"></exception>
        public async Task<RolDTO> CreateRolAsync(RolDTO RolDto)
        {
            try
            {
                ValidateRol(RolDto);

                var rol = MapToEntity(RolDto);

                var rolCreado = await _rolData.CreateAsync(rol);

                return MapToDTO(rolCreado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear nuevo rol: {RolNombre}", RolDto?.Name ?? "null");
                throw new ExternalServiceException("Base de datos", "Error al crear el rol", ex);
            }
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        public async Task<bool> UpdateUserAsync(RolDTO rolDTO)
        {
            try
            {
                ValidateRol(rolDTO);

                var existingRol = await _rolData.GetByIdAsync(rolDTO.Id);
                if (existingRol == null)
                {
                    throw new EntityNotFoundException("Rol", rolDTO.Id);
                }

                // Actualizar propiedades
                existingRol.Id = rolDTO.Id;
                existingRol.Name = rolDTO.Name;
                existingRol.Description = rolDTO.Description;
                existingRol.Active = rolDTO.Status;

                return await _rolData.UpdateAsync(existingRol);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el usuario con ID: {UserId}", rolDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el usuario.", ex);
            }
        }


        /// <summary>
        /// Elimina un rol por ID.
        /// </summary>
        public async Task<bool> DeleteRolAsync(int id)
        {
            try
            {
                var existingRol = await _rolData.GetByIdAsync(id);
                if (existingRol == null)
                {
                    throw new EntityNotFoundException("Rol", id);
                }

                return await _rolData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el rol con ID: {UserId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el rol.", ex);
            }
        }


        /// <summary>
        /// Metodo para Validar el Rol
        /// </summary>
        /// <param name="RolDto"></param>
        /// <exception cref="Utilities.Exceptions.ValidationException"></exception>
        private void ValidateRol(RolDTO RolDto)
        {
            if (RolDto == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto rol no puede ser nulo");
            }

            if (string.IsNullOrWhiteSpace(RolDto.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar un rol con Name vacío");
                throw new Utilities.Exceptions.ValidationException("Name", "El Name del rol es obligatorio");
            }
        }


        /// <summary>
        /// Método para mapear de Rol a RolDTO
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        private RolDTO MapToDTO(Rol rol)
        {
            return new RolDTO
            {
                Id = rol.Id,
                Name = rol.Name,
                Status = rol.Active,// Si existe en la entidad
                Description = rol.Description 
            };
        }


        /// <summary>
        /// Metodo para mapear de RolDTO a Rol 
        /// </summary>
        /// <param name="rolDTO"></param>
        /// <returns></returns>
        private Rol MapToEntity(RolDTO rolDTO)
        {
            return new Rol
            {
                Id = rolDTO.Id,
                Name = rolDTO.Name,
                Active = rolDTO.Status,
                Description = rolDTO.Description // Si existe en la entidad
            };
        }


        /// <summary>
        /// Metodo para mapear una lista de Rol a una lista de RolDTO 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        private IEnumerable<RolDTO> MapToDTOList(IEnumerable<Rol> roles)
        {
            var rolesDTO = new List<RolDTO>();
            foreach (var rol in roles)
            {
                rolesDTO.Add(MapToDTO(rol));
            }
            return rolesDTO;
        }
    }
}

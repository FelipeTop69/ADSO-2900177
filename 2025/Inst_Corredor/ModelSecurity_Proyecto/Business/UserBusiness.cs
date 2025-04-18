﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity.DTOs.UserDTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business
{
    public class UserBusiness
    {
        private readonly UserData _userData;
        private readonly ILogger<UserBusiness> _logger;

        public UserBusiness(UserData userData, ILogger<UserBusiness> logger)
        {
            _userData = userData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los usuarios como DTOs.
        /// </summary>
        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                return  await _userData.GetAllAsyncSQL();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usuarios.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de usuarios.", ex);
            }
        }


        /// <summary>
        /// Obtiene un usuario por ID como DTO.
        /// </summary>
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Intento de obtener un usuario con ID inválido: {UserId}", id);
                throw new ValidationException("id", "El ID del usuario debe ser mayor que cero.");
            }
            var user = await _userData.GetByIdAsyncSQL(id);
            if (user == null)
            {
                _logger.LogInformation("No se encontró ningún usuario con ID: {UserId}", id);
                throw new EntityNotFoundException("User", id);
            }
            try
            {
                

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el usuario con ID: {UserId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el usuario con ID {id}.", ex);
            }
        }


        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        public async Task<UserCreateDTO> CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            ValidateUser(userCreateDTO);

            try
            {
                var user = MapCreateToEntity(userCreateDTO);
                var createdUser = await _userData.CreateAsync(user);

                return MapToCreateDTO(createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo usuario: {Username}", userCreateDTO?.Username ?? "null");
                throw new ExternalServiceException("Base de datos", "Error al crear el usuario.", ex);
            }
        }


        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        public async Task<bool> UpdateUserAsync(UserCreateDTO userCreateDTO)
        {

            ValidateUser(userCreateDTO);

            var existingUser = await _userData.GetByIdAsync(userCreateDTO.Id);
            if (existingUser == null)
            {
                throw new EntityNotFoundException("User", userCreateDTO.Id);
            }

            try
            {
                

                // Actualizar propiedades
                existingUser.Username = userCreateDTO.Username;
                existingUser.Password = userCreateDTO.Password;
                existingUser.Active = userCreateDTO.Status;
                existingUser.PersonId = userCreateDTO.PersonId;

                return await _userData.UpdateAsync(existingUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el usuario con ID: {UserId}", userCreateDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el usuario.", ex);
            }
        }


        /// <summary>
        /// Elimina un usuario por ID.
        /// </summary>
        public async Task<bool> DeleteUserAsync(int id)
        {
            var existingUser = await _userData.GetByIdAsyncSQL(id);
            if (existingUser == null)
            {
                throw new EntityNotFoundException("User", id);
            }

            try
            {
                return await _userData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el usuario con ID: {UserId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el usuario.", ex);
            }
        }


        /// <summary>
        /// Elimina un user de manera logica por ID
        /// </summary>
        public async Task<bool> DeleteUserLogicalAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("ID", "El ID del user debe ser mayor que cero.");
            }

            var existingUser = await _userData.GetByIdAsyncSQL(id);
            if (existingUser == null)
            {
                throw new EntityNotFoundException("User", id);
            }

            try
            {

                return await _userData.DeleteLogicAsyncSQL(id);

            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error en servicio externo al eliminar el user con ID: {UserId}", id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el user de manera logica con ID: {UserId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el user de manera logica.", ex);
            }
        }


        /// <summary>
        /// Valida los datos del usuario.
        /// </summary>
        private void ValidateUser(UserCreateDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ValidationException("El objeto usuario no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(userDTO.Username))
            {
                _logger.LogWarning("Intento de crear/actualizar un usuario con Username vacío.");
                throw new ValidationException("Username", "El nombre de usuario es obligatorio.");
            }
        }


        /// <summary>
        /// Mapea un objeto User a UserDTO.
        /// </summary>
        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Status = user.Active,
                PersonId = user.PersonId,
            };

        }


        /// <summary>
        /// Mapea un objeto UserDTO a User.
        /// </summary>
        private User MapToEntity(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Active = userDTO.Status,
                PersonId = userDTO.PersonId
            };
        }


        /// <summary>
        /// Mapea un objeto User a UserCreateDTO.
        /// </summary>
        private UserCreateDTO MapToCreateDTO(User user)
        {
            return new UserCreateDTO
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Status = user.Active,
                PersonId = user.PersonId,
            };

        }


        /// <summary>
        /// Mapea un objeto UserCreateDTO a User.
        /// </summary>
        private User MapCreateToEntity(UserCreateDTO userCreateDTO)
        {
            return new User
            {
                Id = userCreateDTO.Id,
                Username = userCreateDTO.Username,
                Password = userCreateDTO.Password,
                Active = userCreateDTO.Status,
                PersonId = userCreateDTO.PersonId
            };
        }


        /// <summary>
        /// Metodo para mapear una lista de User a una lista de UserDTO 
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        private IEnumerable<UserDTO> MapToDTOList(IEnumerable<User> users)
        {
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(MapToDTO(user));
            }
            return usersDTO;
        }
    }
}

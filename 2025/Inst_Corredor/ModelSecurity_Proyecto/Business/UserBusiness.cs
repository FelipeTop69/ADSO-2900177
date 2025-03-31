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
                var users = await _userData.GetAllAsync();
                return MapToDTOList(users);
                
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

            try
            {
                var user = await _userData.GetByIdAsync(id);
                if (user == null)
                {
                    _logger.LogInformation("No se encontró ningún usuario con ID: {UserId}", id);
                    throw new EntityNotFoundException("User", id);
                }

                return MapToDTO(user);
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
        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                ValidateUser(userDTO);

                var user = MapToEntity(userDTO);
                var createdUser = await _userData.CreateAsync(user);

                return MapToDTO(createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo usuario: {Username}", userDTO?.Username ?? "null");
                throw new ExternalServiceException("Base de datos", "Error al crear el usuario.", ex);
            }
        }


        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        public async Task<bool> UpdateUserAsync(UserDTO userDTO)
        {
            try
            {
                ValidateUser(userDTO);

                var existingUser = await _userData.GetByIdAsync(userDTO.Id);
                if (existingUser == null)
                {
                    throw new EntityNotFoundException("User", userDTO.Id);
                }

                // Actualizar propiedades
                existingUser.Username = userDTO.Username;
                existingUser.Active = userDTO.Status;
                existingUser.PersonId = userDTO.PersonId;

                return await _userData.UpdateAsync(existingUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el usuario con ID: {UserId}", userDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el usuario.", ex);
            }
        }


        /// <summary>
        /// Elimina un usuario por ID.
        /// </summary>
        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var existingUser = await _userData.GetByIdAsync(id);
                if (existingUser == null)
                {
                    throw new EntityNotFoundException("User", id);
                }

                return await _userData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el usuario con ID: {UserId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el usuario.", ex);
            }
        }


        /// <summary>
        /// Valida los datos del usuario.
        /// </summary>
        private void ValidateUser(UserDTO userDTO)
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
                Status = user.Active,
                PersonId = user.PersonId,
                PersonName = user.Person?.FirstName + " " + user.Person?.LastName
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

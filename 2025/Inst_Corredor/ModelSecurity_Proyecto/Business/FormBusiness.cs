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
    public class FormBusiness
    {
        private readonly FormData _formData;
        private readonly ILogger<FormBusiness> _logger;

        public FormBusiness(FormData formData, ILogger<FormBusiness> logger)
        {
            _formData = formData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los formularios como DTOs.
        /// </summary>
        public async Task<IEnumerable<FormDTO>> GetAllFormsAsync()
        {
            try
            {
                var forms = await _formData.GetAllAsync();
                return MapToDTOList(forms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los formularios.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de formularios.", ex);
            }
        }


        /// <summary>
        /// Obtiene un formulario por ID como DTO.
        /// </summary>
        public async Task<FormDTO> GetFormByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Intento de obtener un formulario con ID inválido: {FormId}", id);
                throw new ValidationException("id", "El ID del formulario debe ser mayor que cero.");
            }

            try
            {
                var form = await _formData.GetByIdAsync(id);
                if (form == null)
                {
                    _logger.LogInformation("No se encontró ningún formulario con ID: {FormId}", id);
                    throw new EntityNotFoundException("Form", id);
                }

                return MapToDTO(form);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el formulario con ID: {FormId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el formulario con ID {id}.", ex);
            }
        }


        /// <summary>
        /// Crea un nuevo formulario.
        /// </summary>
        public async Task<FormDTO> CreateFormAsync(FormDTO formDTO)
        {
            try
            {
                ValidateForm(formDTO);

                var form = MapToEntity(formDTO);
                var createdForm = await _formData.CreateAsync(form);

                return MapToDTO(createdForm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo formulario.");
                throw new ExternalServiceException("Base de datos", "Error al crear el formulario.", ex);
            }
        }


        /// <summary>
        /// Actualiza un formulario existente.
        /// </summary>
        public async Task<bool> UpdateFormAsync(FormDTO formDTO)
        {
            try
            {
                ValidateForm(formDTO);

                var existingForm = await _formData.GetByIdAsync(formDTO.Id);
                if (existingForm == null)
                {
                    throw new EntityNotFoundException("Form", formDTO.Id);
                }

                // Actualizar propiedades
                existingForm.Name = formDTO.Name;
                existingForm.Description = formDTO.Description;

                return await _formData.UpdateAsync(existingForm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el formulario con ID: {FormId}", formDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error al actualizar el formulario.", ex);
            }
        }


        /// <summary>
        /// Elimina un formulario por ID.
        /// </summary>
        public async Task<bool> DeleteFormAsync(int id)
        {
            try
            {
                var existingForm = await _formData.GetByIdAsync(id);
                if (existingForm == null)
                {
                    throw new EntityNotFoundException("Form", id);
                }

                return await _formData.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el formulario con ID: {FormId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el formulario.", ex);
            }
        }


        /// <summary>
        /// Valida los datos del formulario.
        /// </summary>
        private void ValidateForm(FormDTO formDTO)
        {
            if (formDTO == null)
            {
                throw new ValidationException("El objeto formulario no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(formDTO.Name))
            {
                _logger.LogWarning("Intento de crear/actualizar un formulario con Name vacío.");
                throw new ValidationException("Name", "El nombre del formulario es obligatorio.");
            }
        }


        /// <summary>
        /// Mapea un objeto Form a FormDTO.
        /// </summary>
        private FormDTO MapToDTO(Form form)
        {
            return new FormDTO
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description
            };
        }


        /// <summary>
        /// Mapea un objeto FormDTO a Form.
        /// </summary>
        private Form MapToEntity(FormDTO formDTO)
        {
            return new Form
            {
                Id = formDTO.Id,
                Name = formDTO.Name,
                Description = formDTO.Description
            };
        }

        /// <summary>
        /// Metodo para mapear una lista de Form a una lista de FormDTO 
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        private IEnumerable<FormDTO> MapToDTOList(IEnumerable<Form> forms)
        {
            var formsDTO = new List<FormDTO>();
            foreach (var form in forms)
            {
                formsDTO.Add(MapToDTO(form));
            }
            return formsDTO;
        }
    }
}

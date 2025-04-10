﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using Utilities.Exceptions;

namespace Business
{
    ///<summary>
    ///Clase de negocio encargada de la logica relacionada con Form en el sistema;
    ///</summary>
    public class FormBusiness
    {
        private readonly FormData _formData;
        private readonly ILogger<FormBusiness> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormBusiness"/>.
        /// </summary>
        /// <param name="formData">Capa de acceso a datos para Form.</param>
        /// <param name="logger">Logger para registro de Form</param>
        public FormBusiness(FormData formData, ILogger<FormBusiness> logger)
        {
            _formData = formData;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los Forms y los mapea a objetos <see cref="FormDTO"/>.
        /// </summary>
        /// <returns>Una colección de objetos <see cref="FormDTO"/> que representan todos los Forms existentes.</returns>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error al intentar recuperar los datos desde la base de datos.
        /// </exception>
        public async Task<IEnumerable<FormDTO>> GetAllFormsAsync()
        {
            try
            {
                var forms = await _formData.GetAllAsyncSQL();
                return MapToDTOList(forms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los Forms.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de Forms.", ex);
            }
        }


        /// <summary>
        /// Obtiene un Form especifico por su identificador y lo mapea a un objeto <see cref="FormDTO"/>.
        /// </summary>
        /// <param name="id">Identificador único del form a buscar. Debe ser mayor que cero.</param>
        /// <returns>Un objeto <see cref="FormDTO"/> que representa el form solicitado.</returns>
        /// <exception cref="Utilities.Exceptions.ValidationException">
        /// Se lanza cuando el parámetro <paramref name="id"/> es menor o igual a cero.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza cuando no se encuentra ningún form con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al mapear o recuperar el form desde la base de datos.
        /// </exception>
        public async Task<FormDTO> GetFormByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Se intentó obtener un Form con ID inválido: {FormId}", id);
                throw new Utilities.Exceptions.ValidationException("id", "El ID del Form debe ser mayor que cero");
            }

            var form = await _formData.GetByIdAsyncSQL(id);

            if (form == null)
            {
                _logger.LogInformation("No se encontró ningún Form con ID: {FormId}", id);
                throw new EntityNotFoundException("Form", id);
            }

            try
            { 
                return MapToDTO(form);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el Form con ID: {FormId}", id);
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el Form con ID {id}.", ex);
            }
        }


        /// <summary>
        /// Crea un nuevo Form en la base de datos a partir de un objeto <see cref="FormDTO"/>.
        /// </summary>
        /// <param name="FormDto">Objeto <see cref="FormDTO"/> que contiene la información del form a crear.</param>
        /// <returns>El objeto <see cref="FormDTO"/> que representa el Form recién creado, incluyendo su identificador asignado.</returns>
        /// <exception cref="Utilities.Exceptions.ValidationException">
        /// Se lanza si el DTO del form no cumple con las reglas de validación definidas.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error al intentar crear el form en la base de datos.
        /// </exception>
        public async Task<FormDTO> CreateFormAsync(FormDTO formDTO)
        {
            try
            {
                ValidateForm(formDTO);

                var form = MapToEntity(formDTO);
                var createdForm = await _formData.CreateAsyncSQL(form);

                return MapToDTO(createdForm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear nuevo Form: {FormNombre}", formDTO?.Name ?? "null");
                throw new ExternalServiceException("Base de datos", "Error al crear el Form.", ex);
            }
        }


        /// <summary>
        /// Actualiza un Form existente en la base de datos con los datos proporcionados en el <see cref="FormDTO"/>.
        /// </summary>
        /// <param name="formDTO">Objeto <see cref="FormDTO"/> con la información actualizada del Form. Debe contener un ID válido.</param>
        /// <returns>Un valor booleano que indica si la operación de actualización fue exitosa.</returns>
        /// <exception cref="Utilities.Exceptions.ValidationException">
        /// Se lanza si el DTO del form no cumple con las reglas de validación definidas.
        /// </exception>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza si no se encuentra ningún form con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al intentar actualizar el form en la base de datos.
        /// </exception>
        public async Task<bool> UpdateFormAsync(FormDTO formDTO)
        {
            if (formDTO.Id <= 0)
            {
                throw new ValidationException("El ID del Form debe ser mayor a cero.");
            }

            ValidateForm(formDTO);

            var existingForm = await _formData.GetByIdAsyncSQL(formDTO.Id);
            if (existingForm == null)
            {
                throw new EntityNotFoundException("Form", formDTO.Id);
            }

            try
            {
                existingForm.Active = formDTO.Status;
                existingForm.Name = formDTO.Name;
                existingForm.Description = formDTO.Description;

                return await _formData.UpdateAsync(existingForm);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error inesperado al actualizar el Form con ID: {FormId}", formDTO.Id);
                throw new ExternalServiceException("Base de datos", "Error inesperado al actualizar el Form.", ex);
            }
        }


        /// <summary>
        /// Elimina un Form existente por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del Form a eliminar.</param>
        /// <returns>Un valor booleano que indica si la eliminación fue exitosa.</returns>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza si no se encuentra ningún Form con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al intentar eliminar el Form desde la base de datos.
        /// </exception>
        public async Task<bool> DeleteFormAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del Form debe ser un número mayor a cero.", nameof(id));
            }

            var existingForm = await _formData.GetByIdAsyncSQL(id);
            if (existingForm == null)
            {
                throw new EntityNotFoundException("Form", id);
            }

            try
            {
                return await _formData.DeleteAsyncSQL(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el Form con ID: {FormId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el Form.", ex);
            }

        }


        /// <summary>
        /// Elimina un Form existente de manera logica por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del Form a eliminar de manera logica.</param>
        /// <returns>Un valor booleano que indica si la eliminación logica fue exitosa.</returns>
        /// <exception cref="EntityNotFoundException">
        /// Se lanza si no se encuentra ningún Form con el ID especificado.
        /// </exception>
        /// <exception cref="ExternalServiceException">
        /// Se lanza cuando ocurre un error inesperado al intentar eliminar de manera logica el Form desde la base de datos.
        /// </exception>
        public async Task<bool> DeleteFormLogicalAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del Form debe ser un número mayor a cero.", nameof(id));
            }

            var existingForm = await _formData.GetByIdAsyncSQL(id);
            if (existingForm == null)
            {
                throw new EntityNotFoundException("Form", id);
            }

            try
            {
                return await _formData.DeleteLogicAsyncSQL(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el formulario de manera logica con ID: {FormId}", id);
                throw new ExternalServiceException("Base de datos", "Error al eliminar el formulario de manera logica.", ex);
            }
        }


        /// <summary>
        /// Valida los datos del formulario.
        /// </summary>
        private void ValidateForm(FormDTO formDTO)
        {
            if (formDTO == null)
            {
                throw new ValidationException("El objeto Form no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(formDTO.Name))
            {
                _logger.LogWarning("Intento de crear/actualizar un Form con Name vacío.");
                throw new ValidationException("Name", "El nombre del Form es obligatorio.");
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
                Description = form.Description,
                Status = form.Active,
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
                Description = formDTO.Description,
                Active = formDTO.Status,
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

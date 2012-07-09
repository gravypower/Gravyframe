using System;
using System.Collections.Generic;
using Glass.Sitecore.Mapper.Configuration.Attributes;
using FluentValidation.Results;
using FluentValidation;

namespace BusinessObjects
{
    /// <summary>
    /// Abstract base class for business objects.
    /// Contains basic business rule infrastructure.
    /// </summary>
    public abstract class BusinessObject<T>
    {
        public IValidator<T> Validator { get; set; }
  
        protected BusinessObject(IValidator<T> validator)
        {
            Validator = validator;
        }

        #region Sitecore Standard fields

        [SitecoreId]
        public virtual Guid ID { get; set; }

        [SitecoreField("__created")]
        public virtual DateTime Created { get; set; }

        [SitecoreInfo(Glass.Sitecore.Mapper.Configuration.SitecoreInfoType.ContentPath)]
        public virtual string Path { get; set; }

        [SitecoreField("__created by")]
        public virtual string CreatedBy { get; set; }

        #endregion

        // List of validation errors (following validation failure)

        /// <summary>
        /// Gets list of validations errors.
        /// </summary>
        public IList<ValidationFailure> ValidationErrors { get; private set; }

        /// <summary>
        /// Determines whether business rules are valid or not.
        /// Creates a list of validation errors when appropriate.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            var results = Validator.Validate(this);
            ValidationErrors = results.Errors;

            return results.IsValid;
        }

    }
}

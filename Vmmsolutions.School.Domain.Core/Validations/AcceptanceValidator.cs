using FluentValidation;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Domain.Core.Validations
{
    internal class AcceptanceValidator : AbstractValidator<Acceptance>
    {

        public AcceptanceValidator()
        {

            RuleSet("Insert", () =>
            {

            });

            RuleSet("Update", () =>
            {

            });

            RuleSet("Delete", () =>
            {

            });
        }

        #region Validate Fields


        #endregion Validate Fields
    }
}
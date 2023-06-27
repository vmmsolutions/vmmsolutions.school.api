using FluentValidation;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Domain.Core.Validations
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
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
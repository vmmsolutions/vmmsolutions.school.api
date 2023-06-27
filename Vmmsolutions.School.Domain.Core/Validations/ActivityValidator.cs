using FluentValidation;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Domain.Core.Validations
{
    public class ActivityValidator : AbstractValidator<Activity>
    {

        public ActivityValidator()
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
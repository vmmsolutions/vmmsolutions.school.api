using FluentValidation;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Domain.Core.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
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
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Vmmsolutions.School.Domain.Entities;

namespace Vmmsolutions.School.Domain.Core.Validations
{
    internal class ClassValidator : AbstractValidator<Classes>
    {

        public ClassValidator()
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
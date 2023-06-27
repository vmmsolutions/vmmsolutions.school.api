using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class AlertService : Service<Alert>, IAlertService
    {
        //private readonly IAlertRepository _alertRepository;

        public AlertService(IUnitOfWork context, IAlertRepository _alertRepository) : base(context, _alertRepository)
        {
            Validator = new AlertValidator();
        }
    }
}
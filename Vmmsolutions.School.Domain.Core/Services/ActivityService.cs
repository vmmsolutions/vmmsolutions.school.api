using Vmmsolutions.School.Domain.Base;
using Vmmsolutions.School.Domain.Core.Validations;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Domain.Core.Services
{
    public class ActivityService : Service<Activity>, IActivityService
    {
        //private readonly IActivityRepository _activityRepository;

        public ActivityService(IUnitOfWork context, IActivityRepository _activityRepository) : base(context, _activityRepository)
        {
            Validator = new ActivityValidator();
        }
    }
}
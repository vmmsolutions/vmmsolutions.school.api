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
    public class AttachmentService : Service<Attachment>, IAttachmentService
    {
        //private readonly IAttachmentRepository _attachmentRepository;

        public AttachmentService(IUnitOfWork context, IAttachmentRepository _attachmentRepository) : base(context, _attachmentRepository)
        {
            Validator = new AttachmentValidator();
        }
    }
}
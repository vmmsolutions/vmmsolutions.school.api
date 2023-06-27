using AutoMapper;
using Vmmsolutions.School.Application.Base;
using Vmmsolutions.School.Application.Dto.Attachments;
using Vmmsolutions.School.Application.Interface;
using Vmmsolutions.School.Domain.Entities;
using Vmmsolutions.School.Domain.Interface;
using Vmmsolutions.School.Domain.Repositories.Interface;
using Vmmsolutions.School.Domain.Services;

namespace Vmmsolutions.School.Application.Core.Services
{
    public class AttachmentAppService : AppService, IAttachmentAppService
    {
        private readonly IAttachmentRepository _AttachmentsRepository;
        private readonly IAttachmentService _AttachmentsServices;

        public AttachmentAppService(IUnitOfWork uoW, IMapper mapper, IAttachmentRepository AttachmentsRepository, IAttachmentService AttachmentsServices) : base(uoW, mapper)
        {
            this._AttachmentsRepository = AttachmentsRepository;
            this._AttachmentsServices = AttachmentsServices;
        }

        public AttachmentDto GetById(Guid id)
        {
            return Mapper.Map<AttachmentDto>(_AttachmentsServices.GetById(id));
        }

        public IEnumerable<AttachmentDto> GetAll(Guid id)
        {
            return Mapper.Map<IEnumerable<AttachmentDto>>(_AttachmentsRepository.GetAll());
        }

        public AttachmentDto Insert(AttachmentPostDto obj)
        {
            try
            {
                UoW.BeginTransaction();
                Attachment entity = _AttachmentsServices.Insert(Mapper.Map<Attachment>(obj));
                entity.IsActive = true;
                UoW.Commit();

                return Mapper.Map<AttachmentDto>(entity);
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Update(Guid id, AttachmentPatchDto obj)
        {
            try
            {
                UoW.BeginTransaction();

                Attachment entity = _AttachmentsServices.GetById(id);
                entity.IsActive = obj.IsActive;
                entity.UpdatedOn = obj.UpdatedOn;
                entity.UpdatedBy = obj.UpdatedBy;
                entity.Name = obj.Name;

                _AttachmentsServices.Update(entity);

                UoW.Commit();
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                UoW.BeginTransaction();
                Attachment entity = _AttachmentsRepository.GetById(id);
                _AttachmentsServices.Delete(Mapper.Map<Attachment>(entity));
                UoW.Commit();
            }
            catch (Exception ex)
            {
                UoW.Rollback();
                throw ex;
            }
        }
    }
}
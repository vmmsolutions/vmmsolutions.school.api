using Vmmsolutions.School.Application.Dto.Attachments;

namespace Vmmsolutions.School.Application.Interface
{
    public interface IAttachmentAppService
    {
        AttachmentDto GetById(Guid id);
        IEnumerable<AttachmentDto> GetAll(Guid id);
        AttachmentDto Insert(AttachmentPostDto obj);
        void Update(Guid id, AttachmentPatchDto obj);
        void Delete(Guid id);
    }
}

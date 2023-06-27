namespace Vmmsolutions.School.Domain.Interface
{
    public interface IFilterParameters
    {
        int Page { get; set; }

        int PerPage { get; set; }

        string Sort { get; set; }
    }
}

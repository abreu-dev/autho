namespace Autho.Principal
{
    public interface IProfileAppQuery
    {
        IEnumerable<ProfileDto> GetAll();
    }
}

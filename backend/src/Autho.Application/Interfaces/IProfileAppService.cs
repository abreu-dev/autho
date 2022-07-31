namespace Autho.Principal
{
    public interface IProfileAppService
    {
        IResult Add(ProfileCreationDto creationDto);
        IResult Update(Guid id, ProfileCreationDto creationDto);
        IResult Remove(Guid id);
    }
}

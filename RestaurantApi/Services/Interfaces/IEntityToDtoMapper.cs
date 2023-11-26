namespace RestoranApi.Services.Interfaces;

public interface IEntityToDtoMapper
{
    public void UpdateEntityFromDto<TE, TD>(TE entity, TD dto);
}
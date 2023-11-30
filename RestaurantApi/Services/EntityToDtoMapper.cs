using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class EntityToDtoMapper: IEntityToDtoMapper
{
    public void UpdateEntityFromDto<TE, TD>(TE entity, TD dto)
    {
        if (entity == null || dto == null)
            throw new NullReferenceException("Entity and DTO cannot be null");

        foreach (var propertyInfo in typeof(TE).GetProperties())
        {
            var dtoValue = typeof(TD).GetProperty(propertyInfo.Name)?.GetValue(dto);
            
            if (dtoValue != null && !string.IsNullOrEmpty(dtoValue.ToString()))
                propertyInfo.SetValue(entity, dtoValue);
        }
    }
}
namespace Web.Interfaces
{
    public interface IMapper<T, TDto>
    {
        T MapToEntity(TDto dto);
        TDto MapToDto(T entity);
    }
}

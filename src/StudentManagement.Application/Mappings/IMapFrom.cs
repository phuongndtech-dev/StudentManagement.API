using AutoMapper;

namespace StudentManagement.Application.Mappings
{
    public interface IMapFrom<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
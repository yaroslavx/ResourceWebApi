using ResourseWebApi.Models;

namespace ResourseWebApi.Services.Resourses;

public interface ICustomResourseService
{
    void CreateResourse(Resourse resourse);
    Resourse GetResourse(Guid id);
}
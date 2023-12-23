using ResourseWebApi.Models;

namespace ResourseWebApi.Services.Resourses;

public interface ICustomResourseService
{
    void CreateResourse(Resourse resourse);
    Resourse GetResourse(Guid id);
    Resourse UpsertResourse(Resourse resourse);
    void DeleteResourse(Guid id);
}
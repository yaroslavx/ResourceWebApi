using ErrorOr;
using ResourseWebApi.Models;

namespace ResourseWebApi.Services.Resourses;

public interface ICustomResourseService
{
    ErrorOr<Created> CreateResourse(Resourse resourse);
    ErrorOr<Resourse> GetResourse(Guid id);
    ErrorOr<UpsertedResourse> UpsertResourse(Resourse resourse);
    ErrorOr<Deleted> DeleteResourse(Guid id);
}
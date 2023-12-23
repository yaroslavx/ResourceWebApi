using ErrorOr;
using ResourseWebApi.Models;
using ResourseWebApi.ServiceErrors;

namespace ResourseWebApi.Services.Resourses;

public class resourseService : ICustomResourseService
{
    private static readonly Dictionary<Guid, Resourse> _resourses = new();

    public void CreateResourse(Resourse resourse)
    {
        _resourses.Add(resourse.Id, resourse);
    }

    public ErrorOr<Resourse> GetResourse(Guid id)
    {
        if (_resourses.TryGetValue(id, out var resourse))
        {
            return resourse;
        }

        return Errors.Resourse.NotFound;
    }

    public Resourse UpsertResourse(Resourse resourse)
    {
        _resourses[resourse.Id] = resourse;
        return _resourses[resourse.Id];
    }

    public void DeleteResourse(Guid id)
    {
        _resourses.Remove(id);
    }
}
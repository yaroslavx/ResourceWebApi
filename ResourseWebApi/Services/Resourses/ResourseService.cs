using ResourseWebApi.Models;

namespace ResourseWebApi.Services.Resourses;

public class resourseService : ICustomResourseService
{
    private static readonly Dictionary<Guid, Resourse> _resourses = new();

    public void CreateResourse(Resourse resourse)
    {
        _resourses.Add(resourse.Id, resourse);
    }

    public Resourse GetResourse(Guid id)
    {
        return _resourses[id];
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
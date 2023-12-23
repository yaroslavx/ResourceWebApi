using ErrorOr;
using ResourseWebApi.Models;
using ResourseWebApi.ServiceErrors;

namespace ResourseWebApi.Services.Resourses;

public class resourseService : ICustomResourseService
{
    private static readonly Dictionary<Guid, Resourse> _resourses = new();

    public ErrorOr<Created> CreateResourse(Resourse resourse)
    {
        _resourses.Add(resourse.Id, resourse);

        return Result.Created;
    }

    public ErrorOr<Resourse> GetResourse(Guid id)
    {
        if (_resourses.TryGetValue(id, out var resourse))
        {
            return resourse;
        }

        return Errors.Resourse.NotFound;
    }

    public ErrorOr<UpsertedResourse> UpsertResourse(Resourse resourse)
    {
        var IsNewlyCreated = !_resourses.ContainsKey(resourse.Id);
        _resourses[resourse.Id] = resourse;
        return new UpsertedResourse(IsNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteResourse(Guid id)
    {
        _resourses.Remove(id);
        return Result.Deleted;
    }
}
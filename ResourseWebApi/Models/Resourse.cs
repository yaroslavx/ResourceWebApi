using ErrorOr;

namespace ResourseWebApi.Models;

public class Resourse
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Primary { get; }
    public List<string> Secondary { get; }

    private Resourse(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> primary,
        List<string> secondary
    )
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Primary = primary;
        Secondary = secondary;
    }

    public static ErrorOr<Resourse> Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> primary,
        List<string> secondary
    )
    {
        return new Resourse(
            Guid.NewGuid(),
            name,
            description,
            startDateTime,
            endDateTime,
            DateTime.UtcNow,
            primary,
            secondary
        );
    }
}
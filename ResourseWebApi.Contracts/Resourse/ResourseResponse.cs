namespace ResourseWebApi.Contracts.Resourse;

public record ResourseResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Primary,
    List<string> Secondary
    )
{ }
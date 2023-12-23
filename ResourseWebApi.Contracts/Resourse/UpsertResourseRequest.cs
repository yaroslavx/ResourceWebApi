namespace ResourseWebApi.Contracts.Resourse;

public record UpsertResourseRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Primary,
    List<string> Secondary
)
{ }
namespace ResourseWebApi.Contracts.Resourse;

public record CreateResourseRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Primary,
    List<string> Secondary
)
{ }
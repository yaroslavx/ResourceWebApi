using ErrorOr;

namespace ResourseWebApi.ServiceErrors;

public static class Errors
{
    public static class Resourse
    {
        public static Error NotFound => Error.NotFound(
            code: "Resourse.NotFound",
            description: "Resourse not found"
        )
    }
}
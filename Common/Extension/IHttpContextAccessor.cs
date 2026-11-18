using Microsoft.AspNetCore.Http;

namespace Common.Extension;
public static class IHttpContextAccessorExtension
{
    public static int? PersonId(this IHttpContextAccessor accessor)
    {
        var person = accessor.HttpContext?.User;
        var personId = person?.FindFirst("PersonId")?.Value;
        return int.TryParse(personId, out var id) ? id : null;
    }
}

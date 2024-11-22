using ArvefordelerenWebApp.Models;

namespace ArvefordelerenWebApp.Utilities;

public static class RepositoryExtensions
{
    public static int GenerateId<T>(this List<T> repository) where T : IModel
    {
        return repository.MaxBy(x => x.Id)?.Id + 1 ?? 1;
    }
}
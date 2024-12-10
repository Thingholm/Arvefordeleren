namespace ArvefordelerenWebApp.Models
{
    public class InMemoryInheritorRepository : IInheritorRepository
    {
        public List<Inheritor> Inheritors { get; } = new List<Inheritor>();

        public void AddInheritor(Inheritor inheritor)
        {
            Inheritors.Add(inheritor);
        }
    }
}

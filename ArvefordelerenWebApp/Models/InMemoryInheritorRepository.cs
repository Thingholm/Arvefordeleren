namespace ArvefordelerenWebApp.Models
{
    public class InMemoryInheritorRepository : IInheritorRepository
    {
        public List<Inheritor> Inheritors { get; } = new List<Inheritor>();

        public List<Inheritor> GetInheritors()
        {
            return Inheritors;  // Returnere listen af inheritors
        }

        public void AddInheritor(Inheritor inheritor)
        {
            Inheritors.Add(inheritor);
        }
    }
}

namespace ArvefordelerenWebApp.Models
{
    public interface IInheritorRepository
    {
        List<Inheritor> GetInheritors();
        void AddInheritor(Inheritor inheritor);
    }
}

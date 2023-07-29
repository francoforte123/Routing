namespace Routing.Models
{
    public interface IRequestRepository
    {
        void Add(Request request);
        void DeleteById(int id);
        IEnumerable<Request> GetAll();
        Request GetById(int id);
        void Modify(Request request);
    }
}

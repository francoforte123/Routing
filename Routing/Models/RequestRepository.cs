namespace Routing.Models
{
    public class RequestRepository : IRequestRepository
    {
        public readonly List<Request> requests;

        public RequestRepository()
        {
            this.requests = new List<Request>
            {
                new Request
                {
                    Id = 1,
                    Author= "Steven Spielberg",
                    Title= "Write some movies turn around of Steven Spielberg",
                    Description= ""
                },

                new Request
                {
                    Id = 2,
                    Author= "James Cameron",
                    Title= "Write some movies turn around of James Cameron",
                    Description= ""
                }
            };
        }
        public IEnumerable<Request> GetAll()
        {
            return this.requests;
        }

        public void Add(Request request)
        {
            if (this.requests.Any(r => r.Id == request.Id))
            {
                throw new InvalidOperationException("this request already exists");
            }

            this.requests.Add(request);
        }

        public Request GetById(int id)
        {
            return this.requests.Single(r => r.Id == id);
        }

        public void DeleteById(int id)
        {
            this.requests.RemoveAll(r => r.Id == id);
        }

        public void Modify(Request request)
        {
            var existingRequest = this.GetById(request.Id);
            existingRequest.Author = request.Author;
            existingRequest.Title = request.Title;
            existingRequest.Description = request.Description;
        }
    }
}

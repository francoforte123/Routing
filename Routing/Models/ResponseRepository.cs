namespace Routing.Models
{
    public class ResponseRepository : IResponseRepository
    {
        public readonly List<Response> responses;

        public ResponseRepository()
        {
            this.responses = new List<Response>
            {
                new Response
                {
                    Id = 1,
                    Author= "Steven Spielberg",
                    Description= "Lo Squalo, Jurassic Park, Prova a prendermi, Schinder's list, Salvate il soldato Ryan, Ritorno al futuro, Indiana Jones",
                    IsAccepted=""
                },

                new Response
                {
                    Id = 2,
                    Author= "James Cameron",
                    Description= "Titanic, Avatar, Terminator, Rambo 2, Sanctum 3D, Solaris",
                    IsAccepted=""
                }
            };
        }
        public IEnumerable<Response> GetAll()
        {
            return this.responses;
        }

        public void Add(Response response)
        {
            if (this.responses.Any(r => r.Id == response.Id))
            {
                throw new InvalidOperationException("this request already exists");
            }

            this.responses.Add(response);
        }

        public Response GetById(int id)
        {
            return this.responses.Single(r => r.Id == id);
        }

        public void DeleteById(int id)
        {
            this.responses.RemoveAll(r => r.Id == id);
        }

        public void Modify(Response response)
        {
            var existingRequest = this.GetById(response.Id);
            existingRequest.Author = response.Author;
            existingRequest.Description = response.Description;
            existingRequest.IsAccepted = response.IsAccepted;
        }
    }
}

using InnovateAd.Entities;
using InnovateAdSolution;
using Microsoft.EntityFrameworkCore;

namespace InnovateAd.Repositories
{
    public interface IClientRepository
    {
        Task<Client> CreateClient(string name, string lastName, string docType, string document, string email, string clientNumber);
        Task<List<Client>> GetAll();
        Task<Client> UpdateClient(Client client);
        Task<Client> GetClient(int id);
        Task<Client> DeleteClient(Client client);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _db;
        public ClientRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Client> CreateClient(string name, string lastName, string docType, string document, string email, string clientNumber)
        {
            Client newClient = new Client
            {
                name = name,
                last_name = lastName,
                doc_type = docType,
                document = document,
                email = email,
                client_number = clientNumber,
                is_active = true
            };
            await _db.Clients.AddAsync(newClient);
            _db.SaveChanges();
            return newClient;
        }
        public async Task<List<Client>> GetAll()
        {
            return await _db.Clients.ToListAsync();
        }

        public async Task<Client> UpdateClient(Client client)
        {
            _db.Clients.Update(client);
            await _db.SaveChangesAsync();
            return client;
        }
        public async Task<Client> GetClient(int id)
        {
            return await _db.Clients.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<Client> DeleteClient(Client client)
        {
            client.is_active = false;
            _db.Clients.Update(client);
            await _db.SaveChangesAsync();
            return client;
        }
    }
}

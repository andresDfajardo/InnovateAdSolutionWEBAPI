using InnovateAd.Entities;
using InnovateAd.Repositories;
using System.Reflection.Metadata;

namespace InnovateAd.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Client> GetClient(int id);
        Task<Client> CreateClient(string name, string lastName, string docType, string document, string email, string clientNumber);
        Task<Client> UpdateClient(int id, string? name = null, string? lastName = null, string? docType = null, string? document = null, string? email = null, string? clientNumber = null);
        Task<Client> DeleteClient(int id);
    }
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> CreateClient(string name, string lastName, string docType, string document, string email, string clientNumber)
        {
            return await _clientRepository.CreateClient(name, lastName, docType, document, email, clientNumber);
        }

        public async Task<Client> DeleteClient(int id)
        {
            Client desactiveClient = await _clientRepository.GetClient(id);

            if (desactiveClient != null)
            {
                desactiveClient.is_active = false;
                return await _clientRepository.DeleteClient(desactiveClient);

            }
            else
            {
                throw new Exception("Client not found");
            }
        }

        public async Task<Client> GetClient(int id)
        {
            return await _clientRepository.GetClient(id);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clientRepository.GetAll();
        }

        public async Task<Client> UpdateClient(int id, string? name = null, string? lastName = null, string? docType = null, string? document = null, string? email = null, string? clientNumber = null)
        {
            Client newclient = await _clientRepository.GetClient(id);

            if (newclient != null)
            {
                if (name != null)
                {
                    newclient.name = name;
                }
                else if (lastName != null)
                {
                    newclient.last_name = lastName;
                }
                else if (docType != null)
                {
                    newclient.doc_type = docType;
                }
                else if (document != null)
                {
                    newclient.document = document;
                }
                else if (email != null)
                {
                    newclient.email = email;
                }
                else if (clientNumber != null)
                {
                    newclient.client_number = clientNumber;
                }
                return await _clientRepository.UpdateClient(newclient);
            }
            else
                return null;
        }
    }
}

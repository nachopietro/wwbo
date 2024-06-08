using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDB.Driver;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class ClientRepo : IClientRepo
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientRepo(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("WeWise");
            _clients = database.GetCollection<Client>("Clients");
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await _clients.Find(client => true).ToListAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _clients.Find<Client>(client => client.ClientId == id).FirstOrDefaultAsync();
        }

        public async Task CreateClient(Client client)
        {
            await _clients.InsertOneAsync(client);
        }

        public async Task UpdateClient(int id, Client client)
        {
            await _clients.ReplaceOneAsync(client => client.ClientId == id, client);
        }
    }
}

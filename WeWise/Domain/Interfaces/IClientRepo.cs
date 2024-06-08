using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepo
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(int id);
        Task CreateClient(Client client);
        Task UpdateClient(int id, Client client);
    }
}

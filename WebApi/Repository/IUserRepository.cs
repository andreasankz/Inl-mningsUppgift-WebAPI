using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}

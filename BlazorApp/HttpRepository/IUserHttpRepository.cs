using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.HttpRepository
{
    public interface IUserHttpRepository
    {
        Task<List<GetUser>> GetUsers();
    }
}

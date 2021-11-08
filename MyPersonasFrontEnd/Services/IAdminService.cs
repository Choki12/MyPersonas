using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasFrontEnd.Services
{
    public interface IAdminService
    {
        Task<bool> AllowAdminUserCreationAsync();
    }
}

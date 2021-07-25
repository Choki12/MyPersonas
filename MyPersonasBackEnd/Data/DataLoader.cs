using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    public abstract class DataLoader
    {
        public abstract Task LoadDataAsync(Stream fileStream, ApplicationDbContext db);
    }
}

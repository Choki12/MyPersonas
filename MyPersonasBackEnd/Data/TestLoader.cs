using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyPersonasBackEnd.Data;

namespace MyPersonasBackEnd
{
    public class TestLoader : DataLoader
    {
        public override async Task LoadDataAsync(Stream fileStream, ApplicationDbContext db)
        {
            //throw new NotImplementedException();

            var addedTestees = new Dictionary<string, Testee>();
            var addedQuestions = new Dictionary<string, Questions>();

            var arr = await JToken.LoadAsync(new JsonTextReader(new StreamReader(fileStream)));

            var root = arr.ToObject<List<RootObject>>();


        }
    }
}

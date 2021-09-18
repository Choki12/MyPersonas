using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyPersonasBackEnd.Data;

namespace MyPersonasBackEnd
{
    public class SessionizeLoader : DataLoader
    {
        public override async Task LoadDataAsync(Stream fileStream, ApplicationDbContext db)
        {
            var addTestees = new Dictionary<String, Testee>();
            var addTests = new Dictionary<String, Test>();
            //var addedTestAnswers = new Dictionary<String, TestQuestion>();

            var myarray = await JToken.LoadAsync(new JsonTextReader(new StreamReader(fileStream)));

            var root = myarray.ToObject<List<RootObject>>();

            foreach(var date in root)
            {
                foreach (var myTestee in date.testees)
                {

                    if (!addTestees.ContainsKey(myTestee.Name))
                    {
                        var correctTestee = new Testee { Name = myTestee.Name };
                        db.Testees.Add(correctTestee);
                        addTestees.Add(correctTestee.Name, correctTestee);


                    }

                    foreach (var test in date.tests)
                    {

                        if (!addTests.ContainsKey(test.Type))
                        {
                            var testType = new Test { Type = test.Type };
                            db.Test.Add(testType);
                            addTests.Add(testType.Type, testType);


                        }

                        var mytest = new Test
                        {
                            TestState = test.TestState,
                            DateTaken = test.DateTaken
                            
                        };

                        test.TesteeTest = new List<TesteeTest>();
                        /*foreach(var tt in    test.)
                        {
                          
                        }*/
                        foreach(var tt in test.TesteeTest)
                        {
                            mytest.TesteeTest.Add(new TesteeTest
                            {
                                Test = mytest,
                                Testee = addTestees[tt.Name]
                            });

                        }

                        db.Test.Add(mytest);

                    }

                


                }

            
            }

         

        }

        private class RootObject
        {
            public DateTime date { get; set; }

            public List<Test> tests { get; set; }

            public List<TestQuestion> tq { get; set; }

            public List<Testee> testees { get; set; }

        }

        private class ImportTestee
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        private class TestType
        {
            public int id { get; set; }

            public string name { get; set; }

            public List<object> testTypes { get; set; }

            public int sort { get; set; }
        }

        private class ImportTest
        {
            public int id { get; set; }

            public DateTime DateTaken { get; set; }

            public string testState { get; set; }

            public List<ImportTestee> testee { get; set; }

            public List<TestType> testTypes { get; set; }

            public int Attempts { get; set; }




        }

        private class Testing
        {
            public int id { get; set; }

            public String Type { get; set; }

            public List<ImportTest> tests { get; set; }

            public List<ImportTestee> testees { get; set; }

        }






    }


}

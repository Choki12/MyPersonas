using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    /*Reads data in JSON Format and loads it into the DB by implementing the DataLoader abstract class*/ 
    public class DevIntersectionLoader : DataLoader
    {
        public override async Task LoadDataAsync(Stream fileStream, ApplicationDbContext db)
        {
            /*Define JSON reader and convert to file stream*/

            var reader = new JsonTextReader(new StreamReader(fileStream));

            /*Define Key Value pair for Testee and Questions Dictionary*/

            var TesteeNames = new Dictionary<string, Testee>();
            var TestQuestions = new Dictionary<string, Questions>();
            
            JArray document = await JArray.LoadAsync(reader);
            
            foreach (JObject item in document)
            {
                var myTestees = new List<Testee>();

                foreach(var myTesteeName in item["TesteeNames"])
                {
                    if(TesteeNames.ContainsKey(myTesteeName.Value<string>()) == (false))
                    {
                        /*If the dictionary has no list of names pre-populated create a new instance of a testee and set this name as the 1st entry in the dictionary*/
                       
                        var myTestee = new Testee { 
                            Name = myTesteeName.Value<string>() 
                        };

                        /*Populate the DB with a new Testee*/
                        db.Testees.Add(myTestee);

                        TesteeNames.Add(myTesteeName.Value<string>(), myTestee);
                        Console.WriteLine(myTesteeName.Value<string>());  //why?

                    }

                    /*Append the list of testee names contained in the dictionary*/
                    myTestees.Add(TesteeNames[myTesteeName.Value<string>()]);
                }

                /*Add Questions to DB*/
                var myQuestions = new List<Questions>();
                
                foreach(var QuestionAsked in item["TestQuestions"])
                {
                    if(TestQuestions.ContainsKey(QuestionAsked.Value<string>()) == (false))
                    {
                        var myQuestion = new Questions { Question = QuestionAsked.Value<string>() };
                        db.Questions.Add(myQuestion);
                        TestQuestions.Add(QuestionAsked.Value<string>(), myQuestion);

                    }
                    myQuestions.Add(TestQuestions[QuestionAsked.Value<string>()]);
                }

                var test = new Test
                {
                    DateTaken = item["DateTaken"].Value<DateTime>(),
                    Type = item["Type"].Value<string>(),
                    TestState = item["TestState"].Value<string>()
                    

                };

                
                var questions = new Questions
                {
                    Question = item["Question"].Value<string>(),
                    Answer = item["Answer"].Value<string>(),
                    Number = item["QuestionNumber"].Value<int>(),
                    State = item["QuestionState"].Value<string>()

                };

                test.TesteeTest = new List<TesteeTest>();

                foreach(var tt in myTestees)
                {
                    test.TesteeTest.Add(new TesteeTest{
                        Test =  test,
                        Testee = tt
                    });
                }

                db.Test.Add(test);

                //For questions
                questions.TestQuestion = new List<TestQuestion>();

                foreach(var tq in myQuestions)
                {
                    questions.TestQuestion.Add(new TestQuestion{
                        Questions = tq,            
                    });
                }

                db.Questions.Add(questions);
                



            }

        }
    }
}

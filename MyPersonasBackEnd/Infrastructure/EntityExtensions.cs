
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    public static class EntityExtensions
    {
        /*
         * Map testee response 
         */
        public static PersonalityProfilerDTO.TesteeResponse MapTesteeResponse(this Testee testee) =>
            new PersonalityProfilerDTO.TesteeResponse
            {
                Id = testee.Id,
                Name = testee.Name,
                Surname = testee.Surname,
                Email = testee.Email,
                DOB = testee.DOB,
                UserName = testee.UserName,
                Test = testee.TesteeTest?       
                .Select(tt =>
                    new PersonalityProfilerDTO.Test
                    {
                        Id = tt.TestId,
                        Type = tt.Test.Type,
                        DateTaken = tt.Test.DateTaken,
                        TestState = tt.Test.TestState
                    })
                .ToList()

            };

      /*
       * Map test response
       */
        public static PersonalityProfilerDTO.TestResponse MapTestResponse(this Test test) =>
           new PersonalityProfilerDTO.TestResponse
           {
               Id = test.Id,
               Type = test.Type,
               DateTaken = test.DateTaken,
               TestState = test.TestState,
               Testees = test.TesteeTest?
               
               .Select(tt =>
                   new PersonalityProfilerDTO.Testee
                   {
                       Id = tt.TesteeId,
                       Email = tt.Testee.Email,
                       Name = tt.Testee.Name,
                       Surname = tt.Testee.Surname,
                       DOB = tt.Testee.DOB,
                       UserName = tt.UserName

                   })
               .ToList()

           };

      /*
       * Map questions response
       */
        public static PersonalityProfilerDTO.QuestionsResponse MapQuestionsResponse(this Questions Questions) =>
          new PersonalityProfilerDTO.QuestionsResponse
          {
              Id = Questions.Id,
              Question = Questions.Question,
              State = Questions.State,
              Number = Questions.Number,
              Answer = Questions.Answer,
              Tests = Questions.TestQuestion?
              .Select(qq =>
                  new PersonalityProfilerDTO.Test
                  {
                      Id = qq.TestId,
                      Type = qq.Test.Type,
                      DateTaken = qq.Test.DateTaken,   
                      TestState = qq.Test.TestState                   
                  })
              .ToList()

          };
    }
}

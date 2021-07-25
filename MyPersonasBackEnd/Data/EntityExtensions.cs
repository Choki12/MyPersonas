using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasBackEnd.Data
{
    public static class EntityExtensions
    {
        public static PersonalityProfilerDTO.TesteeResponse MapTesteeResponse(this Testee testee) =>
            new PersonalityProfilerDTO.TesteeResponse
            {
                Id = testee.Id,
                Name = testee.Name,
                Surname = testee.Surname,
                Email = testee.Email,
                DOB = testee.DOB,
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalityProfilerDTO
{
    public class QuestionsResponse: Questions
    {
        public ICollection<Test> Tests { get; set; } = new List<Test>();
    }
}

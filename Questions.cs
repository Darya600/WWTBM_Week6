using System;
using System.Collections.Generic;
using System.Text;

namespace Who_want_to_be_a_m2
{
    public class Questions
    {
        public Questions(string qestionText)
        {
            this.questionText = qestionText;
        }
        public string questionText;
        public Answers[] answers;
    }
}

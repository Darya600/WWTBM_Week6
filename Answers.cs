using System;
using System.Collections.Generic;
using System.Text;

namespace Who_want_to_be_a_m2
{

    abstract public class Answers
    {
        public Answers(string answerNumber, string answerText)
        {
            this.answerText = answerText;
            this.answerNumber = answerNumber;

        }
        public string answerText;
        public string answerNumber;
    }
    public class CorrectAnswer : Answers
    {
        public CorrectAnswer(string answerNumber, string answerText) : base(answerNumber, answerText)
        {
         
        }
    }
    public class WrongAnswer : Answers
    {
        public WrongAnswer(string answerNumber, string answerText) : base(answerNumber, answerText)
        {
         
        }

    }   
}

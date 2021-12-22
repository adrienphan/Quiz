using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz
{
    internal class Question
    {
        string question;
        string[] answers;
        int goodAnswer;
        
        public Question(string questionText, string[] answersText, int goodIndex)
        {
            question = questionText;
            answers = answersText;
            goodAnswer = goodIndex;
        }
        public void Ask()
        {
            Console.WriteLine(question);
            foreach(string answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        public bool IsAnswerGood(string userInput)
        {
            if (userInput == answers[goodAnswer])
            {
                return true;
            } else return false;
        }
        public string GoodAnswer()
        {
            return answers[goodAnswer];
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz
{
    internal class Program
    {
        public static int score = 0;
        public static string path = @"C:\Users\adrie\Documents\La Manu\Csharp basics\Quizz\Questions.txt";
        //Console.WriteLine("debug 01");

        /**
         * Main
         */
        static void Main(string[] args)
        {
            Init();
        }
        /**
         * Answer
         * arg: Objet Question
         * Displays the submited Question and its answers, waits for answer, and checks answer
         */
        public static void Answer(Question question)
        {
            Console.Clear();
            //Display Question and answers
            question.Ask();
            //Check if answer is correct
            if (question.IsAnswerGood(Console.ReadLine()))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bravo!");
                Console.ForegroundColor = ConsoleColor.White;
                score++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Mauvaise réponse! la bonne réponse était {question.GoodAnswer()}.");
                Console.ForegroundColor= ConsoleColor.White;
            }
            Console.ReadKey();
        }
        /**
         * DisplayScore
         * Displays the score variable
         */
        public static void DisplayScore()
        {
            Console.Clear();
            Console.WriteLine($"Votre score est de {score} points!");
            Console.ReadKey();
        }

        /**
         * CreateQuestions
         * Pulls Questions from text file and calls Answer Method
         */
        public static void CreateQuestions()
        {
            //text file

            string[] readText = File.ReadAllLines(path);
            
            foreach (string line in readText)
            {
                readText = line.Split('#');
                Question question = new Question( readText[0], readText[1].Split(','), Convert.ToInt32(readText[2]) );
                Answer(question);
            }
            DisplayScore();
        }
        /**
         * NewQuestion
         * asks for inputs to create a new Question
         */
        public static void NewQuestion()
        {
            string newQuestion;
            string[] newAnswer = new string[3];
            int newGoodAnswerIndex;
            int newAnswerIndex = 0;
            Console.WriteLine("Ajoutez une question");
            newQuestion = Console.ReadLine();

            foreach (string potentialAnswer in newAnswer)
            {
                Console.WriteLine("Ajoutez réponse " + (newAnswerIndex + 1));
                newAnswer[newAnswerIndex] = Console.ReadLine();
                newAnswerIndex++;
            }
            Console.WriteLine("Quel est le numero de la bonne réponse ?");
            newGoodAnswerIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            AddQuestion(newQuestion, newAnswer, newGoodAnswerIndex);
        }
        /**
         * AddQuestion
         * Adds a new question and answers to the text file
         */
        public static void AddQuestion(string questionToAdd, string[] answersToAdd, int goodAnswerIndexToAdd)
        {
            //Create the file if it doesn't exist
            string answers = "";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            //Divides the answers for the text file
            foreach(string answer in answersToAdd)
            {
                answers += answer + ",";
            }
            //Write the question, answers and index of the right answer
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.WriteLine(questionToAdd + "#" + answers + "#" + goodAnswerIndexToAdd);
            }
        }
        public static void Init()
        {
            bool admin = false;
            Console.WriteLine("Bienvenue ! Pour vous connecter en administrateur, entrez votre mot de passe, sinon pressez 'enter'.");
            string adminRequest = Console.ReadLine();
            if (adminRequest == "flagadischbluck")
            {
                admin = true;
            } else CreateQuestions();
            if (admin == true)
            {
                adminMenu:
                Console.Clear();
                Console.WriteLine("Que souhaitez vous faire ?");
                Console.Write("1- Ajouter une question: [");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("add");
                Console.ForegroundColor= ConsoleColor.Gray;
                Console.Write("]\n");
                Console.Write("2- Modifier une question: [");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("edit");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("]\n");
                Console.Write("3- Supprimer une question: [");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("delete");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("]\n");

                string adminAction = Console.ReadLine();
                switch (adminAction)
                {
                    case "add":
                        NewQuestion();
                        break;
                    case "edit":
                        //methode editQuestion
                        break;
                    case "delete":
                        //methode deleteQuestion
                        break;
                    default:
                        Console.WriteLine("je n'ai pas compris, réessayez.");
                        Console.ReadKey();
                        goto adminMenu;
                }
            }
        }
    }
}

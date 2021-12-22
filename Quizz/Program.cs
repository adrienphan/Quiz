using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz
{
    internal class Program
    {
        public static int score = 0;
        public static Question question1 = new Question("Quel parchemin est le plus commun dans Nethack?", new string[] { "soin mineur", "identification", "lumière" }, 1);
        public static Question question2 = new Question("Quel film est introduit par le mot \"Rosebud\"?", new string[] { "Metropolis", "La classe américaine", "Citizen Kane" }, 2);
        public static Question question3 = new Question("Qui a composé la Marche Turque?", new string[] { "Wolfgang Amadeus Mozart", "Ludwig Van Beethoven", "Johann Sebastian Bach" }, 0);
        public static Question question4 = new Question("Dans le film d'animation \"La Planète au Trésor\", qui donne la carte à Jim Hawkins?", new string[] { "Long John Silver", "Le vieux Billy Bones", "Ben" }, 1);
        public static Question question5 = new Question("Qui gagne lors d'un combat entre Wolverine et Hulk?", new string[] { "Wolverine", "Hulk", "Loki" }, 2);
        public static Question question6 = new Question("Laquelle de ces expressions désigne une boucle?", new string[] { "do while", "if else", "new" }, 0);
        public static Question question7 = new Question("Quel personnage est mort plus de fois que Captain América dans les comics marvel?", new string[] { "Wolverine", "Tante May", "Professeur X" }, 1);
        public static Question question8 = new Question("Lequel de ces jeux a été créé par Richard Garfield?", new string[] { "7 Wonders", "Magic l'assemblée", "Duel Master" }, 1);
        public static Question question9 = new Question("Quelle est la syntaxe correcte pour écrire Hello World dans la console en C#?", new string[] { "Console.WriteLine(\"Hello World\");", "print(\"Hello World\");", "echo \"Hello World\";" }, 0);
        public static Question question10 = new Question("Quelle est la réponse à la question de la vie, de l'univers, et de tout le reste ?", new string[] { "L'amour", "L'amitié", "42" }, 2);





        static void Main(string[] args)
        {
            Answer(question1);
            Answer(question2);
            Answer(question3);
            Answer(question4);
            Answer(question5);
            Answer(question6);
            Answer(question7);
            Answer(question8);
            Answer(question9);
            Answer(question10);

            DisplayScore();
        }

        public static void Answer(Question question)
        {
            question.Ask();
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
        }
        public static void DisplayScore()
        {
            Console.WriteLine($"Votre score est de {score} points!");
        }
    }
}

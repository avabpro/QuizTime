using System;
using System.Collections.Generic;

namespace QuizTime
{
    class Program
    {
        static void Main(string[] args)
        {
            TrueFalse test = new TrueFalse("The abreviation for United States is \"US.\"", true);
            test.AskQuestion();

            List<string> options = new List<string>();
            options.Add("a: Sunday");
            options.Add("b: Wednesday");
            options.Add("c: Friday");

            MultipleChoice test2 = new MultipleChoice("What is the first day of the Week?", 'a', options);
            test2.AskQuestion();

            List<string> options2 = new List<string>();
            options2.Add("a: Sunday");
            options2.Add("b: Wednesday");
            options2.Add("c: Friday");

            List<char> answer = new List<char>();
            answer.Add('b');
            answer.Add('c');


            CheckBox test3 = new CheckBox("Which days are not the weekend?", answer, options2);
            test3.AskQuestion();
        }
    }

    public abstract class Question
    {
        private string prompt;        
        
        public string Prompt { get; set; }

        public abstract string DisplayPrompt();

        public void AskQuestion()
        {
            string userAnswer = DisplayPrompt();
            CheckAnswer(userAnswer);
        }

        public abstract void CheckAnswer(string answer);

    }

    public class TrueFalse : Question
    {
        private bool answer;

        public bool Answer { get; set; }

        public TrueFalse(string prompt, bool answer)
        {
            this.Prompt = prompt;
            this.Answer = answer;
        }


        public override string DisplayPrompt()
        {
            Console.WriteLine("\n" + Prompt);
            Console.Write("\nPlease enter true or false: ");
            return Console.ReadLine();
        }

        public override void CheckAnswer(string answer)
        {
            if (Answer && (answer.ToLower() == "t" || answer.ToLower() == "true"))
            {
                Console.WriteLine("You entered true. That is correct!");
                Console.WriteLine("---------------------------------");

            }
            else if (!Answer && (answer.ToLower() == "f" || answer.ToLower() == "false"))
            {
                Console.WriteLine("You entered false. That is correct!");
                Console.WriteLine("---------------------------------");

            }
            else
            {
                Console.WriteLine($"Sorry, you entered \"{answer}.\" The correct answer was \"{Answer}.\"");
                Console.WriteLine("---------------------------------");

            }
        }
    }

    public class MultipleChoice : Question
    {
        private char answer;
        private List<string> options;

        public char Answer { get; set; }
        public List<string> Options { get; set; }

        public MultipleChoice(string prompt, char answer, List<string> options)
        {
            this.Prompt = prompt;
            this.Answer = answer;
            this.Options = options;
        }


        public override string DisplayPrompt()
        {
            Console.WriteLine("\n" + Prompt);

            foreach (string option in Options)
            {
                Console.WriteLine(option);
            }

            Console.Write("\nPlease enter your answer: ");
            return Console.ReadLine();

        }
        public override void CheckAnswer(string answer)
        {
            if (Answer.ToString().ToLower() == answer.ToLower())
            {
                Console.WriteLine("Great job! Your answer is correct.");
                Console.WriteLine("---------------------------------");

            }
            else
            {
                Console.WriteLine("Sorry, that answer was incorrect.");
                Console.WriteLine("---------------------------------");

            }
        }
    }

    public class CheckBox : Question
    {
        private List<char> answer;
        private List<string> options;

        public List<char> Answer { get; set; }
        public List<string> Options { get; set; }

        public CheckBox(string prompt, List<char> answer, List<string> options)
        {
            this.Prompt = prompt;
            this.Answer = answer;
            this.Options = options;
        }

        public override string DisplayPrompt()
        {
            Console.WriteLine("\n" + Prompt);

            foreach (string option in Options)
            {
                Console.WriteLine(option);
            }

            Console.Write("\nPlease enter your answer(s) (do NOT separate with spaces or other characters): ");
            return Console.ReadLine();

        }
        public override void CheckAnswer(string answer)
        {
            foreach (char selection in Answer)
            {
                if (!answer.Contains(selection))
                {
                    Console.WriteLine("Sorry, that was not correct.");
                    Console.WriteLine("---------------------------------");
                    return;
                }
                answer = answer.Replace(selection.ToString(), "");

            }
            if (answer.Length != 0)
            {
                Console.WriteLine("Sorry, that was not correct.");
                Console.WriteLine("---------------------------------");
            }
            else
            {
                Console.WriteLine("Well done! That was the correct answer.");
                Console.WriteLine("---------------------------------");
            }

        }
    }


}

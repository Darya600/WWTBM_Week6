using System;
using System.Collections.Generic;
using System.Text;

namespace Who_want_to_be_a_m2
{
    class Game
    {
        public void GameStart()
        {
            User newUser = BeforeBeginning();
            Questions[] question = CreateListQuestions();
            question[0].answers = CreateAnswerList1(question);
            question[1].answers = CreateAnswerList2(question);
            GameLoop(question, newUser);

        }
        public User BeforeBeginning()
        {
            PrintGameRules();
            User newUser = CreateUser();
            return newUser;
        }
        public void PrintGameRules()
        {
            string[] Rules = new string[7];
            Rules[0] = "пт. 1 - для начала игры вы должны внести свое имя; ";
            Rules[1] = "пт. 2 - после начала игры вам будет предложен ограниченный перечень вопросов по очереди;";
            Rules[2] = "пт. 3 - для каждого вопроса предоставляется 4 варианта ответа;";
            Rules[3] = "пт. 4 - для ответа на вопрос необходимо ввести номер в числовом представлении, н.п. '1';";
            Rules[4] = "пт. 5 - при выборе верного ответа на вопрос выйгрыш приумножается х 2, по выбору пользователя "
                + "\n при помощи комманды 'Продолжить игру' игра может быть продолжена или завершена при вооде комманды 'Завершить игру';";
            Rules[5] = "пт. 6 - при выборе не верного ответа на вопрос, игра окончена, выйгрыш = 0;";
            Rules[6] = "пт. 7 - при условии верного ответа на все вопросы или при вооде комманды 'Завершить игру' игрок Выйграл и может забрать свои средства.";
            foreach (string rule in Rules)
            {
                Console.WriteLine(rule);
            }
        }
        public User CreateUser()
        {
            Console.WriteLine("Введите Имя игрока");
            User newUser = new User(Console.ReadLine());
            if (string.IsNullOrEmpty(newUser.userName))
            {
                Console.WriteLine("Вы не ввели имя!");
                return CreateUser();
            }
            else
            {
                Console.WriteLine("Ваше имя " + newUser.userName);
                return newUser;
            }

        }
        public Questions[] CreateListQuestions()
        {
            Questions[] question = new Questions[2];
            question[0] = new Questions("Who is the president of the USA?");
            question[1] = new Questions("Where are we?");
            return question;

        }
        public  Answers[] CreateAnswerList1(Questions[] question)
        {
            question[0].answers = new Answers[4];
            question[0].answers[0]= new WrongAnswer("1",". I am;");
            question[0].answers[1] = new WrongAnswer("2",". You are;");
            question[0].answers[2] = new CorrectAnswer("3",". Joseph Robinette Biden;");
            question[0].answers[3] = new WrongAnswer("4",". Barack Obama.");
            return question[0].answers;

        }
        public Answers[] CreateAnswerList2(Questions[] question)
        {
            question[1].answers = new Answers[4];
            question[1].answers[0] = new CorrectAnswer("1",".We are in Belarus;");
            question[1].answers[1] = new WrongAnswer("2"," .We are in the USA;");
            question[1].answers[2] = new WrongAnswer("3"," .We are in Canada;");
            question[1].answers[3] = new WrongAnswer("4"," .We are in Poland.");

            return question[1].answers;

        }
        public int NumberInput()
        {
            try
            {
                Console.WriteLine("Введите номер верного ответа:");
                int getNumber = int.Parse(Console.ReadLine());
                if (getNumber >= 1 & getNumber <= 4)
                {
                    return getNumber;
                }
                else
                {
                    Console.WriteLine("Введите номер верного ответа от 1 до 4:");
                    return NumberInput();
                }  
            }
            catch
            {
                Console.WriteLine("Введите число от 1 до 4:");
                return NumberInput();
            }
        }
        public string DesignInput()
        {
            try
            {
                string userInput = Console.ReadLine();
                if((string.Equals(userInput, "нет", StringComparison.OrdinalIgnoreCase)) || (string.Equals(userInput, "да", StringComparison.OrdinalIgnoreCase)))
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Введите Да или Нет!");
                    return DesignInput();
                }
            }
            catch
            {
                Console.WriteLine("Введите Да или Нет!");
                return DesignInput();
            }
        }
        public  void GameLoop(Questions [] question,User newUser)
        {
            for(int startindex = 0; startindex < question.Length; startindex++)
            {
                Console.WriteLine(question[startindex].questionText);
                foreach(Answers answerNumberText in question[startindex].answers)
                {
                    Console.WriteLine(answerNumberText.answerNumber+answerNumberText.answerText);
                }
               

                if ((question[startindex].answers[NumberInput()-1] as CorrectAnswer)!=null)
                {
                    if (startindex != question.Length-1)
                    {
                        Console.WriteLine("Вы хотите продолжить игру? Для продлжения игры введите да, для выхода нет.");
                    }
                        
                    if ((newUser.userScore == 200) || (string.Equals(DesignInput(), "нет", StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine(newUser.userName +" Вы выйграли!!!" + "\n Ваш счет = " + newUser.userScore);
                        return;
                    }
                    else
                    {
                        newUser.userScore = newUser.userScore * 2;
                    }
                }
                else
                {
                    newUser.userScore = 0;
                    Console.WriteLine(newUser.userName + " Вы  проиграли!!!"+"\n Ваш счет = "+newUser.userScore);
                    return;
                }

            }
            
        }
    }
    
    


}

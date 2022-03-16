using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ds_c_sharp;
using System.Threading;
namespace ds_c_sharp
{
    
    class Program
    {





        static void Main(string[] args)
        {
            hangman g = new hangman();


            bool exit = false;
            while (!exit)
            {
                g.logo();
                Console.Clear();
                string s_choice;
                int choice = 0;
                Console.Write("1- Start game");
                Console.Write("\n");
                Console.Write("2- How to play");
                Console.Write("\n");
                Console.Write("3- Score");
                Console.Write("\n");
                Console.Write("4- Credit");
                Console.Write("\n");
                Console.Write("5- Exit");
                Console.Write("\n");

                Console.Write("please Enter your choice ?\n");
                while (true)
                {
                    s_choice = Console.ReadLine();
                    if (s_choice != "")
                    { choice = Convert.ToInt32(s_choice); }
                    if (choice > 0 && choice < 6)
                    {
                        break;
                    }
                    else
                    {
                        if (s_choice != "")
                        {
                            Console.WriteLine("please Enter number between 1 and 5.");

                        }
                    }
                }



                switch (choice)
                {

                    case 1:
                        Console.Clear();
                        g.game_continue();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write(" You should read the description of the word then you will try to enter the correct word ");
                        Console.Write(" & you have 3 trials if you you enter the correct word your score will be incremented ");
                        Console.Write("else you fail in the 3 trials a hint will appear to you telling you the number of characters in the word ");
                        Console.Write(" & you will enter character by character & also you have only 3 trials if you win your score will be incremented else you fail ");
                        Console.Write("\n");
                        ///how to play
                        break;
                    case 3:
                        Console.Clear();
                        string f = @"Scores.txt";
                        string readText = File.ReadAllText(f);
                        Console.WriteLine(readText);
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("This project is done by : ");
                        Console.Write("\n");
                        Console.Write("Ahmed Yasser ");
                        Console.Write("\n");
                        Console.Write("Alaaeldin Abderhman");
                        Console.Write("\n");
                        Console.Write("Goher Assem");
                        Console.Write("\n");
                        Console.Write("Hossam Bassem");
                        Console.Write("\n");
                        Console.Write("Mohammad Tarek");
                        Console.Write("\n");
                        Console.Write("Nour Khaild");
                        Console.Write("\n");
                        /////Credit
                        break;
                    case 5:
                        ///Exit
                        exit = true;
                        break;
                    default:
                        break;
                }

            }

        }
    }
}
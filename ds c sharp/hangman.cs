using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ds_c_sharp
{


    public class word
    {
        public string name;
        public string meaning;
        public string category;
    }

    public class hangman
    {

        private int wtry;
        private char[] cword;
        private char[] wtmp;
        private char[] cmean;
        string n;
        int score = 0;
        private char[] hiden_word;
        public List<word> shows = new List<word>();
        public List<word> movies = new List<word>();
        public List<word> songs = new List<word>();
        public List<List<word>> data = new List<List<word>>();
        FileStream Scores = new FileStream("Scores.txt", FileMode.OpenOrCreate);
        public hangman()
        {
            load();
            Scores.Close();
        }
        public void logo()
        {
            Console.WriteLine("                               ||====+                     ");
            Console.WriteLine("                               ||    O                    ");
            Console.WriteLine("                               ||   /|\\                     ");
            Console.WriteLine("   __    __       ___      .__ ||__./ \\_______ .___  ___.      ___      .__   __. ");
            Console.WriteLine("  |  |  |  |     /   \\     |  \\||  |  /  _____||   \\/   |     /   \\     |  \\ |  | ");
            Console.WriteLine("  |  |__|  |    /  ^  \\    |   \\|  | |  |  __  |   \\/   |    /  ^  \\    |   \\|  | ");
            Console.WriteLine("  |   __   |   /  /_\\  \\   |  . `  | |  | |_ | |  |\\/|  |   /  /_\\  \\   |  . `  | ");
            Console.WriteLine("  |  |  |  |  /  _____  \\  |  |\\   | |  |__| | |  |  |  |  /  _____  \\  |  |\\   | ");
            Console.WriteLine("  |__|  |__| /__/     \\__\\ |__| \\__|  \\______| |__|  |__| /__/     \\__\\ |__| \\__| ");
            Console.WriteLine("");
            Console.WriteLine("Enter any key...");
            Console.ReadKey();
        }
       
        
        public void hint()
        {
            for (int i = 0; i < cword.Length; i = i + 3)
            {

                if (!Equals(cword[i], ' '))
                {

                  
                    for (int j = 0; j < cword.Length; j++)
                    {
                        
                        if (cword[i] == wtmp[j])
                        {
                            hiden_word[j] =cword[i];
                            wtmp[j] = '0';
             
                        }
                    }
                }


            }



        }
        public void load()
        {
            StreamReader file = new StreamReader(@"m.txt");

            {

                while (true)
                {
                    word temp = new word();
                    temp.name = file.ReadLine();
                    if (temp.name == "pause")
                    {
                        break;
                    }
                    temp.meaning = file.ReadLine();
                    if (temp.meaning == "pause")
                    {
                        break;
                    }
                    temp.category = file.ReadLine();
                    if (temp.category == "pause")
                    {
                        break;
                    }
                    if (temp.category == "song")
                    {
                        songs.Add(temp);
                    }
                    if (temp.category == "movie")
                    {
                        movies.Add(temp);
                    }
                    if (temp.category == "tv show")
                    {
                        shows.Add(temp);
                    }

                }

                file.Close();
                data.Add(movies);
                data.Add(shows);
                data.Add(songs);

            }
        }
        public bool checkwin(char[] s)
        {
            string s1 = new string(s);
            s1 = s1.ToLower();
            string s2 = new string(cword);
            if (Equals(s1, s2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool checkchar(char s)
        {

            for (int i = 0; i < cword.Length; i++)
            {
                char.ToLower(s);
                if (s == wtmp[i])
                {
                    hiden_word[i] = s;
                    wtmp[i] = '0';
                    return true;
                }
            }
            return false;
        }


        public void random_word(int s)
        {
            int numofrand;
            Random Rand = new Random();
            numofrand = Rand.Next(0, data[s - 1].Count);
            string name0 = data[s - 1][numofrand].name;
            string mean0 = data[s - 1][numofrand].meaning;
            cword = name0.ToCharArray();
            wtmp = name0.ToCharArray();
            hiden_word = name0.ToCharArray();
            cmean = mean0.ToCharArray();
            for (int i = 0; i < cword.Length; i++)
            {

                if (!Equals(cword[i], ' '))
                {
                    hiden_word[i] = '#';
                }

            }
            wtry = 0;
        }
        public void game_continue()
        {


            Console.Write("please enter player's name: ");
            n = Console.ReadLine();
            Console.Clear();
            string s_ans;
            char[] ans;
            bool resume = true;
            Console.Write("Enter category?");
            Console.Write("\n");
            Console.Write("1-Movies");
            Console.Write("\n");
            Console.Write("2-Tv shows");
            Console.Write("\n");
            Console.Write("3-songs");
            Console.Write("\n");
            int cat;
            string level;
            bool level22 = false;
            string s_cat;
            s_cat = Console.ReadLine();
            Console.Clear();
            cat = Convert.ToInt32(s_cat);
            random_word(cat);
            Console.Write("levels:");
            Console.Write("\n");
            Console.Write("1-Easy");
            Console.Write("\n");
            Console.Write("2-Hard");
            Console.Write("\n");
            level = Console.ReadLine();
            Console.Clear();
            if (level == "1")
            {
                level22 = true;
            }
            while (resume)
            {
                draw(wtry);
                Console.Write(cmean);
                Console.Write("\n");



                if (wtry < 3)
                {
                    Console.Write("Enter Word :");

                    s_ans = Console.ReadLine();
                    Console.Clear();
                    ans = s_ans.ToCharArray();
                    if (checkwin(ans))
                    {

                        score += 10;
                        Console.Write("right answer !");

                        Console.Write("\n");
                        random_word(cat);


                    }
                    else
                    {
                        Console.Write("try again");
                        Console.Write("\n");
                        wtry++;


                    }
                }
                else if (wtry >= 3 && wtry < 6)
                {
                    if (level22 == true)
                    {
                        hint();
                    }
                    Console.Write("Enter character :");

                    Console.Write(hiden_word);
                    Console.Write("\n");
                    s_ans = Console.ReadLine();
                    Console.Clear();
                    ans = s_ans.ToCharArray();
                    while (s_ans.Length > 1)
                    {
                        Console.Write("you should enter only one character");
                        Console.Write("\n");
                        Console.Write("enter a character : ");
                        Console.Write("\n");
                        s_ans = Console.ReadLine();
                        ans = s_ans.ToCharArray();
                        Console.Clear();
                    }

                    if (checkchar(ans[0]))
                    {
                        if (checkwin(hiden_word))
                        {
                            /// n.score += 10;
                            score += 10;
                            Console.Write("right answer !");
                            Console.Write("\n");
                            random_word(cat);

                        }
                    }
                    else
                    {
                        wtry++;
                        Console.Write("try again");
                        Console.Write("\n");

                        continue;
                    }
                }
                else
                {

                    Console.Write("GAME OVER !");
                    Console.Write("\n");
                    Console.Write("Your score is ");
                    Console.WriteLine(score);
                    Console.Write("\n");
                    file_Score(n, score);
                    score = 0;
                    resume = false;
                }
            }

        }
        public void draw(int c)
        {
            switch (c)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine(" __           ");
                    Console.WriteLine("|          |          ");
                    Console.WriteLine("|          |          ");
                    Console.WriteLine("|          |          ");
                    Console.WriteLine("| ===      |          ");
                    Console.WriteLine("|__|          ");
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("  __         ");
                    Console.WriteLine(" |  *==     |        ");
                    Console.WriteLine(" |  |       |        ");
                    Console.WriteLine(" |  |       |        ");
                    Console.WriteLine(" | ===      |        ");
                    Console.WriteLine(" |__|        ");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("  __      ");
                    Console.WriteLine(" |  *===O   |     ");
                    Console.WriteLine(" |  |       |     ");
                    Console.WriteLine(" |  |       |     ");
                    Console.WriteLine(" | ===      |     ");
                    Console.WriteLine(" |__|     ");
                    Console.WriteLine();
                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("  __  ");
                    Console.WriteLine(" |  *===O   |      ");
                    Console.WriteLine(" |  |   |   |      ");
                    Console.WriteLine(" |  |       |      ");
                    Console.WriteLine(" | ===      |      ");
                    Console.WriteLine(" |__|      ");
                    Console.WriteLine();
                    break;

                case 5:
                    Console.WriteLine();
                    Console.WriteLine("  __  ");
                    Console.WriteLine(" |  *===O   |      ");
                    Console.WriteLine(" |  |  /|\\  |      ");
                    Console.WriteLine(" |  |       |      ");
                    Console.WriteLine(" | ===      |      ");
                    Console.WriteLine(" |__|      ");
                    Console.WriteLine();
                    break;

                case 6:
                    Console.WriteLine();
                    Console.WriteLine("  __  ");
                    Console.WriteLine(" |  *===O   |      ");
                    Console.WriteLine(" |  |  /|\\  |      ");
                    Console.WriteLine(" |  |  / \\  |      ");
                    Console.WriteLine(" | ===      |      ");
                    Console.WriteLine(" |__|      ");
                    Console.WriteLine();
                    break;

            }
        }
        public void file_Score(string name, int score)
        {
            string fileName = @"Scores.txt";
            FileInfo filetoappend = new FileInfo(fileName);
            using (StreamWriter writer = File.AppendText(@"Scores.txt"))

            {
                writer.Write("Name\t\tScore\n");
                writer.Write(name);
                writer.Write("\t\t ");
                writer.Write(score);
                writer.Write("\n");
                writer.WriteLine("_");

            }


        }


    }



}
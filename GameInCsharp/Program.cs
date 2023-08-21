using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using EZInput;
using System.Threading;
using System.Threading.Tasks;

namespace GameInCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int pikachuHealthCount = 6;
            int spikoHealthCount = 10;
            int darcoHealthCount = 10;
            int score = 0;
            string spikoDirection = "up";
            string darkoDirection = "left";
            Player Dirpikachu = new Player(10, 2, pikachuHealthCount, score);
            Enemy Dirspiko = new Enemy(4, 8, spikoHealthCount, spikoDirection);
            Enemy Dirdarco = new Enemy(56, 18, darcoHealthCount, darkoDirection);
            Bullet k = new Bullet();
            List<Bullet> SB = new List<Bullet>();
            List<Bullet> BP = new List<Bullet>();
            List<Bullet> DB = new List<Bullet>();

            int Timer = 0;
            char[,] maze = new char[25, 71];
            //characters for printing enemy and player
            char pika = (char)1;
            char pika2 = (char)17;
            char pika3 = (char)16;
            char pika4 = (char)124;
            char shark = (char)2;
            char misty1 = (char)19;
            char[,] spiko = new char[2, 3] { { ' ', shark, ' ' }, { pika2, misty1, pika3 } };
            char[,] darco = new char[2, 3] { { ' ', shark, ' ' }, { pika2, misty1, pika3 } };
            char[,] pikachu = new char[2, 3] { { ' ', pika, ' ' }, { pika2, pika4, pika3 } };
            //statrt of game
            // k.StartGame();
            Console.Clear();
            Console.Beep();
            int option=0;
            while (option != -1)
            {
                Header();
                Console.WriteLine("1.start");
                Console.WriteLine("2.option");
                Console.WriteLine("3.exit");
                Console.WriteLine("Enter Your option: ");
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Enter valid choice"); 
                }

                if (option == 1)
                {
                    Console.WriteLine("1.New Game");
                    Console.WriteLine("2.Resume");
                    Console.WriteLine("Enter Your option: ");
                    string choice = Console.ReadLine();
                    if (choice =="2" )
                    {
                        ReadGameFromFile(Dirpikachu, Dirspiko, Dirdarco, k);
                    }
                    Console.WriteLine("LOADING..........");
                    Console.WriteLine("Press any key to continue! ");
                    bool gameRun = true;
                    Console.Clear();
                    ReadMazeFromFile(maze);
                    Maze(maze);
                    while (gameRun)
                    {
                        Thread.Sleep(90);
                        PrintScore(Dirpikachu); //x y bhi pass kr ke aek hee function bna do in saaron ko 
                        PrintSpikoHealth(Dirspiko);
                        PrintDarcoHealth(Dirdarco);
                        Printpikachuhealth(Dirpikachu);
                        MoveSpiko(spiko, maze, Dirspiko);
                        MoveDarco(darco, maze, Dirdarco);
                        ErasePikachu(Dirpikachu);
                        if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            bool flag = CheckPikachuLeft(maze, Dirpikachu, SB);
                            if (!flag)
                            {
                                Dirpikachu.MovePikachuLeft();
                            }
                        }
                        if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            bool flag = CheckPikachuRight(maze, Dirpikachu);
                            if (!flag)
                            {
                                Dirpikachu.MovePikachuRight();
                            }
                        }
                        if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            bool flag = CheckPikachuUp(maze, Dirpikachu);
                            if (!flag)
                            {
                                Dirpikachu.MovePikachuUp();
                            }
                        }
                        if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            bool flag = CheckPikachuDown(maze, Dirpikachu);
                            if (!flag)
                            {
                                Dirpikachu.MovePikachuDown();
                            }
                        }
                        if (EZInput.Keyboard.IsKeyPressed(Key.Space))
                        {
                            GenerateBulletPikachu(BP, Dirpikachu);
                        }
                        if (EZInput.Keyboard.IsKeyPressed(Key.Tab))
                        {
                            //generatebulletpikachupikachuleft(totalbullet, pikachuBulletcount, pikachux, pikachuy);
                        }
                        PrintPikachu(pikachu, Dirpikachu);
                        if (Timer == 3)
                        {
                            GenerateBulletSpiko(SB, Dirspiko);  //generate ka single funciton ho skta h, based on position to spawn
                            GenerateBulletDarco(DB, Dirdarco);  //aur bullet ki list sirf eaek hee ho skti h 

                            Timer = 0;
                        }
                        MoveBulletSpiko(maze, SB, Dirpikachu);      //lehaza move bhi sirf aek hee hoga 
                        //MoveBulletDarco(maze, DB, k, Dirpikachu);
                        Timer++;
                        MoveBulletPikachu(maze, BP, Dirpikachu);
                        WriteGameToFile(Dirpikachu, Dirspiko, Dirdarco, k);
                        pikachuCollisionWithSpiko(Dirpikachu, Dirspiko);
                        if (Dirpikachu.HealthCount <= 0)
                        {
                            gameRun = false;
                            Console.Clear();
                            //gameover(score);
                            Console.WriteLine("Enter any key to continue");
                            Console.ReadKey();
                        }
                    }
                }
                else if (option == 2)
                {
                    Console.Clear();
                    GameInstruction();
                }
                else if (option == 3)     //while lga lena game menu k lie
                {
                    Console.WriteLine("Exit");
                    Console.Clear();
                }
            }
        }
        static void Header()
        {
            Console.WriteLine("LOADING....");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(" OooOOo.     o                   o           Oo             `o    O                       o               ");
            Console.WriteLine("O     `O o  O                  O            oO              o   O   o                   O                 ");
            Console.WriteLine("o      O    o                  o             O              O  O                        o                 ");
            Console.WriteLine("O     .o    o                  O            o'              oOo                         o                 ");
            Console.WriteLine("oOooOO'  O  O  o  .oOoO' .oOo  OoOo. O   o     .oOo         o  o    O  'OoOo. .oOoO .oOoO  .oOo. `oOOoOO. ");
            Console.WriteLine("o        o  OoO   O   o  O     o   o o   O     `Ooo.        O   O   o   o   O o   O o   O  O   o  O  o  o ");
            Console.WriteLine("O        O  o  O  o   O  o     o   O O   o         O        o    o  O   O   o O   o O   o  o   O  o  O  O ");
            Console.WriteLine("o'       o' O   o `OoO'o `OoO' O   o `OoO'o    `OoO'        O     O o'  o   O `OoOo `OoO'o `OoO'  O  o  o ");
            Console.WriteLine("                                                                                  O                       ");
            Console.WriteLine("                                                                               OoO'                       ");
        }
        static void Keys()
        {
            Console.Clear();
            Console.WriteLine("LOADING........");
            Console.ReadKey();
            Console.WriteLine(":::    ::: :::::::::: :::   :::  ::::::::   ");
            Console.WriteLine(":+:   :+:  :+:        :+:   :+: :+:    :+:  ");
            Console.WriteLine("+:+  +:+   +:+         +:+ +:+  +:+         ");
            Console.WriteLine("+#++:++    +#++:++#     +#++:   +#++:++#++  ");
            Console.WriteLine("+#+  +#+   +#+           +#+           +#+  ");
            Console.WriteLine("#+#   #+#  #+#           #+#    #+#    #+#  ");
            Console.WriteLine("###    ### ##########    ###     ########   ");

            Console.WriteLine("Prees up key to move up");
            Console.WriteLine("Press down key to move ");
            Console.WriteLine("Press left key to move left");
            Console.WriteLine("Press right key to move right");
            Console.WriteLine("Press space key to shoot right");
            Console.WriteLine("Press tab key to shoot left");
        }
        static void Instructions()
        {

            Console.WriteLine("LOADING.....");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("::::::::::: ::::    :::  ::::::::  ::::::::::: :::::::::  :::    :::  ::::::::  ::::::::::: :::::::::::  ::::::::  ::::    :::  ::::::::  ");
            Console.WriteLine("    :+:     :+:+:   :+: :+:    :+:     :+:     :+:    :+: :+:    :+: :+:    :+:     :+:         :+:     :+:    :+: :+:+:   :+: :+:    :+: ");
            Console.WriteLine("    +:+     :+:+:+  +:+ +:+            +:+     +:+    +:+ +:+    +:+ +:+            +:+         +:+     +:+    +:+ :+:+:+  +:+ +:+        ");
            Console.WriteLine("    +#+     +#+ +:+ +#+ +#++:++#++     +#+     +#++:++#:  +#+    +:+ +#+            +#+         +#+     +#+    +:+ +#+ +:+ +#+ +#++:++#++ ");
            Console.WriteLine("    +#+     +#+  +#+#+#        +#+     +#+     +#+    +#+ +#+    +#+ +#+            +#+         +#+     +#+    +#+ +#+  +#+#+#        +#+ ");
            Console.WriteLine("    #+#     #+#   #+#+# #+#    #+#     #+#     #+#    #+# #+#    #+# #+#    #+#     #+#         #+#     #+#    #+# #+#   #+#+# #+#    #+# ");
            Console.WriteLine("########### ###    ####  ########      ###     ###    ###  ########   ########      ###     ###########  ########  ###    ####  ########  ");

            Console.WriteLine("shoot the sharks to get extra point");
            Console.WriteLine("collect fish to get points");
            Console.WriteLine("find a key to go to next leve");
            Console.WriteLine("save your player from bullets of sharks");
            Console.WriteLine("sharks health will decrease your bullets will hit them");
            Console.WriteLine("Player bullets should not touch small fish because they will die");
        }
        static void GameInstruction()
        {
            string choice = "";
            while (choice != "3")
            {
                Console.Clear();
                Console.WriteLine("1.keys");
                Console.WriteLine("2.instructions");
                Console.WriteLine("3.exit");
                Console.WriteLine("Enter your option:");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Keys();
                    Console.WriteLine("Press any key to continue");
                }

                else if (choice == "2")
                {
                    Instructions();
                    Console.WriteLine("Press any key to continue");
                }

                else if (choice == "3")
                {
                    Console.Clear();
                }
                Console.ReadKey();
            }
        }


        static void ReadMazeFromFile(char[,] maze)
        {
            string path = "D:\\oopweek4pdTask\\GameInCsharp\\gameMaze.txt";
            StreamReader fp = new StreamReader(path);
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 70; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }
        static void Maze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }3
        }
        //bullet generate function start
        static void GenerateBulletSpiko(List<Bullet> SB, Enemy Dirspiko)
        {
            Bullet Sbullets = new Bullet(Dirspiko.X, Dirspiko.Y);
            if (Dirspiko.HealthCount > 0)
            {
                Sbullets.X = Dirspiko.X + 2;
                Sbullets.Y = Dirspiko.Y;
                Console.SetCursorPosition(Dirspiko.X + 2, Dirspiko.Y);
                Console.WriteLine("-");
                SB.Add(Sbullets);
            }
        }
        static void GenerateBulletDarco(List<Bullet> DB, Enemy DirDarco)
        {
            Bullet Sbullets = new Bullet(DirDarco.X, DirDarco.Y);
            if (DirDarco.HealthCount > 0)
            {
                Sbullets.X = DirDarco.X + 2;
                Sbullets.Y = DirDarco.Y;
                Console.SetCursorPosition(DirDarco.X + 2, DirDarco.Y);
                Console.WriteLine("-");
                DB.Add(Sbullets);
            }
        }
        static void GenerateBulletPikachu(List<Bullet> BP, Player Dirpikachu)
        {
            Bullet Pbullets = new Bullet(Dirpikachu.X, Dirpikachu.Y);
            if (Dirpikachu.HealthCount > 0)
            {
                Pbullets.X = Dirpikachu.X + 2;
                Pbullets.Y = Dirpikachu.Y;
                Console.SetCursorPosition(Dirpikachu.X + 2, Dirpikachu.Y);
                Console.WriteLine("-");
                BP.Add(Pbullets);
            }
        }
        //bullet generate function end
        //print functions start
        static void PrintSpiko(char[,] spiko, Enemy Dirspiko)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (Dirspiko.HealthCount >= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(Dirspiko.X, Dirspiko.Y + i);
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(spiko[i, j]);
                    }
                }
            }
            else if (Dirspiko.HealthCount < 0)
            {
                EraseSpiko(Dirspiko);
            }
        }
        static void PrintDarco(char[,] darco,Enemy DirDarco )
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (DirDarco.HealthCount >= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(DirDarco.X, DirDarco.Y + i);
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(darco[i, j]);
                    }
                }
            }
            else if (DirDarco.HealthCount < 0)
            {
                EraseSpiko(DirDarco);
            }

        }
        static void PrintPikachu(char[,] pikachu, Player Dirpikachu)
        {
            if (Dirpikachu.HealthCount >= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(Dirpikachu.X, Dirpikachu.Y + i);
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(pikachu[i, j]);
                    }
                }
            }
            else if (Dirpikachu.HealthCount < 0)
            {
                ErasePikachu(Dirpikachu);
            }
        }
        //print functins end
        //print bullets functions start
        static void PrintBulletSpiko(ref int spikoBulletX, ref int spikoBulletY)
        {
            Console.SetCursorPosition(spikoBulletX, spikoBulletY);
            Console.WriteLine("-");

        }
        static void PrintBulletDarco(ref int darcoBulletX, ref int darcoBulletY)
        {
            Console.SetCursorPosition(darcoBulletX, darcoBulletY);
            Console.WriteLine("-");

        }
        static void PrintBulletPikachu(ref int pikachuBulletX, ref int pikachuBulletY)
        {
            Console.SetCursorPosition(pikachuBulletX, pikachuBulletY);
            Console.WriteLine("*");

        }
        static void MoveSpiko(char[,] spiko, char[,] maze, Enemy Dirspiko)
        {
            if (Dirspiko.Direction == "up")
            {
                bool flag = CheckSpikoDown(maze, Dirspiko);
                if (!flag)
                {
                    EraseSpiko(Dirspiko);
                    Dirspiko.MoveSpikoDown();
                    PrintSpiko(spiko, Dirspiko);
                }
            }
            if (Dirspiko.Direction == "down")
            {
                bool isflag = CheckSpikoUp(maze, Dirspiko);
                if (!isflag)
                {
                    EraseSpiko(Dirspiko);
                    Dirspiko.MoveSpikoUp();
                    PrintSpiko(spiko, Dirspiko);

                }
            }

        }
        //move functions start
        static bool CheckSpikoDown(char[,] maze, Enemy Dirspiko)
        {
            bool flag = false;

            for (int i = 0; i < 3; i++)
            {
                if (maze[Dirspiko.Y - 1, Dirspiko.X + i] == '&')
                {
                    flag = true;
                    Dirspiko.Direction = "down";
                }
                if (maze[Dirspiko.Y - 1, Dirspiko.X + i] == '*')
                {
                    Dirspiko.HealthCount--;
                }


            }
            return flag;
        }
        static bool CheckSpikoUp(char[,] maze, Enemy Dirspiko)
        {

            bool isflag = false;
            for (int i = 0; i < 3; i++)
            {
                if (maze[Dirspiko.Y + 2, Dirspiko.X + i] == '&')
                {
                    isflag = true;
                    Dirspiko.Direction = "up";
                }
                if (maze[Dirspiko.Y + 2, Dirspiko.X + i] == '*')
                {
                    Dirspiko.HealthCount--;
                }
            }
            return isflag;
        }
        static bool CheckDarcoLeft(char[,]maze,Enemy DirDarco)
        {
            bool isflag = false;
            for(int i=0;i<2;i++)
            {
                if(maze[DirDarco.Y+i,DirDarco.X-1]=='&')
                {
                    isflag = true;
                    DirDarco.Direction = "left";
                }
                if (maze[DirDarco.Y+i,DirDarco.X-1]=='*')
                {
                    DirDarco.HealthCount--;
                }
            }
            return isflag;
        }
        static bool CheckDarcoRight(char[,] maze,Enemy DirDarco)
        {
            bool isflag = false;
            for(int i=0;i<2;i++)
            {
                if(maze[DirDarco.Y+i,DirDarco.X+3]=='&')
                {
                    isflag = true;
                    DirDarco.Direction = "right";
                }
                if(maze[DirDarco.Y+i,DirDarco.X+3]=='*')
                {
                    DirDarco.HealthCount--;
                }
            }
            return isflag;
        }
        static void MoveDarco(char[,] darco, char[,] maze, Enemy DirDarco)
        {

            if (DirDarco.Direction == "left")
            {
                bool flag = CheckDarcoRight(maze, DirDarco);
                if (!flag)
                {
                    EraseDarco(DirDarco);
                    DirDarco.MoveDarcoRight();
                    PrintDarco(darco, DirDarco);
                }
            }
            if (DirDarco.Direction == "right")
            {
                bool isflag = CheckDarcoLeft(maze, DirDarco);
                if (!isflag)
                {
                    EraseDarco(DirDarco);
                    DirDarco.MoveDarcoLeft();
                    PrintDarco(darco, DirDarco);

                }
            }
        }
        static bool CheckPikachuLeft(char[,] maze, Player Dirpikachu, List<Bullet> SB)
        {

            bool flag = false;
            for (int i = 0; i < 2; i++)
            {
                if (maze[Dirpikachu.Y + i, Dirpikachu.X - 1] == '&')
                {
                    flag = true;
                }
                if (maze[Dirpikachu.Y + i, Dirpikachu.X - 1] == '^')
                {
                    Dirpikachu.score++;
                }
            }
            return flag;
        }
        static bool CheckPikachuRight(char[,] maze, Player Dirpikachu)
        {
            bool flag = false;
            for (int i = 0; i < 2; i++)
            {
                if (maze[Dirpikachu.Y + i, Dirpikachu.X + 3] == '&')
                {
                    flag = true;
                }
                else if (maze[Dirpikachu.Y + i, Dirpikachu.X + 3] == '^')
                {
                    Dirpikachu.score++;
                }
            }
            return flag;
        }
        static bool CheckPikachuUp(char[,] maze, Player Dirpikachu)
        {
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                if (maze[Dirpikachu.Y - 1, Dirpikachu.X + i] == '&')
                {
                    flag = true;
                }
                else if (maze[Dirpikachu.Y - 1, Dirpikachu.X + i] == '^')
                {
                    Dirpikachu.score++;
                }
            }
            return flag;
        }
        static bool CheckPikachuDown(char[,] maze, Player Dirpikachu)
        {
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                if (maze[Dirpikachu.Y + 2, Dirpikachu.X + i] == '&')
                {
                    flag = true;
                }
                else if (maze[Dirpikachu.Y + 2, Dirpikachu.X + i] == '^')
                {
                    Dirpikachu.score++;
                }

            }
            return flag;

        }
        //move functions end
        //bullets movement start
        static void MoveBulletSpiko(char[,] maze, List<Bullet> SB, Player Dirpikachu)
        {
            //Game Sbullet = new Game(Dirspiko.X, Dirspiko.Y);
            for (int i = 0; i < SB.Count; i++)
            {
                if (maze[SB[i].Y, SB[i].X + 1] != ' ')
                {

                    EraseBulletSpiko(SB, i);
                    SB.RemoveAt((i));
                }
                if (SB[i].X + 1 == Dirpikachu.X && (SB[i].Y == Dirpikachu.Y || SB[i].Y == Dirpikachu.Y + 1))
                {
                    Dirpikachu.HealthCount--;
                    EraseBulletSpiko(SB, i);
                    SB.RemoveAt((i));

                }
                else
                {
                    EraseBulletSpiko(SB, i);
                    SB[i].X = SB[i].X + 1;
                    PrintBulletSpiko(ref SB[i].X, ref SB[i].Y);

                }
            }
        }
        //static void MoveBulletDarco(char[,] maze, List<Bullet> DB,Bullet k, Player Dirpikachu)
        //{
        //    //Game Sbullet = new Game(Dirspiko.X, Dirspiko.Y);
        //    for (int i = 0; i < DB.Count; i++)
        //    {
        //        if (maze[DB[i].Y, DB[i].X +1] != ' ')
        //        {

        //            EraseBulletDarco(DB, i);
        //            DB.RemoveAt((i));
        //        }
        //        if (DB[i].X +1 == Dirpikachu.X && (DB[i].Y == Dirpikachu.Y || DB[i].Y == Dirpikachu.Y +1))
        //        {
        //            Dirpikachu.HealthCount--;
        //            EraseBulletDarco(DB, i);
        //            DB.RemoveAt((i));

        //        }
        //        else
        //        {
        //            EraseBulletDarco(DB, i);
        //           DB[i].X = DB[i].X + 1;
        //            PrintBulletDarco(ref DB[i].X, ref DB[i].Y);

        //        }
        //    }
        //}
        static void MoveBulletPikachu(char[,] maze, List<Bullet> PB, Player Dirpikachu)
        {
            for (int i = 0; i < PB.Count; i++)
            {
                if (maze[PB[i].Y, PB[i].X + 1] != ' ')
                {
                    EraseBulletPikachu(PB, i);
                    PB.RemoveAt((i));
                }
                else
                {
                    EraseBulletPikachu(PB, i);
                    PB[i].X = PB[i].X + 1;
                    PrintBulletPikachu(ref PB[i].X, ref PB[i].Y);

                }
            }
        }

        ////erasing functions start
        static void EraseSpiko(Enemy Dirspiko)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(Dirspiko.X, Dirspiko.Y + i);
                Console.WriteLine("   ");
            }
        }
        static void EraseDarco(Enemy DirDarco)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(DirDarco.X, DirDarco.Y + i);
                Console.WriteLine("   ");
            }
        }
        static void ErasePikachu(Player Dirpikachu)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(Dirpikachu.X, Dirpikachu.Y + i);
                Console.WriteLine("   ");
            }
        }
        ////bullet erase functions start
        static void EraseBulletSpiko(List<Bullet> SB, int i)
        {
            Console.SetCursorPosition(SB[i].X, SB[i].Y);
            Console.WriteLine(" ");
        }
        static void EraseBulletDarco(List<Bullet>DB,int i)
        {
            Console.SetCursorPosition(DB[i].X, DB[i].Y);
            Console.WriteLine(" ");
        }
        static void EraseBulletPikachu(List<Bullet> BP, int i)
        {
            Console.SetCursorPosition(BP[i].X, BP[i].Y);
            Console.WriteLine(" ");

        }
        ////player enemy collision
        static void pikachuCollisionWithSpiko(Player Dirpikachu, Enemy Dirspiko)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((Dirpikachu.X + i == Dirspiko.X + j) && (Dirpikachu.Y + j == Dirspiko.Y + i))
                    {
                        Dirpikachu.HealthCount--;
                        break;
                    }
                }
            }
        }
        static void PikachuCollisionWithBulletSpiko(Player Dirpikachu)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Dirpikachu.X - 1 == '-' && Dirpikachu.Y + i == '-')
                {
                    Dirpikachu.HealthCount--;
                }
            }
        }

        ////bullet erasing functions end
        static void PrintScore(Player Dirpikachu)
        {
            Console.SetCursorPosition(105, 1);
            Console.WriteLine("Fishes: {0}", Dirpikachu.score);
        }
        static void PrintSpikoHealth(Enemy Dirspiko)
        {
            Console.SetCursorPosition(105, 3);
            if (Dirspiko.HealthCount >= 0)
            {
                Console.WriteLine("spiko health {0}", Dirspiko.HealthCount);
            }
            else if (Dirspiko.HealthCount < 0)
            {
                Console.WriteLine("died         ");
            }
        }
        static void PrintDarcoHealth(Enemy DirDarco)
        {
            Console.SetCursorPosition(105, 4);
            if (DirDarco.HealthCount >= 0)
            {
                Console.WriteLine("spiko health {0}", DirDarco.HealthCount);
            }
            else if (DirDarco.HealthCount < 0)
            {
                Console.WriteLine("died         ");
            }

        }
        static void Printpikachuhealth(Player Dirpikachu)
        {
            Console.SetCursorPosition(105, 6);
            if (Dirpikachu.HealthCount >= 0)
            {
                Console.WriteLine("Pikachu Health: {0}", Dirpikachu.HealthCount);
            }
            else if (Dirpikachu.HealthCount == 0)
            {
                Console.WriteLine("             Died");
            }
        }
        static void WriteGameToFile(Player Dirpikachu, Enemy Dirspiko, Enemy DirDarco,Bullet k)

        {
            string path = "D:\\oopweek4pdTask\\GameInCsharp\\game.txt";
            StreamWriter fileVariable = new StreamWriter(path);
            fileVariable.WriteLine(Dirpikachu.X);
            fileVariable.WriteLine(Dirpikachu.Y);
            fileVariable.WriteLine(DirDarco.X);
            fileVariable.WriteLine(DirDarco.Y);
            fileVariable.WriteLine(Dirspiko.X);
            fileVariable.WriteLine(Dirspiko.Y);
            fileVariable.WriteLine(Dirpikachu.score);
            //fileVariable.WriteLine(pikachuBulletcount);
            //fileVariable.WriteLine(spikoBulletCount);
            //fileVariable.WriteLine(totalbullet);
            fileVariable.WriteLine(Dirspiko.HealthCount);
            fileVariable.WriteLine(DirDarco.HealthCount);
            fileVariable.WriteLine(Dirpikachu.HealthCount);
            fileVariable.Flush();
            fileVariable.Close();

        }
        static void ReadGameFromFile(Player Dirpikachu, Enemy Dirspiko, Enemy DirDarco,Bullet k)
        {
            string path = "D:D:\\oopweek4pdTask\\GameInCsharp\\game.txt";
            StreamReader file = new StreamReader(path);
            while (!file.EndOfStream)
            {
                Dirpikachu.X = int.Parse(file.ReadLine());
                Dirpikachu.Y = int.Parse(file.ReadLine());
                DirDarco.X = int.Parse(file.ReadLine());
                DirDarco.Y = int.Parse(file.ReadLine());
                Dirspiko.X = int.Parse(file.ReadLine());
                Dirspiko.Y = int.Parse(file.ReadLine());
                Dirpikachu.score = int.Parse(file.ReadLine());
                //pikachuBulletcount = int.Parse(file.ReadLine());
                //spikoBulletCount = int.Parse(file.ReadLine());
                //totalbullet = int.Parse(file.ReadLine());
                Dirspiko.HealthCount = int.Parse(file.ReadLine());
                DirDarco.HealthCount = int.Parse(file.ReadLine());
                Dirpikachu.HealthCount = int.Parse(file.ReadLine());
            }
            file.Close();
        }
    }
}

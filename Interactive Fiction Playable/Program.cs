using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //File.

namespace Interactive_Fiction_Playable
{
    class Program
    {
            static bool gameOver = true;
            static bool MainMenu = true;
            static bool question = false;
            static int goTo = 0;
            static int menuLayoutRow = 9;
            static string incorrect = "Incompatible input, please try again";

            

        static void Main(string[] args)
        {

             string errorCheck;
             errorCheck = System.IO.File.ReadAllText("story.txt");

             if (errorCheck == null)
             {
                Console.WriteLine("An error has occured. Story is blank.");
                Console.Beep(100, 1000);
                Console.ReadKey(true);
                gameOver = true;
             }

            string[] story;
            story = System.IO.File.ReadAllLines("story.txt");
            string[] pageContents = story[goTo].Split(';');

            // pageContents[1] = story


            string[] menu;
            menu = System.IO.File.ReadAllLines("menulayout.txt");
            string[] menuOptions = menu[menuLayoutRow].Split(';');

            string deathScreen = System.IO.File.ReadAllText("deathscreen.txt");
            string titleScreen = System.IO.File.ReadAllText("titlescreen.txt");


            String userInput;

            Console.WriteLine(titleScreen);
            Console.ReadKey(true);
            Console.Clear();


            while (MainMenu == true)
            {

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(menu[0]);
                Console.WriteLine(menu[1]);
                Console.WriteLine(menu[2]);
                Console.WriteLine(menu[3]);
                Console.WriteLine(menu[4]);
                Console.WriteLine(menu[5]);
                Console.WriteLine(menu[6]);
                Console.WriteLine(menu[7]);
                Console.WriteLine(menu[8]);
                Console.WriteLine("");

                Console.WriteLine("");
                Console.WriteLine("Make your choice");
                Console.WriteLine("────────────────");
                Console.WriteLine("w - " + menuOptions[0]);
                Console.WriteLine("x - " + menuOptions[1]);
                Console.WriteLine("y - " + menuOptions[2]);
                Console.WriteLine("z - " + menuOptions[3]);
                Console.WriteLine("");

                string saveSlot1 = System.IO.File.ReadAllText("savegame.txt");
                string saveSlot2 = System.IO.File.ReadAllText("savegame2.txt");
                string saveSlot3 = System.IO.File.ReadAllText("savegame3.txt"); 

                userInput = Console.ReadLine();

                if (userInput == "w")  //new game
                {
                    Console.Beep(750, 250);
                    goTo = 0;
                    gameOver = false;
                    Console.Clear();
                }
                else if (userInput == "x")  //save game
                {
                    Console.Beep(750, 250);
                    saveSlot1 = System.IO.File.ReadAllText("savegame.txt");
                    saveSlot2 = System.IO.File.ReadAllText("savegame2.txt");
                    saveSlot3 = System.IO.File.ReadAllText("savegame3.txt");
                    string saveFile = goTo.ToString();  //convert int to string                     

                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Which save slot would you like to use?");
                    Console.WriteLine("1 - Page: " + saveSlot1);
                    Console.WriteLine("2 - Page: " + saveSlot2);
                    Console.WriteLine("3 - Page: " + saveSlot3);
                    Console.WriteLine("");

                    userInput = Console.ReadLine();

                    while (question == true)
                    {
                        if (userInput == "1")
                        {
                            Console.Beep(750, 250);
                            File.WriteAllText("savegame.txt", saveFile);
                            Console.WriteLine("");
                            Console.WriteLine("Game saved to Slot 1");
                            question = false;
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        else if (userInput == "2")
                        {
                            Console.Beep(750, 250);
                            File.WriteAllText("savegame2.txt", saveFile);
                            Console.WriteLine("");
                            Console.WriteLine("Game saved to Slot 2");
                            question = false;
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        else if (userInput == "3")
                        {
                            Console.Beep(750, 250);
                            File.WriteAllText("savegame3.txt", saveFile);
                            Console.WriteLine("");
                            Console.WriteLine("Game saved to Slot 3");
                            question = false;
                            Console.ReadKey(true);
                            Console.Clear();
                        }
                        else
                        {
                            Console.Beep(250, 250);
                            Console.WriteLine(incorrect);
                        }
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Would you like to continue where you left off?");
                    Console.WriteLine("(y/n)");
                    Console.WriteLine("");
                    question = true;


                    while (question == true)
                    {
                        userInput = Console.ReadLine();

                        if (userInput == "y")
                        {
                            Console.Beep(750, 250);
                            gameOver = false;
                            question = false;
                            Console.Clear();
                        }
                        else if (userInput == "n")
                        {
                            Console.Beep(750, 250);
                            question = false;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine(incorrect);
                            Console.Beep(250, 250);
                        }
                    }

                }
                else if (userInput == "y")  //load game
                {
                    Console.Beep(750, 250);
                    saveSlot1 = System.IO.File.ReadAllText("savegame.txt");
                    saveSlot2 = System.IO.File.ReadAllText("savegame2.txt");
                    saveSlot3 = System.IO.File.ReadAllText("savegame3.txt");
                    string loadFile;

                    Console.WriteLine("");
                    Console.WriteLine("Which save slot would you like to use?");
                    Console.WriteLine("1 - Page: " + saveSlot1);
                    Console.WriteLine("2 - Page: " + saveSlot2);
                    Console.WriteLine("3 - Page: " + saveSlot3);
                    Console.WriteLine("");

                    userInput = Console.ReadLine();

                    if (userInput == "1")
                    {
                        Console.Beep(750, 250);
                        loadFile = System.IO.File.ReadAllText("savegame.txt");
                        goTo = int.Parse(loadFile);
                        Console.WriteLine("");
                        Console.WriteLine("Game loaded from Slot 1");
                        gameOver = false;
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else if (userInput == "2")
                    {
                        Console.Beep(750, 250);
                        loadFile = System.IO.File.ReadAllText("savegame2.txt");
                        goTo = int.Parse(loadFile);
                        Console.WriteLine("");
                        Console.WriteLine("Game loaded from Slot 2");
                        gameOver = false;
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else if (userInput == "3")
                    {
                        Console.Beep(750, 250);
                        loadFile = System.IO.File.ReadAllText("savegame3.txt");
                        goTo = int.Parse(loadFile);
                        Console.WriteLine("");
                        Console.WriteLine("Game loaded from Slot 3");
                        gameOver = false;
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }
                else if (userInput == "z")  //quit game
                {
                    break;
                }
                else
                {
                    Console.Beep(250, 250);
                    Console.WriteLine(incorrect);
                }    

                while (gameOver == false)  //game starts
                { 

                    pageContents = story[goTo].Split(';');


                    Console.WriteLine("");
                    Console.WriteLine(pageContents[0]);

                    if (pageContents[3] == (""))    //game over
                    {
                        Console.WriteLine(pageContents[1]);
                        Console.WriteLine(pageContents[2]);
                        Console.WriteLine(pageContents[3]);
                        Console.WriteLine(pageContents[4]);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        gameOver = true;
                        Console.WriteLine(deathScreen);
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Make your choice");
                        Console.WriteLine("────────────────");
                        Console.WriteLine("A - " + pageContents[1]);
                        Console.WriteLine("B - " + pageContents[2]);
                        Console.WriteLine("════════════════════════════════════════");
                        Console.WriteLine("| S - Quick Save | M - Menu | Q - Quit |");
                        Console.WriteLine("════════════════════════════════════════");
                        Console.WriteLine("");


                        question = true;
                    }

                    while (question == true)
                    {
                        userInput = Console.ReadLine();

                        if (userInput == "a") //choice 1
                        {
                            goTo = int.Parse(pageContents[3]);
                            Console.Beep(750, 250);
                            question = false;
                            Console.Clear();
                        }
                        else if (userInput == "b")  //choice 2
                        {
                            goTo = int.Parse(pageContents[4]);
                            Console.Beep(750, 250);
                            question = false;
                            Console.Clear();
                        }
                        else if (userInput == "m")  //menu
                        {
                            Console.Beep(500, 250);
                            MainMenu = true;
                            gameOver = true;
                            question = false;
                            Console.Clear();
                        }
                        else if (userInput == "s")  //quick save
                        {
                            Console.Beep(750, 250);
                            saveSlot1 = System.IO.File.ReadAllText("savegame.txt");
                            saveSlot2 = System.IO.File.ReadAllText("savegame2.txt");
                            saveSlot3 = System.IO.File.ReadAllText("savegame3.txt");
                            string saveFile = goTo.ToString();  //convert int to string                     

                            Console.WriteLine("");
                            Console.WriteLine("Which save slot would you like to use?");
                            Console.WriteLine("1 - Page: " + saveSlot1);
                            Console.WriteLine("2 - Page: " + saveSlot2);
                            Console.WriteLine("3 - Page: " + saveSlot3);
                            Console.WriteLine("");

                            userInput = Console.ReadLine();

                            if (userInput == "1")
                            {
                                Console.Beep(750, 250);
                                File.WriteAllText("savegame.txt", saveFile);
                                question = false;
                                Console.WriteLine("");
                                Console.WriteLine("Game saved to Slot 1");
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                            else if (userInput == "2")
                            {
                                Console.Beep(750, 250);
                                File.WriteAllText("savegame2.txt", saveFile);
                                question = false;
                                Console.WriteLine("");
                                Console.WriteLine("Game saved to Slot 2");
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                            else if (userInput == "3")
                            {
                                Console.Beep(750, 250);
                                File.WriteAllText("savegame3.txt", saveFile);
                                question = false;
                                Console.WriteLine("");
                                Console.WriteLine("Game saved to Slot 3");
                                Console.ReadKey(true);
                                Console.Clear();
                            }
                        }
                        else if (userInput == "q")  //quit
                        {
                            Console.Beep(400, 250);
                            MainMenu = false;
                        }
                        else
                        {
                            Console.Beep(750, 250);
                            Console.WriteLine(incorrect);
                        }
                    }

                }
            }
        }

    }
}

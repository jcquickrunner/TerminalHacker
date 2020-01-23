
using System;
using System.Collections.Generic;
using UnityEngine;


public class Hacker : MonoBehaviour
{

    //game configurations
    string[] levelOnePasswords = { "css", "annoying customers", "mod", "lp", "manager", "supervisor" };
    string[] levelTwoPasswords = { "cop", "lp", "ticket", "arrest", "handcuffs" };
    string[] levelThreePasswords = { "secret", "classified", "files", "john wick", "agent" };
    //state
    int level;
    enum Screen { MainMenu,Password,Burlington,Police,CIA,Win,TalkToComputer}; //enums a unique way of storing states within code
    /*[SerializeField] makes the dropdown work*/
     Screen currentScreen = Screen.MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        StartingScreen();
        
    }
    void OnUserInput(string input)

    {
        if (input == "menu")// in general does not specify state therefore works on every state
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("");
            Terminal.WriteLine("");
            Terminal.WriteLine("");
            Terminal.WriteLine("");
            StartingScreen();
            currentScreen = Screen.MainMenu;//set to this in this state


        }else if (currentScreen == Screen.MainMenu)//which it is
        {
            RunMainMenu(input);
        }else if (currentScreen== Screen.Burlington)
        {
            PasswordGuessBurlington(input);
        }else if (currentScreen == Screen.Police)
        {
            PasswordGuessPoliceStation(input);
        }else if (currentScreen == Screen.CIA)
        {
            PasswordGuessCia(input);
        }else if (currentScreen == Screen.TalkToComputer)
        {
            TalkToPc(input);//talk to pc using this input (string)
        }else if (currentScreen == Screen.Win)
            WinInput(input);
       
    }

    private static void WinInput(string input)
    {
        if (input == "continue")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine(@"
 |        |
(|For Ley |)
 |  #1   |
  \     /
   `---'
   _|_|_ ");
        }
    }

    private void PasswordGuessBurlington(string input)// must make it so it only runs based on a choice on password screen
    {
        bool isValidPasswordB = (input == levelOnePasswords[0] || input == levelOnePasswords[1] || input == levelOnePasswords[2] || input == levelOnePasswords[3] || input == levelOnePasswords[4] || input == levelOnePasswords[5]);
        if (isValidPasswordB)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("INITIALIZING..........");
            Terminal.WriteLine("");
            Terminal.WriteLine("CRASHING REGISTERS.........SUCCESS");


            Terminal.WriteLine("");
            Terminal.WriteLine("*congratulations all the employees are going home early today thanks to you!");
            Terminal.WriteLine("the registers are unable to process any type of payments"); 
            Terminal.WriteLine("and cutsomers were complaining");
            Terminal.WriteLine("");
            Terminal.WriteLine("Type continue to claim your reward");
            currentScreen = Screen.Win;
            
                
            
            


        }
        else
        {
            Terminal.WriteLine("Incorrect Password");
        }
    }
    private void PasswordGuessCia(string input)
    {
        bool isValidPasswordC = (input == levelThreePasswords[0] || input == levelThreePasswords[1] || input == levelThreePasswords[2] || input == levelThreePasswords[3] || input == levelThreePasswords[4]);// this is true when this is equal to this
        if (isValidPasswordC)// if this evaluates to true
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("INITIALIZING..........");
            Terminal.WriteLine("");
            Terminal.WriteLine("WELCOME BACK MR.WICK");
            Terminal.WriteLine(".....HOW MAY I BE OF SERVICE TODAY....");
            Terminal.WriteLine("");
            currentScreen = Screen.Win;
            Terminal.WriteLine("type continue to claim your reward");

        }
        else
        {
            Terminal.WriteLine("Incorrect Password");
        }
    } 
    private void TalkToPc(string input)
    {
        if (input == "1")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("I know you are not JC, please do not try to fool me");

        } else if (input== "2")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("I only listen to my master, JC");
        }else
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("INVALID COMMAND");
        }
    }
    
    private void PasswordGuessPoliceStation(string input)// must make it so it only runs based on a choice on password screen
    {
        bool isValidPasswordP = (input == levelTwoPasswords[0] || input == levelTwoPasswords[1] || input == levelTwoPasswords[2] || input == levelTwoPasswords[3] || input == levelTwoPasswords[4]);
        if (isValidPasswordP)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("INITIALIZING..........");
            Terminal.WriteLine("");
            Terminal.WriteLine("ACESS GRANTED");


            Terminal.WriteLine("");
            Terminal.WriteLine("*You have managed to get into the police stations database.");
            Terminal.WriteLine("Unfortunately the celebration was short lived as they ");
            Terminal.WriteLine("tracked the hack back to you and were arrested");
            Terminal.WriteLine("before getting the chance to do anything");
           
           


        }
        else
        {
            Terminal.WriteLine("Incorrect Password");
        }
    }

    private void RunMainMenu(string input)
    {
        
       
         if (currentScreen == Screen.MainMenu)// if this is the screen have acess to thie following if and else if block of code screen.mainmenu is a state
        {
            if (input == "1")
            {

                level = 1;
                StartGame(1);//runs this with 1
                currentScreen = Screen.Burlington;
            }
            else if (input == "2")
            {
                level = 2;
                StartGame(2);//run this with 2
                currentScreen = Screen.Police;
            } else if (input == "3") 
            {
                level = 3;
                StartGame(3);//runs this with 3
                currentScreen = Screen.CIA;



            }else if ( input == "4")
            {
                level = 4;
                StartGame(4);//runs this with 4
                currentScreen = Screen.TalkToComputer;
            }
            else if (input == "quit")
            {
                Application.Quit();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("That command is Invalid because JC did not program me to think in that way");
            }

        }// checking if input is this

       
            
    }
    

    private void StartGame(int level)// a way of deciding what to do based on the argument passed through the startgame function
    {
        
        if (level == 1)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You have chosen to get into Burlingtons Main servers and crash the registers.");
            Terminal.WriteLine("");
            Terminal.WriteLine("Please enter network password: ");
            Terminal.WriteLine("hint: scs, aonnyngi tocusmers, dom, pl, neraamg, persusorvi ");
        } else if (level == 2)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You have chosen to hack into the police stations database");
            Terminal.WriteLine("");
            Terminal.WriteLine("Please enter network password:"); 
            Terminal.WriteLine("hint: cpo,pl,serrta,hadnffscu ");
        }else if (level ==3)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("You have chosen to try to get into the league of assasins classified files");
            Terminal.WriteLine("");
            Terminal.WriteLine("Please enter network password: ");
            Terminal.WriteLine("hint: retces,claifissed,liesf,                jnho ckiw, netag ");
        }
        else if (level == 4)
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Are you JC or Ley");
            Terminal.WriteLine("");
            Terminal.WriteLine("1.JC");
            Terminal.WriteLine("2.Ley");
        }
    }
    private static void StartingScreen()//inital main menu
    {
        string firstLine = "Welcome Laura Croft, In this Game      you must hack into a Location.You can   also choose to talk to the computer";
        Terminal.WriteLine(firstLine);
        Terminal.WriteLine("");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("1.Burlington");
        Terminal.WriteLine("2.Police Station");
        Terminal.WriteLine("3.The League of Assasins");
        Terminal.WriteLine("4.Talk to the computer");
        Terminal.WriteLine("");
        Terminal.WriteLine("Choose your selection");
        
    }

   
}

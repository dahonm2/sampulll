using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Markup;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml.Linq;

namespace ConsoleApp6
{
    class forStructure
    {
        public struct userSelectedChoices
        {
            public string name;
            public string selectedGender;
            public string selectedEthnicity;
            public string selectedBodyType;
            public string selectedSkinColor;
            public string selectedHairStyle;
            public string selectedHairColor;
            public string selectedFaceShape;
            public string selectedEyeShape;
            public string selectedEyeColor;
            public bool Tattoo;
            public string selectedClothes;
            public string selectedPants;
            public string selectedShoes;
            public string selectedAccessories;
            public string selectedPersonalVehicle;
            public string selectedVehicleColor;
            public string selectedMount;
            public string selectedStarterPack;
            public string selectedRoles;
            public string selectedSkills;
            public byte rangeWeapon, meleeWeapon, projectileWeapon, luckMastery, regenMastery;
            public int totalPoints;
        }
    }
    public class Game : dkopaAlamParaSaan
    {
        public Game()
        {
            try
            {
                mySqlConnection = new SqlConnection(characterDatabase);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while connecting to the database: {ex.Message}");
            }
        }
        SqlConnection mySqlConnection;
        string characterDatabase = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\DEN MHAR\SOURCE\REPOS\CONSOLEAPP11\CONSOLEAPP11\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        forStructure.userSelectedChoices selectedChoice;
        Choices ethnicity = new Choices();
        bool[] stepsChecking = new bool[6];
        byte selection;
        private int currentCharID = 0;
        public List<string> selectedAns = new List<string>();
        public List<string> databaseLike = new List<string>();

        public void Start()
        {
            displayTitleScreen();
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("\n\nPRESS ANY KEY TO ENTER THE BATTLEFIELD"); ReadKey(true);
            ResetColor();
            Title = "Evory Hell - Battle Ground Royale";
            RunMainMenu();
        }
        private void RunMainMenu()
        {

            string prompt = @"
▓█████ ██▒   █▓ ▒█████   ██▀███ ▓██   ██▓    ██░ ██ ▓█████  ██▓     ██▓    
▓█   ▀▓██░   █▒▒██▒  ██▒▓██ ▒ ██▒▒██  ██▒   ▓██░ ██▒▓█   ▀ ▓██▒    ▓██▒    
▒███   ▓██  █▒░▒██░  ██▒▓██ ░▄█ ▒ ▒██ ██░   ▒██▀▀██░▒███   ▒██░    ▒██░    
▒▓█  ▄  ▒██ █░░▒██   ██░▒██▀▀█▄   ░ ▐██▓░   ░▓█ ░██ ▒▓█  ▄ ▒██░    ▒██░    
░▒████▒  ▒▀█░  ░ ████▓▒░░██▓ ▒██▒ ░ ██▒▓░   ░▓█▒░██▓░▒████▒░██████▒░██████▒
░░ ▒░ ░  ░ ▐░  ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░  ██▒▒▒     ▒ ░░▒░▒░░ ▒░ ░░ ▒░▓  ░░ ▒░▓  ░
 ░ ░  ░  ░ ░░    ░ ▒ ▒░   ░▒ ░ ▒░▓██ ░▒░     ▒ ░▒░ ░ ░ ░  ░░ ░ ▒  ░░ ░ ▒  ░
   ░       ░░  ░ ░ ░ ▒    ░░   ░ ▒ ▒ ░░      ░  ░░ ░   ░     ░ ░     ░ ░   
   ░  ░     ░      ░ ░     ░     ░ ░         ░  ░  ░   ░  ░    ░  ░    ░  ░
           ░                     ░ ░                                       


[WELCOME TO EVORY HELL WHERE DEMONS ARE FUCKING EACH OTHER]";


            string[] options = { "NEW GAME", "LOAD GAME", "CAMPAIGN MODE", "CREDITS", "EXIT" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            storeToList();
            storeToListCharID();
            switch (selectedIndex)
            {
                case 0:
                    NewGame();
                    break;
                case 1:
                    LoadGame();
                    break;
                case 2:
                    CampaignMode();
                    break;
                case 3:
                    Credits();
                    break;
                case 4:
                    Exit();
                    break;
            }
        }
        public void storeToList()
        {
            string query = "SELECT charName FROM CHARACTERGAMECREATION";
            SqlCommand command = new SqlCommand(query, mySqlConnection);
            mySqlConnection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string charName = reader["charName"].ToString();
                    databaseLike.Add(charName);
                }
            }

            mySqlConnection.Close();
        }
        public void storeToListCharID()
        {
            string query = "SELECT charID FROM CHARACTERGAMECREATION";
            SqlCommand command = new SqlCommand(query, mySqlConnection);
            mySqlConnection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string charID = reader["charID"].ToString();
                    databaseLike.Add(charID);
                }
            }

            mySqlConnection.Close();
        }

        public void characterCreation()
        {
            mySqlConnection.Open();

            string query = "INSERT INTO dbo.CHARACTERGAMECREATION(charName, charGender, charRace, charBodyType, charSkinColor, charHairStyle, charHairColor, charFaceShape, charEyeShape, charEyeColor," +
                "charTattoo, charClothes, charPants, charShoes, charAccessories, charPersonalVehicle, charVehicleColor, charMount, charStarterPack, charRoles, charSkills, charRangeWeaponStats," +
                "charMeleeWeaponStats, charProjectileWeaponStats, charLuckMasteryStats, charRegenMasteryStats) VALUES (@charName, @charGender, @charRace, @charBodyType, @charSkinColor, @charHairStyle, @charHairColor, @charFaceShape, @charEyeShape, @charEyeColor," +
                "@charTattoo, @charClothes, @charPants, @charShoes, @charAccessories, @charPersonalVehicle, @charVehicleColor, @charMount, @charStarterPack, @charRoles, @charSkills, @charRangeWeaponStats," +
                "@charMeleeWeaponStats, @charProjectileWeaponStats, @charLuckMasteryStats, @charRegenMasteryStats)";

            SqlCommand insertData = new SqlCommand(query, mySqlConnection);

            insertData.Parameters.AddWithValue("@charName", selectedAns[0]);
            insertData.Parameters.AddWithValue("@charGender", selectedAns[1]);
            insertData.Parameters.AddWithValue("@charRace", selectedAns[2]);
            insertData.Parameters.AddWithValue("@charBodyType", selectedAns[3]);
            insertData.Parameters.AddWithValue("@charSkinColor", selectedAns[4]);
            insertData.Parameters.AddWithValue("@charHairStyle", selectedAns[5]);
            insertData.Parameters.AddWithValue("@charHairColor", selectedAns[6]);
            insertData.Parameters.AddWithValue("@charFaceShape", selectedAns[7]);
            insertData.Parameters.AddWithValue("@charEyeShape", selectedAns[8]);
            insertData.Parameters.AddWithValue("@charEyeColor", selectedAns[9]);
            insertData.Parameters.AddWithValue("@charTattoo", selectedAns[10]);
            insertData.Parameters.AddWithValue("@charClothes", selectedAns[11]);
            insertData.Parameters.AddWithValue("@charPants", selectedAns[12]);
            insertData.Parameters.AddWithValue("@charShoes", selectedAns[13]);
            insertData.Parameters.AddWithValue("@charAccessories", selectedAns[14]);
            insertData.Parameters.AddWithValue("@charPersonalVehicle", selectedAns[15]);
            insertData.Parameters.AddWithValue("@charVehicleColor", selectedAns[16]);
            insertData.Parameters.AddWithValue("@charMount", selectedAns[17]);
            insertData.Parameters.AddWithValue("@charStarterPack", selectedAns[18]);
            insertData.Parameters.AddWithValue("@charRoles", selectedAns[19]);
            insertData.Parameters.AddWithValue("@charSkills", selectedAns[20]);
            insertData.Parameters.AddWithValue("@charRangeWeaponStats", selectedAns[21]);
            insertData.Parameters.AddWithValue("@charMeleeWeaponStats", selectedAns[22]);
            insertData.Parameters.AddWithValue("@charProjectileWeaponStats", selectedAns[23]);
            insertData.Parameters.AddWithValue("@charLuckMasteryStats", selectedAns[24]);
            insertData.Parameters.AddWithValue("@charRegenMasteryStats", selectedAns[25]);

            insertData.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public override void Exit()
        {
            WriteLine("[1] Go back to main menu\n[2] Exit");
            string prompt = "Are you sure you want to exit?...";
            string[] options = { "[1] GO BACK TO MAIN MENU", "[2] EXIT" };
            Menu exitMenu = new Menu(prompt, options);
            int selectedIndex = exitMenu.Run();
            int i;
            string exiting = "Exiting";

            switch (selectedIndex)
            {
                case 0: RunMainMenu(); break;
                case 1:
                    ForegroundColor = ConsoleColor.DarkRed;
                    Write("\n" + exiting);
                    for (i = 0; i < 4; i++)
                    {
                        Thread.Sleep(900);
                        Write(".");
                    }
                    ResetColor();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nYOU HAVE SURVIVED IN HELL! -- THANK YOU FOR PLAYING~");
                    ResetColor();
                    Environment.Exit(0);
                    break;
            }
        }
        public override void Credits()
        {
            Clear();
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("Kenneth Reyes - The Programmerist, The Leader, and The Chosen One.");
            WriteLine("Den Mhar Germo - The Documentationist, The Member, and The Significant Other of ChatGPT.");
            ResetColor();

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Press any key to return to the menu. ");
            ResetColor();

            ReadKey(true);
            RunMainMenu();
        }
        public override void CampaignMode()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            Clear();
            WriteLine("In the year 5000, Earth has been altered by the sudden appearance of mysterious portals, which open at random, leading to different realms and battlefields across the universe. \nThese portals disrupt the fabric of reality itself, and people from all over the world are drawn to them, seeking to harness the power of these strange gates.");
            WriteLine("Each portal serves as an entry point to a different environment, where participants must fight for survival. \nThese battlefields range from ancient worlds like the Murim realm, where martial artists engage in deadly combat, to futuristic dystopian cities filled with high-tech weapons and cyber-enhanced enemies.");
            WriteLine("As players enter these portals, they are thrust into intense battle royale scenarios, where only one can emerge victorious.");
            WriteLine("\nThe concept of the game revolves around players entering different battle royale environments, each accessible through one of the many portals that appear across the Earth. \nPlayers drop into vast, ever-shifting maps where they must scavenge for weapons, resources, and power-ups to survive.");
            WriteLine("The Murim world may offer powerful martial arts techniques, while a cyberpunk city could provide access to advanced weapons and tech to outsmart opponents. \nThe portals are random, so each match will present unique challenges depending on which realm the players land in.");
            WriteLine("As the match progresses, the battlefield shrinks, forcing players into conflict and making the final showdown inevitable.");

            WriteLine("\nPlayers can form alliances with others in the battle for dominance or opt to fight solo. \nEach portal realm has unique elements that give players an advantage if they adapt to their environment.");
            WriteLine("In the Murim world, mastering martial arts or cultivating inner energy may give a player an edge, while in futuristic cyber worlds, technological gadgets and hacking abilities could turn the tide of battle.");
            WriteLine("The dynamic nature of the portals ensures no two matches are the same, keeping the gameplay fresh and unpredictable.");
            WriteLine("As players fight to the death, they must uncover the truth behind the portals' origins and the ultimate reason they are thrust into these cross-dimensional battle royales.");
            WriteLine("The fate of each realm and the future of Earth depends on who can control the portals and emerge as the ultimate victor.");
            ResetColor();

            WriteLine();

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Press any key to return to the menu. ");
            ResetColor();

            ReadKey(true);
            RunMainMenu();
        }
        public override void LoadGame()
        {
            Clear();
            string prompt = "WHAT WOULD YOU LIKE TO DO:";
            string[] options = { "A. DISPLAY ALL INFO OF ALL CHARACTERS", "B. DELETE A CHARACTER", "C. RETURN TO MAIN MENU" };
            Menu loadGameMenu = new Menu(prompt, options);
            int selectedIndex = loadGameMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    displayAllCharacters();
                    break;
                case 1:
                    deleteCharacter();
                    break;
                case 2:
                    returnToMenu();
                    break;
            }
        }

        private void displayAllCharacters()
        {

            string inquery = @"
SELECT charID, charName, charGender, charRace, charSkinColor, charHairStyle, charHairColor, charFaceShape, charEyeShape, charEyeColor, charTattoo, 
       charClothes, charPants, charShoes, charAccessories, charPersonalVehicle, charVehicleColor, charMount, charStarterPack, charRoles, charSkills, 
       charRangeWeaponStats, charMeleeWeaponStats, charProjectileWeaponStats, charLuckMasteryStats, charRegenMasteryStats
FROM CHARACTERGAMECREATION";

            try
            {
                mySqlConnection.Open();
                using (SqlCommand command = new SqlCommand(inquery, mySqlConnection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Clear();
                            while (reader.Read())
                            {
                                DisplayCharacterInfo(reader);
                                DisplayCharacterAppearance(reader);
                                DisplayCharacterOutfit(reader);
                                DisplayCharacterGameplay(reader);
                                DisplayCharacterStats(reader);
                            }
                            mySqlConnection.Close();
                            string prompt = "WHAT DO YOU WANT TO DO NOW?";
                            string options = "[1]GO BACK TO MAIN MENU\n[2]EXIT";
                            DisplayMenuOptions(prompt, options);
                        }
                        else
                        {
                            Clear();
                            WriteLine("NO CHARACTERS FOUND.");
                            mySqlConnection.Close();
                            string prompt = "WHAT DO YOU WANT TO DO NOW?";
                            string options = "[1]GO BACK TO MAIN MENU\n[2]EXIT";
                            DisplayMenuOptions(prompt, options);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

        }

        private void DisplayCharacterInfo(SqlDataReader reader)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Character Details:");
            WriteLine("------------------");
            ResetColor();

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("\nA. CHARACTER INFO:");
            ResetColor();

            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine($"Character ID: {reader["charID"]}");
            WriteLine($"Character Name: {reader["charName"]}");
            WriteLine($"Character Gender: {reader["charGender"]}");
            WriteLine($"Character Race: {reader["charRace"]}\n");
            ResetColor();
        }

        private void DisplayCharacterAppearance(SqlDataReader reader)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("B. CHARACTER APPEARANCE:");
            ResetColor();

            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine($"Character Skin Color: {reader["charSkinColor"]}");
            WriteLine($"Character Hair Style: {reader["charHairStyle"]}");
            WriteLine($"Character Hair Color: {reader["charHairColor"]}");
            WriteLine($"Character Face Shape: {reader["charFaceShape"]}");
            WriteLine($"Character Eye Shape: {reader["charEyeShape"]}");
            WriteLine($"Character Eye Color: {reader["charEyeColor"]}");
            WriteLine($"Character Tattoo: {reader["charTattoo"]}\n");
            ResetColor();
        }

        private void DisplayCharacterOutfit(SqlDataReader reader)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("C. CHARACTER OUTFIT:");
            ResetColor();

            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine($"Character Clothes: {reader["charClothes"]}");
            WriteLine($"Character Pants: {reader["charPants"]}");
            WriteLine($"Character Shoes: {reader["charShoes"]}");
            WriteLine($"Character Accessories: {reader["charAccessories"]}\n");
            ResetColor();
        }

        private void DisplayCharacterGameplay(SqlDataReader reader)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("D. CHARACTER GAMEPLAY:");
            ResetColor();

            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine($"Character Personal Vehicle: {reader["charPersonalVehicle"]}");
            WriteLine($"Character Vehicle Color: {reader["charVehicleColor"]}");
            WriteLine($"Character Mount: {reader["charMount"]}");
            WriteLine($"Character Starter Pack: {reader["charStarterPack"]}");
            WriteLine($"Character Roles: {reader["charRoles"]}");
            WriteLine($"Character Skills: {reader["charSkills"]}\n");
            ResetColor();
        }

        private void DisplayCharacterStats(SqlDataReader reader)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("E. CHARACTER STATS:");
            ResetColor();

            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine($"Character Range Weapon Stats: {reader["charRangeWeaponStats"]}");
            WriteLine($"Character Melee Weapon Stats: {reader["charMeleeWeaponStats"]}");
            WriteLine($"Character Projectile Weapon Stats: {reader["charProjectileWeaponStats"]}");
            WriteLine($"Character Luck Mastery Stats: {reader["charLuckMasteryStats"]}");
            WriteLine($"Character Regen Mastery Stats: {reader["charRegenMasteryStats"]}\n");
            ResetColor();

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("---------------------------------------------------------------------------------------------------------------");
            ResetColor();
        }
        private void DisplayMenuOptions(string prompt, string options)
        {
            bool isValidOption = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                WriteLine(prompt);
                ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                WriteLine(options);
                ResetColor();
                ConsoleKeyInfo keyInfoDISPLAYOPTIONS = Console.ReadKey(true);

                switch (keyInfoDISPLAYOPTIONS.KeyChar)
                {
                    case '1':
                        RunMainMenu();
                        isValidOption = true;
                        storeToListCharID();
                        break;
                    case '2':
                        Exit();
                        isValidOption = true;
                        storeToListCharID();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine("\nWHAT YOU ENTER IS NOT A VALID OPTION. PLEASE CHOOSE APPROPRIATELY\n");
                        ResetColor();
                        break;
                }
            } while (!isValidOption);
        }
        private void properMenuOptions(string prompt, string options)
        {
            bool isValidOption = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                WriteLine(prompt);
                ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                WriteLine(options);
                ResetColor();
                ConsoleKeyInfo keyInfoProperOptions = Console.ReadKey(true);

                switch (keyInfoProperOptions.KeyChar)
                {
                    case 'Y':
                        ResetCharacterData();
                        isValidOption = true;
                        break;
                    case 'N':
                        NewGame();
                        return;
                        isValidOption = true;
                        break;
                    case 'y':
                        ResetCharacterData();
                        isValidOption = true;
                        break;
                    case 'n':
                        NewGame();
                        return;
                        isValidOption = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine("\nWHAT YOU ENTER IS NOT A VALID OPTION. PLEASE CHOOSE APPROPRIATELY\n");
                        ResetColor();
                        break;
                }
            } while (!isValidOption);
        }
        public void deleteCharacter()
        {
            Clear();

            while (true)
            {
                try
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Write("DO YOU WANT TO DELETE A SPECIFIC CHARACTER or ALL CHARACTERS?\n");
                    ResetColor();
                    Write("1. ");
                    ForegroundColor = ConsoleColor.Yellow;
                    Write("DELETE A SPECIFIC CHARACTER\n");
                    ResetColor();
                    Write("2. ");
                    ForegroundColor = ConsoleColor.Yellow;
                    Write("DELETE ALL CHARACTERS\n");
                    ResetColor();
                    Write("3. ");
                    ForegroundColor = ConsoleColor.Yellow;
                    Write("RETURN TO LOADGAME\n");
                    ResetColor();
                    ForegroundColor = ConsoleColor.Cyan;
                    Write("ENTER YOUR CHOICE[1, 2 or 3]: ");
                    ResetColor();
                    int choice = Convert.ToInt32(ReadLine());
                    if (choice == 1)
                    {
                        Clear();
                        mySqlConnection.Open();
                        string inquery = @"
SELECT charID, charName, charGender, charRace, charSkinColor, charHairStyle, charHairColor, charFaceShape, charEyeShape, charEyeColor, charTattoo, 
       charClothes, charPants, charShoes, charAccessories, charPersonalVehicle, charVehicleColor, charMount, charStarterPack, charRoles, charSkills, 
       charRangeWeaponStats, charMeleeWeaponStats, charProjectileWeaponStats, charLuckMasteryStats, charRegenMasteryStats
FROM CHARACTERGAMECREATION";
                        using (SqlCommand command = new SqlCommand(inquery, mySqlConnection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        DisplayCharacterInfo(reader);
                                        DisplayCharacterAppearance(reader);
                                        DisplayCharacterOutfit(reader);
                                        DisplayCharacterGameplay(reader);
                                        DisplayCharacterStats(reader);
                                    }
                                }
                            }
                        }
                        mySqlConnection.Close();
                        ForegroundColor = ConsoleColor.Red;
                        Write("ENTER THE charID OF THE CHARACTER YOU WANT TO DELETE: ");
                        ResetColor();
                        string charID = ReadLine();
                        while (true)
                        {
                            try
                            {
                                ForegroundColor = ConsoleColor.DarkRed;
                                Write("ARE YOU SURE YOU WANT TO DELETE CHARACTER ID: ");
                                ResetColor();
                                Write(charID);
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("\n[1]YES\n[2]NO");
                                ResetColor();
                                int confirmedDelete = Convert.ToInt32(ReadLine());

                                if (confirmedDelete == 1)
                                {
                                    mySqlConnection.Open();
                                    Clear();
                                    string query1 = $"DELETE FROM CHARACTERGAMECREATION WHERE charID = {charID};";
                                    using (SqlCommand command1 = new SqlCommand(query1, mySqlConnection))
                                    {
                                        command1.ExecuteNonQuery();
                                    }
                                    mySqlConnection.Close();
                         
                                    if (databaseLike.Any(existingCharID => existingCharID == charID))
                                    {
                                        ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("CHARACTER WITH charID " + charID + " SUCCESSFULLY DELETED.");
                                        string prompt = "WHAT DO YOU WANT TO DO NOW?";
                                        string options = "[1]GO BACK TO MAIN MENU\n[2]EXIT";
                                        DisplayMenuOptions(prompt, options);
                                    }
                                    else 
                                    {
                                        Clear();
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("CHARACTER ID DOES NOT EXIST.");
                                        ResetColor();
                                        Thread.Sleep(2000);
                                        Clear();
                                        break;
                                    }

                                    
                                }
                                else if (confirmedDelete == 2)
                                {
                                    deleteCharacter();
                                }
                                else
                                {
                                    throw new UserOutOfIndexSelection("PLEASE ONLY SELECT AMONG THE CHOICES.\n");
                                }
                            }
                            catch (UserOutOfIndexSelection ex)
                            {
                                ForegroundColor = ConsoleColor.DarkRed;
                                Write("ERROR:");
                                ResetColor();
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine(ex.Message);
                                ResetColor();
                            }
                            catch (FormatException)
                            {
                                ForegroundColor = ConsoleColor.DarkRed;
                                Write("ERROR: ");
                                ResetColor();
                                ForegroundColor = ConsoleColor.Yellow;
                                Write("PLEASE INPUT AN APPROPRIATE DIGIT.\n");
                            }
                        }
                    }
                    else if (choice == 2)
                    {
                        Clear();
                        mySqlConnection.Open();
                        string inquery = @"
SELECT charID, charName, charGender, charRace, charSkinColor, charHairStyle, charHairColor, charFaceShape, charEyeShape, charEyeColor, charTattoo, 
       charClothes, charPants, charShoes, charAccessories, charPersonalVehicle, charVehicleColor, charMount, charStarterPack, charRoles, charSkills, 
       charRangeWeaponStats, charMeleeWeaponStats, charProjectileWeaponStats, charLuckMasteryStats, charRegenMasteryStats
FROM CHARACTERGAMECREATION";
                        using (SqlCommand command = new SqlCommand(inquery, mySqlConnection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        DisplayCharacterInfo(reader);
                                        DisplayCharacterAppearance(reader);
                                        DisplayCharacterOutfit(reader);
                                        DisplayCharacterGameplay(reader);
                                        DisplayCharacterStats(reader);
                                    }
                                }
                            }
                        }
                        mySqlConnection.Close();
                        while (true)
                        {
                            try
                            {
                                ForegroundColor = ConsoleColor.DarkRed;
                                WriteLine("ARE YOU SURE YOU WANT TO DELETE ALL THE CHARACTERS YOU MADE? ");
                                ResetColor();
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine("[1]YES\n[2]NO");
                                ResetColor();
                                int confirmedDel = Convert.ToInt32(Console.ReadLine());

                                if (confirmedDel == 1)
                                {
                                    mySqlConnection.Open();
                                    Clear();
                                    string queryTruncate1 = "TRUNCATE TABLE CHARACTERGAMECREATION;";
                                    using (SqlCommand command1 = new SqlCommand(queryTruncate1, mySqlConnection))
                                    {
                                        command1.ExecuteNonQuery();
                                    }
                                    databaseLike.Clear();
                                    mySqlConnection.Close();
                                    ForegroundColor = ConsoleColor.Green;
                                    WriteLine("ALL CHARACTERS SUCCESSFULLY DELETED.");
                                    ResetColor();
                                    bool tamaOmali = false;
                                    do
                                    {
                                        ForegroundColor = ConsoleColor.DarkRed;
                                        WriteLine("\nWHAT DO YOU WANT TO DO NOW?:");
                                        ResetColor();
                                        ForegroundColor = ConsoleColor.Yellow;
                                        WriteLine("[1]GO BACK TO MAIN MENU\n[2]EXIT");
                                        ResetColor();
                                        int confirmedOut1 = Convert.ToInt32(ReadLine());

                                        if (confirmedOut1 == 1)
                                        {
                                            RunMainMenu();
                                            tamaOmali = true;
                                        }
                                        else if (confirmedOut1 == 2)
                                        {
                                            Exit();
                                            tamaOmali = true;
                                        }
                                        else
                                        {
                                            ForegroundColor = ConsoleColor.DarkRed;
                                            Write("ERROR: ");
                                            ResetColor();
                                            ForegroundColor = ConsoleColor.Yellow;
                                            Write("\nWHAT YOU ENTER IS NOT A VALID OPTION. PLEASE CHOOSE APPROPRIATELY");
                                            ResetColor();
                                            tamaOmali = false;
                                        }
                                    } while (!tamaOmali);
                                }
                                else if (confirmedDel == 2)
                                {
                                    deleteCharacter();
                                }
                                else
                                {
                                    throw new UserOutOfIndexSelection("PLEASE ONLY SELECT AMONG THE CHOICES.");
                                }
                            }
                            catch (UserOutOfIndexSelection ex)
                            {
                                ForegroundColor = ConsoleColor.DarkRed;
                                Write("\nERROR:");
                                ResetColor();
                                ForegroundColor = ConsoleColor.Yellow;
                                WriteLine(ex.Message);
                                ResetColor();
                            }
                            catch (FormatException)
                            {
                                ForegroundColor = ConsoleColor.DarkRed;
                                Write("\nERROR: ");
                                ResetColor();
                                ForegroundColor = ConsoleColor.Yellow;
                                Write("PLEASE INPUT AN APPROPRIATE DIGIT.\n");
                            }

                        }
                    }
                    else if (choice == 3)
                    {
                        LoadGame();
                    }
                    else if (choice < 1 || choice > 3)
                    {
                        throw new UserOutOfIndexSelection("INVALID CHOICE. PLEASE CHOOSE APPROPRIATELY AMONG [1, 2 or 3].\n");
                    }
                }
                catch (UserOutOfIndexSelection ex)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Write("\nERROR: ");
                    ResetColor();
                    ForegroundColor = ConsoleColor.Yellow;
                    Write(ex.Message);
                    ResetColor();
                }
                catch (Exception ex)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Write($"\nAN ERROR OCCURED:");
                    ResetColor();
                    ForegroundColor = ConsoleColor.Yellow;
                    Write(ex.Message);
                    ResetColor();
                }
            }
        }
        private void returnToMenu()
        {
            RunMainMenu();
        }
        public override void NewGame()
        {
            Clear();
            string prompt = "CHOOSE WHAT YOU WANT TO DO FIRST: ";
            string[] options = { "A. CHARACTER INFO", "B. CHARACTER APPEARANCE", "C. CHARACTER OUTFIT", "D. CHARACTER GAMEPLAY", "E. CHARACTER STATS", "F. SAVE ALL", "G. BACK TO MAIN MENU" };
            ResetColor();

            Menu newgameMenu = new Menu(prompt, options);

            int selectedIndex = newgameMenu.Run();

            byte completedSteps = 0;
            foreach (bool step in stepsChecking)
            {
                if (step) completedSteps++;

            }

            if (selectedIndex != 5 && selectedIndex < stepsChecking.Length && stepsChecking[selectedIndex])
            {
                string prompt1 = "WARNING: YOU HAVE ALREADY COMPLETED " + options + " IF YOU TRULY WISH TO PROCEED, THE DATA FOR ALL STEPS WILL BE RESET ARE YOU OKAY WITH THIS?";
                string options1 = "[Y]YES or [N]NO";
                properMenuOptions(prompt1, options1);
            }

            switch (selectedIndex)
            {
                case 0:
                    characterInformation();
                    break;

                case 1:
                    characterAppearance();
                    break;

                case 2:
                    characterOutfit();
                    break;

                case 3:
                    characterGameplay();
                    break;

                case 4:
                    characterStats();
                    break;

                case 5:
                    saveAll();
                    if (completedSteps == 5)
                    {
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("CHARACTER CREATED SUCCESSFULLY!");
                        ResetColor();
                        characterCreation();
                        stepsChecking[5] = true;
                        completedSteps++;
                        Thread.Sleep(2000);
                        ResetCharacterData();
                        RunMainMenu();

                    }
                    else if (completedSteps == 0)
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("THERE ARE NO DATA TO SAVE. PLEASE SELECT YOUR CHARATER PROPERTIES FIRST. PRESS[Y] TO RETURN TO MAIN MENU & [ANY KEY TO CONTINUE WITH CHARACTER CREATION]");
                        ResetColor();
                        ConsoleKeyInfo keyInfo = ReadKey(true);

                        if (keyInfo.Key == ConsoleKey.Y)
                        {
                            backToMainMenu();
                        }
                        else
                        {
                            Console.WriteLine("CONTINUING WITH CHARACTER CREATION...");
                            Thread.Sleep(3000);
                            NewGame();
                        }
                    }
                    else if (completedSteps < stepsChecking.Length)
                    {
                        Clear();
                        WriteLine("GAME CHARACTER IS NOT COMPLETED YET. PLEASE FINISH IT FIRST BEFORE SAVING");
                        Thread.Sleep(3000);
                        NewGame();
                    }
                    break;

                case 6:
                    if (completedSteps < 6)
                    {
                        do
                        {
                            ForegroundColor = ConsoleColor.DarkRed;
                            WriteLine("WARNING: IF YOU GO BACK NOW, THE CHARACTER YOU WERE CREATING WILL BE DISCARDED. ARE YOU SURE YOU WANT TO GO BACK?)");
                            ResetColor();
                            ForegroundColor = ConsoleColor.Yellow;
                            WriteLine("[1]YES\n[2]NO");
                            ResetColor();

                            ConsoleKeyInfo keyInfoCompletedSteps;
                            bool validSelection = false;

                            while (!validSelection)
                            {
                                keyInfoCompletedSteps = ReadKey(true);

                                if (keyInfoCompletedSteps.KeyChar != '1' && keyInfoCompletedSteps.KeyChar != '2')
                                {
                                    ForegroundColor = ConsoleColor.DarkRed;
                                    WriteLine("ERROR: Please select between [1]YES or [2]NO.");
                                    ResetColor();
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    validSelection = true;
                                    if (keyInfoCompletedSteps.KeyChar == '1')
                                    {
                                        selection = 1;
                                        ResetCharacterData();
                                        backToMainMenu();
                                    }
                                    else if (keyInfoCompletedSteps.KeyChar == '2')
                                    {
                                        selection = 2;

                                        WriteLine("CONTINUING WITH CHARACTER CREATION...");
                                        NewGame();
                                        break;
                                    }
                                }
                            }
                        } while (selection == 2);
                    }
                    break;
            }

        }
        private void characterInformation()
        {
            try
            {
                do
                {
                    Clear();
                    WriteLine("A. Character Info: ");
                    selectedChoice.name = validateName();

                    WriteLine();

                    string[] choiceGender = ethnicity.genderChoice();
                    selectedChoice.selectedGender = Menu.SelectOptions("Choose your Gender:", choiceGender);
                    WriteLine();

                    string[] choiceEthnicity = ethnicity.ethnicityChoice();
                    selectedChoice.selectedEthnicity = Menu.SelectOptions("Choose your Race:", choiceEthnicity);

                    WriteLine();

                    WriteLine("Character name: " + selectedChoice.name);
                    WriteLine("Gender: " + selectedChoice.selectedGender);
                    WriteLine("Race: " + selectedChoice.selectedEthnicity);

                    WriteLine();

                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("CONFIRM YOUR SELECTION:");
                    ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("[1]CONFIRM\n[2]RE-DO");
                    ResetColor();
                    ConsoleKeyInfo keyInfoGameInfo;
                    bool validSelection = false;

                    while (!validSelection)
                    {
                        keyInfoGameInfo = ReadKey(true);

                        if (keyInfoGameInfo.KeyChar != '1' && keyInfoGameInfo.KeyChar != '2')
                        {
                            ForegroundColor = ConsoleColor.DarkRed;
                            WriteLine("ERROR: Please select between [1] CONFIRM or [2] RE-DO only.");
                            ResetColor();
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            validSelection = true;
                            if (keyInfoGameInfo.KeyChar == '1')
                            {
                                selection = 1;
                                selectedAns.Add(selectedChoice.name);
                                selectedAns.Add(selectedChoice.selectedGender);
                                selectedAns.Add(selectedChoice.selectedEthnicity);
                                stepsChecking[0] = true;
                            }
                            else if (keyInfoGameInfo.KeyChar == '2')
                            {
                                selection = 2;
                                break;
                            }
                        }
                    }
                } while (selection == 2);
                string output = "\nSAVING YOUR CHARACTER INFO";

                ForegroundColor = ConsoleColor.DarkBlue;
                Write(output);
                ResetColor();
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                    Write(".");
                }
                Thread.Sleep(300);
                NewGame();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        private void characterInformationOutput(string bodyType, string skinColor, string hairStyle, string hairColor, string faceShape, string eyeShape, string eyeColor, bool tattoo)//output for characterAppearance
        {
            WriteLine("Body Type: " + bodyType);
            WriteLine("Skin Color: " + skinColor);
            WriteLine("Hair Style: " + hairStyle);
            WriteLine("Hair Color: " + hairColor);
            WriteLine("Face Shape: " + faceShape);
            WriteLine("Eye Shape: " + eyeShape);
            WriteLine("Eye Color: " + eyeColor);
            WriteLine("Tattoo?: " + tattoo);
        }
        private void characterAppearance()
        {
            do
            {
                Clear();
                WriteLine("B. Character Appearance: ");
                string[] bodyType = ethnicity.bodyTypeChoice();
                selectedChoice.selectedBodyType = Menu.SelectOptions("Choose your Body Type:", bodyType);

                WriteLine();

                string[] skinColor = ethnicity.skinColorChoice();
                selectedChoice.selectedSkinColor = Menu.SelectOptions("Choose your Skin Color:", skinColor);

                WriteLine();

                string[] hairStyle = ethnicity.hairStyleChoice();
                selectedChoice.selectedHairStyle = Menu.SelectOptions("Choose your Hair Style:", hairStyle);

                WriteLine();

                string[] hairColor = ethnicity.hairColorChoice();
                selectedChoice.selectedHairColor = Menu.SelectOptions("Choose your Hair Color: ", hairColor);

                WriteLine();

                string[] faceShape = ethnicity.faceShapeChoice();
                selectedChoice.selectedFaceShape = Menu.SelectOptions("Choose your Face Shape:", faceShape);

                WriteLine();

                string[] eyeShape = ethnicity.eyeShapeChoice();
                selectedChoice.selectedEyeShape = Menu.SelectOptions("Choose your Eye Shape:", eyeShape);

                WriteLine();

                string[] eyeColor = ethnicity.eyeColorChoice();
                selectedChoice.selectedEyeColor = Menu.SelectOptions("Choose your Eye Color", eyeColor);

                WriteLine();

                bool validInput = false;

                while (!validInput)
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("Add tattoo? (Y/N)");
                    ResetColor();

                    ForegroundColor = ConsoleColor.White;
                    string inputTattoo = ReadLine();
                    ResetColor();

                    if (inputTattoo == "Y" || inputTattoo == "y")
                    {
                        selectedChoice.Tattoo = true;
                        validInput = true;
                    }
                    else if (inputTattoo == "N" || inputTattoo == "n")
                    {
                        selectedChoice.Tattoo = false;
                        validInput = true;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("ERROR: PLEASE SELECT BETWEEN Y OR N ONLY");
                        ResetColor();
                    }
                }

                WriteLine();

                characterInformationOutput(selectedChoice.selectedBodyType, selectedChoice.selectedSkinColor, selectedChoice.selectedHairStyle, selectedChoice.selectedHairColor, selectedChoice.selectedFaceShape, selectedChoice.selectedEyeShape, selectedChoice.selectedEyeColor, selectedChoice.Tattoo);

                WriteLine();

                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("CONFIRM YOUR SELECTION:");
                ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("[1] CONFIRM\n[2] RE-DO");
                ResetColor();

                ConsoleKeyInfo keyInfoAppearance;
                bool validSelection = false;

                while (!validSelection)
                {
                    keyInfoAppearance = ReadKey(true);

                    if (keyInfoAppearance.KeyChar != '1' && keyInfoAppearance.KeyChar != '2')
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("ERROR: Please select between [1] CONFIRM or [2] RE-DO only.");
                        ResetColor();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        validSelection = true;
                        if (keyInfoAppearance.KeyChar == '1')
                        {
                            selection = 1;
                            selectedAns.Add(selectedChoice.selectedBodyType);
                            selectedAns.Add(selectedChoice.selectedSkinColor);
                            selectedAns.Add(selectedChoice.selectedHairStyle);
                            selectedAns.Add(selectedChoice.selectedHairColor);
                            selectedAns.Add(selectedChoice.selectedFaceShape);
                            selectedAns.Add(selectedChoice.selectedEyeShape);
                            selectedAns.Add(selectedChoice.selectedEyeColor);
                            selectedAns.Add(selectedChoice.Tattoo.ToString());
                            stepsChecking[1] = true;
                        }
                        else if (keyInfoAppearance.KeyChar == '2')
                        {
                            selection = 2;
                            break;
                        }
                    }
                }
            } while (selection == 2);

            string output = "\nSAVING YOUR CHARACTER APPEARANCE";
            ForegroundColor = ConsoleColor.DarkBlue;
            Write(output);
            ResetColor();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Write(".");
            }
            Thread.Sleep(300);
            NewGame();
        }


        private void characterInformationOutput(string clothes, string pants, string shoes, string accessories)//output for characterOutfit
        {
            WriteLine("Top: " + clothes);
            WriteLine("Pants: " + pants);
            WriteLine("Shoes: " + shoes);
            WriteLine("Accessories: " + accessories);
        }
        private void characterOutfit()
        {
            do
            {
                Clear();
                WriteLine("C. Character Outfit: ");
                string[] clothes = ethnicity.clothesChoice();
                selectedChoice.selectedClothes = Menu.SelectOptions("Choose your Top:", clothes);

                WriteLine();

                string[] pants = ethnicity.pantsChoice();
                selectedChoice.selectedPants = Menu.SelectOptions("Choose your Pants:", pants);

                WriteLine();

                string[] shoes = ethnicity.shoesChoice();
                selectedChoice.selectedShoes = Menu.SelectOptions("Choose your Shoes:", shoes);

                WriteLine();

                string[] accessories = ethnicity.accessoriesChoice();
                selectedChoice.selectedAccessories = Menu.SelectOptions("Choose your Accessories:", accessories);

                WriteLine();

                characterInformationOutput(selectedChoice.selectedClothes, selectedChoice.selectedPants, selectedChoice.selectedShoes, selectedChoice.selectedAccessories);

                WriteLine();

                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("CONFIRM YOUR SELECTION:");
                ResetColor();
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("[1]CONFIRM\n[2]RE-DO");
                ResetColor();

                ConsoleKeyInfo keyInfoOutfit;
                bool validSelection = false;

                while (!validSelection)
                {
                    keyInfoOutfit = ReadKey(true);

                    if (keyInfoOutfit.KeyChar != '1' && keyInfoOutfit.KeyChar != '2')
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("ERROR: Please select between [1] CONFIRM or [2] RE-DO only.");
                        ResetColor();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        validSelection = true;
                        if (keyInfoOutfit.KeyChar == '1')
                        {
                            selection = 1;
                            selectedAns.Add(selectedChoice.selectedClothes);
                            selectedAns.Add(selectedChoice.selectedPants);
                            selectedAns.Add(selectedChoice.selectedShoes);
                            selectedAns.Add(selectedChoice.selectedAccessories);
                            stepsChecking[2] = true;
                        }
                        else if (keyInfoOutfit.KeyChar == '2')
                        {
                            selection = 2;
                            break;
                        }
                    }
                }
            } while (selection == 2);
            string output = "\nSAVING YOUR CHARACTER OUTFIT";

            ForegroundColor = ConsoleColor.DarkBlue;
            Write(output);
            ResetColor();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Write(".");
            }
            Thread.Sleep(300);
            NewGame();
        }
        private void characterInfomationOutput(string personalVehicle, string vehicleColor, string mount, string starterPack, string roles, string skills)//output for characterGameplay
        {
            WriteLine("Personal Vehicle: " + personalVehicle);
            WriteLine("Personal Vehicle Color: " + vehicleColor);
            WriteLine("Mount: " + mount);
            WriteLine("Starter Pack: " + starterPack);
            WriteLine("Role: " + roles);
            WriteLine("Skill: " + skills);
        }
        private void characterGameplay()
        {
            do
            {
                Clear();
                ForegroundColor = ConsoleColor.White;
                WriteLine("D. Character Gameplay: ");
                ResetColor();

                string[] personalVehicle = ethnicity.personalVehicleChoice();
                selectedChoice.selectedPersonalVehicle = Menu.SelectOptions("Choose your Personal Vehicle:", personalVehicle);

                WriteLine();

                string[] vehicleColor = ethnicity.vehicleColorChoice();
                selectedChoice.selectedVehicleColor = Menu.SelectOptions("Choose your Personal Vehicle Color:", vehicleColor);

                WriteLine();

                string[] mount = ethnicity.mountChoice();
                selectedChoice.selectedMount = Menu.SelectOptions("Choose your Mount:", mount);

                WriteLine();

                string[] starterPack = ethnicity.starterPackChoice();
                selectedChoice.selectedStarterPack = Menu.SelectOptions("Choose your Starter Pack:", starterPack);

                WriteLine();

                string[] roles = ethnicity.rolesChoice();
                selectedChoice.selectedRoles = Menu.SelectOptions("Choose your role:", roles);

                WriteLine();

                string[] skills = ethnicity.skillsChoice();
                selectedChoice.selectedSkills = Menu.SelectOptions("Choose your Skill:", skills);


                WriteLine();

                characterInfomationOutput(selectedChoice.selectedPersonalVehicle, selectedChoice.selectedVehicleColor, selectedChoice.selectedMount, selectedChoice.selectedStarterPack, selectedChoice.selectedRoles, selectedChoice.selectedSkills);

                WriteLine();

                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("CONFIRM YOUR SELECTION:");
                ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("[1]CONFIRM\n[2]RE-DO");
                ResetColor();

                ConsoleKeyInfo keyInfoGameplay;
                bool validSelection = false;

                while (!validSelection)
                {
                    keyInfoGameplay = ReadKey(true);

                    if (keyInfoGameplay.KeyChar != '1' && keyInfoGameplay.KeyChar != '2')
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("ERROR: Please select between [1] CONFIRM or [2] RE-DO only.");
                        ResetColor();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        validSelection = true;
                        if (keyInfoGameplay.KeyChar == '1')
                        {
                            selection = 1;
                            selectedAns.Add(selectedChoice.selectedPersonalVehicle);
                            selectedAns.Add(selectedChoice.selectedVehicleColor);
                            selectedAns.Add(selectedChoice.selectedMount);
                            selectedAns.Add(selectedChoice.selectedStarterPack);
                            selectedAns.Add(selectedChoice.selectedRoles);
                            selectedAns.Add(selectedChoice.selectedSkills);
                            stepsChecking[3] = true;
                        }
                        else if (keyInfoGameplay.KeyChar == '2')
                        {
                            selection = 2;
                            break;
                        }
                    }
                }
            } while (selection == 2);
            string output = "\nSAVING YOUR CHARACTER GAMEPLAY";

            ForegroundColor = ConsoleColor.DarkBlue;
            Write(output);
            ResetColor();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Write(".");
            }
            Thread.Sleep(300);
            NewGame();
        }
        private void characterInformationOutput(byte rangeWeapon, byte meleeWeapon, byte projectileWeapon, byte luckMastery, byte regenMastery)
        {
            WriteLine("Ranged Weapon Mastery: " + rangeWeapon);
            WriteLine("Melee Weapon Mastery: " + meleeWeapon);
            WriteLine("Projectile Weapon Mastery: " + projectileWeapon);
            WriteLine("Luck Mastery: " + luckMastery);
            WriteLine("Regeneration Mastery: " + regenMastery);
        }
        private void characterStats()
        {
            do
            {
                Clear();
                ForegroundColor = ConsoleColor.White;
                WriteLine("E. Character Stats: ");
                ResetColor();

                WriteLine();

                ForegroundColor = ConsoleColor.Green;
                WriteLine("You have total of 10 points to allocate and distribute. Each stat can only have maximum of 3 points.");
                ResetColor();

                WriteLine("RANGE WEAPON MASTERY: \nMELEE WEAPON MASTERY:\nPROJECTILE WEAPON MASTERY:\nLUCK MASTERY:\nREGENERATION MASTERY:");
                selectedChoice.totalPoints = 10;
                selectedChoice.rangeWeapon = 0; selectedChoice.meleeWeapon = 0; selectedChoice.projectileWeapon = 0; selectedChoice.luckMastery = 0; selectedChoice.regenMastery = 0;

                while (selectedChoice.totalPoints > 0)
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("\nRANGED WEAPON MASTERY (Guns and Bows) [0-3]:");
                    ResetColor();
                    selectedChoice.rangeWeapon = Menu.AllocatePoints(selectedChoice.rangeWeapon, selectedChoice.totalPoints);
                    selectedChoice.totalPoints -= selectedChoice.rangeWeapon;
                    if (selectedChoice.totalPoints <= 0) break;

                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("MELEE WEAPON MASTERY (Hack-and-Slash) [0-3]:");
                    ResetColor();
                    selectedChoice.meleeWeapon = Menu.AllocatePoints(selectedChoice.meleeWeapon, selectedChoice.totalPoints);
                    selectedChoice.totalPoints -= selectedChoice.meleeWeapon;
                    if (selectedChoice.totalPoints <= 0) break;

                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("PROJECTILE WEAPON MASTERY (Grenades and Throwing Knives) [0-3]:");
                    ResetColor();
                    selectedChoice.projectileWeapon = Menu.AllocatePoints(selectedChoice.projectileWeapon, selectedChoice.totalPoints);
                    selectedChoice.totalPoints -= selectedChoice.projectileWeapon;
                    if (selectedChoice.totalPoints <= 0) break;

                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("LUCK MASTERY (Find more resources) [0-3]:");
                    ResetColor();
                    selectedChoice.luckMastery = Menu.AllocatePoints(selectedChoice.luckMastery, selectedChoice.totalPoints);
                    selectedChoice.totalPoints -= selectedChoice.luckMastery;
                    if (selectedChoice.totalPoints <= 0) break;

                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("REGENERATION MASTERY (Player’s stamina / energy) [0-3]:");
                    ResetColor();
                    selectedChoice.regenMastery = Menu.AllocatePoints(selectedChoice.regenMastery, selectedChoice.totalPoints);
                    selectedChoice.totalPoints -= selectedChoice.regenMastery;
                    if (selectedChoice.totalPoints <= 0) break;
                }

                if (selectedChoice.totalPoints == 0)
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nAll points have been allocated successfully!");
                    ResetColor();
                }

                characterInformationOutput(selectedChoice.rangeWeapon, selectedChoice.meleeWeapon, selectedChoice.projectileWeapon, selectedChoice.luckMastery, selectedChoice.regenMastery);

                WriteLine();

                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("CONFIRM YOUR SELECTION:");
                ResetColor();
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("[1]CONFIRM\n[2]RE-DO");
                ResetColor();
                ConsoleKeyInfo KeyInfoStats;

                bool validSelection = false;
                while (!validSelection)
                {
                    KeyInfoStats = ReadKey(true);

                    if (KeyInfoStats.KeyChar != '1' && KeyInfoStats.KeyChar != '2')
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("ERROR: Please select between [1] CONFIRM or [2] RE-DO only.");
                        ResetColor();
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        validSelection = true;
                        if (KeyInfoStats.KeyChar == '1')
                        {
                            selection = 1;
                            selectedAns.Add(selectedChoice.rangeWeapon.ToString());
                            selectedAns.Add(selectedChoice.meleeWeapon.ToString());
                            selectedAns.Add(selectedChoice.projectileWeapon.ToString());
                            selectedAns.Add(selectedChoice.luckMastery.ToString());
                            selectedAns.Add(selectedChoice.regenMastery.ToString());
                            stepsChecking[4] = true;
                        }
                        else if (KeyInfoStats.KeyChar == '2')
                        {
                            selection = 2;
                            break;
                        }
                    }
                }
            } while (selection == 2);
            string output = "\nSAVING YOUR CHARACTER STATS";

            ForegroundColor = ConsoleColor.DarkBlue;
            Write(output);
            ResetColor();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Write(".");
            }
            Thread.Sleep(300);
            NewGame();
        }
        private void backToMainMenu()
        {
            RunMainMenu();
        }
        private void ResetCharacterData()
        {
            Array.Clear(stepsChecking, 0, stepsChecking.Length);
            selectedAns.Clear();
        }
        private void saveAll()
        {
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("CONFIRM YOUR SELECTION:");
            ResetColor();
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("[1]CONFIRM\n[2]GO BACK TO CHARACTER SELECTION MENU");
            ResetColor();
            int checkingSelection = Convert.ToInt32(ReadLine());
            if (checkingSelection == 1)
            {
                selection = 1;
            }
            else if (checkingSelection >= 2)
            {
                selection = 0;
                NewGame();
            }
            string output = "\nSAVING";

            ForegroundColor = ConsoleColor.DarkBlue;
            Write(output);
            ResetColor();
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Write(".");
            }
            WriteLine();
            Thread.Sleep(350);
        }
        public string validateName()
        {
            string name;
            while (true)
            {
                Clear();
                ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter your character's name: ");
                name = Console.ReadLine();

                if (name.Length < 3 || name.Length > 16)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: The name must be between 3 and 16 characters.");
                    ResetColor();
                    Thread.Sleep(3000);
                    continue;
                }

                if (name.Contains(' '))
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: Spaces are not allowed in the name.");
                    ResetColor();
                    Thread.Sleep(3000);
                    continue;
                }

                if (!Regex.IsMatch(name, @"^[a-zA-Z0-9_.-]+$"))
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: The name can only contain letters, numbers, _, -, or .");
                    ResetColor();
                    Thread.Sleep(3000);
                    continue;
                }

                if (Regex.IsMatch(name, @"[^\u0000-\u007F]"))
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: Emojis or special characters are not allowed.");
                    ResetColor();
                    Thread.Sleep(3000);
                    continue;
                }
                if (databaseLike.Any(existingName => existingName == name))
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("This name is already taken.");
                    ResetColor();
                    Thread.Sleep(3000);
                    continue;
                }
                return name;
            }
        }

    }
}
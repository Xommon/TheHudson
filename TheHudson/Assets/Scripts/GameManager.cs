using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Character> characters = new List<Character>();
    public List<Room> rooms = new List<Room>();

    // Start is called before the first frame update
    void Start()
    {
        // Create the characters
        while (characters.Count < 11)
        {
            // Create a new character
            Character character = new Character();
            characters.Add(character);

            // Gender
            character.gender = ChooseFrom(new DataClass("male", 45), new DataClass("female", 45), new DataClass("other", 10));

            // Pronouns
            if (character.gender == "male")
            {
                character.pronouns.Add("He");
                character.pronouns.Add("Him");
                character.pronouns.Add("His");
                character.pronouns.Add("His");
                character.pronouns.Add("Himself");
                character.pronouns.Add("Is");
            }
            else if (character.gender == "female")
            {
                character.pronouns.Add("She");
                character.pronouns.Add("Her");
                character.pronouns.Add("Her");
                character.pronouns.Add("Hers");
                character.pronouns.Add("Herself");
                character.pronouns.Add("Is");
            }
            else if (character.gender == "other")
            {
                character.pronouns.Add("They");
                character.pronouns.Add("Them");
                character.pronouns.Add("Their");
                character.pronouns.Add("Theirs");
                character.pronouns.Add("Themself");
                character.pronouns.Add("Are");
            }

            // Country
            character.country = ChooseFrom(new DataClass("United States", 100), new DataClass("Canada", 25), new DataClass("Mexico", 15), new DataClass("Argentina", 5), new DataClass("Cuba", 5));

            // City and State
            if (character.country == "United States")
            {
                character.city = ChooseFrom("New York, NY", "Brooklyn, NY", "Queens, NY", "The Bronx, NY", "Staten Island, NY", "Los Angeles, CA", "Chicago, IL", "Seattle, WA", "Portland, OR", "Charlotte, NC", "Burlington, VT", "Virginia Beach, VA", "Las Vegas, NV", "Madison, WI", "Green Bay, WI", "Oklahoma City, OK", "Charleston, WV", "Charlestone, SC", "Iowa City, IA", "Des Moines, IA", "San Jose, TX", "Oakland, CA", "Evanston, IL", "Wichita, KS", "Louisville, KY", "Topeka, KS", "San Francisco, CA", "San Antonio, TX", "Jacksonville, FL", "Memphis, TN", "Nashville, TN", "Raleigh, NC", "Richmond, VA", "Baltimore, MD", "Jackson, MS", "Manchester, NH", "Newark, NJ", "Jersey City, NJ", "Buffalo, NY", "Little Rock, AR", "Sioux Falls, SD", "Boise, ID", "Billings, MT", "Cheyenne, WY", "Birmingham, AL", "Houston, TX", "Dallas, TX", "Albuquerque, NM", "Austin, TX", "Milwaukee, WI", "Minneapolis, MN", "St. Paul, MN", "Duluth, MN", "Columbus, OH", "Dayton, OH", "Cleveland, OH", "Indianapolis, IN", "Fort Wayne, IN", "Kansas City, MO", "St. Louis, MO", "Miami, FL", "Boston, MA", "Providence, RI", "Phoenix, AZ", "Denver, CO", "Salt Lake City, UT", "Omaha, NE", "Fargo, ND", "Philadelphia, PA", "Pittsburgh, PA", "Cincinnati, OH", "San Diego, CA", "Honolulu, HI", "Anchorage, AK", "Detroit, MI", "New Orleans, LA", "Washington D.C.", "Atlanta, GA", "Tampa, FL", "Orlando, FL");
                if (character.city != "Washington D.C.")
                {
                    character.state = character.city.Substring(character.city.Length - 2, 2);
                }
                character.city = character.city.Substring(0, character.city.Length - 4);
            }
            else if (character.country == "Canada")
            {
                character.city = ChooseFrom("Toronto, ON", "Montreal, QC", "Vancouver, BC", "Calgary, AB", "Edmonton, AB", "Ottawa, ON", "Quebec City, QC", "Winnipeg, MB", "Saskatoon, SK", "Regina, SK", "Victoria, BC", "Thunder Bay, ON", "Mississauga, ON", "London, ON", "Windsor, ON", "Halifax, NS", "St. John's, NL", "Yellowknife, NT", "Whitehorse, YT", "Iqaluit, NU");
                character.state = character.city.Substring(character.city.Length - 2, 2);
                character.city = character.city.Substring(0, character.city.Length - 4);
            }
            else if (character.country == "Mexico")
            {
                character.city = ChooseFrom("Mexico City", "Mexico City", "Guadalajara", "Puebla", "Juarez", "Tijuana", "Cancun", "Chihuahua");
            }
            else if (character.country == "Argentina")
            {
                character.city = ChooseFrom("Buenoas Aires", "Cordoba", "Rosario", "La Plata");
            }
            else if (character.country == "Cuba")
            {
                character.city = ChooseFrom("Havana", "Santiago de Cuba", "Camagüey");
            }
            else if (character.country == "China")
            {
                character.city = ChooseFrom("Beijing", "Shanghai", "Chongqing", "Shenzen", "Tianjing", "Guangzhou", "Wuhan", "Nanjing", "Chengdu", "Harbin", "Xi'an", "Hangzhou");
            }

            // Ethnicity
            if (character.country == "United States")
            {
                /*if (character.city == "Honolulu")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 15), new DataClass("latino", 0), new DataClass("black", 0), new DataClass("east asian", 30), new DataClass("south asian", 1), new DataClass("middle eastern", 1), new DataClass("native american", 1), new DataClass("pacific islander", 52));
                }
                else if (character.city == "Los Angeles" || character.city == "Dallas" || character.city == "Houston" || character.city == "San Antonio" || character.city == "Austin")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 25), new DataClass("latino", 35), new DataClass("black", 20), new DataClass("east asian", 15), new DataClass("south asian", 2), new DataClass("middle eastern", 1), new DataClass("native american", 1), new DataClass("pacific islander", 1));
                }
                else if (character.city == "New Orleans" || character.city == "Jackson" || character.city == "Birmingham" || character.city == "Little Rock" || character.city == "Charlotte" || character.city == "Charleston" || character.city == "Washington D.C." || character.city == "Atlanta" || character.city == "Baltimore" || character.city == "Raleigh")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 21), new DataClass("latino", 10), new DataClass("black", 60), new DataClass("east asian", 5), new DataClass("south asian", 2), new DataClass("middle eastern", 1), new DataClass("native american", 1), new DataClass("pacific islander", 0));
                }
                else if (character.city == "Albuquerque")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 20), new DataClass("latino", 15), new DataClass("black", 10), new DataClass("east asian", 2), new DataClass("south asian", 1), new DataClass("middle eastern", 1), new DataClass("native american", 51), new DataClass("pacific islander", 0));
                }
                else if (character.city == "Detroit")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 15), new DataClass("latino", 8), new DataClass("black", 50), new DataClass("east asian", 2), new DataClass("south asian", 5), new DataClass("middle eastern", 20), new DataClass("native american", 0), new DataClass("pacific islander", 0));
                }
                else if (character.city == "Anchorage")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 50), new DataClass("latino", 0), new DataClass("black", 3), new DataClass("east asian", 5), new DataClass("south asian", 2), new DataClass("middle eastern", 3), new DataClass("native american", 7), new DataClass("pacific islander", 0), new DataClass("inuit", 30));
                }
                else*/
                {
                    character.ethnicGroup = ChooseFrom
                        (
                        new DataClass(ChooseFrom("white", new DataClass("latino", 3), new DataClass("black", 2), new DataClass("east asian", 1), new DataClass("south asian", 1), new DataClass("middle eastern", 2), new DataClass("native american", 1), new DataClass("pacific islander", 1)), 50), 
                        new DataClass(ChooseFrom("latino", new DataClass("white", 3), new DataClass("black", 2), new DataClass("east asian", 1), new DataClass("south asian", 1), new DataClass("middle eastern", 1), new DataClass("native american", 10), new DataClass("pacific islander", 1)), 20), 
                        new DataClass(ChooseFrom("black", new DataClass("latino", 2), new DataClass("white", 4), new DataClass("east asian", 1), new DataClass("south asian", 1), new DataClass("middle eastern", 1), new DataClass("native american", 1), new DataClass("pacific islander", 1)), 15), 
                        new DataClass(ChooseFrom("east asian", new DataClass("latino", 1), new DataClass("black", 2), new DataClass("white", 3), new DataClass("south asian", 1), new DataClass("middle eastern", 1), new DataClass("native american", 1), new DataClass("pacific islander", 1)), 5), 
                        new DataClass(ChooseFrom("south asian", new DataClass("latino", 1), new DataClass("black", 2), new DataClass("east asian", 3), new DataClass("white", 2), new DataClass("middle eastern", 1), new DataClass("native american", 1), new DataClass("pacific islander", 1)), 5), 
                        new DataClass(ChooseFrom("middle eastern", new DataClass("latino", 1), new DataClass("black", 2), new DataClass("east asian", 1), new DataClass("south asian", 1), new DataClass("white", 4), new DataClass("native american", 1), new DataClass("pacific islander", 1)), 3), 
                        new DataClass(ChooseFrom("native american", new DataClass("latino", 3), new DataClass("black", 2), new DataClass("east asian", 1), new DataClass("south asian", 1), new DataClass("middle eastern", 2), new DataClass("white", 1), new DataClass("pacific islander", 1)), 1), 
                        new DataClass(ChooseFrom("pacific islander", new DataClass("latino", 1), new DataClass("black", 1), new DataClass("east asian", 5), new DataClass("south asian", 1), new DataClass("middle eastern", 1), new DataClass("native american", 2), new DataClass("white", 3)), 1)
                        );
                }
            }
            else if (character.country == "Canada")
            {
                if (character.city == "Iqaluit")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 50), new DataClass("latino", 0), new DataClass("black", 3), new DataClass("east asian", 5), new DataClass("south asian", 2), new DataClass("middle eastern", 3), new DataClass("native american", 7), new DataClass("pacific islander", 0), new DataClass("inuit", 30));
                }
                else if (character.city == "Yellowknife" || character.city == "Iqaluit")
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 50), new DataClass("latino", 0), new DataClass("black", 3), new DataClass("east asian", 4), new DataClass("south asian", 3), new DataClass("middle eastern", 3), new DataClass("native american", 32), new DataClass("pacific islander", 0), new DataClass("inuit", 5));
                }
                else
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 56), new DataClass("latino", 1), new DataClass("black", 5), new DataClass("east asian", 11), new DataClass("south asian", 13), new DataClass("middle eastern", 9), new DataClass("native american", 5), new DataClass("pacific islander", 0));
                }
            }
            else if (character.country == "Mexico" || character.country == "Argentina" || character.country == "Cuba")
            {
                character.ethnicGroup = ChooseFrom("latino", new DataClass("white", 25), new DataClass("black", 5), new DataClass("east asian", 1), new DataClass("native american", 25));
            }

            // First name
            if (character.ethnicGroup == "latino")
            {
                if (character.gender == "male")
                {
                    character.firstName = ChooseFrom("Michael", "Juan", "Jacob", "Alex", "Jason", "Tony", "David", "Daniel", "Mark", "Sam", "Angel", "Alejandro", "Jesus", "Miguel", "Eduardo");
                }
                else if (character.gender == "female")
                {
                    character.firstName = ChooseFrom("Diana", "Mary", "Jessica", "Julia", "Amy", "Sarah", "Toni", "Rosie", "Maria", "Jennifer", "Rachel", "Sam", "Alondra");
                }
                else if (character.gender == "other")
                {
                    character.firstName = ChooseFrom("Alex", "Sam", "Mae", "Travis", "Blake", "Jason", "Toni", "Angel", "Alexi");
                }
            }
            else if (character.ethnicGroup == "south asian")
            {
                if (character.gender == "male")
                {
                    character.firstName = ChooseFrom("Aarav", "Rohan", "Aditya", "Muhammad", "Sai", "Arnav", "David", "Daniel", "Dhruv", "Krishna", "Kabir");
                }
                else if (character.gender == "female")
                {
                    character.firstName = ChooseFrom("Diana", "Saanvi", "Kiara", "Diya", "Aditi", "Sarah", "Priyanka", "Fatima", "Sri", "Sruthi", "Rachel", "Anika", "Vanya");
                }
                else if (character.gender == "other")
                {
                    character.firstName = ChooseFrom("Aarav", "Sai", "Arnav", "Diya", "Blake", "Aditi", "Sri", "Angel", "Alex");
                }
            }
            else if (character.ethnicGroup == "middle eastern")
            {
                if (character.gender == "male")
                {
                    character.firstName = ChooseFrom("Muhammad", "Muhammad", "Ali", "Amir", "Khalid", "Khalil", "David", "Ibrahim", "Omar", "Kabeer");
                }
                else if (character.gender == "female")
                {
                    character.firstName = ChooseFrom("Diana", "Zahirah", "Khadijah", "Nur", "Laila", "Sarah", "Maryam", "Fatima", "Lena", "Amira", "Rachel", "Aisha", "Salma");
                }
                else if (character.gender == "other")
                {
                    character.firstName = ChooseFrom("Ali", "Nur", "Khaj", "Davi", "Sam", "Danni", "Angel", "Alex");
                }
            }
            else
            {
                if (character.gender == "male")
                {
                    character.firstName = ChooseFrom("Michael", "John", "Jacob", "Alex", "Jason", "Travis", "Blake", "Tim", "David", "Daniel", "Mark", "Keith", "Samuel", "Chris");
                }
                else if (character.gender == "female")
                {
                    character.firstName = ChooseFrom("Diana", "Mary", "Jessica", "Julia", "Karen", "Amy", "Cindy", "Sarah", "Darlene", "Leanne", "Inga", "Toni", "Rosie", "Jennifer", "Rachel", "Sam");
                }
                else if (character.gender == "other")
                {
                    character.firstName = ChooseFrom("Alex", "Sam", "Mae", "Travis", "Blake", "Jason", "Toni", "Chris");
                }
            }

            // Last name
            character.lastName = "Smith";

            // Age
            if (PercentChance(76))
            {
                // Average
                character.age = Random.Range(28, 38);
            }
            else if (PercentChance(25))
            {
                // Younger
                character.age = Random.Range(21, 28);
            }
            else if (PercentChance(75))
            {
                // Older
                character.age = Random.Range(38, 49);
            }
            else
            {
                // Much Older
                character.age = Random.Range(50, 60);
            }

            // Height
            if (character.gender == "male")
            {
                if (PercentChance(76))
                {
                    // Average
                    character.height = Random.Range(175, 179);
                }
                else if (PercentChance(50))
                {
                    // Shorter
                    character.height = Random.Range(165, 175);
                }
                else
                {
                    // Taller
                    character.height = Random.Range(179, 206);
                }
            }
            else if (character.gender == "female")
            {
                if (PercentChance(88))
                {
                    // Average
                    character.height = Random.Range(162, 169);
                }
                else if (PercentChance(50))
                {
                    // Shorter
                    character.height = Random.Range(148, 162);
                }
                else
                {
                    // Taller
                    character.height = Random.Range(169, 188);
                }
            }
            else if (character.gender == "other")
            {
                if (PercentChance(76))
                {
                    // Average
                    character.height = Random.Range(162, 179);
                }
                else if (PercentChance(50))
                {
                    // Shorter
                    character.height = Random.Range(148, 162);
                }
                else
                {
                    // Taller
                    character.height = Random.Range(179, 206);
                }
            }

            float inches = character.height * 0.393701f;
            if (Mathf.Round(inches % 12) == 12)
            {
                character.heightFeetAndInches = ((inches / 12) + 1).ToString().Substring(0, 1) + "ft " + 0 + "in";
            }
            else
            {
                character.heightFeetAndInches = (inches / 12).ToString().Substring(0, 1) + "ft " + Mathf.Round(inches % 12) + "in";
            }

            // Occupation
            if (character.age < 27)
            {
                character.occupation = ChooseFrom(" student", " plumber", " model", "n athlete", " librarian", " painter", " drawer", "n actor", " powerlifter", " translator", " singer", " photographer", " software developer");
            }
            else if (character.age >= 27 && character.age < 36)
            {
                character.occupation = ChooseFrom(" plumber", " model", "n athlete", " librarian", " painter", " drawer", "n actor", " teacher", " powerlifter", " translator", " singer", " photographer", " software developer");
            }
            else
            {
                character.occupation = ChooseFrom(" plumber", " librarian", " painter", " drawer", "n actor", " professor", " translator", " singer", " photographer", " software developer");
            }

            // Personality
            character.friendlinessMax = Random.Range(20, 100);
            character.irritabilityMax = Random.Range(20, 100);
            character.humourMax = Random.Range(20, 100);
            character.flirtinessMax = Random.Range(20, 100);
            character.emotionalnessMax = Random.Range(20, 100);

            if (character.friendlinessMax <= 40)
            {
                character.friendlinessDescription = "very unfriendly";
            }
            if (character.friendlinessMax > 40 && character.friendlinessMax <= 60)
            {
                character.friendlinessDescription = "standoffish";
            }
            if (character.friendlinessMax > 60 && character.friendlinessMax <= 80)
            {
                character.friendlinessDescription = "warm";
            }
            if (character.friendlinessMax > 80)
            {
                character.friendlinessDescription = "very friendly";
            }

            if (character.irritabilityMax <= 40)
            {
                character.irritabilityDescription = "extremely hot-headed";
            }
            if (character.irritabilityMax > 40 && character.irritabilityMax <= 60)
            {
                character.irritabilityDescription = "hot-headed";
            }
            if (character.irritabilityMax > 60 && character.irritabilityMax <= 80)
            {
                character.irritabilityDescription = "congeinial";
            }
            if (character.irritabilityMax > 80)
            {
                character.irritabilityDescription = "very level-headed";
            }

            if (character.flirtinessMax <= 40)
            {
                character.flirtinessDescription = "asexual";
            }
            if (character.flirtinessMax > 40 && character.flirtinessMax <= 60)
            {
                character.flirtinessDescription = "prudish";
            }
            if (character.flirtinessMax > 60 && character.flirtinessMax <= 80)
            {
                character.flirtinessDescription = "flirtatious";
            }
            if (character.flirtinessMax > 80)
            {
                character.flirtinessDescription = "highly flirtatious";
            }

            if (character.humourMax <= 40)
            {
                character.humourDescription = "boring";
            }
            if (character.humourMax > 40 && character.humourMax <= 60)
            {
                character.humourDescription = "slightly serious";
            }
            if (character.humourMax > 60 && character.humourMax <= 80)
            {
                character.humourDescription = "humorous";
            }
            if (character.humourMax > 80)
            {
                character.humourDescription = "a comical genius";
            }

            if (character.emotionalnessMax <= 40)
            {
                character.emotionalnessDescription = "an emotional wreck";
            }
            if (character.emotionalnessMax > 40 && character.emotionalnessMax <= 60)
            {
                character.emotionalnessDescription = "highly emotional";
            }
            if (character.emotionalnessMax > 60 && character.emotionalnessMax <= 80)
            {
                character.emotionalnessDescription = "quite reasonable emotionally";
            }
            if (character.emotionalnessMax > 80)
            {
                character.emotionalnessDescription = "very emotionally sound";
            }
            
            Debug.Log
                (
                character.firstName + " is from " + character.city + ", " + character.state + ", " + character.country + ". " +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.ethnicGroup + " and " + character.pronouns[2].ToLower() + " occupation is a" + character.occupation + ". " +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.age + "-years-old and " + character.pronouns[5].ToLower() + " " + character.height + "cm/" + character.heightFeetAndInches + " tall.\n" +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.friendlinessDescription + ", " + character.irritabilityDescription + ", " + character.flirtinessDescription + ", " + character.humourDescription + ", and " + character.emotionalnessDescription + "."
                );
        }

        while (rooms.Count < 18)
        {
            // Create a new room
            Room room = new Room();
            rooms.Add(room);

            if (rooms.Count < 10)
            {
                room.name = "#10" + (rooms.Count) + " / " + characters[rooms.Count - 1].firstName + "'s Room";
                room.owner = characters[rooms.Count - 1];
            }
            else if (rooms.Count >= 10 && rooms.Count < 12)
            {
                room.name = "#1" + (rooms.Count) + " / " + characters[rooms.Count - 1].firstName + "'s Room";
                room.owner = characters[rooms.Count - 1];
            }
            else if (rooms.Count == 12)
            {
                room.name = "#112 / Your Room";
            }
            else if (rooms.Count == 13)
            {
                room.name = "Hallway";
            }
            else if (rooms.Count == 14)
            {
                room.name = "Kitchen";
            }
            else if (rooms.Count == 15)
            {
                room.name = "Dining Room";
            }
            else if (rooms.Count == 16)
            {
                room.name = "Pool";
            }
            else if (rooms.Count == 17)
            {
                room.name = "Gym";
            }
        }

        for (int i = 0; i < rooms.Count - 1; i++)
        {
            Debug.Log(rooms[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
            Debug.ClearDeveloperConsole();
        }
    }

    public bool PercentChance(float percent)
    {
        if (percent > 100)
        {
            percent = 100;
        }
        else if (percent < 0)
        {
            percent = 0;
        }

        float selection = Random.Range(0.0f, 100.0f);
        if (selection <= percent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string ChooseFrom(params string[] things)
    {
        return things[Random.Range(0, things.Length)];
    }

    public string ChooseFrom(string mainEthnicity, params DataClass[] things)
    {
        // Create a list of each bracket
        List<Vector2> brackets = new List<Vector2>();
        int previousPercentage = 0;
        for (int i = 0; i < things.Length; i++)
        {
            if (things[i].percentage > 0)
            {
                brackets.Add(new Vector2(previousPercentage, previousPercentage + things[i].percentage - 1));
                previousPercentage = previousPercentage + things[i].percentage;
            }
        }

        // Choose a random number to determine what is selected
        int selectedNumber = Random.Range(0, 99);

        // Attribute the selected bracket to a string
        for (int i = 0; i < things.Length; i++)
        {
            if (selectedNumber >= brackets[i].x && selectedNumber <= brackets[i].y)
            {
                return mainEthnicity + "/" + things[i].word;
            }
        }

        return mainEthnicity;
    }

    public string ChooseFrom(params DataClass[] things)
    {
        // Create a list of each bracket
        List<Vector2> brackets = new List<Vector2>();
        int previousPercentage = 0;
        for (int i = 0; i < things.Length; i++)
        {
            if (things[i].percentage > 0)
            {
                brackets.Add(new Vector2(previousPercentage, previousPercentage + things[i].percentage - 1));
                previousPercentage = previousPercentage + things[i].percentage;
            }
        }

        // Choose a random number to determine what is selected
        int selectedNumber = Random.Range(0, 99);

        // Attribute the selected bracket to a string
        for (int i = 0; i < things.Length; i++)
        {
            if (selectedNumber >= brackets[i].x && selectedNumber <= brackets[i].y)
            {
                return things[i].word;
            }
        }

        return null;
    }
}

public class DataClass
{
    public string word;
    public int percentage;

    public DataClass(string _word, int _percentage)
    {
        word = _word;
        percentage = _percentage;
    }
}
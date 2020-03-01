using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Character> characters = new List<Character>();

    // Start is called before the first frame update
    void Start()
    {
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
            //character.country = ChooseFrom("united states", "canada", "mexico");
            character.country = ChooseFrom(new DataClass("United States", 50), new DataClass("Canada", 25), new DataClass("Mexico", 25));

            // City
            if (character.country == "United States")
            {
                character.city = ChooseFrom("New York", "Los Angeles", "Chicago", "Seattle", "Portland", "San Francisco", "Houston", "Dallas", "Austin", "Milwaukee", "Minneapolis", "Columbus", "Cleveland", "Indianapolis", "Kansas City", "St. Louis", "Miami", "Boston", "Providence", "Phoenix", "Denver", "Salt Lake City", "Omaha", "Fargo", "Philadelphia", "Pittsburgh", "Cincinnati", "San Diego", "Honolulu", "Anchorage", "Detroit", "New Orleans", "Washington D.C.", "Atlanta", "Tampa");
            }
            else if (character.country == "Canada")
            {
                character.city = ChooseFrom("Toronto", "Montreal", "Vancouver", "Calgary", "Edmonton", "Ottawa", "Quebec City", "Winnipeg", "Saskatoon", "Regina", "Victoria", "Thunder Bay", "Mississauga", "London", "Windsor", "Halifax", "St. John's", "Yellowknife", "Whitehorse", "Iqaluit");
            }
            else if (character.country == "Mexico")
            {
                character.city = ChooseFrom("Mexico City", "Mexico City", "Guadalajara", "Puebla", "Juarez", "Tijuana", "Cancun", "Chihuahua");
            }

            // Ethnicity
            if (character.country == "United States")
            {
                character.ethnicGroup = ChooseFrom(new DataClass("white", 50), new DataClass("latino", 20), new DataClass("black", 15), new DataClass("east asian", 5), new DataClass("south asian", 5), new DataClass("middle eastern", 3), new DataClass("native american", 1), new DataClass("pacific islander", 1));
            }
            else if (character.country == "Canada")
            {
                character.ethnicGroup = ChooseFrom(new DataClass("white", 55), new DataClass("latino", 2), new DataClass("black", 5), new DataClass("east asian", 11), new DataClass("south asian", 13), new DataClass("middle eastern", 9), new DataClass("native american", 5), new DataClass("pacific islander", 0));
            }
            else if (character.country == "Mexico")
            {
                character.ethnicGroup = "latino";
            }
            
            if (character.ethnicGroup == "white")
            {
                character.ethnicGroup2 = ChooseFrom(new DataClass(null, 80), new DataClass("latino", 3), new DataClass("black", 10), new DataClass("east asian", 2), new DataClass("south asian", 1), new DataClass("middle eastern", 1), new DataClass("native american", 3), new DataClass("pacific islander", 0));
            }
            else
            {
                character.ethnicGroup2 = ChooseFrom(new DataClass(null, 70), new DataClass("white", 10), new DataClass("black", 7), new DataClass("east asian", 4), new DataClass("south asian", 2), new DataClass("middle eastern", 2), new DataClass("native american", 3), new DataClass("pacific islander", 2));
            }

            if (character.ethnicGroup == character.ethnicGroup2)
            {
                character.ethnicGroup2 = null;
            }

            if (character.ethnicGroup2 == null)
            {
                character.ethnicity = character.ethnicGroup;
            }
            else
            {
                character.ethnicity = character.ethnicGroup + "/" + character.ethnicGroup2;
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
                    character.firstName = ChooseFrom("Mary", "Jessica", "Julia", "Amy", "Sarah", "Toni", "Rosie", "Maria", "Jennifer", "Rachel", "Sam", "Alondra");
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
                    character.firstName = ChooseFrom("Saanvi", "Kiara", "Diya", "Aditi", "Sarah", "Priyanka", "Fatima", "Sri", "Sruthi", "Rachel", "Anika", "Vanya");
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
                    character.firstName = ChooseFrom("Zahirah", "Khadijah", "Nur", "Laila", "Sarah", "Maryam", "Fatima", "Lena", "Amira", "Rachel", "Aisha", "Salma");
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
                    character.firstName = ChooseFrom("Mary", "Jessica", "Julia", "Karen", "Amy", "Cindy", "Sarah", "Darlene", "Leanne", "Inga", "Toni", "Rosie", "Jennifer", "Rachel", "Sam");
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
                if (PercentChance(76))
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
            character.heightFeetAndInches = (inches / 12).ToString().Substring(0, 1) + "ft " + Mathf.Round(inches % 12) + "in";

            // Occupation
            character.occupation = ChooseFrom(" student", " plumber", " model", "n athlete", " librarian", " painter", " drawer", "n actor");

            // Personality
            character.friendlinessMax = Random.Range(20, 100);
            character.irritabilityMax = Random.Range(20, 100);
            character.humourMax = Random.Range(20, 100);
            character.flirtinessMax = Random.Range(20, 100);
            character.emotionalnessMax = Random.Range(20, 100);
            
            string friendliness;
            string irritability;
            string humour;
            string flirtiness;
            string emotionalness;

            if (character.friendlinessMax <= 40)
            {
                friendliness = "very unfriendly";
            }
            if (character.friendlinessMax <= 60)
            {
                friendliness = "standoffish";
            }
            if (character.friendlinessMax <= 70)
            {
                friendliness = "warm";
            }
            if (character.friendlinessMax <= 90)
            {
                friendliness = "very friendly";
            }

            if (character.irritabilityMax <= 40)
            {
                irritability = "extremely hot-headed";
            }
            if (character.irritabilityMax <= 60)
            {
                irritability = "hot-headed";
            }
            if (character.irritabilityMax <= 70)
            {
                irritability = "congeinial";
            }
            if (character.irritabilityMax <= 90)
            {
                irritability = "very level-headed";
            }

            if (character.flirtinessMax <= 40)
            {
                flirtiness = "asexual";
            }
            if (character.flirtinessMax <= 60)
            {
                flirtiness = "prudish";
            }
            if (character.flirtinessMax <= 70)
            {
                flirtiness = "flirtatious";
            }
            if (character.flirtinessMax <= 90)
            {
                flirtiness = "highly flirtatious";
            }

            if (character.humourMax <= 40)
            {
                humour = "boring";
            }
            if (character.humourMax <= 60)
            {
                humour = "slightly serious";
            }
            if (character.humourMax <= 70)
            {
                humour = "humourous";
            }
            if (character.humourMax <= 90)
            {
                humour = "a comical genius";
            }

            if (character.emotionalnessMax <= 40)
            {
                emotionalness = "an emotional wreck";
            }
            if (character.emotionalnessMax <= 60)
            {
                emotionalness = "highly emotional";
            }
            if (character.emotionalnessMax <= 70)
            {
                emotionalness = "quite reasonable emotionally";
            }
            if (character.emotionalnessMax <= 90)
            {
                emotionalness = "very emotionally sound";
            }
            
            Debug.Log
                (
                character.firstName + " is from " + character.city + ", " + character.country + ".\n" +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.ethnicity + " and " + character.pronouns[2].ToLower() + " occupation is a" + character.occupation + ". " +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.age + "-years-old and " + character.pronouns[5].ToLower() + " " + character.height + "cm/" + character.heightFeetAndInches + " tall."
                );
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

    public string ToCapitalise(string word)
    {
        string newWord = "";

        if (word != null)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (i == 0)
                {
                    newWord += word.Substring(0, 1).ToUpper();
                }
                else
                {
                    if (word[i - 1] == ' ' || word[i - 1] == '.')
                    {
                        newWord += word[i].ToString().ToUpper();
                    }
                    else
                    {
                        newWord += word[i];
                    }
                }
            }
        }

        return newWord;
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
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Reference
    public static GameManager instance;
    public TextMesh time;

    // Character management
    public RectTransform characterPanel;
    public List<Character> characters = new List<Character>();
    public List<Character> charactersInScene = new List<Character>();

    // Room management
    public List<Room> rooms = new List<Room>();
    public int minutes;
    public int hours;
    
    void Awake()
    {
        instance = this;

        // Set Time
        hours = 9;
        minutes = 0;

        // Create the characters
        while (characters.Count < 12)
        {
            // Create a new character
            Character character = new Character();
            characters.Add(character);

            // Gender
            character.gender = ChooseFrom(new DataClass("male", 45), new DataClass("female", 45), new DataClass("other", 10));

            // Pronouns
            if (character.gender == "male")
            {
                character.pronouns.Add("He"); // 0
                character.pronouns.Add("Him"); // 1
                character.pronouns.Add("His"); // 2
                character.pronouns.Add("His"); // 3
                character.pronouns.Add("Himself"); // 4
                character.pronouns.Add("Is"); // 5
                character.pronouns.Add("Mr. "); // 6
                character.pronouns.Add("Man"); // 7
                character.pronouns.Add("Was"); // 8
            }
            else if (character.gender == "female")
            {
                character.pronouns.Add("She"); // 0
                character.pronouns.Add("Her"); // 1
                character.pronouns.Add("Her"); // 2
                character.pronouns.Add("Hers"); // 3
                character.pronouns.Add("Herself"); // 4
                character.pronouns.Add("Is"); // 5
                character.pronouns.Add("Ms. "); // 6
                character.pronouns.Add("Woman"); // 7
                character.pronouns.Add("Was"); // 8
            }
            else if (character.gender == "other")
            {
                character.pronouns.Add("They"); // 0
                character.pronouns.Add("Them"); // 1
                character.pronouns.Add("Their"); // 2
                character.pronouns.Add("Theirs"); // 3
                character.pronouns.Add("Themself"); // 4
                character.pronouns.Add("Are"); // 5
                character.pronouns.Add("Mx. "); // 6
                character.pronouns.Add("Person"); // 7
                character.pronouns.Add("Were"); // 8
            }

            // Country
            character.country = ChooseFrom(new DataClass("United States", 60), new DataClass("Canada", 20), new DataClass("Mexico", 5), new DataClass("Argentina", 5), new DataClass("Cuba", 5), new DataClass("Singapore", 5));

            // City and State
            if (character.country == "United States")
            {
                character.city = ChooseFrom("New York, NY", "Brooklyn, NY", "Queens, NY", "The Bronx, NY", "Staten Island, NY", "Los Angeles, CA", "Chicago, IL", "Seattle, WA", "Portland, OR", "Charlotte, NC", "Burlington, VT", "Virginia Beach, VA", "Las Vegas, NV", "Madison, WI", "Green Bay, WI", "Oklahoma City, OK", "Charleston, WV", "Charleston, SC", "Iowa City, IA", "Des Moines, IA", "San Jose, TX", "Oakland, CA", "Evanston, IL", "Wichita, KS", "Louisville, KY", "Topeka, KS", "San Francisco, CA", "San Antonio, TX", "Jacksonville, FL", "Memphis, TN", "Nashville, TN", "Raleigh, NC", "Richmond, VA", "Baltimore, MD", "Jackson, MS", "Manchester, NH", "Newark, NJ", "Jersey City, NJ", "Buffalo, NY", "Little Rock, AR", "Sioux Falls, SD", "Boise, ID", "Billings, MT", "Cheyenne, WY", "Birmingham, AL", "Houston, TX", "Dallas, TX", "Albuquerque, NM", "Austin, TX", "Milwaukee, WI", "Minneapolis, MN", "St. Paul, MN", "Duluth, MN", "Columbus, OH", "Dayton, OH", "Cleveland, OH", "Indianapolis, IN", "Fort Wayne, IN", "Kansas City, MO", "St. Louis, MO", "Miami, FL", "Boston, MA", "Providence, RI", "Phoenix, AZ", "Denver, CO", "Salt Lake City, UT", "Omaha, NE", "Fargo, ND", "Philadelphia, PA", "Pittsburgh, PA", "Cincinnati, OH", "San Diego, CA", "Honolulu, HI", "Anchorage, AK", "Detroit, MI", "New Orleans, LA", "Washington D.C.", "Atlanta, GA", "Tampa, FL", "Orlando, FL");
            }
            else if (character.country == "Canada")
            {
                character.city = ChooseFrom("Toronto, ON", "Montreal, QC", "Vancouver, BC", "Calgary, AB", "Edmonton, AB", "Ottawa, ON", "Quebec City, QC", "Winnipeg, MB", "Saskatoon, SK", "Regina, SK", "Victoria, BC", "Thunder Bay, ON", "Mississauga, ON", "London, ON", "Windsor, ON", "Halifax, NS", "St. John's, NL", "Yellowknife, NT", "Whitehorse, YT", "Iqaluit, NU");
            }
            else if (character.country == "Mexico")
            {
                character.city = ChooseFrom("Mexico City, CDMX", "Guadalajara, JAL.", "Puebla, PUE.", "Juarez, CHIH", "Tijuana, B.C.", "Cancun, Q.R.", "Chihuahua, CHIH");
            }
            else if (character.country == "Argentina")
            {
                character.city = ChooseFrom("Buenos Aires", "Cordoba", "Rosario", "La Plata");
            }
            else if (character.country == "Cuba")
            {
                character.city = ChooseFrom("Havana", "Santiago de Cuba", "Camagüey");
            }
            else if (character.country == "China")
            {
                character.city = ChooseFrom("Beijing", "Shanghai", "Chongqing", "Shenzen", "Tianjing", "Guangzhou", "Wuhan", "Nanjing", "Chengdu", "Harbin", "Xi'an", "Hangzhou");
            }

            if (character.city != null && character.city != "Washington D.C." && (character.city[character.city.Length - 3] == ' ' && character.city[character.city.Length - 5] == ' '))
            {
                character.state = character.city.Substring(character.city.Length - 2, 2);
                character.city = character.city.Substring(0, character.city.Length - 4);
            }

            if (character.state != null)
            {
                character.cityAndState = character.city + ", " + character.state;
            }
            else
            {
                character.cityAndState = character.city;
            }

            if (character.city != null)
            {
                character.location = character.cityAndState + ", " + character.country;
            }
            else
            {
                character.location = character.country;
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
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 50), new DataClass("latino", 0), new DataClass("black", 0), new DataClass("east asian", 4), new DataClass("south asian", 3), new DataClass("middle eastern", 3), new DataClass("native american", 33), new DataClass("pacific islander", 0), new DataClass("inuit", 7));
                }
                else
                {
                    character.ethnicGroup = ChooseFrom(new DataClass("white", 56), new DataClass("latino", 1), new DataClass("black", 5), new DataClass("east asian", 11), new DataClass("south asian", 13), new DataClass("middle eastern", 9), new DataClass("native american", 5), new DataClass("pacific islander", 0));
                }
            }
            else if (character.country == "Mexico")
            {
                character.ethnicGroup = ChooseFrom("latino", new DataClass("white", 25), new DataClass("black", 5), new DataClass("east asian", 1), new DataClass("native american", 25));
            }
            else if (character.country == "Argentina" || character.country == "Cuba")
            {
                character.ethnicGroup = ChooseFrom("latino", new DataClass("white", 50), new DataClass("black", 1), new DataClass("east asian", 1), new DataClass("native american", 3));
            }
            else if (character.country == "Singapore")
            {
                character.ethnicGroup = ChooseFrom(new DataClass("east asian", 87), new DataClass("south asian", 13), 2);
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
            if (character.ethnicGroup.Contains("white") || character.ethnicGroup.Contains("native american"))
            {
                character.lastName = ChooseFrom("Williams", "Johnson", "Smith", "Jones", "Brown", "Jackson", "Davis", "Thomas", "Harris", "Robinson", "Taylor", "Wilson", "Moore", "White", "Lewis", "Walker", "Green", "Washington", "Thompson", "Anderson", "Scott", "Carter", "Graves", "George", "Sanders", "McKenzie", "McNulty", "Nutt", "Shoemacher", "Weinstein", "Goldstein", "Blick", "Kingston", "Quentin", "Belle");
            }
            else if (character.ethnicGroup.Contains("black"))
            {
                character.lastName = ChooseFrom("Williams", "Johnson", "Smith", "Jones", "Brown", "Jackson", "Davis", "Thomas", "Harris", "Robinson", "Taylor", "Wilson", "Moore", "White", "Lewis", "Walker", "Green", "Washington", "Thompson", "Anderson", "Scott", "Carter");
            }
            else if (character.ethnicGroup.Contains("latino"))
            {
                character.lastName = ChooseFrom("Hernández", "García", "Martínez", "González", "Rodríguez", "Pérez", "Sánchez", "Ramírez", "Fernández", "Ruiz", "Gutiérrez");
            }
            else if (character.ethnicGroup.Contains("east asian"))
            {
                character.lastName = ChooseFrom("Wang", "Li", "Zhang", "Liu", "Chen", "Yang", "Huang", "Zhao", "Kim", "Lee", "Park", "Choi", "Jeong", "Sato", "Suzuki", "Takahashi", "Tanaka", "Watanabe", "Ito", "Yamamoto", "Nakamura", "Nguyen", "Huynh", "Dang");
            }
            else if (character.ethnicGroup.Contains("south asian"))
            {
                character.lastName = ChooseFrom("Kumar", "Sharma", "Shan", "Khan", "Patel", "Laghari", "Arya", "Bhatt", "Varma", "Chawla", "Lal", "Mangal", "Kohli", "Molhotra", "Jain", "Khanna", "Ghosh", "Dhar");
            }
            else if (character.ethnicGroup.Contains("middle eastern"))
            {
                character.lastName = ChooseFrom("Ali", "Abdallah", "Ahmad", "Abadi", "Bakir", "Baghdadi", "Bilal", "Darwish", "Ebeid", "Fadel", "Faez", "Faheem", "Farhat", "Farouq", "Farsi", "Fasil", "Habib", "Hakim", "Hussein", "Ibrahim", "Iqbal", "Jameel", "Marwan", "Noor", "Taleb", "Sultan", "Wahed", "Yusuf", "Zaman");
            }
            else if (character.ethnicGroup.Contains("pacific islander"))
            {
                character.lastName = ChooseFrom("Kahale", "Mahoe", "'Opunui", "Kelekolio", "Ka'ana'ana", "Henare", "Ngata", "Parata", "Rewi", "Taumata", "Turei", "Williams", "Johnson", "Smith", "Jones", "Brown", "Jackson", "Davis", "Thomas", "Harris", "Robinson", "Taylor", "Wilson", "Moore");
            }
            else if (character.ethnicGroup.Contains("inuit"))
            {
                character.lastName = ChooseFrom("Aluq", "Alluluk", "Aleqasina", "Akimayuq", "Eyuka", "Inoudtliak", "Itakulla", "Iqirquq", "Kablutsiak", "Kaitanak", "Mupaloo", "Nakyuraq", "Naqi", "Ooa", "Pitseolak");
            }

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
                character.firstName + " is from " + character.location + ". " +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.ethnicGroup + " and " + character.pronouns[2].ToLower() + " occupation is a" + character.occupation + ". " +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.age + "-years-old and " + character.pronouns[5].ToLower() + " " + character.height + "cm/" + character.heightFeetAndInches + " tall.\n" +
                character.pronouns[0] + " " + character.pronouns[5].ToLower() + " " + character.friendlinessDescription + ", " + character.irritabilityDescription + ", " + character.flirtinessDescription + ", " + character.humourDescription + ", and " + character.emotionalnessDescription + "."
                );
        }

        while (rooms.Count < 23)
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
            else if (rooms.Count == 18)
            {
                room.name = "Bar";
            }
            else if (rooms.Count == 19)
            {
                room.name = "Deck";
            }
            else if (rooms.Count == 20)
            {
                room.name = "Sauna";
            }
            else if (rooms.Count == 21)
            {
                room.name = "Engine Room";
            }
            else if (rooms.Count == 22)
            {
                room.name = "Staff Quarters";
            }
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

    public void GetCharacter(int index)
    {
        // Load character
        //GameObject prefab = Resources.Load ("Prefabs/Char[" + index + "]" as GameObject);
        //Instantiate(prefab);
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

    // Choose from any argument randomly
    public string ChooseFrom(params string[] things)
    {
        return things[Random.Range(0, things.Length)];
    }

    // Choose the first argument mixed with any subsequent argument randomly
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

    // Choose from any argument at a specific percentage
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

    // Choose either of the two arguments with a possibility of mixing both at a specific percentage
    public string ChooseFrom(DataClass option1, DataClass option2, int percentage)
    {
        // Choose a random number to determine what is selected
        int selectedNumber = Random.Range(0, 99);

        // Determine whether to mix the two options or choose one separately
        if (selectedNumber < percentage)
        {
            return option1.word + "/" + option2.word;
        }
        else
        {
            if (PercentChance(option1.percentage - 1))
            {
                return option1.word;
            }
            else
            {
                return option2.word;
            }
        }
    }

    public string ChooseFrom(int white, int latino, int black, Vector4 eastAsianCJKM, Vector4 southeastAsianVTCB, Vector3 southAsianIPTam)
    {
        return "";
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
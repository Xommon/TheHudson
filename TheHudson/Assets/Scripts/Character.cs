using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    // Physical Characteristics
    public string gender;
    public List<string> pronouns = new List<string>();
    public string country;
    public string city;
    public string state;
    public string ethnicGroup;
    public string ethnicGroup2;
    public string ethnicity;
    public string firstName;
    public string lastName;
    public int age;
    public int height;
    public string heightFeetAndInches;
    public string occupation;
    public string nonProfitName;

    // Personality
    [Range(0f, 1f)]
    public int friendlinessMax;
    [Range(0f, 1f)]
    public int irritabilityMax;
    [Range(0f, 1f)]
    public int humourMax;
    [Range(0f, 1f)]
    public int flirtinessMax;
    [Range(0f, 1f)]
    public int emotionalnessMax;

    public string friendlinessDescription;
    public string irritabilityDescription;
    public string humourDescription;
    public string flirtinessDescription;
    public string emotionalnessDescription;

    public int friendliness;
    public int irritability;
    public int humour;
    public int flirtiness;
    public int emotionalness;
}

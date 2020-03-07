using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    // References
    GameManager gameManager;

    // Room variables
    public string name;
    public Character owner;
    public int floor;
    public List<Character> charactersInRoom = new List<Character>();

    public void EnterRoom(Character character)
    {
        charactersInRoom.Add(character);
    }

    public void EnterRoom(int index)
    {
        charactersInRoom.Add(gameManager.characters[index]);
    }

    public void ExitRoom(Character character)
    {
        charactersInRoom.Remove(character);
    }

    public void ExitRoom(int index)
    {
        charactersInRoom.Remove(gameManager.characters[index]);
    }

    public string GetRoomName()
    {
        return name;
    }
}

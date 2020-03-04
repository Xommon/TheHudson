using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    DialogueSystem dialogue;
    public GameManager gameManager;
    public string testName;
    public List<string> s = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;

        s.Add("Welcome all to this VERY exlusive sponsorship event!");
        s.Add("I've gathered the greatest and most exceptional hard workers from around the world for a chance at a sizeable donation for their nonprofit organization! |false");
        s.Add("Let's go ahead and introduce everyone! |false");
        for (int i = 0; i < 12; i++)
        {
            s.Add(gameManager.characters[i].pronouns[6] + gameManager.characters[i].firstName + " " + gameManager.characters[i].lastName + ", from " + gameManager.characters[i].location + ".|false");
        }
        s.Add("And last, but not least, Mx. Player from Country!");

        if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
        {
            if (index >= s.Count)
            {
                return;
            }

            Say(s[index], true, "Sponsor");
            index++;
        }
    }

    /*string[] s = new string[]
    {
        "Hmm ... ",
        "how did you sleep ... ",
        "last night ... ",
        "ahgaghahfdhadhf",
    };*/

    int index = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
            {
                if (index >= s.Count)
                {
                    return;
                }

                Say(s[index], false, "Sponsor");
                index++;
            }
        }
    }

    void Say(string s, bool additive, string speaker)
    {
        string[] parts = s.Split('|');
        string speech = parts[0];
        /*if (speaker == "")
        {
            speaker = (parts.Length >= 2) ? parts[1] : "";
        }*/
        if (((parts.Length >= 2) ? parts[1] : "") == "true")
        {
            additive = true;
        }
        else if (((parts.Length >= 2) ? parts[1] : "") == "false")
        {
            additive = false;
        }

        dialogue.Say(speech, additive, speaker);
    }
}

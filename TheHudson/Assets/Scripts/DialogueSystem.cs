using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;
    public ELEMENTS elements;

    private void Awake()
    {
        instance = this;
    }

    // Say something and show it on the speech bar.
    public void Say(string speech, bool additive = false, string speaker = "")
    {
        StopSpeaking();
        speaking = StartCoroutine(Speaking(speech, additive, speaker));
    }

    // Say something to be added to what is already on the screen
    public void SayAdd(string speech, bool additive = false, string speaker = "")
    {
        StopSpeaking();
        speechText.text = targetSpeech;
        speaking = StartCoroutine(Speaking(speech, additive, speaker));
    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }

    public bool isSpeaking { get { return speaking != null; } }
    [HideInInspector]public bool isWaitingForUserInput = false;

    string targetSpeech = "";
    Coroutine speaking = null;
    IEnumerator Speaking(string speech, bool additive, string speaker = "")
    {
        speechPanel.SetActive(true);
        targetSpeech = speech;
        if (!additive)
        {
            speechText.text = "";
        }
        else
        {
            targetSpeech = speechText.text + targetSpeech;
        }
        speakerNameText.text = DetermineSpeaker(speaker); // Temporary
        isWaitingForUserInput = false;

        while(speechText.text != targetSpeech)
        {
            speechText.text += targetSpeech[speechText.text.Length];
            yield return new WaitForEndOfFrame();
        }

        // Text finished
        isWaitingForUserInput = true;
        while(isWaitingForUserInput)
        {
            yield return new WaitForEndOfFrame();
        }

        StopSpeaking();
    }

    string DetermineSpeaker(string s)
    {
        string retVal = speakerNameText.text;
        if (s != speakerNameText.text && s != "")
        {
            retVal = (s.ToLower().Contains("narrator")) ? "" : s;
        }

        return retVal;
    }

    [System.Serializable]
    public class ELEMENTS
    {
        // The main panel containing all dialogue related elements on the UI.
        public GameObject speechPanel;
        public TMP_Text speakerNameText;
        public TMP_Text speechText;
    }

    public GameObject speechPanel {get{return elements.speechPanel;}}
    public TMP_Text speakerNameText { get { return elements.speakerNameText;}}
    public TMP_Text speechText { get { return elements.speechText;}}
}

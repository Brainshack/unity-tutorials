﻿using TMPro;
using Tutorials.Dialog_System.Part_1.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogWindow : MonoBehaviour
{
    public TMP_Text dialogText;

    public Button Option1Button;
    public Button Option2Button;
    public Button Option3Button;
    public Button Option4Button;

    public DialogSegment Segment;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateDialog(Segment);   
    }

    private void UpdateDialog(DialogSegment newSegment)
    {
        dialogText.text = newSegment.DialogText;
        Option1Button.GetComponentInChildren<Text>().text = newSegment.Answer1;
        Option2Button.GetComponentInChildren<Text>().text = newSegment.Answer2;
        Option3Button.GetComponentInChildren<Text>().text = newSegment.Answer3;
        Option4Button.GetComponentInChildren<Text>().text = newSegment.Answer4;
    }
}

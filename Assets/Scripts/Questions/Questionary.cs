using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Questionary 
{
    [SerializeField]
    public Question[] Questions = new Question[10];
    public int current_question = 0;
    public bool Answered = false;
    public bool Displayed = false;
}

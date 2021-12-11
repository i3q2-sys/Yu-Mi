using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Question 
{
    [SerializeField]
    public string QuestionString;
    [SerializeField]
    public string[] ArrayOfAnswers = new string[4];

}

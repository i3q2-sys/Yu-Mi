using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum State {Questionary, Cinematic , Idle}
public class Orchestrator : MonoBehaviour
{
    [SerializeField]

    public GameObject UI;
    public TextMeshProUGUI Question;
    public TextMeshProUGUI[] Answers = new TextMeshProUGUI[4];


    public Questionary PlayerPersonalityTest;
    private State CurrenState = State.Cinematic;
    private Questionary CurrenQuestionary;

    Animator An;

    private int[] PersonalityResponses = new int[7];
    private int[] EmotionalResponses = new int[7];


    public void Start()
    {
        An = gameObject.GetComponent<Animator>();
        PlayPersonalityTest();
    }


    public void Update()
    {
        
    }

    public void PlayPersonalityTest() 
    {
        UI.SetActive(true);
        CurrenQuestionary = PlayerPersonalityTest;
        CurrenState = State.Questionary;
        An.SetTrigger("Answered");
    }

    public void SetNextQuestion()
    {

        if (CurrenQuestionary.current_question >= CurrenQuestionary.Questions.Length)
        {
            if (CurrenQuestionary == PlayerPersonalityTest)
            {

            }
            else
            {

            }
        }

        Question.text = CurrenQuestionary.Questions[CurrenQuestionary.current_question].QuestionString;
        for (int i = 0; i < 4; i++)
        {
            Answers[i].text = CurrenQuestionary.Questions[CurrenQuestionary.current_question].ArrayOfAnswers[i];
        }
        

        
    }


    public void QuestionAnswered(int response) 
    {
        if (CurrenQuestionary == PlayerPersonalityTest)
        {
            PersonalityResponses[CurrenQuestionary.current_question] = response;
        }
        else 
        {
            EmotionalResponses[CurrenQuestionary.current_question] = response;
        }
        An.SetTrigger("Answered");
        CurrenQuestionary.current_question++;

    }
   
}

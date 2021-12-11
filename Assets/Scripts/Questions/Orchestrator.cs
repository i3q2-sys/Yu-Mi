using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

enum State {Questionary, Cinematic , Idle}
public class Orchestrator : MonoBehaviour
{
    [SerializeField]

    public GameObject YuMi;
    public SceneManager SM;
    public GameObject UI;
    public TextMeshProUGUI Question;
    public TextMeshProUGUI[] Answers = new TextMeshProUGUI[4];


    public PlayableDirector[] Timeline;
    public float[] TimelineDuration;

    public Questionary PlayerPersonalityTest;
    private State CurrenState = State.Cinematic;
    private Questionary CurrenQuestionary;

    Animator An;

    private int[] PersonalityResponses = new int[7];
    private int[] EmotionalResponses = new int[10];


    public void Start()
    {
        An = gameObject.GetComponent<Animator>();
        PlayPersonalityTest();
    }


    public void Update()
    {
        
    }


    public void PlayWelcomeCinematic() 
    {
        SM.CanInput = false;
        CurrenState = State.Cinematic;
        Timeline[0].Play();
        StartCoroutine(Countdown(TimelineDuration[0]));


    }


    public void PlayPersonalityTest() 
    {
        SM.CanInput = false;
        UI.SetActive(true);
        CurrenQuestionary = PlayerPersonalityTest;
        CurrenState = State.Questionary;
        An.SetTrigger("Questionary");
        An.SetTrigger("Answered");
    }

    public void SetNextQuestion()
    {

        if (CurrenQuestionary.current_question >= CurrenQuestionary.Questions.Length)
        {
            if (CurrenQuestionary == PlayerPersonalityTest)
            {
                YuMi.GetComponent<YuMi>().inicialitzar(PersonalityResponses, 0);
            }
            else
            {
                YuMi.GetComponent<YuMi>().inicialitzar(EmotionalResponses, 1);
            }
            CurrenQuestionary = null;
            CurrenState = State.Idle;
            UI.SetActive(false);
            SM.CanInput = true;
            An.SetTrigger("FinishedQuestionary");
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


    private IEnumerator Countdown(float time)
    {
        
        yield return new WaitForSeconds(time);
        CurrenState = State.Idle;
        
    }

}

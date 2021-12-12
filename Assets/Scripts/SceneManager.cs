using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject C;
    private Animator An;
    public bool CanInput = false;

    public GameObject MeditationAnimation;
    public GameObject MeditationYuMi;
    public GameObject MainYuMi;

    public GameObject MainButtons;
    public GameObject MeditationButtons;
    public GameObject HPbuttons;
    public GameObject GameButons;


    // Start is called before the first frame update
    void Start()
    {
        gameManager.SetActive(false);
        An = C.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanInput)ManageInput();
    }

    public void GoToMainScene() 
    {
        MeditationAnimation.SetActive(false);
        MeditationYuMi.SetActive(false);
        gameManager.SetActive(false);
        MainYuMi.SetActive(true);
        HPbuttons.SetActive(false);
        GameButons.SetActive(false);
        MeditationButtons.SetActive(false);
        MainButtons.SetActive(true);
        An.SetTrigger("Main");
    }

    public void GoToMeditation() 
    {
        MeditationAnimation.SetActive(true);
        MeditationYuMi.SetActive(true);
        gameManager.SetActive(false);
        MainYuMi.SetActive(false);
        MainButtons.SetActive(false);
        MeditationButtons.SetActive(true);
        An.SetTrigger("Meditation");

    }

    public void GoToHappyWall() 
    {
        gameManager.SetActive(false);
        HPbuttons.SetActive(true);
        MainButtons.SetActive(false);
        MainYuMi.SetActive(false);
        An.SetTrigger("HappyWall");

    }

    public void GoToGame() 
    {
        GameButons.SetActive(true);
        MainButtons.SetActive(false);
        gameManager.SetActive(true);
        MainYuMi.SetActive(false);
        An.SetTrigger("Game");

    }

    public void Rant() 
    {
       // gameManager.SetActive(false);
       // MainYuMi.SetActive(false);
        An.SetTrigger("Rant");

    }

    public void  ManageInput() 
    {


        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(0).position));
            if (hit.collider)
            {

                if (hit.collider.CompareTag("HappyWall"))
                {
                    GoToHappyWall();
                }
                else if (hit.collider.CompareTag("Game"))
                {
                    GoToGame();
                }
                else if (hit.collider.CompareTag("Meditation"))
                {
                    GoToMeditation();
                }
                else if (hit.collider.CompareTag("Main"))
                {
                    GoToMainScene();
                }
                else if (hit.collider.CompareTag("AddPhoto"))
                {
                    FindObjectOfType<HappyWall>().OpenUI();
                }
                else if (hit.collider.CompareTag("Meditate"))
                {
                    FindObjectOfType<Orchestrator>().PlayMeditation();
                }
                else if (hit.collider.CompareTag("Sound"))
                {
                    Debug.Log("Music");
                    FindObjectOfType<MusicManager>().Music();
                }

                
            }
        }
    }
}

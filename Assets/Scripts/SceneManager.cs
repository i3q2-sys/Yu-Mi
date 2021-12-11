using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject C;
    private Animator An;
    public bool CanInput = false;

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
        gameManager.SetActive(false);
        An.SetTrigger("Main");
        Debug.Log("Main");
    }

    public void GoToMeditation() 
    {
        gameManager.SetActive(false);
        An.SetTrigger("Meditation");
        Debug.Log("Meditation");

    }

    public void GoToHappyWall() 
    {
        gameManager.SetActive(false);
        An.SetTrigger("HappyWall");
        Debug.Log("HappyWall");

    }

    public void GoToGame() 
    {
        gameManager.SetActive(true);
        An.SetTrigger("Game");
        Debug.Log("Game");

    }

    public void Rant() 
    {
        gameManager.SetActive(false);
        An.SetTrigger("Rant");
        Debug.Log("Rant");

    }

    public void  ManageInput() 
    {


        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Debug.Log("Touch");
            Vector2 test = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D hit = Physics2D.Raycast(test, (Input.GetTouch(0).position));
            if (hit.collider)
            {
                Debug.Log("Something Hit");

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
            }
        }
    }
}

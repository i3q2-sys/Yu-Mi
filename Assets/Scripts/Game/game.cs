using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    private const int height = 11;
    private const float blocksize = 1f;
    public GameObject log;
    private troncScript[] tree;
    // Start is called before the first frame update

    private troncScript untronc(int alt)
    {
        troncScript tronc = Instantiate(log).GetComponent<troncScript>();
        tronc.transform.position = log.transform.position + new Vector3(0, alt * blocksize, 0);
        tronc.yTarget = log.transform.position.y + alt * blocksize;
        return tronc;
    }
    void Start()
    {
        tree = new troncScript[height];
        for (int i = 0; i < height; i++) tree[i]=untronc(i);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 coord = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            bool b = Input.GetKeyDown(KeyCode.A) || coord.x < -10.5;
            bool c = Input.GetKeyDown(KeyCode.D) || coord.x > -10.5;
            if (b || c)
            {
                if (c) tree[0].kicked = 1;
                if (b) tree[0].kicked = -1;
                for (int i = 1; i < height; i++)
                {
                    tree[i].yTarget -= blocksize;
                    tree[i - 1] = tree[i];

                }
                tree[height - 1] = untronc(height - 1);
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    private const int height = 11;
    private const float blocksize = 0.5f;
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
        bool b = Input.GetKeyDown(KeyCode.A);
        bool c = Input.GetKeyDown(KeyCode.D);
        bool a = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        if (b || c || a)
        {

            if (c) tree[0].kicked = 1;
            if (b) tree[0].kicked = -1;
            for (int i = 1; i<height;i++)
            {
                tree[i].yTarget -= blocksize;
                tree[i - 1] = tree[i];
               
            }
            tree[height-1] = untronc(height - 1);
        }
        
    }
}

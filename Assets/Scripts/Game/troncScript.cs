using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troncScript : MonoBehaviour
{

    public float yTarget;
    public int kicked=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (kicked == 0)
        {
            float yOffset = transform.position.y - yTarget;
            if (yOffset > 0)
            {
                float sped = Time.deltaTime * 10 * yOffset * yOffset * yOffset;
                if (yOffset > sped) transform.position -= new Vector3(0, sped, 0);
                else transform.position -= new Vector3(0, yOffset, 0);
            }
        }
        else
        {
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -Time.deltaTime * kicked * 200);
            transform.position += new Vector3(Time.deltaTime*kicked*10, 0, 0);
            if (transform.position.x >= 0 || transform.position.x < -10)
            {
                Destroy(gameObject);
            } 
        }
    }
}

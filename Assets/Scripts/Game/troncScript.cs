using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troncScript : MonoBehaviour
{
    public int kid = 0;
    public float yTarget;
    public int kicked=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool kick(bool right) {
        if (right) kicked = 1;
        else kicked = -1;
        if ((right && kid == 1) || (!right && kid == -1)) return true;
        return false;
    }

    public void generateChild() {
        if (Random.Range(0.0f, 5.0f) > 4.0f)
        {
            GameObject c = Instantiate(gameObject);
            c.transform.parent = gameObject.transform;
            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                kid = 1;
                c.transform.position += new Vector3(1.6f, 0, 0);
            }
            else
            {
                kid = -1;
                c.transform.position -= new Vector3(1.6f, 0, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {


        if (kicked == 0)
        {
            float yOffset = transform.position.y - yTarget;
            if (yOffset > 0)
            {
                float sped = 0.5f*Time.deltaTime + Time.deltaTime * 10 * yOffset * yOffset * yOffset;
                if (yOffset > sped) transform.position -= new Vector3(0, sped, 0);
                else transform.position -= new Vector3(0, yOffset, 0);
            }
        }
        else
        {
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -Time.deltaTime * kicked * 200);
            transform.position += new Vector3(Time.deltaTime*kicked*10, 0, 0);
            if (transform.position.x >= -5 || transform.position.x < -15)
            {
                Destroy(gameObject);
            } 
        }
    }
}

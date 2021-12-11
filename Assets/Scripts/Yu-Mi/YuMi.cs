using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct personalitat {

    public int extrovertit, dependent, irascible, tranquil, vergonnyos;
    public personalitat(int e, int d, int i, int t, int v)
    {
        extrovertit = e;
        dependent = d;
        irascible = i;
        tranquil = t;
        vergonnyos = v;
    }

}
struct sAnim
{
    public int nerviosisme, tristesa, enfado;
    public sAnim(int n, int t, int e)
    {
        nerviosisme = n;
        tristesa = t;
        enfado = e;
    }
    public int max()
    {
        if (nerviosisme >= tristesa)
        {
            if (nerviosisme >= enfado) return nerviosisme;
            return enfado;
        }
        else
        {
            if (tristesa >= enfado) return tristesa;
            else return enfado;
        }
    }
}

public class YuMi : MonoBehaviour
{

    public Orchestrator orch;
    public SceneManager sceneManager;
    public GameObject algo;
    private personalitat perso = new personalitat(0,0,0,0,0);
    private sAnim emocions= new sAnim(0,0,0);
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void inicialitzar(int[] valorRes, int n)
    {
        if (emocions.nerviosisme == emocions.max()) sceneManager.GoToMeditation();

        else if (emocions.tristesa == emocions.max()) sceneManager.GoToHappyWall();

        else if (emocions.enfado == emocions.max())
        {
            int tot = perso.extrovertit + perso.dependent - perso.vergonnyos;
            if (tot >= 5) sceneManager.Rant();

            else sceneManager.GoToGame();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct personalitat {

    public int e, d, i, t, v;
    public personalitat(int extrovertit, int dependent, int irascible, int tranquil, int vergonyos)
    {
        e = extrovertit;
        d = dependent;
        i = irascible;
        t = tranquil;
        v = vergonyos;
    }

}
struct sAnim
{
    public int n, t, e;
    public sAnim(int nerviosisme, int tristesa, int enfado)
    {
        n = nerviosisme;
        t = tristesa;
        e = enfado;
    }
    public int max()
    {
        if (n >= t)
        {
            if (n >= e) return n;
            return e;
        }
        else
        {
            if (t >= e) return t;
            else return e;
        }
    }
}

public class YuMi : MonoBehaviour
{

    public Orchestrator orch;
    public SceneManager sceneManager;
    private personalitat perso = new personalitat(0,0,0,0,0);
    private sAnim emocions= new sAnim(0,0,0);
    
    // Start is called before the first frame update
    void Start()
    {

    }

    public void inicialitzar(int[] valorRes, int n)
    {

        if (n == 0)
        {
            int val;
            for (int i = 0; i < 7; ++i)
            {
                val = i * 4 + valorRes[i];
                switch (val)
                {
                    case 0: perso.e += 2; perso.d += 1; break;
                    case 1: perso.e += 1; perso.v += 1; break;
                    case 2: perso.e -= 1; break;
                    case 3: perso.e -= 2; perso.d += 1; break;
                    case 4: perso.t += 1; perso.d -= 1; break;
                    case 5: perso.t -= 2; perso.e += 1; break;
                    case 6: perso.e -= 1; perso.v -= 1; break;
                    case 7: perso.e -= 1; perso.d += 1; break;
                    case 8: perso.t += 2; break;
                    case 9: perso.i += 3; perso.t -= 2; break;
                    case 10: perso.t -= 2; break;
                    case 11: perso.v += 1; perso.i -= 2; perso.t += 1; break;
                    case 12: perso.e += 1; perso.v += 1; break;
                    case 13: perso.e += 2; perso.v -= 1; break;
                    case 14: perso.e -= 1; perso.d += 2; perso.v += 1; break;
                    case 15: perso.v += 1; perso.d += 1; break;
                    case 16: perso.d += 2; break;
                    case 17: perso.t += 2; break;
                    case 18: perso.t += 1; perso.i -= 1; perso.t += 1; break;
                    case 19: perso.d += 2; perso.i -= 1; perso.t += 1; break;
                    case 20: perso.t += 2; perso.d -= 1; perso.e += 1; break;
                    case 21: perso.d += 3; break;
                    case 22: perso.d += 1; perso.e -= 1; break;
                    case 23: perso.e -= 2; break;
                    case 24: perso.t -= 2; perso.e -= 2; break;
                    case 25: break;
                    case 26: perso.e += 2; break;
                    case 27: perso.e += 1; perso.t -= 1; break;
                    default: break;
                }
            }

           // if (emocions.nerviosisme == emocions.max()) sceneManager.GoToMeditation();

           // else if (emocions.tristesa == emocions.max()) sceneManager.GoToHappyWall();

            /*else if (emocions.e == emocions.max())
            {
                int tot = perso.e + perso.d - perso.v;
                if (tot >= 5) sceneManager.Rant();

                //else sceneManager.GoToGame();
            }*/
        }
        else if (n == 1)
        {
            int val;
            for (int i = 0; i < 5; ++i)
            {
                val = i * 4 + valorRes[i];
                switch (val)
                {
                    case 0: break;
                    case 1: emocions.n += 1; break;
                    case 2: emocions.t += 1; break;
                    case 3: emocions.e += 1; break;
                    case 4: emocions.n += 2; break;
                    case 5: emocions.t += 1;  break;
                    case 6: break;
                    case 7: break;
                    case 8: emocions.t += 2; break;
                    case 9: emocions.n += 1; break;
                    case 10: emocions.e += 1; break;
                    case 11: break;
                    case 12: emocions.e += 2; break;
                    case 13: emocions.t += 1; break;
                    case 14: emocions.n += 1; break;
                    case 15: break;
                    case 16: break;
                    case 17: emocions.t += 1; break;
                    case 18: emocions.n += 1; break;
                    case 19: emocions.e += 2; break;
                    default: break;
                }
            }
        }
        orch.PlayWelcomeCinematic();


    }

    // Update is called once per frame
    void Update()
    {
        
    }



}

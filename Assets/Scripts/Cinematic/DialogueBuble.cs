using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBuble : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool FacingLeft = true;


    public void SetText(string Text)
    {
        text.text = Text;
    }

    public void SetPosition(Vector2 position)
    {
        gameObject.GetComponent<RectTransform>().localPosition = position;
    }

    public void SetFacingLeft(bool left)
    {
        if (left && !FacingLeft)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            text.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            FacingLeft = true;
            Debug.Log("Here");
        }
        if (!left && FacingLeft)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
            text.gameObject.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
            FacingLeft = false;

        }

    }

    public void SetTransparency(float alpha)
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
    }
}
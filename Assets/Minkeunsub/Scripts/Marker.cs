using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    States thisState;
    [SerializeField] Image MarkerImg;
    [SerializeField] Image Icon;
    InGameCanvas canvas;

    Animator anime;


    public void SetImage(Sprite _marker, Sprite _icon, InGameCanvas _canvas)
    {
        anime = GetComponent<Animator>();
        anime.SetBool("On", true);
        MarkerImg.sprite = _marker;
        Icon.sprite = _icon;
        canvas = _canvas;
    }

    public void ButtonClick()
    {
        switch (thisState)
        {
            case States.ENVIRONMENT:
                break;
            case States.HAPPINESS:
                break;
            case States.POPULATION:
                break;
            case States.RESOURCES:
                break;
            default:
                break;
        }
        anime.SetBool("Off", true);
    }

    public void OnEnd()
    {
        anime.SetBool("On", false);
        anime.SetBool("Off", false);
    }

    public void Push()
    {
        canvas.Push(this);
        OnEnd();
    }
}

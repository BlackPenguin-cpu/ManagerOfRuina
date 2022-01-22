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

    public void SetImage(Sprite _marker, Sprite _icon, InGameCanvas _canvas)
    {
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
        canvas.Push(this);
    }
}

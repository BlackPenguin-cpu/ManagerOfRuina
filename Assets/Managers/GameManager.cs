using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Values
{
    public int Human;
    public int Happy;
    public int Environmet;
    public int Mineral;
}
public class GameManager : Singleton<GameManager>
{
    public Values Status;
    public Values addStatusMaxValue;
    public Values addStatusMinValue;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickedBallon(BallonType type)
    {
        switch (type)
        {
            case BallonType.HUMAN:
                Status.Human += Random.Range(addStatusMinValue.Human,addStatusMaxValue.Human);
                break;
            case BallonType.HAPPY:
                Status.Happy += Random.Range(addStatusMinValue.Happy,addStatusMaxValue.Happy);
                break;
            case BallonType.ENVIRONMENT:
                Status.Environmet += Random.Range(addStatusMinValue.Environmet,addStatusMaxValue.Environmet);
                break;
            case BallonType.MINERAL:
                Status.Mineral += Random.Range(addStatusMinValue.Mineral,addStatusMaxValue.Mineral);
                break;
            default:
                break;
        }
    }
}

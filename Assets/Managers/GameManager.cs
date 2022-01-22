using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Values
{
    public int Human;
    public int Happy;
    public int Environmet;
    public int Mineral;
}
public class GameManager : Singleton<GameManager>
{
    [Header("메인 스테이터스")]
    public Values Status;
    
    [Header("Ballon 관련")]
    public Values addStatusMaxValue;
    public Values addStatusMinValue;
    public float BallonCooltime;
    private float nowBallonCooltime;

    [Header("음양게이지")]
    public int MainGauge;

    [Header("MP 관련")]
    public int MPMax;
    public int MP;
    public int MpRegenrateValue;
    private float nowMpRegenrateValue
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

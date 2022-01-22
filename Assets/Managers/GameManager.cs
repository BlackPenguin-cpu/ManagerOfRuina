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
    [Header("���� �������ͽ�")]
    public Values Status;
    [SerializeField] private List<Slider> StatusGague;
    
    [Header("Ballon ����")]
    public Values addStatusMaxValue;
    public Values addStatusMinValue;
    public float BallonCooltime;
    private float nowBallonCooltime;

    [Header("���������")]
    public int MainGauge;
    [SerializeField] private Slider MainGague;

    [Header("MP ����")]
    public int MPMax;
    public int MP;
    public int MpRegenrateValue;
    private float nowMpRegenrateCooldown;
    [SerializeField] private Slider MpGague;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GaugePrint();
        MpIncrease();
    }
    void GaugePrint()
    {
        //Status Value
        StatusGague[0].value = status
    }

    void MpIncrease()
    {
        if(nowMpRegenrateCooldown > 1 && MPMax > MP)
        {
            MP += MpRegenrateValue;
        }
        nowMpRegenrateCooldown += Time.deltaTime;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Values
{
    public int Population;
    public int Happiness;
    public int Environment;
    public int Resources;
}
public class GameManager : Singleton<GameManager>
{
    [Header("Status Info")]
    public Values Status;
    [SerializeField] private List<Image> StatusGauge;
    
    [Header("Ballon Info")]
    public Values addStatusMaxValue;
    public Values addStatusMinValue;
    public float BallonCooltime;
    private float nowBallonCooltime;

    [Header("Duality Info")]
    public int MainValue;
    [SerializeField] private Image MainGauge;

    [Header("MP Info")]
    public int MPMax;
    public int MP;
    public int MpRegenrateValue;
    private float nowMpRegenrateCooldown;
    [SerializeField] private Image MpGauge;
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
        StatusGauge[0].fillAmount = (float)Status.Population / 100;
        StatusGauge[1].fillAmount = (float)Status.Happiness / 100;
        StatusGauge[2].fillAmount = (float)Status.Environment / 100;
        StatusGauge[3].fillAmount = (float)Status.Resources / 100;

        float All = Status.Environment + Status.Resources + Status.Happiness + Status.Population;
        MainGauge.fillAmount = All / 400;

        MpGauge.fillAmount = (float)MP / (float)MPMax;
    }

    void MpIncrease()
    {
        if(nowMpRegenrateCooldown > 1 && MPMax > MP)
        {
            MP += MpRegenrateValue;
        }
        nowMpRegenrateCooldown += Time.deltaTime;
    }
    public void ClickedBallon(States type)
    {
        switch (type)
        {
            case States.POPULATION:
                Status.Population += Random.Range(addStatusMinValue.Population,addStatusMaxValue.Population);
                break;
            case States.HAPPINESS:
                Status.Happiness += Random.Range(addStatusMinValue.Happiness,addStatusMaxValue.Happiness);
                break;
            case States.ENVIRONMENT:
                Status.Environment += Random.Range(addStatusMinValue.Environment,addStatusMaxValue.Environment);
                break;
            case States.RESOURCES:
                Status.Resources += Random.Range(addStatusMinValue.Resources,addStatusMaxValue.Resources);
                break;
            default:
                break;
        }
    }
}

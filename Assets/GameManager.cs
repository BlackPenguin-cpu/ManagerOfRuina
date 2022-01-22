using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct Values
{
    public int Population;
    public int Happiness;
    public int Resources;
    public int Environment;
}
public class GameManager : Singleton<GameManager>
{
    [Header("Status Info")]
    public Values Status;
    [SerializeField] private List<Image> StatusGauge;
    [SerializeField] private List<TextMeshProUGUI> Texts;

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
        SummonBubble();
        MpIncrease();
        GaugePrint();
        ValueChecker();
    }
    void GaugePrint()
    {
        //Status Value
        StatusGauge[0].fillAmount = (float)Status.Population / 100;
        StatusGauge[1].fillAmount = (float)Status.Happiness / 100;
        StatusGauge[2].fillAmount = (float)Status.Environment / 100;
        StatusGauge[3].fillAmount = (float)Status.Resources / 100;

        Texts[0].text = Status.Population + " / 100";
        Texts[1].text = Status.Happiness + " / 100";
        Texts[2].text = Status.Environment + " / 100";
        Texts[3].text = Status.Resources + " / 100";

        float All = Status.Environment + Status.Resources + Status.Happiness + Status.Population;
        MainGauge.fillAmount = All / 400;

        MpGauge.fillAmount = (float)MP / (float)MPMax;
    }
    void ValueChecker()
    {
        if (Status.Environment <= 0 || Status.Happiness <= 0 || Status.Population <= 0 || Status.Happiness <= 0)
        {
            GameOver();
        }
        if (Status.Environment > 100)
        {
            Status.Environment = 100;
        }
        if(Status.Happiness > 100)
        {
            Status.Happiness = 100;
        }
        if(Status.Environment > 100)
        {
            Status.Environment = 100;
        }
        if (Status.Resources > 100)
        {
            Status.Resources = 100;
        }
        if(400 == Status.Environment + Status.Resources + Status.Happiness + Status.Population)
        {
            GameWin();
        }
    }

    void SummonBubble()
    {
        if (BallonCooltime < nowBallonCooltime)
        {
            nowBallonCooltime = 0;
            InGameCanvas.Instance.Pop((States)Random.Range(0, 4));
        }
        nowBallonCooltime += Time.deltaTime;
    }
    void MpIncrease()
    {
        if (nowMpRegenrateCooldown > 1 && MPMax > MP)
        {
            nowMpRegenrateCooldown = 0;
            MP += MpRegenrateValue;
        }
        nowMpRegenrateCooldown += Time.deltaTime;
    }
    public void ClickedBallon(States type)
    {
        switch (type)
        {
            case States.POPULATION:
                Status.Population += Random.Range(addStatusMinValue.Population, addStatusMaxValue.Population);
                break;
            case States.HAPPINESS:
                Status.Happiness += Random.Range(addStatusMinValue.Happiness, addStatusMaxValue.Happiness);
                break;
            case States.ENVIRONMENT:
                Status.Environment += Random.Range(addStatusMinValue.Environment, addStatusMaxValue.Environment);
                break;
            case States.RESOURCES:
                Status.Resources += Random.Range(addStatusMinValue.Resources, addStatusMaxValue.Resources);
                break;
            default:
                break;
        }
    }
    public void GameOver()
    {
        Debug.Log("우린 망했어!");
        Time.timeScale = 0;
    }
    public void GameWin()
    {
        Debug.Log("우린 살았어!");
        Time.timeScale = 0;
    }
}

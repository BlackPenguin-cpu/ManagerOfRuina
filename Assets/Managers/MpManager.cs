using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MpManager : MonoBehaviour
{
    [SerializeField] Image SkillBar;
    [SerializeField] Image PowerBar;
    bool SkillBarOn;
    [SerializeField] Sprite[] Barsprites;
    bool PowerBarOn;

    int ManaLevelupCost = 100;
    int ManaLevelupLevel = 1;
    [SerializeField] TextMeshProUGUI MpText;

    int MaxManaCost = 50;
    int MaxManaLevel = 1;
    [SerializeField] TextMeshProUGUI MaxMpText;

    int YanPowerCost = 125;
    [SerializeField] TextMeshProUGUI YanPowerText;

    int YinPowerCost = 100;

    int StatusUpgradeValue = 40;
    [SerializeField] TextMeshProUGUI StatusText;

    public void OnOffButton()
    {
        if (!SkillBarOn)
        {
            SkillBar.transform.DOLocalMoveX(258, 1).SetEase(Ease.InOutBack);
            SkillBarOn = true;
            SkillBar.sprite = Barsprites[1];
        }
        else
        {
            SkillBar.sprite = Barsprites[0];
            SkillBar.transform.DOLocalMoveX(940, 1).SetEase(Ease.InOutBack);
            SkillBarOn = false;
        }
    }
    public void OnOffPowerButton()
    {
        if (!PowerBarOn)
        {
            PowerBar.sprite = Barsprites[1];
            PowerBar.transform.DOLocalMoveX(-258, 1).SetEase(Ease.InOutBack);
            PowerBarOn = true;
        }
        else
        {
            PowerBar.sprite = Barsprites[0];
            PowerBar.transform.DOLocalMoveX(-940, 1).SetEase(Ease.InOutBack);
            PowerBarOn = false;
        }
    }
    public void RegenerateMpLevelUp()
    {
        if (GameManager.Instance.MP > ManaLevelupCost * ManaLevelupLevel)
        {
            GameManager.Instance.MP -= ManaLevelupCost * ManaLevelupLevel;
            ManaLevelupLevel++;
            GameManager.Instance.MpRegenrateValue++;
            MpText.text = (ManaLevelupCost * ManaLevelupLevel).ToString();
        }
    }

    public void MaxMpLevelUp()
    {
        if (GameManager.Instance.MP > MaxManaCost * MaxManaLevel)
        {
            GameManager.Instance.MP -= MaxManaCost * MaxManaLevel;
            MaxManaLevel++;
            GameManager.Instance.MPMax += 25;
            MaxMpText.text = (MaxManaCost * MaxManaLevel).ToString();
        }
    }

    Coroutine YanPowerCoroutine;
    public void YanPower()
    {
        if (GameManager.Instance.MP >= YanPowerCost)
        {
            GameManager.Instance.MP -= YanPowerCost;
            if (YanPowerCoroutine != null)
                StopCoroutine(YanPowerCoroutine);

            YanPowerCoroutine = StartCoroutine(YanPowerDelay());
        }
    }
    IEnumerator YanPowerDelay()
    {
        GameManager.Instance.MaxValue = true;
        YanPowerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);
        GameManager.Instance.MaxValue = false;
        YanPowerText.gameObject.SetActive(false);
    }

    Coroutine YinPowerCoroutine;
    public void YinPower()
    {
        if (GameManager.Instance.MP >= YinPowerCost)
        {
            GameManager.Instance.MP -= YinPowerCost;

            if (YinPowerCoroutine != null)
            {
                StopCoroutine(YinPowerCoroutine);
            }
            YinPowerCoroutine = StartCoroutine(YinPowerDelay());
        }
    }
    IEnumerator YinPowerDelay()
    {
        GameManager.Instance.BallonCooltime = 1;
        yield return new WaitForSeconds(15);
        GameManager.Instance.BallonCooltime = 2;
    }

    public void PopulationUpgrade()
    {
        if (GameManager.Instance.MP >= StatusUpgradeValue * GameManager.Instance.addStatusMinValue.Population)
        {
            GameManager.Instance.MP -= StatusUpgradeValue * GameManager.Instance.addStatusMinValue.Population;
            GameManager.Instance.addStatusMinValue.Population++;
        }
    }
    public void EnvironmentUpgrade()
    {
        if (GameManager.Instance.MP >= StatusUpgradeValue * GameManager.Instance.addStatusMinValue.Environment)
        {
            GameManager.Instance.MP -= StatusUpgradeValue * GameManager.Instance.addStatusMinValue.Environment;
            GameManager.Instance.addStatusMinValue.Environment++;
        }
    }
    public void HappinessUpgrade()
    {
        if (GameManager.Instance.MP >= StatusUpgradeValue)
        {
            GameManager.Instance.MP -= StatusUpgradeValue * GameManager.Instance.addStatusMinValue.Happiness;
            GameManager.Instance.addStatusMinValue.Happiness++;
        }
    }

    public void ResourcesUpgrade()
    {
        if (GameManager.Instance.MP >= StatusUpgradeValue * GameManager.Instance.addStatusMinValue.Resources)
        {
            GameManager.Instance.MP -= StatusUpgradeValue * GameManager.Instance.addStatusMinValue.Resources;
            GameManager.Instance.addStatusMinValue.Resources++;
        }
    }

}

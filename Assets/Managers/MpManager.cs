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
    bool PowerBarOn;
    [SerializeField] Sprite[] Barsprites;

    int ManaLevelupCost = 100;
    int ManaLevelupLevel = 1;
    [SerializeField] TextMeshProUGUI MpText;

    int MaxManaCost = 50;
    int MaxManaLevel = 1;
    [SerializeField] TextMeshProUGUI MaxMpText;

    int YanPowerCost = 150;
    [SerializeField] TextMeshProUGUI YanPowerText;

    

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
        }
    }

    public void MaxMpLevelUp()
    {
        if (GameManager.Instance.MP > MaxManaCost * MaxManaLevel)
        {
            GameManager.Instance.MP -= MaxManaCost * MaxManaLevel;
            MaxManaLevel++;
            GameManager.Instance.MPMax += 25;
        }
    }

    Coroutine YanPowerCoroutine;
    public void YanPower()
    {
        if (GameManager.Instance.MP >= YanPowerCost)
        {
            GameManager.Instance.MP -= 150;
            StopCoroutine(YanPowerCoroutine);
            YanPowerCoroutine = StartCoroutine(YanPowerDelay());
        }
    }
    IEnumerator YanPowerDelay()
    {
        GameManager.Instance.MaxValue = true;
        YanPowerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(15);
        GameManager.Instance.MaxValue = false;
        YanPowerText.gameObject.SetActive(false);
    }

}

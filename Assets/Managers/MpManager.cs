using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MpManager : MonoBehaviour
{
    int ManaLevelupCost = 100;
    int ManaLevelupLevel = 1;
    [SerializeField] TextMeshProUGUI MpText;

    int MaxManaCost = 50;
    int MaxManaLevel = 1;
    [SerializeField] TextMeshProUGUI MaxMpText;



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
        StopCoroutine(YanPowerCoroutine);
        YanPowerCoroutine = StartCoroutine(YanPowerDelay());
    }
    IEnumerator YanPowerDelay()
    {
        GameManager.Instance.MaxValue = true;
        yield return new WaitForSeconds(15);
        GameManager.Instance.MaxValue = false;
    }
}

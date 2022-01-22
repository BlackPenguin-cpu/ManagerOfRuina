using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public enum BallonType
{
    HUMAN,
    HAPPY,
    ENVIRONMENT,
    MINERAL
}

public abstract class PointBallon : MonoBehaviour
{
    Button button;
    public BallonType Type;
    SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Action());
    }

    public void Action()
    {
        GameManager.Instance.ClickedBallon(Type);
        StartCoroutine(OnclickEvent());
    }

    IEnumerator OnclickEvent()
    {

        yield return new WaitForSeconds(1);
        renderer.DOFade(0,1);
    }
}

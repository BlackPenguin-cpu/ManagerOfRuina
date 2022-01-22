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
[RequireComponent(typeof(Button))]
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
        transform.DOScale(new Vector3(2,2,2),1);
        yield return new WaitForSeconds(0.3f);
        renderer.DOFade(0,1);

        BallonManager.Instance.ReturnObj(this);
    }
}

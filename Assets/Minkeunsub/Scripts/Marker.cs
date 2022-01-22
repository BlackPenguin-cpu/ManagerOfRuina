using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class Marker : MonoBehaviour
{
    SpriteRenderer renderer;
    States thisState;
    [SerializeField] Image MarkerImg;
    [SerializeField] Image Icon;
    Button button;
    InGameCanvas canvas;
    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void SetImage(Sprite _marker, Sprite _icon, InGameCanvas _canvas)
    {
        MarkerImg.sprite = _marker;
        Icon.sprite = _icon;
        canvas = _canvas;
    }

    public void ButtonClick()
    {
        GameManager.Instance.ClickedBallon(thisState);
        StartCoroutine(OnclickEvent());
        Destroy(button);
        canvas.Push(this);
    }
    IEnumerator OnclickEvent()
    {
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.3f);
        renderer.DOFade(0, 1).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class Marker : MonoBehaviour
{
    public int index;
    public Vector3 markPosition;
    SpriteRenderer sprite;
    States thisState;
    [SerializeField] Image MarkerImg;
    [SerializeField] Image Icon;
    Button button;
    InGameCanvas canvas;
    private void Start()
    {
        button = GetComponent<Button>();
    }

    Animator anime;


    public void SetImage(Sprite _marker, Sprite _icon, InGameCanvas _canvas, States _state)
    {
        thisState = _state;
        anime = GetComponent<Animator>();
        anime.SetBool("On", true);
        MarkerImg.sprite = _marker;
        Icon.sprite = _icon;
        canvas = _canvas;
    }

    public void ButtonClick()
    {
        GameManager.Instance.ClickedBallon(thisState);
        anime.SetBool("Off", true);
    }

    public void OnEnd()
    {
        anime.SetBool("On", false);
        anime.SetBool("Off", false);
    }

    public void Push()
    {
        canvas.Push(this);
        OnEnd();
    }
    //IEnumerator OnclickEvent()
    //{
    //    transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1).SetEase(Ease.OutBack);
    //    yield return new WaitForSeconds(0.3f);
    //    sprite.DOFade(0, 1).SetEase(Ease.InOutBack);
    //    yield return new WaitForSeconds(1);
    //    Destroy(gameObject);
    //}
}

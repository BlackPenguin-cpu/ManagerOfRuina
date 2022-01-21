using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Action());
    }

    public void Action()
    {
        GameManager.Instance.ClickedBallon(Type);
        
    }   
}

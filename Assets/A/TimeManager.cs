using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    private float duration;
    public int years { get; private set; }
    [SerializeField]
    private TextMeshProUGUI tmpro;
    // Start is called before the first frame update
    void Start()
    {
        years = 1;
        tmpro.text = years.ToString() + "년 차";
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;
        if(duration >= 20)
        {
            duration = 0;
            years++;
            tmpro.text = years.ToString() + "년 차";
            if(years % 2 == 0 && years != 2)
            {
                Singleton<EventManager>.Instance.Event();
            }
        }
    }
}

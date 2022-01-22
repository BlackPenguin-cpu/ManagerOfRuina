using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float duration;
    private int years;
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
        if(duration >= 10)
        {
            duration -= 10;
            years++;
            tmpro.text = years.ToString() + "년 차";
            if(years % 2 == 0)
            {
                Singleton<EventManager>.Instance.Event();
            }
        }
    }
}

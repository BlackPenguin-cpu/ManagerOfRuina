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
    [SerializeField]
    private EventManager ev;
    // Start is called before the first frame update
    void Start()
    {
        years = 0;
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;
        if(duration >= 60)
        {
            duration -= 60;
            years++;
            tmpro.text = years.ToString() + "³â Â÷";
            if(years % 2 == 0)
            {
                ev.Event();
            }
        }
    }
}

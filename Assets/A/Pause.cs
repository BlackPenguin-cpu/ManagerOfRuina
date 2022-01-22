using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseobj;
    public void OnClick()
    {
        Time.timeScale = 0;
        pauseobj.SetActive(true);
    }
    public void OnClick2()
    {
    }
    public void OnClick3()
    {
        Time.timeScale = 1;
        pauseobj.SetActive(false);
    }
    public void OnClick4()
    {
        Application.Quit();
    }
}

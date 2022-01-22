using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    public void OnClick()
    {
        SceneManager.LoadScene("InGameScene");
    }
    void Update()
    {
        obj.transform.Rotate(Vector3.forward * 25 * Time.deltaTime);
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("InGameScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum States
{
    ENVIRONMENT,
    HAPPINESS,
    POPULATION,
    RESOURCES
}

public class InGameCanvas : Singleton<InGameCanvas>
{
    [Header("Marker")]
    [SerializeField] Marker MarkerPrefab;
    [SerializeField] List<Marker> MarkersList = new List<Marker>();
    List<bool> MarkAble = new List<bool>();
    List<Transform> positions;
    Coroutine nowCoroutine;

    [Header("Sprites")]
    [SerializeField] Sprite[] Icons = new Sprite[4];
    [SerializeField] Sprite[] Backgrounds = new Sprite[4];

    [Header("Slider")]
    [SerializeField] Slider BackgroundSlider;
    [SerializeField] Slider EffectSlider;

    [SerializeField] Transform Tank;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Pop((States)Random.Range(0, 4));
        }
    }

    public void GetPositions(List<Transform> _pos)
    {
        positions = _pos;
        InitMarkers();
        nowCoroutine = StartCoroutine(SetPositionCoroutine());
    }

    void InitMarkers()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            var temp = Instantiate(MarkerPrefab, Tank);
            temp.gameObject.SetActive(false);
            MarkersList.Add(temp);
            MarkAble.Add(true);
        }
    }

    public void Push(Marker _obj)
    {
        _obj.gameObject.SetActive(false);
        MarkAble[_obj.index] = true;
    }

    public Marker Pop(States state)
    {
        int index = 0;
        int markerIndex = Random.Range(0, MarkersList.Count);
        while (!MarkAble[markerIndex] && index < MarkersList.Count - 1)
        {
            index++;
            markerIndex = Random.Range(0, MarkersList.Count);
        }

        var temp = MarkersList[markerIndex];
        MarkAble[markerIndex] = false;
        temp.gameObject.SetActive(true);
        temp.index = markerIndex;
        temp.SetImage(Backgrounds[(int)state], Icons[(int)state], this, state);
        return temp;
    }

    IEnumerator SetPositionCoroutine()
    {
        while (true)
        {
            SetMarkerPosition();
            yield return null;
        }
    }

    void SetMarkerPosition()
    {
        for (int i = 0; i < MarkersList.Count; i++)
        {
            if (positions[i].position.y >= -5)
                MarkersList[i].transform.position = positions[i].position;
            else
            {
                Vector3 temp = positions[i].position;
                temp.y = -5;
                MarkersList[i].transform.position = temp;
            }
        }
    }
}

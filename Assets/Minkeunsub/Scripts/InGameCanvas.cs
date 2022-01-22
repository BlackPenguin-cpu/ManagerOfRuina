using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Stack<Marker> Markers = new Stack<Marker>();
    List<Transform> positions;
    Coroutine nowCoroutine;

    [Header("Sprites")]
    [SerializeField] Sprite[] Icons = new Sprite[4];
    [SerializeField] Sprite[] Backgrounds = new Sprite[4];

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Pop(Random.Range(0, 4));
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
            var temp = Instantiate(MarkerPrefab, transform);
            temp.gameObject.SetActive(false);
            Markers.Push(temp);
            MarkersList.Add(temp);
        }
    }

    public void Push(Marker _obj)
    {
        _obj.gameObject.SetActive(false);
        Markers.Push(_obj);
    }

    public Marker Pop(int index)
    {
        var temp = Markers.Pop();
        temp.gameObject.SetActive(true);
        temp.SetImage(Backgrounds[index], Icons[index], this, (States)index);
        return temp;
    }

    public Marker Pop(States state)
    {
        var temp = Markers.Pop();
        temp.gameObject.SetActive(true);
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

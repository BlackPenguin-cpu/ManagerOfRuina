using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    public int objectsCount;
    [SerializeField] Transform markPos;
    public List<Transform> MarkPositions;
    [SerializeField] float moveSpeed;
    [SerializeField] InGameCanvas canvas;

    void Start()
    {
        InitPositions();
    }

    void InitPositions()
    {
        for (int i = 0; i < objectsCount; i++)
        {
            Transform temp = Instantiate(markPos, transform);
            temp.localPosition = Random.insideUnitCircle * 5;
            MarkPositions.Add(temp);
        }

        canvas.GetPositions(MarkPositions);
    }

    void Rotating()
    {
        transform.Rotate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Update()
    {
        Rotating();
    }
}

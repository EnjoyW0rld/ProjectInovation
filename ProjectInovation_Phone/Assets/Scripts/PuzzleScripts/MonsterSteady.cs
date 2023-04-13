using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSteady : MonoBehaviour
{
    [SerializeField] private RectTransform moveObj;
    [SerializeField] private RectTransform targetObj;

    private Vector2 targetDir = Vector2.zero;
    [SerializeField] private float halfSize;
    [SerializeField] private float xMax;

    private void Start()
    {
        halfSize = targetObj.sizeDelta.x / 2;
        xMax = Camera.main.pixelRect.xMax / 2 - halfSize;
    }
    // Update is called once per frame
    void Update()
    {
        float dirX = RoundToTwo(Input.acceleration.x);
        moveObj.position += new Vector3(dirX, 0, 0);

        targetObj.anchoredPosition += targetDir;
        targetObj.anchoredPosition = new Vector3(Mathf.Clamp(targetObj.anchoredPosition.x, -xMax, xMax), 0, 0);

        targetDir.x += Random.Range(-2f, 2f);
        targetDir.x = Mathf.Clamp(targetDir.x, -2f, 2f);

        float relative = (moveObj.anchoredPosition - targetObj.anchoredPosition).magnitude;
        if (relative <= halfSize)
        {
            //print("Inside box");
        }
    }

    private float RoundToTwo(float value)
    {
        return ((int)(value * 100)) / 100.0f;
    }
}
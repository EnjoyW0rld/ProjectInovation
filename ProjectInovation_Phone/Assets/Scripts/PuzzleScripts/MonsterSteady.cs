using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSteady : MonoBehaviour
{
    [SerializeField] private RectTransform moveObj;
    [SerializeField] private RectTransform targetObj;

    [SerializeField] private float attackTime = 7;
    [SerializeField] private float maxTimeOutside = 1;
    private float currentTimeOutside;
    private float currentAttackTime;

    private Vector2 targetDir = Vector2.zero;
    private float halfSize;
    private float xMax;



    private void Start()
    {
        halfSize = targetObj.sizeDelta.x / 2;
        xMax = Camera.main.pixelRect.xMax / 2 - halfSize;

        currentAttackTime = attackTime;
        currentTimeOutside = 0;
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

        currentTimeOutside += Time.deltaTime;
        currentAttackTime -= Time.deltaTime;

        float relative = (moveObj.anchoredPosition - targetObj.anchoredPosition).magnitude;
        if (relative <= halfSize)
        {
            currentTimeOutside = 0;
        }
        if(currentTimeOutside >= attackTime)
        {
            print("YOu failed");
        }
        if(currentAttackTime <= 0)
        {
            Destroy(this.gameObject);
        }


    }

    private float RoundToTwo(float value)
    {
        return ((int)(value * 100)) / 100.0f;
    }
}
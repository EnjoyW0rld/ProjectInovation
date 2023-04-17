using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MonsterSteady : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private RectTransform moveObj;
    [SerializeField] private RectTransform targetObj;

    [Header("Speed variables")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float barSpeed;
    [SerializeField] private float maxBarSpeed = 2f;


    [Header("Time variables")]
    [SerializeField] private float attackTime = 7;
    [SerializeField] private float maxTimeOutside = 1;
    public UnityEvent OnFailed;

    private float currentTimeOutside;
    private float currentAttackTime;

    private Vector2 targetDir = Vector2.zero;
    private float halfSize;
    private float xMax;

    private bool failed;

    private void Start()
    {
        halfSize = targetObj.sizeDelta.x / 2;
        xMax = Camera.main.pixelRect.xMax / 2 - halfSize;

        currentAttackTime = attackTime;
        currentTimeOutside = 0;
    }

    void Update()
    {
        float dirX = RoundToTwo(Input.acceleration.x);
        moveObj.position += new Vector3(dirX * Time.deltaTime * playerSpeed, 0, 0);


        targetObj.anchoredPosition += targetDir * Time.deltaTime * barSpeed;
        targetObj.anchoredPosition = new Vector3(Mathf.Clamp(targetObj.anchoredPosition.x, -xMax, xMax), 0, 0);

        targetDir.x += Random.Range(-2f, 2f);
        targetDir.x = Mathf.Clamp(targetDir.x, -maxBarSpeed, maxBarSpeed);

        currentTimeOutside += Time.deltaTime;
        currentAttackTime -= Time.deltaTime;

        float relative = (moveObj.anchoredPosition - targetObj.anchoredPosition).magnitude;
        if (relative <= halfSize)
        {
            currentTimeOutside = 0;
        }
        //Check if player failed
        if (currentTimeOutside >= maxTimeOutside)
        {
            print("you failed");
            OnFailed?.Invoke();
            failed = true;
        }
        //Check if player done!
        if (currentAttackTime <= 0 && !failed)
        {
            Destroy(this.gameObject);
        }
    }

    private float RoundToTwo(float value)
    {
        return ((int)(value * 100)) / 100.0f;
    }
}
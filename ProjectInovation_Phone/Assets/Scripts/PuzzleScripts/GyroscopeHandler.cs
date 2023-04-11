using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeHandler : MonoBehaviour
{
    private Vector3 _defaultPosition;
    private Quaternion _calibrated;
    [SerializeField] private float threshold;

    [SerializeField] private float shakeLeft;
    private float maxBreak;
    [SerializeField] private float currentBreak;
    private bool doneShaking = true;
    [SerializeField] private Vector3 previousPos = Vector3.zero;

    void Update()
    {
        if (_defaultPosition == Vector3.zero)
        {
            _defaultPosition = Input.acceleration;
            Quaternion rotate = Quaternion.FromToRotation(new Vector3(0, 0, 1f), _defaultPosition);
            _calibrated = Quaternion.Inverse(rotate);
            return;
        }
        Vector3 direction = RoundToTwo(GetDirection());

        if (Input.touchCount > 0) StartShake(3, 3);

        if (!doneShaking)
        {
            //print(Vector3.Angle(previousPos, direction));
            //print();
            if (Vector3.Angle(previousPos, direction) > threshold)
            {
                currentBreak = 0;
                previousPos = direction;
            }
            else
            {
                currentBreak += Time.deltaTime;
            }
            if (currentBreak >= maxBreak)
            {
                doneShaking = true;
                print("Not success");
            }
            if (shakeLeft <= 0)
            {
                print("Done shaking!");
                doneShaking = true;
            }
            shakeLeft -= Time.deltaTime;
        }
    }

    private void StartShake(float shakeTime, float maxBreak)
    {
        print("shake started");
        doneShaking = false;
        shakeLeft = shakeTime;
        currentBreak = 0;
        this.maxBreak = maxBreak;
        previousPos = Vector3.one;
    }


    private Vector3 GetDirection()
    {
        Vector3 rightAcceleration = _calibrated * Input.acceleration;
        Vector3 direction = new Vector3(rightAcceleration.x, -rightAcceleration.y, 0);
        return direction;
    }

    //private Vector3 currentPos = Vector3.zero;

    float timeTillUpdate = .5f;

    private bool isShaking(Vector3 dir)
    {
        //if (Vector3.Angle(dir, previousPos) > 0) print(Vector3.Angle(previousPos, dir));
        if (timeTillUpdate <= 0)
        {
            previousPos = dir;
            print("now pos update");
            timeTillUpdate = .5f;
        }
        else timeTillUpdate -= Time.deltaTime;
        if (Vector3.Angle(previousPos, dir) > threshold)
        {
            //print("executed");
            //previousPos = dir;
            return true;
        }
        return false;

    }

    private Vector3 RoundToTwo(Vector3 val)
    {
        Vector3 res = Vector3.zero;
        for (int i = 0; i < 3; i++)
        {
            res[i] = ((int)(val[i] * 100)) / 100.0f;
        }
        return res;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeHandler : MonoBehaviour
{
    private Vector3 _defaultPosition;
    private Quaternion _calibrated;
    [SerializeField] private float threshold;

    void Update()
    {
        if (_defaultPosition == Vector3.zero)
        {
            _defaultPosition = Input.acceleration;
            Quaternion rotate = Quaternion.FromToRotation(new Vector3(0, 0, 1f), _defaultPosition);
            _calibrated = Quaternion.Inverse(rotate);
            return;
        }
        Vector3 direction = GetDirection();

        Debug.Log(Vector3.Angle(Vector3.one, RoundToTwo(direction)));
        //isShaking(direction);
    }

    private Vector3 GetDirection()
    {
        Vector3 rightAcceleration = _calibrated * Input.acceleration;
        Vector3 direction = new Vector3(rightAcceleration.x, -rightAcceleration.y, 0);
        return direction;
    }

    [SerializeField] private Vector3 previousPos = Vector3.zero;
    //private Vector3 currentPos = Vector3.zero;

    float timeTillUpdate = .5f;

    private bool isShaking(Vector3 dir)
    {
        if (Vector3.Angle(dir, previousPos) > 0) print(Vector3.Angle(previousPos, dir));
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

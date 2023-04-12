using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GyroscopeHandler : MonoBehaviour
{
    private Vector3 _defaultPosition;
    private Quaternion _calibrated;
    [SerializeField] private float threshold;

    /*
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
    
    private bool isShakeDone;

    [SerializeField] private float updateTime = .2f;
     */
    [SerializeField] private Vector3 previousPos = Vector3.one;
    private float timeTillUpdate;
    [SerializeField] private UnityEvent OnShakeComplete;
    [SerializeField] private float desiredShakeTime = 1.5f;
    [SerializeField] private float currentShakeTime;

    [SerializeField]private float ShakeDetectionThreshold;
    [SerializeField] private float MinShakeInterval;
    private float sqrDetectionThreshold;
    private float timeSinceLastShake;

    private void Start()
    {
        sqrDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
    }


    
    private float timeToBreak;
    

    private void Update()
    {
        /*
        if (_defaultPosition == Vector3.zero)
        {
            _defaultPosition = Input.acceleration;
            Quaternion rotate = Quaternion.FromToRotation(new Vector3(0, 0, 1f), _defaultPosition);
            _calibrated = Quaternion.Inverse(rotate);
            return;
        }
        Vector3 direction = RoundToTwo(GetDirection());
         */


        if(Input.acceleration.sqrMagnitude >= sqrDetectionThreshold &&
            Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            timeToBreak = 1;
            timeSinceLastShake = Time.unscaledTime;
        }
        currentShakeTime += Time.deltaTime;
        if(timeToBreak <= 0)
        {
            currentShakeTime = 0;
        }
        timeToBreak -= Time.deltaTime;
        if(currentShakeTime >= desiredShakeTime)
        {
            print("shaked!");
            OnShakeComplete?.Invoke();

        }
        /*
        if (timeTillUpdate <= 0)
        {
            previousPos = direction;
            timeTillUpdate = updateTime;
        }
        else timeTillUpdate -= Time.deltaTime;

        if (Vector3.Angle(previousPos,direction) > threshold)
        {
            currentShakeTime += Time.deltaTime;
            if (currentShakeTime >= desiredShakeTime)
            {
                isShakeDone = true;
                OnShakeComplete?.Invoke();
                print("Done shaking!!");
            }
            //previousPos = direction;
        }
        else
        {
            currentShakeTime = 0;
        }
         */

    }



    private Vector3 GetDirection()
    {
        Vector3 rightAcceleration = _calibrated * Input.acceleration;
        Vector3 direction = new Vector3(rightAcceleration.x, -rightAcceleration.y, 0);
        return direction;
    }

    //private Vector3 currentPos = Vector3.zero;

    //float timeTillUpdate = .5f;

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

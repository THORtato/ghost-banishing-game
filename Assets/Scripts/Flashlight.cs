﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] FieldOfView fieldOfView = default;
    private Camera cam;
    [SerializeField] float batteryMaxAmount;
    private float currentAmount;
    public int batteryCount;

    void Start()
    {
        cam = Camera.main;
        currentAmount = batteryMaxAmount;
    }

    void Update()
    {
        if (currentAmount <= 0)
        {
            if(batteryCount > 0)
            {
                RefillBattery();
                return;
            }

            fieldOfView.Disable();
        }
        else
        {
            currentAmount -= Time.deltaTime;
        }
    }

    public void RefillBattery()
    {
        currentAmount = batteryMaxAmount;
        batteryCount--;
    }

    public void HandleAim(Vector3 playerPosition)
    {
        Vector3 aimDir = (cam.ScreenToWorldPoint(Input.mousePosition) - playerPosition).normalized;
        fieldOfView.SetAimDirection(aimDir);
        fieldOfView.SetOrigin(playerPosition);

        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}

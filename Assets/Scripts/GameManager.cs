﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;



    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (UIManager.instance.pauseScreen.activeInHierarchy)
        {
            UIManager.instance.pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
        else
        {
            UIManager.instance.pauseScreen.SetActive(true);
            UIManager.instance.CloseOptions();

            Time.timeScale = 0f;
        }
    }


}
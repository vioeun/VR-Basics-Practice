﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCursor : MonoBehaviour
{
    public Image CursorGaugeImage; // public => inspector에 나타난다.
    private Vector3 ScreenCenter;
    private float GaugeTimer;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2); // 화면의 중심점
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = GaugeTimer;

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.tag == "GameStart")
            {
                GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    SceneManager.LoadScene("PlayerSelect");
                    GaugeTimer = 0.0f;
                }
            }
            else
                GaugeTimer = 0.0f;
        }
        else
            GaugeTimer = 0.0f;
    }
}

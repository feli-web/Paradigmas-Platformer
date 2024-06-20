using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    int bananas;
    float time;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bananaText;
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");

    }

    public void AddBanana()
    {
        bananas++;
        bananaText.text = bananas.ToString("D2");
    }
}

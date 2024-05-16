using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Image pause;
    bool isPaused;
    void Start()
    {
        isPaused = false;
        pause.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(Pause());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

    }
    public void PauseButton()
    {
        StartCoroutine(Pause());
    }
    public IEnumerator Pause()
    {
        isPaused = !isPaused;
        yield return new WaitForSecondsRealtime(0.1f); 
        if (isPaused)
        {
            Time.timeScale = 0;
            pause.gameObject.SetActive(true);
        }
        if (!isPaused)
        {
            Time.timeScale = 1;
            pause.gameObject.SetActive(false);
        }
    }
    public void Menu(int destination)
    {
        SceneManager.LoadScene(destination);
    }
}

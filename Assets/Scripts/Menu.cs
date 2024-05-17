using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float moveSpeed;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sr.material.mainTextureOffset = new Vector2(0f, Time.realtimeSinceStartup * -moveSpeed);
    }
    public void ChangeScene(int destination)
    {
        SceneManager.LoadScene(destination);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

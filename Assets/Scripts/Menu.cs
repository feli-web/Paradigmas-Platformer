using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public float moveSpeed;
    private SpriteRenderer sr;
    private Button play;
    private Button quit;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        play = GameObject.FindWithTag("Play").GetComponent<Button>();
        quit = GameObject.FindWithTag("Quit").GetComponent<Button>();

        
        play.onClick.AddListener(() => ChangeScene(1)); 
        quit.onClick.AddListener(() => Quit());
    }

    // Update is called once per frame
    void Update()
    {
        sr.material.mainTextureOffset = new Vector2(0f, Time.realtimeSinceStartup * -moveSpeed);
    }

    void ChangeScene(int destination)
    {
        SceneManager.LoadScene(destination);
    }

    void Quit()
    {
        Application.Quit();
    }
}


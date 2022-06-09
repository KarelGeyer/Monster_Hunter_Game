using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] chars;
    public GameObject gameOverText;

    public static GameManager instance;
    public static Scene sc;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    public void Awake()
    {

        // Singleton -> look it up
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        sc = scene;
        if (scene.name == "Gameplay" || scene.name == "Gameplay_2")
        {
            Instantiate(chars[CharIndex]); 
        }
    }

    void Update()
    {
        if (sc.name != "Main_Menu" && Player.instance.IsPlayerAlive == 0)
        {
            print(sc.name);

            if(!GameObject.FindGameObjectWithTag("Game_Over_Text")) {
                Instantiate(gameOverText);
            }
        }
    }
}

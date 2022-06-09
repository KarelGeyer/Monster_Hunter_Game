using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    public void PlayGame()
    {
        string clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        int selectedPlayer = int.Parse(clickedObj) - 1;

        GameManager.instance.CharIndex = selectedPlayer;

        SceneManager.LoadScene("Gameplay");
    }
}

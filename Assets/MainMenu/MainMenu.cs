using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    private InputField nameInputField;
    public void PlayGame()
    {
        nameInputField = GameObject.Find("nameInput").GetComponent<InputField>();
        PlayerPrefs.SetString("playerName", nameInputField.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {

        Application.CancelQuit();

    }
   

}

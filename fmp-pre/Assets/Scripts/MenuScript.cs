using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu, settingsMenu;
    void Start()
    {
        settingsMenu.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SettingsMenu()
    {
        //Open settings menu
    }
    public void QuitGame()
    {
        print("Quitting...");
        Application.Quit();
    }
}

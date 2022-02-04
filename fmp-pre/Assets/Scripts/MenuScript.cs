using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public GameObject settingsMenu;
    void Start() => settingsMenu.SetActive(false);
    public void ContinueGame(int level) => SceneManager.LoadScene(level);
    public void StartGame() => SceneManager.LoadScene("SampleScene");
    public void QuitGame() => Application.Quit();
}
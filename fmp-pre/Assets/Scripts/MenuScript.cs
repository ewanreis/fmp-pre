using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    private bool buttonAvailable = true, isCreepy = false;
    private int level = 1;

    public GameObject settingsMenu;
    public AudioClip[] clips;
    public AudioSource source;

    enum Sounds
    {
        continueHover, // 0
        continueClick, // 1
        clickDeny, // 2
        startClick, // 3
        hoverDeny, // 4
        startHover, // 5
        quitClick, // 6
        menuMusic, // 7
        menuMusicCreepy // 8
    }

    void Start() 
    {
        settingsMenu.SetActive(false);
        Sounds music = (isCreepy) ? Sounds.menuMusic : Sounds.menuMusicCreepy;
        source.PlayOneShot(clips[(int)music],0.05f);
    }

    public void ContinueGame() 
    {
        if (buttonAvailable)
        {
            source.PlayOneShot(clips[(int)Sounds.continueClick]);
            Invoke("LoadScene", 1.5f);
        }
        else
            source.PlayOneShot(clips[(int)Sounds.clickDeny]);
    }

    public void StartGame() 
    {
        level = 2;
        source.PlayOneShot(clips[(int)Sounds.startClick]);
        Invoke("LoadScene", 1.5f);
    }

    public void QuitGame()
    {
        source.PlayOneShot(clips[(int)Sounds.quitClick]);
        Invoke("EndGame", 1f);
    }

    public void ContinueHover() => source.PlayOneShot(clips[(buttonAvailable) ? (int)Sounds.continueHover : (int)Sounds.hoverDeny]);
    public void StartHover() => source.PlayOneShot(clips[(int)Sounds.startHover]);

    private void EndGame() => Application.Quit();
    private void LoadScene() => SceneManager.LoadScene(level); 
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasSettings;
    [SerializeField] private AudioSource audioSource;

    /**
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        GameManager.Scene_Cinematic();
    }**/

    public void LaunchHome()
    {
        GameManager.Scene_Home();
    }

    // Fonction pour montrer les settings
    public void LaunchSettings()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0)
        {
            canvasMenu.SetActive(false);
            canvasSettings.SetActive(true);
        }
        else
        {
            canvasPause.SetActive(true);
            //pause game
        }
    }

    // Fonction pour cacher les settings
    public void QuitSettings()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0)
        {
            canvasMenu.SetActive(true);
            canvasSettings.SetActive(false);
        }
        else
        {
            canvasPause.SetActive(false);
            //resume game
        }
    }

    // Fonction pour retourner au menu
    public void LaunchMenu()
    {
        GameManager.Scene_Menu();
    }

    // Fonction pour retourner au menu
    public void LaunchMap()
    {
        GameManager.Scene_Map();
    }

    // Fonction pour quitter l'application
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject tryAgainButton;

    [SerializeField]
    GameObject quitButton;

    [SerializeField]
    GameObject postProccesing;

    [SerializeField]
    GameObject postProccesingGreenPill;

    [SerializeField]
    GameObject postProccesingTimeWarp;
    public void EndGame (float score)
    {
        
        Cursor.visible = true;
        tryAgainButton.SetActive(true);
        quitButton.SetActive(true);
        postProccesing.SetActive(true);
        postProccesingGreenPill.SetActive(false);
        postProccesingTimeWarp.SetActive(false);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        postProccesing.SetActive(false);
        postProccesingGreenPill.SetActive(false);
        postProccesingTimeWarp.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

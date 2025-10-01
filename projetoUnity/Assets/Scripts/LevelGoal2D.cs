using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGoal2D : MonoBehaviour
{
    [Header("UI")]
    public GameObject winPanel;           
    public Text messageText;              
    public string message = "Fase Concluída!";

    [Header("Fluxo")]
    public string nextSceneName = "";     
    public AudioSource sfxSource;         
    public AudioClip winSfx;              

    bool finished;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (finished || !other.CompareTag("Player")) return;
        finished = true;

        if (sfxSource && winSfx) sfxSource.PlayOneShot(winSfx);
        if (winPanel) winPanel.SetActive(true);
        if (messageText) messageText.text = message;

        Time.timeScale = 0f;              // congela o jogo
        Cursor.visible = true;
    }

    public void Btn_Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Btn_Next()
    {
        if (string.IsNullOrEmpty(nextSceneName)) return;
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneName);
    }

    public void Btn_Menu(string menuScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }
}

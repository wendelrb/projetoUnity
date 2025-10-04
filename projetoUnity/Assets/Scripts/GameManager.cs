using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI de Fim")]
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TextMeshProUGUI endText; // se usar TMP: troque por TextMeshProUGUI e "using TMPro;"

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (endPanel != null) endPanel.SetActive(false);
        Time.timeScale = 1f; // garante normal ao carregar cena
    }

    public void EndGame(bool victory)
    {
        Time.timeScale = 0f; // congela o jogo
        if (endPanel != null) endPanel.SetActive(true);

        if (endText != null)
            endText.text = victory ? "🎉 Vitória! Fase concluída!" : "💀 Fim! Você perdeu.";
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}

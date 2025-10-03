using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public static PlayerHealthUI Instance;

    [SerializeField] private Slider healthSlider;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
          
        else
            Destroy(gameObject);
    }

    public void InitHealthBar(int max)
    {
        healthSlider.maxValue = max;
        healthSlider.value = max;
    }

    public void UpdateHealthBar(int current, int max)
    {
        healthSlider.value = current;
    }
}

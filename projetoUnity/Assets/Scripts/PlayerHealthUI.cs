using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthSlider;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        healthSlider.maxValue = playerHealth.maxHp;
        healthSlider.value = playerHealth.maxHp;
    }

    void Update()
    {
        healthSlider.value = playerHealth.CurrentHp;
    }
}

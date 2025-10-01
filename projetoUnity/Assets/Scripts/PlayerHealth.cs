using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int CurrentHp => hp;

    public int maxHp = 5;
    int hp;

    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }

    void Die()
    {
        // Simples: reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine;

public class AudioActions : MonoBehaviour
{
    public AudioClip jumpSFX;
    public AudioClip attackSFX;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpSFX);
    }

    public void PlayAttack()
    {
        audioSource.PlayOneShot(attackSFX);
    }
}

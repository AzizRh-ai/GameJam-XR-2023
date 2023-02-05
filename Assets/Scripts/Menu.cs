using UnityEngine;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameMenuController menu;
    [SerializeField] private AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            audioSource.Play();
            menu.PauseGameEnd();
        }

    }
}

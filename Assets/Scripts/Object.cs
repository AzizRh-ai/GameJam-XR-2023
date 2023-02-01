using UnityEngine;

public class Object : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioSource audioSource;
    private GameMenuController _gameMenuController;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ScoreManager.instance.IncScore();
            audioSource.PlayOneShot(hitSound);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

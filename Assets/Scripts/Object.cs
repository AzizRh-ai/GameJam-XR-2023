using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioSource audioSource;
    private GameMenuController _gameMenuController;
    private GameObject target;
    private bool move;
    private float speed = 5f;
    [SerializeField] private GameObject winPoint;
    [SerializeField] private Transform pointEffect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("PointCounter");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Weapon")
        {
            Debug.Log("+5 scores");
            ScoreManager.instance.IncScore(1000);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            //Instantiate(winPoint, pointEffect.position, gameObject.transform.rotation);
            //gameObject.transform.Rotate(0, Random.Range(1, 180), 0);
            ScoreManager.instance.IncScore(1);
            move = true;
            audioSource.PlayOneShot(hitSound);
            Destroy(gameObject, 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}

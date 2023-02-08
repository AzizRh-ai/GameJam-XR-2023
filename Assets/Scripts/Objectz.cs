using UnityEngine;
using UnityEngine.XR;

public class Objectz : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioSource audioSource;
    private GameMenuController _gameMenuController;
    private GameObject target;
    private bool move;
    private float speed = 2f;
    [SerializeField] private GameObject winPoint;
    // [SerializeField] private Transform pointEffect;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("PointCounter");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.tag);


        if (collision.gameObject.CompareTag("Projectile"))
        {

            if (gameObject.CompareTag("plusCent"))
            {
                Debug.Log("+100 points");
                ScoreManager.instance.AddTime(1f);
                ScoreManager.instance.IncScore(100);
            }

            else if (gameObject.CompareTag("plus500"))
            {
                ScoreManager.instance.IncScore(500);
                ScoreManager.instance.AddTime(5f);
                Destroy(gameObject, 1f);
            }

            //Controller Haptic
            SendImpulseToController();

            ScoreManager.instance.IncScore(1);
            move = true;
            audioSource.PlayOneShot(hitSound);
            Destroy(gameObject, 2f);

        }
    }

    private static void SendImpulseToController()
    {
        //vibration controller droite
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        HapticCapabilities capabilities;

        // si device a la vibration
        if (device.TryGetHapticCapabilities(out capabilities))
        {
            if (capabilities.supportsImpulse)
                device.SendHapticImpulse(0, 0.5f, 1.0f); // on envoie l'impulsion
        }

        //vibration controller gauche
        device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (device.TryGetHapticCapabilities(out capabilities))
        {
            if (capabilities.supportsImpulse)
            {
                device.SendHapticImpulse(0, 0.5f, 1.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}

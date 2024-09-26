
using UnityEngine;

public class TableShoot : MonoBehaviour
{

    //variabler
    public float throwStrength;
    public float torque;
    public Vector3 throwDirection;
    private Rigidbody2D rb;
    [SerializeField] GameObject table;
    [SerializeField] Animator explodeAnimator;
    public int spaceButtonPressed;
    CameraScript cameraScript;
    private AudioSource audioSource;
    public bool hasShot;



    private void Start()
    {
        spaceButtonPressed = 0;
        cameraScript = FindFirstObjectByType<CameraScript>();
        rb = table.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        //if sats för att skjuta iväg spelaren beroende på spelarens input
        if (spaceButtonPressed == 2 && cameraScript.launchReady)
        {
            hasShot = true;
            audioSource.pitch = Random.Range(0.5f, 1.5f);
            audioSource.Play();
            explodeAnimator.Play("New State");
            rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
            rb.AddTorque(-torque, ForceMode2D.Impulse);
            spaceButtonPressed = 3;
           
        }
    }
}


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
    public int spaceButtonPressed = 0;
    CameraScript cameraScript;



    private void Start()
    {
        cameraScript = FindFirstObjectByType<CameraScript>();
        rb = table.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        //if sats för att skjuta iväg spelaren beroende på spelarens input
        if (spaceButtonPressed == 2 && cameraScript.launchReady)
        {
            explodeAnimator.Play("New State");
            rb.AddForce(throwDirection.normalized * throwStrength, ForceMode2D.Impulse);
            rb.AddTorque(-torque, ForceMode2D.Impulse);
            spaceButtonPressed = 3;
        }
    }
}

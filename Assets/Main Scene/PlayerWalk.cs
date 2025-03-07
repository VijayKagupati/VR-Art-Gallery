using UnityEngine;

public class LookMoveTo : MonoBehaviour {

    public Transform vrCamera;
    public GameObject character;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    private bool moveForward;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        if (character.GetComponent<Rigidbody>() == null) {
            rb = character.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        } else {
            rb = character.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update () {
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f) {
            moveForward = true;
        }
        else {
            moveForward = false;
        }

        if (moveForward) {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            forward.y = 0; // This ensures movement is only on the horizontal plane
            forward.Normalize();
            rb.MovePosition(rb.position + forward * speed * Time.deltaTime);
        }
    }
}

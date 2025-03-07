using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform VRPlayer;
    public float lookdownangle = 25f;
    private CharacterController cc;
    public float speed = 3.0f;
    private bool movefarword;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VRPlayer.eulerAngles.x > lookdownangle && VRPlayer.eulerAngles.x < 90.0f)
        {
            movefarword = true;
        }
        else
        {
            movefarword = false;
        }

        if (movefarword == true)
        {
            Vector3 farword = VRPlayer.TransformDirection(Vector3.forward);
            cc.SimpleMove(farword);
        }
    }
}

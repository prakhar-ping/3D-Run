using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    private CharacterController control;
    private Vector3 direction;
    public ParticleSystem flame;
    public float forwardSpeed;
    private float desiredLane = 1;
    public float LaneDist = 4;
    public float jump;
    public float gravity = -30;


    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        control.Move(direction * Time.deltaTime);

        direction.z = forwardSpeed;
        direction.y += gravity * Time.deltaTime;

        if(control.isGrounded)
        {
            if (SwipeManager.swipeUp)
                Jump();
        }

        if(!control.isGrounded)
        {
            if (SwipeManager.swipeDown)
                Slide();
        }

        if(SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPos += Vector3.left * LaneDist;
        }
        else if(desiredLane == 2)
        {
            targetPos += Vector3.right * LaneDist;
        }

        transform.position = targetPos;
    
    }

    private void Jump()
    {
        direction.y = jump;
    }

    private void Slide()
    {
        direction.y = -(jump + 5);
    }


    private void FixedUpdate()
    {
        //control.Move(direction * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            //flame.enableEmission = true;
            Event.gameover = true;
           
        }
    }
}

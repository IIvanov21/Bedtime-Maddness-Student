using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;

    float horizontal;
    float vertical;

    bool shooting=false;

    private void Awake()
    {
        //Grab the animator component
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Capturing the movement i.e. WASD or Arrow keys input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        MovingAnimation();

        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            Shooting();
        }
    }

    //Moving Animations function
    void MovingAnimation()
    {
        UpdateAnimation(horizontal, vertical);
    }

    //Shooting Animation function
    void Shooting()
    {
        shooting = !shooting; //Simply swtich between true and false
        playerAnimator.SetBool("isShooting", shooting);
    }
    //Create an Update Animation function
    public void UpdateAnimation(float h, float v)//Takes horizontal and vertical values to control animations
    {
        playerAnimator.SetFloat("horizontal", h);
        playerAnimator.SetFloat("vertical", v);
    }
}

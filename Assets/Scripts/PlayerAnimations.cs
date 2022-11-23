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
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        MoveAnimation();

        if (Input.GetButtonDown("Fire1"))
        {
            ShootingAnimation();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            ShootingAnimation();
        }
    }

    void MoveAnimation()
    {
        UpdateAnimations(horizontal, vertical);
    }

    void ShootingAnimation()
    {
        shooting = !shooting;//Switch statement

        playerAnimator.SetBool("isShooting", shooting);
    }

    public void UpdateAnimations(float h, float v)//Being able to pass horizontal and vertical input inside the function
    {
        playerAnimator.SetFloat("horizontal",h);
        playerAnimator.SetFloat("vertical", v);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed;
    private bool isFacingLeft = false;
    private float horizontalMove;
    [SerializeField] Rigidbody2D playerRb;
    private float xDir;
    private float yDir;
    [SerializeField] Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        xDir = this.transform.localScale.x;
        yDir = this.transform.localScale.y;
        playerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        FlipCharacter();
        PlayRunAnim();

    }

    private void ReadInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(horizontalMove*runSpeed, 0);
    }
    private void FlipCharacter()
    {
        if (horizontalMove > 0 && isFacingLeft == true)
        {
            this.transform.localScale = new Vector2(xDir, yDir);
            isFacingLeft = false;
        }
        else if (horizontalMove < 0 && isFacingLeft == false)
        {
            this.transform.localScale = new Vector2(-xDir, yDir);
            isFacingLeft = true;
        }
    }
    private void PlayRunAnim()
    {
        if (horizontalMove != 0)
        {
            playerAnim.SetBool("isMoving", true);
        }
        else if (horizontalMove == 0)
        {
            playerAnim.SetBool("isMoving", false);
        }
    }
}

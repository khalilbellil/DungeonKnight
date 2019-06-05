using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    #region VARIABLES
    [Header("LINKS :")]
    Rigidbody2D rb;
    #endregion

    #region Player Stats
    [Header("Player Stats:")]
    //Walk Speed:
    [Range(20f, 50f)]
    public float playerSpeed = 35f;
    float maxSpeed = 50f;

    //Jump:
    [Range(20f, 50f)]
    public float jumpForce = 30f;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovementAnimations();
    }

    void FixedUpdate()
    {
        PlayerMovement();
        Jump();
    }

    void PlayerMovement()
    {

    }


    void MovementAnimations()
    {

    }

    void Jump()
    {

    }

}

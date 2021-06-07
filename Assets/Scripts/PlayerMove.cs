using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
  bool alive = true;

  public float speed = 4;
  public float speedIncreasePerPoint = 0.1f;

  float horizontalInput;
  public float horizontalMultiplier = 2;

  public Rigidbody rb;
  private Animator playerAnim;

    [SerializeField]
    float jumpForce = 400f;
    [SerializeField]
    LayerMask groundMask;


    // Start is called before the first frame update
    void Start()
    {
     playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (!alive) return;

      Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
      Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
      rb.MovePosition(rb.position + forwardMove + horizontalMove);
      /*  transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
          if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
          {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
          }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
          if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
          {
          transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
          }
        } */
    }

    private void Update () {
      horizontalInput = Input.GetAxis("Horizontal");

      if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

      if (transform.position.y < -5) {
        Die();
      }
    }

    public void Die()
    {
      alive = false;
      //Falls Restart function with 2 seconds delay
      Invoke("Restart", 2);
    }

    void Restart () {
      //Restart the Game
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        if (!isGrounded)
        {
            return;
        }

        rb.AddForce(Vector3.up * jumpForce);
        playerAnim.SetTrigger("Jump_trig");
    }
}

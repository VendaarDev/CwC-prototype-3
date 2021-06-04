using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
  bool alive = true;

  public float speed = 4;

  float horizontalInput;
  public float horizontalMultiplier = 2;

  public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

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
}

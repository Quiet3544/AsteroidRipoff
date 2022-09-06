using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovementScript : MonoBehaviour
{
    Vector2 move;
    Rigidbody2D rb;
    public Animator playerAnimator;
    public float shipSpeed = 500f;
    public float reverseSpeed = 200f;
    public float rotoateSpeed = 20f;
    float horizontalInput;
    float verticalInput;
    public static int health = 5;
    public float offsetX = 2f;
    public float offsetY = 2f;
    public void transport()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x > stageDimensions.x)
        {
            transform.position = new Vector2(-(stageDimensions.x) + offsetX, transform.position.y);
        }
        else if (transform.position.x < -(stageDimensions.x))
        {
            transform.position = new Vector2(stageDimensions.x - offsetX, transform.position.y);

        }

        if (transform.position.y > stageDimensions.y)
        {
            transform.position = new Vector2(transform.position.x, -(stageDimensions.y) + offsetY);
        }
        else if (transform.position.y < -(stageDimensions.y))
        {
            transform.position = new Vector2(transform.position.x, stageDimensions.y - offsetY);
        }
    }
    void Start()
    {
        // referncing which rigibody
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // thrust controller
        if (verticalInput > 0)
        {
            rb.AddForce(transform.up * shipSpeed * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            rb.AddForce((-transform.up) * reverseSpeed * Time.deltaTime);
        }

        //rotation controller
        if(horizontalInput > 0)
        {
            rb.AddTorque(rotoateSpeed * Time.deltaTime);
        }
        else if (horizontalInput < 0)
        {
            rb.AddTorque(-rotoateSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transport();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            health--;
            if (health > 0)
            {
                playerAnimator.SetBool("isDead", true);
                this.Wait(0.45f, () =>
                 {

                     gameObject.GetComponent<SpriteRenderer>().enabled = false;
                     gameObject.GetComponent<Weapons>().enabled = false;
                     playerAnimator.SetBool("isDead", false);
                 });
                this.Wait(2f, () =>
                {
                    transform.position = new Vector2(0, 0);
                    gameObject.GetComponent<Weapons>().enabled = true;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;

                });
            }
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
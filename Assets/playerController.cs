using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public GameObject bullet;
    public GameObject instantiatedBulllet;
    public static int playerHealth = 10;
    public Text playerHealthText;
    void Start()
    {
        playerHealthText.text = "PlayerHealth : " + playerHealth.ToString() + " Hearts";
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(0.05f, 0, 0);
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            anim.SetBool("isWalking", false);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.localScale = new Vector3(5f, 4f, 5f);
            anim.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            transform.localScale = new Vector3(5f, 5f, 5f);
            anim.SetBool("isCrouching", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            transform.Translate(0.05f, 0, 0);
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            anim.SetBool("isJumping", true);
            transform.Translate(Vector2.up * 50 * Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            anim.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetBool("isJumping", true);
            //transform.Translate(0, 3f, 0);
            transform.Translate(Vector2.up * 80 * Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            anim.SetBool("isJumping", false);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            Vector2 newPosition = new Vector2();
            newPosition = transform.position;
            newPosition.y = newPosition.y - 0.2f;
            Quaternion rotation = transform.rotation;

            if (rotation.eulerAngles.y == 180)
            {
                newPosition.x = newPosition.x - 0.2f;
            }
            else {
                newPosition.x = newPosition.x + 0.2f;
            }
            
            instantiatedBulllet = Instantiate(bullet, newPosition, rotation);
        }
       /* if (Input.GetKeyUp(KeyCode.Q)) {
            Destroy(instantiatedBulllet);
        }*/

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("bottomBoundary") || collision.gameObject.name.StartsWith("specialEnemy") || collision.gameObject.name.StartsWith("enemy"))  {
            
            transform.position = new Vector2(-4.16f,1.26f);
            playerHealth--;
            playerHealthText.text = "PlayerHealth : " + playerHealth.ToString() + " Hearts";
        }
        
    }

    public void healthDecrementer() {
        playerHealth--;
        playerHealthText.text = "PlayerHealth : " + playerHealth.ToString() + " Hearts";

    }
}

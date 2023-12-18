using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class sawScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed = 2f;
    public Text playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("mainPlayer")) {
            Destroy(transform.gameObject);
            SpecialEnemyController.sawFlag = true;
            playerController pc = FindObjectOfType<playerController>();
            pc.healthDecrementer();


        }
        
    }
}

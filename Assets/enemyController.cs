using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("enemy" ) || collision.gameObject.name.StartsWith("SpecialEnemy"))
        {
            Quaternion rotation = transform.rotation;
            if (rotation.eulerAngles.y == 0)
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else if (rotation.eulerAngles.y == 180) {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}

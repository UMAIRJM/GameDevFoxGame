using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chekPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool level2 = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("mainPlayer")) {

            level2 = true;
            Destroy(transform.gameObject);
            SpecialEnemyController.sawFlag = true;
            bulletController.hits = new int[10];
            bulletController.specialEnemy2health = 10;
            bulletController.specialEnemyHealth = 10;
            bulletController.commonEnemyChecker = 0;
            bulletController.specialEnemyChecker = 0;
            bulletController.specialEnemyHealth = 10;
            SceneManager.LoadScene("level2");
        
        }
    }
}

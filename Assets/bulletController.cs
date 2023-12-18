using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class bulletController : MonoBehaviour
{
    public static int[] hits = new int[10];
    public string enemyTag;
    public static int specialEnemyHealth = 10;
    public Text specialEnemyText;
    // Start is called before the first frame update
    void Start()
    {
        specialEnemyText.text = "ChainSawHealth: " + specialEnemyHealth.ToString() + "Blacks";
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.06f, 0, 0);
        
    
    }
    public int hitCounter(string enemyName) {
        if (enemyName == "enemy1")
        {
            
            hits[0] = hits[0]+1;
            return hits[0];
        }
        else if (enemyName == "enemy2")
        {
            
            hits[1] = hits[1] + 1;
            return hits[1];            
        }
        else if (enemyName == "enemy3") {
           
            hits[2] = hits[2] + 1;
            return hits[2];
        }
        else if (enemyName == "enemy4") {
            
            hits[3] = hits[3] + 1;
            return hits[3];
        }
        return 0;
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TilemapCollider2D>() != null) {
           
            Destroy(transform.gameObject);
        

        }
        if (collision.gameObject.name.StartsWith("saw")) {
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
            SpecialEnemyController.sawFlag = true;
        }
        if (collision.gameObject.name.StartsWith("specialEnemy")) {
            Destroy(transform.gameObject);
            specialEnemyHealth--;
            specialEnemyText.text = "ChainSawHealth: " + specialEnemyHealth.ToString() + "Blacks";

        }
        if (collision.gameObject.name.StartsWith("enemy"))
        {
            Destroy(transform.gameObject);
            enemyTag = collision.gameObject.tag;
            print(enemyTag);
            int returnedValue = hitCounter(enemyTag);
            if (returnedValue == 3) {
                Destroy(collision.gameObject);
                
                //Object.DestroyImmediate(collision.gameObject);
                enemyScript es = FindObjectOfType<enemyScript>();
                es.gameObjectHandler(enemyTag);

            }



        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class bulletController : MonoBehaviour
{
    public static int[] hits = new int[10];
    public GameObject finalCheclpoint;
    public GameObject finalCheclpoint2;
    public GameObject specialEnemy;
    public string enemyTag;
    public static int specialEnemyHealth = 10;
    public Text specialEnemyText;
    public static int commonEnemyChecker=0;
    public static int specialEnemyChecker = 0;
    public static int finalBossHealth = 100;
    public Text finalBossText ;
    public int commonTraget = 3;
    public int specialTarget = 1;
    public static int specialEnemy2health = 10;
    public static int specialEnemy2Checker = 0;
    public static bool winnerFlag = false;
    public Text specialEnemy2text;
    // Start is called before the first frame update
    void Start()
    {
        if (level2CheckPointScript.finalLevel == true)
        {
            finalBossText.text = "ChainSawHealth: " + specialEnemyHealth.ToString() + "Blacks";
        }


        if (chekPointScript.level2 == true) {
            commonTraget = 6;
            specialTarget = 1;
        }
        specialEnemyText.text = "ChainSawHealth: " + specialEnemyHealth.ToString() + "Blacks";
        finalCheclpoint.SetActive(false);
        finalCheclpoint2.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.06f, 0, 0);
        
        print("enemt checkses" + specialEnemyChecker );
        print("enemt checkses" + commonEnemyChecker);
        if (chekPointScript.level2 == false ) {
            if (commonEnemyChecker == commonTraget && specialEnemyChecker == specialTarget)
            {
                print("3 common enemies are dead and one special enemy is dead");
                finalCheclpoint.SetActive(true);
            }
        }



        if (chekPointScript.level2 == true ) {
            if (commonEnemyChecker == commonTraget && specialEnemyChecker == specialTarget && specialEnemy2Checker == 1 ) 
            {
                print("6 common enemies are dead and 2 special enemy are dead");
                finalCheclpoint2.SetActive(true);
            }

        }
        if (level2CheckPointScript.finalLevel == true && winnerFlag == true) {
            SceneManager.LoadScene("startingScene");
            
        }
        
    
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
        else if (enemyName == "enemy7")
        {

            hits[4] = hits[4] + 1;
            return hits[4];
        }
        else if (enemyName == "enemy8")
        {

            hits[5] = hits[5] + 1;
            return hits[5];
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
        if (collision.gameObject.name.StartsWith("SEnemy2")) {
            Destroy(transform.gameObject);
            specialEnemy2health--;
            specialEnemy2text.text = "ChainSawHealth: " + specialEnemy2health.ToString() + "Blacks";

            if (specialEnemy2health <= 0) {
                specialEnemy2Checker++;
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.name.StartsWith("finalBoss")) {
            finalBossHealth--;
            Destroy(transform.gameObject);
            specialEnemyText.text = "ChainSawHealth: " + finalBossHealth.ToString() + "Blacks";
            if (finalBossHealth <= 0) {
                winnerFlag = true;
                Destroy(collision.gameObject);
            }


        }
        if (collision.gameObject.name.StartsWith("specialEnemy")) {

            Destroy(transform.gameObject);
            specialEnemyHealth--;
            specialEnemyText.text = "ChainSawHealth: " + specialEnemyHealth.ToString() + "Blacks";

            if (specialEnemyHealth <= 0 )
            {
                specialEnemyChecker++;
                Destroy(specialEnemy);
            }
            
        }
        if (collision.gameObject.name.StartsWith("enemy"))
        {
            Destroy(transform.gameObject);
            enemyTag = collision.gameObject.tag;
            print(enemyTag);
            int returnedValue = hitCounter(enemyTag);
            if (returnedValue == 3) {
                commonEnemyChecker++;

                Destroy(collision.gameObject);
                
                //Object.DestroyImmediate(collision.gameObject);
                enemyScript es = FindObjectOfType<enemyScript>();
                es.gameObjectHandler(enemyTag);

            }



        }
    }
}

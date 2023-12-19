using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sceneReloader() {
        
        SpecialEnemyController.sawFlag = true;
        bulletController.hits = new int[10];
        bulletController.specialEnemyHealth = 10;
        bulletController.commonEnemyChecker = 0;
        bulletController.specialEnemyChecker = 0;
        playerController.playerHealth = 10;
        bulletController.specialEnemyHealth = 10;
        chekPointScript.level2 = false;
        SceneManager.LoadScene("level1");
    }
}

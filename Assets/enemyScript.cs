using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GameObject[] gameObjectArray ;
    public GameObject[] instantiatedEnemies;
    Vector2[] randomPositionsArray = new Vector2[7];
    float[] rotationRange = { 0f, 180f };
    int numberOfEnemy = 3;
    public GameObject randomGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
        randomPositionsArray[0] = new Vector2(1.04f, 3.39f);
        randomPositionsArray[1] = new Vector2(13.1f, 1.68f);
        randomPositionsArray[2] = new Vector2(7.97f, -3.19f);
        randomPositionsArray[3] = new Vector2(7.97f, 3.73f);
        randomPositionsArray[4] = new Vector2(6.83f, -0.28f);
        randomPositionsArray[5] = new Vector2(6.83f, 3.86f);
        randomPositionsArray[6] = new Vector2(0.28f, -2.23f);

        instantiatedEnemies = new GameObject[numberOfEnemy];

        int lengthOfArray = randomPositionsArray.Length - 1;
        
        int lengthofGameobjectArray = gameObjectArray.Length - 1;
        
        for (int i = 0; i < numberOfEnemy; i++) {

            instantiatedEnemies[i] = Instantiate(gameObjectArray[i], randomPositionsArray[Random.Range(0, lengthOfArray+1)], Quaternion.Euler(0, rotationRange[Random.Range(0,2)],0));
            //Cannot use below random gameObjectArray as it was causing error related to reference as we are destroying the object
//            instantiatedEnemies[i] = Instantiate(gameObjectArray[Random.Range(0, lengthofGameobjectArray + 1)], randomPositionsArray[Random.Range(0, lengthOfArray + 1)], Quaternion.Euler(0, rotationRange[Random.Range(0, 2)], 0));

        }


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfEnemy; i++) {
            Vector2 position = new Vector2();
            position = instantiatedEnemies[i].transform.position;
            Quaternion rotation = instantiatedEnemies[i].transform.rotation;
            
            if ((position.x <=3.695f&& position.x>=0.87f) && position.y <= -3.39f && rotation.eulerAngles.y == 180)
            {
                
                instantiatedEnemies[i].transform.position = new Vector2(0.87f, -2.86f);
            }

            if ((position.x <=-0.66f && position.x>=-2.17f) && position.y <= -2.89f && rotation.eulerAngles.y == 180f)
            {
                
                instantiatedEnemies[i].transform.position = new Vector2(-2.35f, -0.82f);

            }
            if ((position.x <= 7.38f && position.x >= 6.99f) && position.y <= 1f && rotation.eulerAngles.y == 0f)
            {

                instantiatedEnemies[i].transform.position = new Vector2(3.16f, 3.5f);

            }
            if ((position.x <= 0.825f && position.x >= 0.441) && position.y <= -1f && rotation.eulerAngles.y == 0) {
                instantiatedEnemies[i].transform.position = new Vector2(2.35f, -0.87f);
            }
            if (position.x >= 12.38)
            {
                instantiatedEnemies[i].transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else if(position.x <= -4.16){
                instantiatedEnemies[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            instantiatedEnemies[i].transform.Translate(0.01f, 0, 0);
            
        }



    }

    public void gameObjectHandler(string tagName) {
        for (int i = 0; i < instantiatedEnemies.Length; i++) {
            if (instantiatedEnemies[i].tag == tagName) {
                instantiatedEnemies[i] = randomGameObject;
            }
        }
        
    }
}

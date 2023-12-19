using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBoosScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject saw;
    public float spawnInterval = 5f;
    void Start()
    {
        InvokeRepeating("instantiatorFunction", spawnInterval, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiatorFunction() {
        int loopCounter = 10;
        while (loopCounter != 0) {

            loopCounter-- ;
            Instantiate(saw, transform.position, Quaternion.identity);

        }
    }
}

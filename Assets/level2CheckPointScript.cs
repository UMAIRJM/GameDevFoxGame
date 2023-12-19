using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2CheckPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool finalLevel = false;
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
            
            finalLevel = true;
            SceneManager.LoadScene("finalLevl");
        }
    }
}

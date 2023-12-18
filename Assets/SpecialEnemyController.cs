using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.Mathematics;
using UnityEngine;

public class SpecialEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed = 5f;
    public bool distanceFlag= false;
    public GameObject saw;
    public int sawCounter = 0;
    public static bool sawFlag = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        quaternion rotation = target.rotation;
        transform.rotation = rotation;

        if (target != null && distanceFlag == false) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < 4f)
        {

            distanceFlag = true;
            
            if (sawFlag == true )
            {
                sawFlag = false;
                sawCounter++;
                Vector2 position = transform.position;
                quaternion Rotation = transform.rotation;
                Instantiate(saw, position, Rotation);
                

            }

        }
        else {
            sawCounter = 0;
            distanceFlag = false;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() 
    {
        if(BirdController.instance != null)
        {
            if(BirdController.instance.flag == 1)
            {
                Destroy(GetComponent<PipeController>());
            }
        }
        PipeMovement();    
    }

    // Update is called once per frame
    void PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
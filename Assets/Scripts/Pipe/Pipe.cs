using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;    


    // Update is called once per frame
    void Update()
    {
        if (BirdController.instance !=null)
        {
            if (BirdController.instance.flag == 0)
            {
                Destroy(this);
            }
        }
        _PipeMoveMent();
    }

    void _PipeMoveMent()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;

    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Destroy"){
            Destroy(gameObject); 
        }
    }
}


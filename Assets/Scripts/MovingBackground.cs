using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{

    public float speed;
    public GameObject pivot;
    public GameObject pivot2;
    Vector2 position1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 position = transform.position;

        position1 = new Vector2(position.x, position.y + speed * Time.deltaTime);

        if(position.y != pivot2.transform.position.y)

        {
            transform.position = position1;
        }

        if (position.y > pivot2.transform.position.y)

        {
            transform.position = pivot.transform.position;
        }


    }
}

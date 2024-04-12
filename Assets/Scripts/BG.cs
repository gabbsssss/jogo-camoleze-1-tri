using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public Transform camera;
    private float startposition, tamanhoBG;
    public float speed;

    void Update()
    {
       float temp = (camera.position.x * (1-speed));
       float distancia = (camera.position.x * speed);

       transform.position = new Vector3(startposition + distancia, transform.position.y, transform.position.z);

       if (temp > startposition + tamanhoBG)
       {
         startposition += tamanhoBG;
       }

       if (temp < startposition - tamanhoBG)
       {
         startposition -= tamanhoBG;
       }
    }

    void Start()
    {
       startposition = transform.position.x;
       tamanhoBG = GetComponent<SpriteRenderer>().bounds.size.x;
    }
}

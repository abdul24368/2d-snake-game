using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {

        Bounds bounds = this.gridArea.bounds; //sets the bounds of the grid area as the location in which the object can spawn
     float x = Random.Range(bounds.min.x,bounds.max.x); 
     float y = Random.Range(bounds.min.y,bounds.max.y);//Random.range requires two values to be set as max and min
        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y), 0.0f); //changes the positions according to above values
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomizePosition();
            
        }
    }
}

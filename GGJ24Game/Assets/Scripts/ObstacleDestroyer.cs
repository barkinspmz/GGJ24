using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (collision.gameObject.GetComponent<Animator>()!=null)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            }

            Destroy(collision.gameObject,2f);
        }
    }
}

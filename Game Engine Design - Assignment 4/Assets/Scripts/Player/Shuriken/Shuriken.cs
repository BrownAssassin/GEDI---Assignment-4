using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            FindObjectOfType<PointCollect>().points++;
            BasicPool.Instance.AddToPool(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            BasicPool.Instance.AddToPool(gameObject);
        }
    }
}

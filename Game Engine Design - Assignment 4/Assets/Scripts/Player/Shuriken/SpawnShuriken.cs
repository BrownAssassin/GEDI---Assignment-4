using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShuriken : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private float throwRate = 0.5f;
    [SerializeField] private float shurikenSpeed = 20f;

   private float lastTime;

    void Update()
    {
        if (Time.time - lastTime > throwRate)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                ObjectPoolSpawn();
            }
        }
    }

    private void ObjectPoolSpawn()
    {
        lastTime = Time.time;

        Vector2 position = transform.position;

        var shuriken = BasicPool.Instance.GetFromPool();
        shuriken.transform.position = position;

        Rigidbody2D rigidbody = shuriken.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(player.transform.localScale.x * shurikenSpeed, 0);
    }
}

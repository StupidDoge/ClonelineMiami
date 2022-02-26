using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    public bool PlayerBullet { get; set; }

    void FixedUpdate()
    {
        transform.Translate(new Vector2(0, speed * Time.fixedDeltaTime));
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("environment"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Hit env");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}

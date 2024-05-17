using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OneWay : MonoBehaviour
{
    TilemapCollider2D tc;
    void Start()
    {
        tc = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y > -1f)
            {
                tc.isTrigger = false;
            }
        }
    }
}

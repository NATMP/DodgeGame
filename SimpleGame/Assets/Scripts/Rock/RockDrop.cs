using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RockDrop : MonoBehaviour
{
    private float minDropSpeed;
    private float maxDropSpeed;
    private float ranDropSpeed;
    private Rigidbody2D rockRb;
    [SerializeField] MinMaxDropSpeedConfig minMaxDropSpeedValues;
    private void Awake()
    {
        minDropSpeed = minMaxDropSpeedValues.minDropSpeedConfig;
        maxDropSpeed = minMaxDropSpeedValues.maxDropSpeedConfig;
        //Debug.Log("Min Drop Speed Load: " + minDropSpeed);
        //Debug.Log("Max Drop Speed Load: " + maxDropSpeed);
    }
    private void Start()
    {
        ranDropSpeed = Random.Range(minDropSpeed, maxDropSpeed);
        rockRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rockRb.velocity = new Vector2(0, -ranDropSpeed);
        //Debug.Log("Random Drop Speed: "+ranDropSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
            RockManager.countRock--;
            ranDropSpeed = Random.Range(minDropSpeed, maxDropSpeed);
            GameManager.score += 1;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            RockManager.countRock=0;
            FindObjectOfType<LostMenu>().SetActive();
            collision.gameObject.GetComponent<PlayerMovement>().enabled= false;
        }
    }
}

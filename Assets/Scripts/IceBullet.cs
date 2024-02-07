﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public float damageAmount;
    public bool isEggs = true;
    public GameObject hitSound;
    Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        if (isEggs)
        {
            m_rb.angularVelocity = (Random.value < 0.5) ? 90f : -90f;
        }
        //Destroy(gameObject, timeToDestroy);
        //StartCoroutine(DeleteBullet());
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("PauseGame", 0) == 1)
        {
            m_rb.velocity = Vector2.zero;
        }
        else
        {
            m_rb.velocity = Vector2.right * speed;
            if (gameObject.activeSelf)
            {
                StartCoroutine(DeleteBullet());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // Giảm máu của enemy đi một giá trị nào đó.
            col.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
            Instantiate(hitSound, this.transform.position, Quaternion.identity);

            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.StartCoroutine(enemy.SlowDown(0.5f, 1f));
                enemy.ChangeColor();// Chậm 50% trong 3 giây.
            }
            gameObject.SetActive(false);
        }
    }
    private IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        gameObject.SetActive(false);
    }
}

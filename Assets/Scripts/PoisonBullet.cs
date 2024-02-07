﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : MonoBehaviour
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

    // Update is called once per frame
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
            Health enemy = col.gameObject.GetComponent<Health>();
            Instantiate(hitSound, this.transform.position, Quaternion.identity);
            if (enemy != null)
            {
                enemy.Poison(damageAmount, 2f);
            }
            Enemy ene = col.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                ene.StartCoroutine(ene.SlowDown(0.3f, 1f));
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

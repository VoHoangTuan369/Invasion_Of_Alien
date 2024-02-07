using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    public float damageAmount;
    public float directionY;
    Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
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
            m_rb.velocity = new Vector2(-1, directionY) * speed;
            if (gameObject.activeSelf)
            {
                StartCoroutine(DeleteBullet());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fence"))
        {
            col.gameObject.GetComponent<Fence>().TakeDamage(damageAmount);
            gameObject.SetActive(false);
        }
    }
    private IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(timeToDestroy);
        gameObject.SetActive(false);
    }
}

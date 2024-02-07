﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    float shootTimer;

    public float shootDelay;
    public int bulletCount;
    public int bulletToCreate;
    public float delayBetweenBullets;

    public GameObject bullet;
    public Transform shootingPoint;
    public int goldToBuy;
    public AudioClip soundShoot;

    private Animator anim;
    private AudioSource audioSource;
    private List<GameObject> inactiveBullets = new List<GameObject>();
    // Update is called once per frame
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundShoot;

        for (int i = 0; i < bulletToCreate; i++)
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.SetActive(false);
            inactiveBullets.Add(newBullet);
        }
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("PauseGame", 0) == 1)
        {
        }
        else
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (bullet && shootingPoint)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Vector3 enemyViewportPosition = Camera.main.WorldToViewportPoint(enemy.transform.position);

                if (enemy.activeSelf && enemyViewportPosition.x > 0 && enemyViewportPosition.x < 1 && enemyViewportPosition.y > 0 && enemyViewportPosition.y < 1 && Mathf.Approximately(enemy.transform.position.y, shootingPoint.position.y))
                {
                    this.shootTimer += Time.deltaTime;

                    // Kiểm tra xem đã hết thời gian delay giữa các lần bắn hay chưa
                    if (this.shootTimer <= this.shootDelay)
                        return;

                    this.shootTimer = 0;
                    anim.SetBool("Shoot", true);
                    StartCoroutine(ShootBullets());

                    break;
                }
            }
        }
    }
    IEnumerator ShootBullets()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            if (audioSource && soundShoot)
            {
                audioSource.PlayOneShot(soundShoot);
            }
            //Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            GameObject bulletToShoot = GetBullet();
            if (bulletToShoot != null)
            {
                bulletToShoot.SetActive(true);
                bulletToShoot.transform.position = shootingPoint.position;
            }
            yield return new WaitForSeconds(delayBetweenBullets); // Delay để tạo ra viên đạn tiếp theo
        }
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Shoot", false);
    }
    GameObject GetBullet()
    {
        foreach (GameObject bullet in inactiveBullets)
        {
            if (!bullet.activeSelf)
            {
                return bullet;
            }
        }

        return null;
    }
    void OnDestroy()
    {
        foreach (GameObject bullet in inactiveBullets)
        {
            Destroy(bullet);
        }

        inactiveBullets.Clear();
    }
}

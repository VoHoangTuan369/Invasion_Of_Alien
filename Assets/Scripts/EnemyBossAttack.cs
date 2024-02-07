using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAttack : MonoBehaviour
{
    float shootTimer;

    public float shootDelay;
    public int bulletCount;
    public float delayBetweenBullets;

    public GameObject[] bullet;
    public int bulletToCreate;
    public GameObject bulletLaser;
    public int bulletLaserToCreate;
    public Transform shootingPoint;
    public Transform shootingPoint2;
    public Transform[] movePoint;
    private Animator anim;

    public AudioClip soundAttack;
    public AudioClip soundLaser;

    private AudioSource audioSource;
    private Health health;
    private bool isMove = false;
    private List<GameObject> inactiveBullets = new List<GameObject>();
    private List<GameObject> inactiveBulletLasers = new List<GameObject>();

    int bulletCounter = 0;
    void Start()
    {
        health = GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        for (int i = 0; i < bulletLaserToCreate; i++)
        {
            GameObject newBullet = Instantiate(bulletLaser);
            newBullet.SetActive(false);
            inactiveBulletLasers.Add(newBullet);
        }
        for (int i = 0; i < bulletToCreate; i++)
        {
            for (int j = 0; j < bullet.Length; j++)
            {
                GameObject newBullet = Instantiate(bullet[j]);
                newBullet.SetActive(false);
                inactiveBullets.Add(newBullet);
            }
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
        if (health.GetCurrenHealth() <= health.maxHealth / 3) 
        {
            BossRage();
        }
    }
    public void Shoot()
    {
        if (bulletCounter % 2 == 0)
        {
            if (bulletLaser && shootingPoint)
            {
                this.shootTimer += Time.deltaTime;

                // Kiểm tra xem đã hết thời gian delay giữa các lần bắn hay chưa
                if (this.shootTimer <= this.shootDelay)
                    return;

                this.shootTimer = 0;
                anim.SetBool("Shoot", true);
                StartCoroutine(ShootBullets(bulletLaser));
                bulletCounter++;
            }
        }
        else {
            foreach (GameObject b in bullet)
            {
                if (b && shootingPoint)
                {
                    this.shootTimer += Time.deltaTime;

                    // Kiểm tra xem đã hết thời gian delay giữa các lần bắn hay chưa
                    if (this.shootTimer <= this.shootDelay)
                        return;

                    this.shootTimer = 0;
                    // Duyệt qua từng loại đạn và bắn cùng một lúc
                    for (int i = 0; i < bullet.Length; i++)
                    {
                        StartCoroutine(ShootBulletsRocket(bullet[i]));
                    }
                    bulletCounter++;
                }
            }
        }
    }
    IEnumerator ShootBullets(GameObject bullet)
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < bulletCount; i++)
        {
            if (audioSource && soundLaser)
            {
                audioSource.PlayOneShot(soundLaser);
            }
            GameObject bulletToShoot = GetBulletLaser();
            if (bulletToShoot != null)
            {
                bulletToShoot.SetActive(true);
                bulletToShoot.transform.position = shootingPoint.position;
            }
            yield return new WaitForSeconds(delayBetweenBullets); // Delay để tạo ra viên đạn tiếp theo
        }
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Shoot", false);
    }
    IEnumerator ShootBulletsRocket(GameObject bullet)
    {
        anim.SetBool("ShootRocket", true);
        for (int i = 0; i < bulletCount; i++)
        {
            if (audioSource && soundAttack)
            {
                audioSource.PlayOneShot(soundAttack);
            }
            GameObject bulletToShoot = GetBullet();
            if (bulletToShoot != null)
            {
                bulletToShoot.SetActive(true);
                bulletToShoot.transform.position = shootingPoint2.position;
            }
            yield return new WaitForSeconds(delayBetweenBullets); // Delay để tạo ra viên đạn tiếp theo
        }
        anim.SetBool("ShootRocket", false);
    }
    void MoveToRandomPoint()
    {
        int randomIndex = Random.Range(0, movePoint.Length);
        Transform randomPoint = movePoint[randomIndex];

        // Gọi hàm di chuyển tới điểm ngẫu nhiên đã chọn
        MoveToPoint(randomPoint.position);
    }

    void MoveToPoint(Vector3 point)
    {
        transform.position = point;
    }
    void BossRage() 
    {
        shootDelay = 2f;
        bulletCount = 4;
        if (isMove == false)
        {
            MoveToRandomPoint();
            isMove = true;
        }
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
    GameObject GetBulletLaser()
    {
        foreach (GameObject bullet in inactiveBulletLasers)
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
        foreach (GameObject bullet in inactiveBulletLasers)
        {
            Destroy(bullet);
        }

        inactiveBulletLasers.Clear();
    }
}

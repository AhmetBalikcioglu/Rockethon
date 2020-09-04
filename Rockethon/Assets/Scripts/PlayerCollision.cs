/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** BİTİRME ÇALIŞMASI
** 2019-2020 YAZ DÖNEMİ
**
** ÖĞRETİM ÜYESİ..............: Doç.Dr. CÜNEYT BAYILMIŞ
** ÖĞRENCİ ADI................: AHMET YAŞAR BALIKÇIOĞLU
** ÖĞRENCİ NUMARASI...........: G1512.10001
** BİTİRMENİN ALINDIĞI GRUP...: 1F
****************************************************************************/

using UnityEngine;

// Bu sınıfımızı çarpışmaları kontrol etmek için kullanıyoruz
public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameManager gameManager;
    public GameObject deathAnimation;
    private GameObject[] obstacles;
    private GameObject[] glassObstacles;
    private GameObject[] turnObstacles;
    Score score;
    private Material playerMat;
    private float buffTimer = 2f;
    private float alpha = 0f;
    private float duration = 5f;
    private float timer1 = 0f;
    private float timer2 = 0f;
    private bool buffEnabled = false;
    private Color color;

    // Başlangıçta uçak indeximizi ve uçağımızın materyalini atıyoruz
    void Start()
    {
        int index = PlayerPrefs.GetInt("PlayerIndex");
        playerMat = transform.GetChild(index).gameObject.GetComponent<Renderer>().material;
        color = playerMat.color;
    }

    void FixedUpdate()
    {
        // Buff(Yıldız) alınmış ise uçağımızın materyali görünmez oluyor
        if (buffEnabled)
        {
            float lerp = Mathf.PingPong(Time.time, buffTimer) / buffTimer;

            alpha = Mathf.Lerp(0.35f, 0.66f, lerp);
            
            color.a = alpha;
            playerMat.color = color;

            timer1 += Time.deltaTime;
            timer2 += Time.deltaTime;
            if (timer2 % 60 >= 3f)
            {
                DisableBoxCollider();
                timer2 = 0f;
            }
            
            if (duration <= timer1 % 60)
            {
                buffEnabled = false;
                timer1 = 0;
                timer2 = 0;
                color.a = 1f;
                playerMat.color = color;
                EnableBoxCollider();
                Debug.Log("BUFF BITTI");
            }
        }
    }

    // Çarpışmaları kontrol eden fonksiyon
    void OnCollisionEnter(Collision collisionInfo)
    {
        // Engellere çarpılırsa oyun bitiyor
        if (collisionInfo.collider.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            movement.enabled = false;
            gameObject.SetActive(false);
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Debug.Log("Carptin: " + collisionInfo.collider.name);
        }
        // Elmas alınırsa elmas sayısı 1 arttırılıyor
        if (collisionInfo.collider.tag == "Diamond" && collisionInfo.gameObject.active)
        {
            FindObjectOfType<AudioManager>().Play("DiamondSound");
            collisionInfo.gameObject.SetActive(false);
            Destroy(collisionInfo.gameObject);
            gameManager.diamondTotal += 1;
        }
        // Buff(Yıldız) alınırsa 5 saniyeliğine engele çarpma kapatılıyor
        if (collisionInfo.collider.tag == "Buff" && collisionInfo.gameObject.active)
        {
            FindObjectOfType<AudioManager>().Play("BuffSound");
            collisionInfo.gameObject.SetActive(false);
            Destroy(collisionInfo.gameObject);
            buffEnabled = true;
            DisableBoxCollider();
            Debug.Log("BUFF ALINDI");
            timer1 = 0;
            timer2 = 0;
        }
    }

    // Engellere çarpılmayı kapatan fonksiyon
    void DisableBoxCollider()
    {
        obstacles = null;
        glassObstacles = null;
        turnObstacles = null;

        if (obstacles == null && glassObstacles == null && turnObstacles == null)
        {
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            glassObstacles = GameObject.FindGameObjectsWithTag("TurnObstacle");
            turnObstacles = GameObject.FindGameObjectsWithTag("GlassObstacle");
        }
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.GetComponent<Collider>().isTrigger = true;
            Debug.Log("Kapandı: " + obstacle.transform.name);
        }
        foreach (GameObject glassObstacle in glassObstacles)
        {
            foreach(Transform temp in glassObstacle.transform)
            {
                temp.GetComponent<Collider>().isTrigger = true;
                Debug.Log("Kapandı: " + temp.name);
            }
        }
        foreach (GameObject turnObstacle in turnObstacles)
        {
            foreach(Transform temp in turnObstacle.transform)
            {
                temp.GetComponent<Collider>().isTrigger = true;
                Debug.Log("Kapandı: " + temp.name);
            }
        }
    }

    // Engellere çarpılmayı açan fonksiyon
    void EnableBoxCollider()
    {
        obstacles = null;
        glassObstacles = null;
        turnObstacles = null;

        if (obstacles == null && glassObstacles == null && turnObstacles == null)
        {
            obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            glassObstacles = GameObject.FindGameObjectsWithTag("TurnObstacle");
            turnObstacles = GameObject.FindGameObjectsWithTag("GlassObstacle");
        }
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.transform.GetComponent<Collider>().isTrigger = false;
            Debug.Log("Acildi: " + obstacle.transform.name);
        }
        foreach (GameObject glassObstacle in glassObstacles)
        {
            foreach (Transform temp in glassObstacle.transform)
            {
                temp.GetComponent<Collider>().isTrigger = false;
                Debug.Log("Acildi: " + temp.name);
            }
        }
        foreach (GameObject turnObstacle in turnObstacles)
        {
            foreach (Transform temp in turnObstacle.transform)
            {
                temp.GetComponent<Collider>().isTrigger = false;
                Debug.Log("Acildi: " + temp.name);
            }
        }
    }
}

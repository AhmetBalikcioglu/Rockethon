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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bu sınıfımızı Seviye modunda cisim spawnlamak için kullanıyoruz
public class SpawnerLevel : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject collectable;
    public GameObject end;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn = 2f;
    public float runTime = 35f;
    public GameManager gm;
    public GameObject player;

    // Verdiğimiz sayıya göre engel, elmas ve bitiş cisimlerini spawnlayan Update fonksiyonumuz
    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstacle.Length);
            if (rand == 0) // Astroid cisimini spawnlama
            {
                rand = Random.Range(-4, 0);
                Instantiate(obstacle[0], transform.position + new Vector3(rand, rand, 0), Quaternion.identity);
                rand = Random.Range(0, 4);
                Instantiate(obstacle[0], transform.position + new Vector3(rand, rand, 0), Quaternion.identity);
            }
            else if (rand == 1) // FullStar cisimini spawnlama
            {
                Instantiate(obstacle[rand], transform.position, Quaternion.identity);
                rand = Random.Range(0, 2);
                if (rand == 0) // Elmas cisimini spawnlama
                {
                    gm.diamondSpawned += 1;
                    rand = Random.Range(0, 8);
                    if (rand == 0)
                    {
                        Instantiate(collectable, new Vector3(1.5f, 9f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 1)
                    {
                        Instantiate(collectable, new Vector3(-1.5f, 9f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 2)
                    {
                        Instantiate(collectable, new Vector3(3.5f, 6.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 3)
                    {
                        Instantiate(collectable, new Vector3(-3.5f, 6.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 4)
                    {
                        Instantiate(collectable, new Vector3(3.5f, 3.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 5)
                    {
                        Instantiate(collectable, new Vector3(-3.5f, 3.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 6)
                    {
                        Instantiate(collectable, new Vector3(1.5f, 1f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 7)
                    {
                        Instantiate(collectable, new Vector3(-1.5f, 1f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                }
            }
            else if (rand == 2) // Glass(Cam) cisimini spawnlama
            {
                rand = Random.Range(-3, 0);
                Instantiate(obstacle[2], transform.position + new Vector3(0, rand, 0), Quaternion.identity);
                rand = Random.Range(0, 4);
                Instantiate(obstacle[2], transform.position + new Vector3(0, rand, 0), Quaternion.identity);
            }
            else if (rand == 3) // Mountain(Dağ) cisimini spawnlama
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    rand = Random.Range(0, 3);
                    if (rand == 0) // Elmas cisimini spawnlama
                    {
                        gm.diamondSpawned += 1;
                        Instantiate(collectable, new Vector3(1.5f, 9f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 1) // Elmas cisimini spawnlama
                    {
                        gm.diamondSpawned += 1;
                        Instantiate(collectable, new Vector3(-3, 6, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    Instantiate(obstacle[3], transform.position + new Vector3(5, -5, 0), Quaternion.Euler(0, 0, 45));
                    Instantiate(obstacle[3], transform.position + new Vector3(-5, -5, 0), Quaternion.Euler(0, 0, -45));
                }
                else
                {
                    rand = Random.Range(0, 3);
                    if (rand == 0) // Elmas cisimini spawnlama
                    {
                        gm.diamondSpawned += 1;
                        Instantiate(collectable, new Vector3(-1, 1, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 1) // Elmas cisimini spawnlama
                    {
                        gm.diamondSpawned += 1;
                        Instantiate(collectable, new Vector3(3, 4, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    Instantiate(obstacle[3], transform.position + new Vector3(5, 5, 0), Quaternion.Euler(0, 0, 135));
                    Instantiate(obstacle[3], transform.position + new Vector3(-5, 5, 0), Quaternion.Euler(0, 0, -135));
                }
            }
            else if (rand == 4) // Plus(Artı) cisimini spawnlama
            {
                Instantiate(obstacle[rand], transform.position, Quaternion.identity);
                rand = Random.Range(0, 2);
                if (rand == 0) // Elmas cisimini spawnlama
                {
                    gm.diamondSpawned += 1;
                    rand = Random.Range(0, 4);
                    if (rand == 0)
                    {
                        Instantiate(collectable, new Vector3(-2.5f, 2.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 1)
                    {
                        Instantiate(collectable, new Vector3(-2.5f, 7.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 2)
                    {
                        Instantiate(collectable, new Vector3(2.5f, 2.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 3)
                    {
                        Instantiate(collectable, new Vector3(2.5f, 7.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                }
            }
            else if (rand == 5) // SideStar(Yan yıldız) cisimini spawnlama
            {
                Instantiate(obstacle[rand], transform.position, Quaternion.identity);
                rand = Random.Range(0, 2);
                if (rand == 0) // Elmas cisimini spawnlama
                {
                    gm.diamondSpawned += 1;
                    rand = Random.Range(0, 6);
                    if (rand == 0)
                    {
                        Instantiate(collectable, new Vector3(0, 2.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 1)
                    {
                        Instantiate(collectable, new Vector3(-3.6f, 3.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 2)
                    {
                        Instantiate(collectable, new Vector3(-3.6f, 6.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 3)
                    {
                        Instantiate(collectable, new Vector3(0, 7.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 4)
                    {
                        Instantiate(collectable, new Vector3(3.6f, 3.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 5)
                    {
                        Instantiate(collectable, new Vector3(3.6f, 6.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                }
            }
            else if (rand == 6) // UpStar(Üst Star) cisimini spawnlama
            {
                Instantiate(obstacle[rand], transform.position, Quaternion.identity);
                rand = Random.Range(0, 2);
                if (rand == 0) // Elmas cisimini spawnlama
                {
                    gm.diamondSpawned += 1;
                    rand = Random.Range(0, 6);
                    if (rand == 0)
                    {
                        Instantiate(collectable, new Vector3(-3.5f, 5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 1)
                    {
                        Instantiate(collectable, new Vector3(-1.5f, 9f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 2)
                    {
                        Instantiate(collectable, new Vector3(1.5f, 9f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 3)
                    {
                        Instantiate(collectable, new Vector3(3.5f, 5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 4)
                    {
                        Instantiate(collectable, new Vector3(-1.5f, 1f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 5)
                    {
                        Instantiate(collectable, new Vector3(1.5f, 1f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                }
            }
            else if (rand == 7) // X cisimini spawnlama
            {
                Instantiate(obstacle[rand], transform.position, Quaternion.identity);
                rand = Random.Range(0, 2);
                if (rand == 0) // Elmas cisimini spawnlama
                {
                    gm.diamondSpawned += 1;
                    rand = Random.Range(0, 4);
                    if (rand == 0)
                    {
                        Instantiate(collectable, new Vector3(0, 7.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 1)
                    {
                        Instantiate(collectable, new Vector3(0f, 2.5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 2)
                    {
                        Instantiate(collectable, new Vector3(2.5f, 5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                    else if (rand == 3)
                    {
                        Instantiate(collectable, new Vector3(-2.5f, 5f, transform.position.z), Quaternion.Euler(90f, 0, 0));
                    }
                }
            }
            
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        runTime -= Time.deltaTime;

        // Verilen toplam süre biterse bitişi belirleyen end cisimini spawnlama
        if (runTime <= 5f)
        {
            timeBtwSpawn = 50f;
            //Instantiate(end, transform.position, Quaternion.identity);
            
            //return;
        }
        if (runTime < 0f && player.gameObject.active)
        {
            runTime = 50f;
            gm.CompleteLevel();
            
            Debug.Log("ENDDDDD");
            return;
        }
    }

}

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Bu sınıfımızı kullanıcının seçtiği uçak ile oynaması için kullanıyoruz
public class PlaneSelection : MonoBehaviour
{
    private GameObject[] planeList;
    private int index;
    private Button select;
    private TextMeshProUGUI price;
    public int[] bought;

    // Plane bounce
    public Rigidbody player;
    float bounceForce = 2f;
    float rotateForce = 120f;
    bool goingDown = true;
    bool turning = true;
    bool bounce = true;
    int turn = 0;

    // Başlangıçta tüm kullanıcı atamalarımızı(kullanıcı bilgileri) yapıyoruz
    void Start()
    {
        PlayerPrefs.SetFloat("BestScore", 0f);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("PlayerIndex", 0);
        PlayerPrefs.SetInt("StageCleared", 1);
        PlayerPrefs.SetString("PlaneBought", "1000000000000");
        select = GetComponent<Button>();
        SaveScore.LoadPlayer();
        index = PlayerPrefs.GetInt("PlayerIndex");
        planeList = new GameObject[transform.childCount];

        CharToIntArray();
        
        // Elimizdeki modelleri dizinin içine atıyoruz
        for (int i = 0; i < transform.childCount; i++)
        {
            planeList[i] = transform.GetChild(i).gameObject;
            Debug.Log("Player Index: " + (i+1) + " - " + bought[i]);
        }

        // Tüm modelleri kapatıyoruz
        foreach (GameObject plane in planeList)
        {
            plane.SetActive(false);
        }

        // Kullanıcının seçtiği modeli açıyoruz
        if (planeList[index])
        {
            if (bought[index] == 1)
            {
                planeList[index].SetActive(true);
            }
            else
            {
                index = 0;
                PlayerPrefs.SetInt("PlayerIndex", 0);
                planeList[index].SetActive(true);
            }            
        }
    }

    // Shopta(Market) sol butonuna basınca şuanki modeli kapatıp önceki modeli açan fonksiyon
    public void ToggleLeft()
    {
        // Şuanki modeli kapatıyoruz
        planeList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = planeList.Length - 1;
        }

        // Önceki modeli açıyoruz
        planeList[index].SetActive(true);

        select = GameObject.Find("Select").GetComponent<Button>();
        price = GameObject.Find("Cost").GetComponent<TextMeshProUGUI>();

        // Sahip olunmaya göre alındığı, seçildiği, fiyatı arasında yazıları değiştiriyoruz
        if (bought[index] == 1)
        {
            select.GetComponentInChildren<TextMeshProUGUI>().SetText("Select");

            if (PlayerPrefs.GetInt("PlayerIndex") == index)
            {
                price.SetText("Selected");
            }
            else
            {
                price.SetText("Sold");
            }
        }
        else
        {
            select.GetComponentInChildren<TextMeshProUGUI>().SetText("Buy");
            price.SetText("10 Diamonds");
        }
    }
    
    // Shopta(Market) sağ butonuna basınca şuanki modeli kapatıp sonraki modeli açan fonksiyon
    public void ToggleRight()
    {
        //Şuanki modeli kapatalım.
        planeList[index].SetActive(false);
        index++;
        if (index == planeList.Length)
        {
            index = 0;
        }

        //Sonraki modeli açalım.
        planeList[index].SetActive(true);

        select = GameObject.Find("Select").GetComponent<Button>();
        price = GameObject.Find("Cost").GetComponent<TextMeshProUGUI>();

        // Sahip olunmaya göre alındığı, seçildiği, fiyatı arasında yazıları değiştiriyoruz
        if (bought[index] == 1)
        {
            select.GetComponentInChildren<TextMeshProUGUI>().SetText("Select");
            
            if (PlayerPrefs.GetInt("PlayerIndex") == index)
            {
                price.SetText("Selected");
            }
            else
            {
                price.SetText("Sold");
            }
        }
        else
        {
            select.GetComponentInChildren<TextMeshProUGUI>().SetText("Buy");
            price.SetText("10 Diamonds");
        }
    }

    // Seçim butonuna basılınca çağırılan fonksiyon
    public void SelectButton()
    {
        select = GameObject.Find("Select").GetComponent<Button>();
        price = GameObject.Find("Cost").GetComponent<TextMeshProUGUI>();
        // Satın alınmışsa seçim yapıyoruz
        if (bought[index] == 1)
        {
            PlayerPrefs.SetInt("PlayerIndex", index);
            price.SetText("Selected");
        }
        else if(PlayerPrefs.GetInt("Money") >= 10) // Cüzdanımızda 10 elmastan fazla elmas var ise satın alıyoruz
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.SetInt("PlayerIndex", index);
            select.GetComponentInChildren<TextMeshProUGUI>().SetText("Select");
            price.SetText("Selected");
            bought[index] = 1;
            IntToCharArray();
            SaveScore.SavePlayer();
        }
    }

    // Geri butonuna basınca çağırılan fonksiyon
    public void BackButton()
    {
        // Satın alınmış ve seçilmiş olan en son modeli açan fonksiyon
        if (index != PlayerPrefs.GetInt("PlayerIndex"))
        {
            planeList[index].SetActive(false);
            index = PlayerPrefs.GetInt("PlayerIndex");
            planeList[index].SetActive(true);
        }
        transform.position = new Vector3(0, 4, 3.7f);
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        bounce = true;
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 5, 0);
        SaveScore.SavePlayer();
    }

    // Shop(Market) butonunna basılınca çağırılan fonksiyon
    public void ShopMenu()
    {
        turning = false;
        turn = 0;
        bounce = false;
        SaveScore.LoadPlayer();
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
        transform.position = new Vector3(0, 4.9f, 4);
        transform.eulerAngles = new Vector3(6.5f, 160f, 5f);
        transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 5, 2.1f);
    }
    
    // Kayıtlı dosyamızdan alınan PlaneBougth(Sahip olunan uçak modelleri) stringini bölüp bought int dizisinin içine atan fonksiyon
    private void CharToIntArray()
    {
        char[] myCharArray = PlayerPrefs.GetString("PlaneBought").ToCharArray();
        bought = Array.ConvertAll(myCharArray, c => (int)Char.GetNumericValue(c));
    }
    
    // Bought int dizisindekileri sıralı bir string şekilde PlaneBought'a yazan fonksiyon
    private void IntToCharArray()
    {
        //char[] myCharArray = Array.ConvertAll(bought, c => Convert.ToChar(c));
        PlayerPrefs.SetString("PlaneBought", string.Join("", bought));
        
        Debug.Log("String: " + PlayerPrefs.GetString("PlaneBought"));
    }


    void FixedUpdate()
    {
        // Eğer menü sahnesindeysek ve uçak süzülmesi açık ise uçak modelini yukarı aşağı oynatıp arada 360 derece döndürüyoruz
        if (bounce && SceneManager.GetActiveScene().name == "Menu")
        {
            // 1000de 1 şans ile 360 derece döndürme
            if (UnityEngine.Random.Range(0, 1000) == 1 || turning)
            {
                turning = true;
                player.transform.Rotate(0, 0, rotateForce * Time.deltaTime);
                turn++;
                if (turn == 300)
                {
                    turning = false;
                    turn = 0;
                }
            }

            if (goingDown)
            {
                player.AddForce(0, -bounceForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                if (player.transform.position.y <= 3.7f)
                {
                    goingDown = false;
                }
            }
            if (!goingDown)
            {
                player.AddForce(0, bounceForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                if (player.transform.position.y >= 3.8f)
                {
                    goingDown = true;
                }
            }
        }
    }
}

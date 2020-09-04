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
using UnityEngine;
using UnityEngine.SceneManagement;

// Bu sınıfımızı sahne geçişleri ve elmas sayılarını tutmak için kullanıyoruz
public class GameManager : MonoBehaviour
{
    public Rigidbody player;
    public GameObject completeLevelUI;
    public int stageNumber;
    public int diamondTotal = 0;
    public int diamondSpawned = 0;
    public float width;
    public float height;
    private int[] stars;

    void Start()
    {
        SaveScore.LoadPlayer();
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;
    }

    // Seviye tamamlanınca çağırılan fonksiyon
    public void CompleteLevel()
    {
        CharToIntArray();
        // Seviye tamamlandıyse 1 yıldız, en az 1 elmas toplandı ise 2 yıldız, tüm elmaslar toplandı ise 3 yıldız atıyoruz
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == stageNumber-1)
            {
                stars[i] = 1;
                if (diamondTotal >= 1)
                {
                    stars[i] = 2;
                }
                if (diamondTotal == diamondSpawned)
                {
                    stars[i] = 3;
                }
            }
        }
        IntToCharArray();
        // Bir sonraki seviyeyi açıyoruz
        if (PlayerPrefs.GetInt("StageCleared") <= stageNumber)
        {
            PlayerPrefs.SetInt("StageCleared", stageNumber + 1);
        }
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + diamondTotal);
        Debug.Log("Game manager içi diamond toplamı: " + diamondTotal);
        SaveScore.SavePlayer();
        completeLevelUI.SetActive(true);
    }
    
    // Menüye dönme butonuna basıldığında çağırılan fonksiyon
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Retry(Tekrar dene) butonuna basıldığında çağırılan fonksiyon
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Kayıtlı dosyamızdan alınan StageStars(Bölümlerde kazanılan yıldızlar) stringini bölüp stars int dizisinin içine atan fonksiyon
    private void CharToIntArray()
    {
        char[] myCharArray = PlayerPrefs.GetString("StageStars").ToCharArray();
        stars = Array.ConvertAll(myCharArray, c => (int)Char.GetNumericValue(c));
    }

    // Stars int dizisindekileri sıralı bir string şekilde StageStars'a yazan fonksiyon
    private void IntToCharArray()
    {
        PlayerPrefs.SetString("StageStars", string.Join("", stars));
    }
}

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
using UnityEngine.UI;

// Bu sınıfımızda menüdeki butonlarımızın yapmasını istediğimiz fonksiyonları tutuyoruz
public class MenuScript : MonoBehaviour
{
    public Button[] buttons;
    private int[] stars;
    private GameObject star1;
    private GameObject star2;
    private GameObject star3;

    // Kullanıcının kaldığı bölüme kadar butonları açan fonksiyon
    public void EnableButtons()
    {
        // Tüm butonları kapatıyoruz
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        Debug.Log("Stage: " + PlayerPrefs.GetInt("StageCleared"));

        // Kalınan bölüme kadar olan butonları açıyoruz
        for (int i = 0; i < PlayerPrefs.GetInt("StageCleared"); i++)
        {
            buttons[i].interactable = true;
            Debug.Log("Stage: " + PlayerPrefs.GetInt("StageCleared"));
        }
    }

    // Kullanıcının bölümlerde kazandığı yıldızları açan fonksiyon
    public void EnableStars()
    {
        // Tüm bölüm butonların üzerindeki yıldızları kapatıyoruz
        foreach (Button button in buttons)
        {
            star1 = button.transform.Find("Star1").gameObject;
            star2 = button.transform.Find("Star2").gameObject;
            star3 = button.transform.Find("Star3").gameObject;
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        Debug.Log("StageStars: " + PlayerPrefs.GetString("StageStars"));
        CharToIntArray();
        // Kazanılan yıldızları açıyoruz.
        for (int i = 0; i < buttons.Length; i++)
        {
            star1 = buttons[i].transform.Find("Star1").gameObject;
            star2 = buttons[i].transform.Find("Star2").gameObject;
            star3 = buttons[i].transform.Find("Star3").gameObject;
            if (stars[i] == 1)
            {
                star2.SetActive(true);
            }
            else if (stars[i] == 2)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }
            else if (stars[i] == 3)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
        }
    }

    // Verilen sayıya göre bölümü açan fonksiyon
    public void PlayStage(int stage)
    {
        SceneManager.LoadScene(stage);
    }

    // Çıkış butonuna basılınca çağırılan fonksiyon
    public void Quit()
    {
        if (SaveScore.SavePlayer())
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("QUIT!");
            Application.Quit();
        }
    }

    

    // Kayıtlı dosyamızdan alınan StageStars(Bölümlerde kazanılan yıldızlar) stringini bölüp stars int dizisinin içine atan fonksiyon
    private void CharToIntArray()
    {
        char[] myCharArray = PlayerPrefs.GetString("StageStars").ToCharArray();
        stars = Array.ConvertAll(myCharArray, c => (int)Char.GetNumericValue(c));
    }
}

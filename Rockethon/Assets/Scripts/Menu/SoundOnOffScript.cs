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
using UnityEngine.UI;

// Bu sınıfta müziği açıp kapatıyoruz ve bunlara uyan resimleri atıyoruz
public class SoundOnOffScript : MonoBehaviour
{
    private Button button;
    public Sprite soundOn;
    public Sprite soundOff;
    private bool isSoundOn;

    // Start is called before the first frame update
    void Start()
    {
        isSoundOn = true;
        button = GetComponent<Button>();
    }

    // Ses açma ve kapama butonuna basıldığında butonun üzerindeki resmi değiştiren ve sesi kapatıp açan fonksiyon.
    public void ChangeButtonSprite()
    {
        if (isSoundOn)
        {
            FindObjectOfType<AudioManager>().ChangeVolume("Theme",isSoundOn);
            button.image.overrideSprite = soundOff;
            isSoundOn = false;
        }
        else
        {
            FindObjectOfType<AudioManager>().ChangeVolume("Theme", isSoundOn);
            button.image.overrideSprite = soundOn;
            isSoundOn = true;
        }
    }
}

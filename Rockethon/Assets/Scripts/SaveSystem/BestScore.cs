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

// Bu sınıfımızı kullanıcının oyun içinde bilgilerini tutmak için kullanıyoruz
[System.Serializable]
public class BestScore
{
    public int planeIndex;
    public float bestScore;
    public int diamondCount;
    public string planeBought;
    public int stageCleared;
    public string stageStars;

    // Kayıt edilmesi gereken tüm kullanıcı bilgilerini tutan sınıfımızın kurucu fonksiyonu
    public BestScore(float player, int money, int index, string bought, int stage, string stars)
    {
        bestScore = player;
        diamondCount = money;
        planeIndex = index;
        planeBought = bought;
        stageCleared = stage;
        stageStars = stars;
    }
}

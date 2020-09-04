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
using TMPro;

// Bu sınıfımızı cüzdanımızdaki elmas sayısını değiştirmek için kullanıyoruz
public class Wallet : MonoBehaviour
{
    public TextMeshProUGUI wallet;

    // Shop(Market) kısmımızdaki cüzdanımızı değiştiren Update fonksiyonu
    private void Update()
    {
        wallet.SetText("Wallet\n" + PlayerPrefs.GetInt("Money").ToString() + " Diamonds");
    }

}

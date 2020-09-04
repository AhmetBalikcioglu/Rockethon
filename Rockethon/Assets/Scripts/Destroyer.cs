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

// Bu sınıfımızı cisimleri silmek için kullanıyoruz
public class Destroyer : MonoBehaviour
{
    private float lifeTime = 8f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}

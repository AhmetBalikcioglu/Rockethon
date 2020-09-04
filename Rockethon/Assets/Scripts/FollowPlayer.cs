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

// Bu sınıfımızı kameranın uçağı takip etmesi için kullanıyoruz
public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(2*player.position.x/3, 2 + 2*player.position.y/3, transform.position.z);
    }
}

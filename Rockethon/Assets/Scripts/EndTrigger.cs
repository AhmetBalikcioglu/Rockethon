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

// Bu sınıfımızı Seviyeleri kazandığımızı belirlemek için kullanıyoruz
public class EndTrigger : MonoBehaviour
{
    // End(Son) cismine çarpıldığında çağırılan fonksiyon
    void OnTriggerEnter()
    {
        GameManager gm = (GameManager)FindObjectOfType<GameManager>();
        if (gm)
        {
            gm.CompleteLevel();
            Destroy(gameObject);
            Debug.Log("ENDDDDD");
        }
        else
        {
            Debug.Log("END YOKKK");
        }
        
    }
}

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

// Bu sınıfımızı uçağımız hariç tüm cisimleri hareket ettirmek için kullanıyoruz
public class Movement : MonoBehaviour
{
    private float speed = 4f;
    private float rotateSpeed = 20f;
    private bool glassOut = false;

    // Başlangıçta 15 ile 26 arasında rastgele bir dönüş hızı belirliyoruz
    void Awake()
    {
        int rand = Random.Range(15, 26);
        rotateSpeed = (float)rand;
    }

    private void FixedUpdate()
    {
        // Sürekli cisimleri uçağımıza doğru hareket ettiriyoruz
        transform.Translate(0, 0, -10f * speed * Time.deltaTime,Space.World);
        
        // Eğer cismimizin etiketi TurnObstacle(DönenEngel) ise döndürüyoruz
        if (gameObject.tag == "TurnObstacle")
        {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));
        }
        else if (gameObject.tag == "GlassObstacle") // Eğer cismimizin etiketi GlassObstacle(CamEngel) ise yukarı aşağı hareket ettiriyoruz
        {
            if (!glassOut)
            {
                transform.Translate(0, 2f * Time.deltaTime, 0);
                if (transform.position.y >= 8.5f)
                {
                    glassOut = true;
                }

            }
            else if (glassOut)
            {
                transform.Translate(0, -2f * Time.deltaTime, 0);
                if (transform.position.y <= 1.5f)
                {
                    glassOut = false;
                }
            }
        }
    }

}

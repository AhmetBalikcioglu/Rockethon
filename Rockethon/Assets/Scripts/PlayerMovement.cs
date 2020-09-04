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

using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

// Bu sınıfımızda kullanıcı kontrollerini kontrol edip uçağımızı girişlere göre oynatıyoruz
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public GameManager gm;

    public float sidewaysForce = 50f;

    float smooth = 5.0f;
    float tiltAngle = 20.0f;
    
    Touch touch;

    // Update is called once per frame
    void FixedUpdate()
    {
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Telefon dokunmatik girişlerini kontrol ediyoruz
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                player.transform.position = new Vector3(
                    PositionLimit(player.transform.position.x + (6 * touch.deltaPosition.x) / gm.width, 4.1f, true),
                    PositionLimit(player.transform.position.y + (3 * touch.deltaPosition.y) / gm.height, 9.5f, false),
                    player.transform.position.z);
            }
        }

        // Bilgisayar girişlerini kontrol ediyoruz
        if (Input.GetKey("d"))
        {
            player.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            player.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("w"))
        {
            player.AddForce(0, sidewaysForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            player.AddForce(0, -sidewaysForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        Quaternion target = Quaternion.Euler(-tiltAroundX, 0, -tiltAroundZ);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, target, Time.deltaTime * smooth);
    }

    // Dokunmatik sensör ile oyun alanından çıkmamak için limit belirliyoruz
    private float PositionLimit(float position, float limit, bool x)
    {
        if (x)
        {
            if (position <= -limit)
            {
                return -limit;
            }
            else if (position >= limit)
            {
                return limit;
            }
            else
                return position;
        }
        else
        {
            if (position <= 0.5f)
            {
                return 0.5f;
            }
            else if (position >= limit)
            {
                return limit;
            }
            else
                return position;
        }
    }
}

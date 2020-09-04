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

// Bu sınıfımızı ışıkların ve haritadaki sisin rengini değiştirmek için kullanıyoruz
public class RGBLight : MonoBehaviour
{
    private float redLightFactor = 146f;
    private float greenLightFactor = 255f;
    private float blueLightFactor = 255f;
    private float redFogFactor = 42f;
    private float greenFogFactor = 90f;
    private float blueFogFactor = 90f;

    private float speed = 50f;
    // Light that should be controlled by the LightController
    public Light controlledLight = null;
    private Light ourLight;
    private int goingDownLight = 0;
    private int goingDownFog = 0;

    void Start()
    {
        ourLight = controlledLight.GetComponent<Light>(); // Get the Light component
    }

    void Update()
    {
        if (goingDownFog == 0)
        {
            greenFogFactor -= Time.deltaTime * speed /2.27f;
            if (greenFogFactor <= 42f)
            {
                goingDownFog = 1;
            }
        }
        else if (goingDownFog == 1)
        {
            redFogFactor += Time.deltaTime * speed / 2.27f;
            if (redFogFactor >= 90f)
            {
                goingDownFog = 2;
            }
        }
        else if (goingDownFog == 2)
        {
            blueFogFactor -= Time.deltaTime * speed / 2.27f;
            if (blueFogFactor <= 42f)
            {
                goingDownFog = 3;
            }
        }
        else if (goingDownFog == 3)
        {
            greenFogFactor += Time.deltaTime * speed / 2.27f;
            if (greenFogFactor >= 90f)
            {
                goingDownFog = 4;
            }
        }
        else if (goingDownFog == 4)
        {
            redFogFactor -= Time.deltaTime * speed / 2.27f;
            if (redFogFactor <= 42f)
            {
                goingDownFog = 5;
            }
        }
        else if (goingDownFog == 5)
        {
            blueFogFactor += Time.deltaTime * speed / 2.27f;
            if (blueFogFactor >= 90f)
            {
                goingDownFog = 0;
            }
        }

        if (goingDownLight == 0)
        {
            greenLightFactor -= Time.deltaTime * speed;
            if (greenLightFactor <= 146f)
            {
                goingDownLight = 1;
            }
        }
        else if (goingDownLight == 1)
        {
            redLightFactor += Time.deltaTime * speed;
            if (redLightFactor >= 255f)
            {
                goingDownLight = 2;
            }
        }
        else if (goingDownLight == 2)
        {
            blueLightFactor -= Time.deltaTime * speed;
            if (blueLightFactor <= 146f)
            {
                goingDownLight = 3;
            }
        }
        else if (goingDownLight == 3)
        {
            greenLightFactor += Time.deltaTime * speed;
            if (greenLightFactor >= 255f)
            {
                goingDownLight = 4;
            }
        }
        else if (goingDownLight == 4)
        {
            redLightFactor -= Time.deltaTime * speed;
            if (redLightFactor <= 146f)
            {
                goingDownLight = 5;
            }
        }
        else if (goingDownLight == 5)
        {
            blueLightFactor += Time.deltaTime * speed;
            if (blueLightFactor >= 255f)
            {
                goingDownLight = 0;
            }
        }
        // Yeni ışık rengini atama
        if (controlledLight != null)
        { // If we have a light as a field
            Color lightColors = new Color();
            lightColors.r = redLightFactor / 255f;
            lightColors.g = greenLightFactor / 255f;
            lightColors.b = blueLightFactor / 255f;
            lightColors.a = 1f;
            ourLight.color = lightColors;
        }
        // Yeni sis rengini atama
        if (RenderSettings.fog == true)
        { // If we have a light as a field
            Color fogColors = new Color();
            fogColors.r = redFogFactor / 255f;
            fogColors.g = greenFogFactor / 255f;
            fogColors.b = blueFogFactor / 255f;
            fogColors.a = 1f;
            RenderSettings.fogColor = fogColors;
        }
    }
}

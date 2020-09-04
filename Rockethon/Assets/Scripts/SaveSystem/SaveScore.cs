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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Bu sınıfımızı kullanıcımızın oyunda bilgilerini dosyaya şifreleyip kaydetme veya deşifreleyip atama yapmak için kullanıyoruz
public static class SaveScore
{
    // BestScore adlı sınıfımızdaki bilgileri(Kullanıcı bilgileri) bir dosyaya şifreleyip kayıt eden fonksiyon
    public static bool SavePlayer()
    {
        if (PlayerPrefs.GetString("PlaneBought") == "")
        {
            return false;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "score.fun");
        FileStream stream = new FileStream(path, FileMode.Create);

        BestScore data = new BestScore(PlayerPrefs.GetFloat("BestScore"), PlayerPrefs.GetInt("Money"), PlayerPrefs.GetInt("PlayerIndex"), PlayerPrefs.GetString("PlaneBought"), PlayerPrefs.GetInt("StageCleared"), PlayerPrefs.GetString("StageStars"));

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Save Listesi\n------------\nBest Score: " + PlayerPrefs.GetFloat("BestScore") + "\nMoney: " + PlayerPrefs.GetInt("Money") + "\nPlane Index: " + PlayerPrefs.GetInt("PlayerIndex") + "\nPlane Bought: " + PlayerPrefs.GetString("PlaneBought") + "\nStage Cleared: " + PlayerPrefs.GetInt("StageCleared") + "\nStage Stars: " + PlayerPrefs.GetString("StageStars"));
        return true;
    }

    // Varsa şifrelenip kayıt edilen kullanıcı bilgilerini deşifre edip atama yapan, yoksa bu bilgileri ilk oyun halinde atayan fonksiyon
    public static BestScore LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "score.fun");
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            BestScore data = formatter.Deserialize(stream) as BestScore;
            Debug.Log(path);
            stream.Close();
            PlayerPrefs.SetInt("Money", data.diamondCount);
            PlayerPrefs.SetFloat("BestScore", data.bestScore);
            PlayerPrefs.SetInt("PlayerIndex", data.planeIndex);
            PlayerPrefs.SetInt("StageCleared", data.stageCleared);
            PlayerPrefs.SetString("StageStars", data.stageStars);

            if (data.planeBought == null)
            {
                Debug.Log("PlaneBought null ");
                PlayerPrefs.SetString("PlaneBought", "1000000000000");
            }
            else
            {
                PlayerPrefs.SetString("PlaneBought", data.planeBought);
                Debug.Log("PlaneBought: " + PlayerPrefs.GetString("PlaneBought"));
            }
            if (PlayerPrefs.GetInt("StageCleared") < 1)
            {
                PlayerPrefs.SetInt("StageCleared", 1);
            }
           
            return data;
        }
        else
        {
            PlayerPrefs.SetFloat("BestScore", 0f);
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("PlayerIndex", 0);
            PlayerPrefs.SetInt("StageCleared", 1);
            PlayerPrefs.SetString("PlaneBought", "1000000000000");
            PlayerPrefs.SetString("StageStars", "000000000000000");
            Debug.LogError("Save file not found in " + path);

            return null;
        }
    }

    // Çıkış butonu haricinde çıkış yapılırsa çağırılan fonksiyon
    static void Quit()
    {
        if (SavePlayer())
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("QUITTEDDD!!!!");
        }
    }

    // Çıkış yapıldığında Quit fonksiyonunu çağıran fonksiyon
    [RuntimeInitializeOnLoadMethod]
    static void RunOnStart()
    {
        Application.quitting += Quit;
    }
}
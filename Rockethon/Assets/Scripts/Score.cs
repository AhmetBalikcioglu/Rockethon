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
using UnityEngine.UI;

// Bu sınıfımızı skor tablolarımızı düzenlemek, skorlarımızı kaydetmek için kullanıyoruz
public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text travelScoreText;
    public GameObject gameOverPanel;
    public GameObject inGameScore;
    public Text endScoreText;
    public Text endDiamondText;
    public Text bestScoreText;
    public Text gameOverText;
    public float score = 0;
    public GameManager gameManager;
    private float time;
    public bool speedRun = false;
    
    
    void Update()
    {
        // SpeedRun modunda mıyız kontrol ediyoruz eğer öyle ise süre bazında skor ve toplanılan elmas sayılarını yazdırıyoruz
        if (speedRun)
        {
            scoreText.text = "Diamond\n" + gameManager.diamondTotal.ToString();
            time += Time.deltaTime;
            if (player.gameObject.active)
            {
                score = (time * 30);
                travelScoreText.text = "Travelled\n" + score.ToString("0");
            }
            else
            {
                inGameScore.SetActive(false);
                gameOverPanel.SetActive(true);
                SaveBiggestScore();
                endScoreText.text = "Score: " + score.ToString("0");
                endDiamondText.text = "Diamonds Collected: " + gameManager.diamondTotal.ToString();
                bestScoreText.text = "Best Score: " + PlayerPrefs.GetFloat("BestScore").ToString("0");
            }
        }
        else // Değil ise sadece elmas sayısını yazdırıyoruz
        {
            if (player.gameObject.active)
            {
                scoreText.text = gameManager.diamondTotal.ToString();
            }
            else
            {
                inGameScore.SetActive(false);
                gameOverPanel.SetActive(true);
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + gameManager.diamondTotal);
                SaveScore.SavePlayer();
                endDiamondText.text = "Diamonds Collected: " + gameManager.diamondTotal.ToString();
            }
        }
    }

    // Kullanıcının en yüksek skorunu karşılaştırıyoruz ve kayıtlarımızı yapıyoruz
    public void SaveBiggestScore()
    {
        if (score > PlayerPrefs.GetFloat("BestScore"))
        {
            gameOverText.text = "This is your best run yet!";
            PlayerPrefs.SetFloat("BestScore", score);
        }
        else
        {
            gameOverText.text = "Game Over!";
        }
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + gameManager.diamondTotal);
        SaveScore.SavePlayer();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class LevelEndMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject nextLevelButton;
    public Text levelClearedFailedText;
    public Text currencyGained;

    public GameObject SaveMoney;

    bool endCheck = false;
    bool defeat = false;

    public static int highestClearedLevel = 1;
    public int actualLevel;
    public int levelCurrencyGained;

    /*public string menuSceneName = "MainMenu";
    ScreenFader screenFader;

    public ScreenFader screenFader;
    public string menuSceneName = "MainMenu";*/

    public void Victory()
    {
        MobileCameraControlBackup.gameEnd = true;
        Health.gameOver = true;
        if (defeat == false)
        {
            ui.SetActive(true);
            levelClearedFailedText.text = "Cleared";
            currencyGained.text = "Got " + levelCurrencyGained + " currency";
            nextLevelButton.SetActive(true);
            if (highestClearedLevel <= actualLevel)
            highestClearedLevel ++;
            TurretLevelUp.upgradeCurrency += levelCurrencyGained;
        }
        
        
    }
    public void Defeat()
    {
        MobileCameraControlBackup.gameEnd = true;
        Health.gameOver = true;
        ui.SetActive(true);
        levelClearedFailedText.text = "Failed";
        nextLevelButton.SetActive(false);
        if (ui.activeSelf)
        {
            if (endCheck == false)
            {
                // Time.timeScale = 0f;
                defeat = true;
                endCheck = true;
            }
            
        }
    }
    public void SaveLevelProgress()
    {
        SaveSystem.SaveLevelProgress(this);
    }

    public void LoadLevelProgress()
    {
        SaveData data = SaveSystem.LoadData();

        highestClearedLevel = data.currentLevel;
    }

}

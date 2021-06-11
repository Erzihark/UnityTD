using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public ScreenFader screenFader;

    public Button[] levelButtons;

    public static LevelEndMenu levelProgress;

    private void Start()
    {
        int levelReached = LevelEndMenu.highestClearedLevel;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i+1 > levelReached)
            levelButtons[i].interactable = false;
        }
    }

    public void SelectLevel(string levelName)
    {
        screenFader.FadeTo(levelName);
    }


}

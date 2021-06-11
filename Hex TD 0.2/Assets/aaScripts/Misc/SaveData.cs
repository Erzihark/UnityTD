
[System.Serializable]
public class SaveData 
{
    public int currentLevel;

   public SaveData (LevelEndMenu save) //This is a constructor, it initializes objects of a class
                                      // this one in particular is parameterized
    {
        currentLevel = LevelEndMenu.highestClearedLevel;
    }
}

using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public GameObject selectButton;
    public GameObject deselectButton;

   public void Select()
    {
        if (LoadoutMenu.turretsSelected < (LoadoutMenu.turretQuantity + LoadoutMenu.turretsSelected))
        {
            selectButton.SetActive(false);
            deselectButton.SetActive(true);
        }
        
    }

   public void Deselect()
    {
        if (LoadoutMenu.turretsSelected > 0)
        {
            selectButton.SetActive(true);
            deselectButton.SetActive(false);
        }
        
    }

    public void Apply()
    {
        deselectButton.SetActive(false);
        selectButton.SetActive(true);
    }
 
}

using UnityEngine;
using UnityEngine.UI;

public class colorSelectButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;
    public bool isColorPlayer = false;

    public void onButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            saveController.instance.colorPlayer = paddleReference.color;
        }
        else
        {
            saveController.instance.colorEnemy = paddleReference.color;
        }
    }
}

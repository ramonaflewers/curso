using UnityEngine;
using TMPro;

public class mainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;

    void Start()
    {
        string lastWinner = saveController.instance.GetLastWinner();

        if (!string.IsNullOrEmpty(lastWinner))
        {
            uiWinner.text = "Último vencedor: " + lastWinner;
        }
        else
        {
            uiWinner.text = "";
        }

        saveController.instance.reset();
    }
}

using UnityEngine;
using TMPro;

public class InputName : MonoBehaviour
{
    public bool isPlayer1;
    public TMP_InputField InputField;

    private void Start(){
        InputField.onValueChanged.AddListener(UpdateName);
    }

    public void UpdateName(string name){
        if (isPlayer1){
            saveController.instance.namePlayer = name;
        }
        else{
            saveController.instance.nameEnemy = name;
        }
    }
}

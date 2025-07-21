using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void ClearData(){
        saveController.instance.ClearSave();
    }
}

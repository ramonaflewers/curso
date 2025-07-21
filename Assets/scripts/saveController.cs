using UnityEngine;
using UnityEngine.SceneManagement;

public class saveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    private static saveController _instance;

    public string namePlayer;
    public string nameEnemy;

    public static saveController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<saveController>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(saveController).Name);
                    _instance = singletonObject.AddComponent<saveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SavedWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner", "");
    }

    public void ClearSave(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    internal ObjController LastSelected;
    internal ObjController CurrentSelected;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void SceneLoad() 
    {
        SceneManager.LoadScene(1);
    }
}

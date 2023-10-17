using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public container container;

    private void Awake()
    {
        /*if (Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
            return;
        }*/

        Instance = this;
    }
}

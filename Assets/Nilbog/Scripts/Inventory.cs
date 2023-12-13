using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Sprite SetUpSprite;
    //public static Inventory instance;

    void Awake()
    {
        /*if (instance == null) instance = this;
        else Destroy(gameObject);*/
    }

    public void AddImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image Image;
    public Sprite SetUpSprite;
    public static Inventory instance;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddImage(Sprite sprite)
    {
        Image.sprite = sprite;
    }
}

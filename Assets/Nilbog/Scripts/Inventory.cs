using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image Image;

    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void AddImage(Sprite sprite)
    {
        Image.sprite = sprite;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class container : MonoBehaviour
{
    public Image Image;

    public static container Instance;

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

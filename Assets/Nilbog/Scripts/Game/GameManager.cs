using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour//, IPointerClickHandler
{
    public static GameManager Instance;
    internal SceneManaging sceneManaging;

    internal Objects LastSelected;
    internal Objects CurrentSelected;

    private int scene;
    private int actualScene;

    public static int Count;
    public int numb;

    internal GameObject TipsCanvas;

    //public GameObject DefeatMenu;

    private void Start()
    {
        UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;

        //CurrentSelected = null;
        //LastSelected = null;

        //Inventory.instance.AddImage();

        actualScene = SceneManaging.Instance.scene.buildIndex;

        Debug.Log($"Cena de agora: {actualScene}");

        if (Instance == null)
        {
            InstanceBasics();
            Debug.Log(numb);
        }
        else
        {
            if (actualScene != GameObject.FindWithTag("GameManager").GetComponent<GameManager>().scene)
            {
                Destroy(GameObject.FindWithTag("GameManager"));
                InstanceBasics();
                numb = 0;
                Debug.Log(numb);
            }
            else if (!CompareTag("GameManager"))
            {
                numb = ++Count;
                Debug.Log(numb);
                Destroy(gameObject);
                GameObject[] tips = GameObject.FindGameObjectsWithTag("TipsCanvas");
                foreach (GameObject t in tips)
                {
                    t.SetActive(false);
                }
                GameObject.FindWithTag("ButtonHelpCanvas").GetComponent<TipsButton>().status = false;
                //GameObject.FindWithTag("InventoryImage").GetComponent<Image>().sprite = Inventory.instance.SetUpSprite;
                CurrentSelected = null;
                LastSelected = null;
            }
        }
    }

    private void InstanceBasics()
    {
        Instance = this;
        gameObject.tag = "GameManager";
        scene = SceneManaging.Instance.scene.buildIndex;
        //GameObject.FindWithTag("InventoryImage").GetComponent<Image>().sprite = Inventory.instance.SetUpSprite;
        DontDestroyOnLoad(gameObject);
        LastSelected = null;
        CurrentSelected = null;
    }

    /*public void Update()
    {
        if (!GameObject.FindGameObjectWithTag("DefeatMenu"))
            Inventory.instance.AddImage(CurrentSelected.GetComponent<InteractiveObjects>().objInfo.sprite);
        else
            Inventory.instance.AddImage(CurrentSelected.GetComponent<InteractiveObjects>().objInfo.sprite_2);
    }*/

    public void ChangeImageCanvas()
    {
        if (GameObject.FindGameObjectWithTag("DefeatMenu"))
            GameObject.FindGameObjectWithTag("InventoryImage").GetComponent<Image>().sprite =
                CurrentSelected.GetComponent<InteractiveObjects>().objInfo.sprite_2;
        if (!GameObject.FindGameObjectWithTag("DefeatMenu"))
            GameObject.FindGameObjectWithTag("InventoryImage").GetComponent<Image>().sprite =
                CurrentSelected.GetComponent<InteractiveObjects>().objInfo.sprite;
    }
}

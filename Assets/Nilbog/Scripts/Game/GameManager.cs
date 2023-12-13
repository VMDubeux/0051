using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
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

    //private Canvas Derrota;
    public Sprite Image;

    private void Start()
    {
        UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;

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
        DontDestroyOnLoad(gameObject);
        LastSelected = null;
        CurrentSelected = null;
    }

    private void Update()
    {
        if (FindObjectOfType<Canvas>().CompareTag("DefeatMenu"))
            Inventory.instance.AddImage(Image);
    }
}

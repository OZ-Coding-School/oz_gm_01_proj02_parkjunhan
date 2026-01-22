using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    #region field
    public static InteractionManager Instance { get; private set; }

    [Header("CharactorUI")]
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject shopUI;
    public bool isActive = false;
    #endregion

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerUI = GameObject.Find("GameObject/Canvas/UI/PlayerUI");

        if (playerUI.activeInHierarchy) playerUI.SetActive(false);
    }

    void Update()
    {
        PressKeyCheck();
    }

    #region method
    void PressKeyCheck()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerUI.SetActive(!playerUI.activeSelf);
            isActive = !isActive;
        }
    }
    #endregion
}

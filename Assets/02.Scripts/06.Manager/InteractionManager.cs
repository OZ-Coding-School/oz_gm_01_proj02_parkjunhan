using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    #region field
    public static InteractionManager Instance { get; private set; }

    [Header("CharactorUI")]
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject shopUI;
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
        shopUI = GameObject.Find("GameObject/Canvas/UI/ShopUI");

        if (playerUI.activeInHierarchy) playerUI.SetActive(false);
        if (shopUI.activeInHierarchy) shopUI.SetActive(false);
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
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            shopUI.SetActive(!shopUI.activeSelf);
            if (!playerUI.activeSelf) playerUI.SetActive(true);
            if (!shopUI.activeSelf) playerUI.SetActive(false);
        }
    }
    #endregion
}

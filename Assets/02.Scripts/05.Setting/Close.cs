using UnityEngine;

public class Close : MonoBehaviour
{
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject shopUI;

    private void Awake()
    {
        playerUI = GameObject.Find("GameObject/Canvas/UI/PlayerUI");
        shopUI = GameObject.Find("GameObject/Canvas/UI/ShopUI");
    }

    public void ClosePlayerUI()
    {
        playerUI.SetActive(false);
        InteractionManager.Instance.isActive = !InteractionManager.Instance.isActive;
    }

    public void CloseShopUI()
    {
        playerUI.SetActive(false);
        shopUI.SetActive(false);
        InteractionManager.Instance.isActive = !InteractionManager.Instance.isActive;
    }
}

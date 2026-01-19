using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    #region field
    public static InteractionManager Instance { get; private set; }

    [Header("상호작용 UI")]
    [SerializeField] Equipment equipment;
    [SerializeField] Inventory inventory;
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

        inventory = FindObjectOfType<Inventory>(true);
        equipment = FindObjectOfType<Equipment>(true);
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
            inventory.inventoryUI.SetActive(!inventory.inventoryUI.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            equipment.equipmentUI.SetActive(!equipment.equipmentUI.activeSelf);
        }
    }
    #endregion
}

using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Tilemap))]
public class PlayerController : MonoBehaviour
{
    #region field
    [SerializeField] public float moveSpeed = 3.0f;
    Vector3 inputPos;
    Vector3 targetWorldPos;
    Vector3Int cellPos;

    //컴포넌트
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Tilemap tilemap;

    //안개
    [SerializeField] Tilemap fog;
    [SerializeField] int vision = 3;

    //애니메이션
    static readonly int moveHash = Animator.StringToHash("Move");
    bool isMoving;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

    void Update()
    {
        if (!InteractionManager.Instance.isActive)
        {
            Move();
        }
    }

    #region method
    public void Move()
    {
        if (Input.GetMouseButton(0))
        {
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            inputPos.z = 0f;

            Debug.Log($"inputPos = {inputPos}");

            cellPos = tilemap.WorldToCell(inputPos);

            if (tilemap.HasTile(cellPos))
            {
                targetWorldPos = tilemap.GetCellCenterWorld(cellPos);
            }
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetWorldPos,
            moveSpeed * Time.deltaTime
            );

        float distance = Vector2.Distance(transform.position, inputPos);

        isMoving = distance > 0.01f;
        anim.SetBool(moveHash, isMoving);

        direction();
        UpdateFog();
    }

    void direction()
    {
        if (transform.position.x >= 0 && transform.position.x < inputPos.x)
        {
            sr.flipX = false;
        }
        else if (transform.position.x >= 0 && transform.position.x > inputPos.x)
        {
            sr.flipX = true;
        }
        else if (transform.position.x < 0 && transform.position.x < inputPos.x)
        {
            sr.flipX = false;
        }
        else if (transform.position.x < 0 && transform.position.x > inputPos.x)
        {
            sr.flipX = true;
        }
    }

    void UpdateFog()
    {
        Vector3Int currentPlayerTile = fog.WorldToCell(transform.position);

        for (int x = -vision; x <= vision; x++)
        {
            for (int y = -vision; y <= vision; y++)
            {
                fog.SetTile(currentPlayerTile + new Vector3Int(x, y, 0), null);
            }
        }
    }
    #endregion
}
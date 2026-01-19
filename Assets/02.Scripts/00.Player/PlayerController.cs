using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    #region field
    [SerializeField] public float moveSpeed = 3.0f;
    Vector3 inputPos;

    //컴포넌트
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    //안개
    [SerializeField] Tilemap fog;
    [SerializeField] int vision = 1;

    //애니메이션
    static readonly int moveHash = Animator.StringToHash("Move");
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    #region method
    public void Move()
    {
        if (Input.GetMouseButton(0))
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = Vector2.MoveTowards(
            transform.position,
            inputPos,
            moveSpeed * Time.deltaTime
            );

        if (transform.position.x != inputPos.x && transform.position.y != inputPos.y)
        {
            anim.SetBool(moveHash, true);
        }
        else if (transform.position.x == inputPos.x && transform.position.y == inputPos.y)
        {
            anim.SetBool(moveHash, false);
        }

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
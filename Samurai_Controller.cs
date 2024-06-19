using UnityEngine;

public class SamuraiController : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 설정

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float jumpForce = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
     
    void Update()
    {
        // 방향키 입력을 받습니다.
        float moveInput = Input.GetAxisRaw("Horizontal");

        // 입력에 따라 방향을 설정합니다.
        Vector3 moveDirection = Vector3.right * moveInput;

        // 캐릭터 회전 처리
        if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // 왼쪽으로 이동 시 캐릭터를 좌우 반전합니다.
        }
        else if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // 오른쪽으로 이동 시 캐릭터를 좌우 반전을 해제합니다.
        }

        // 현재 위치에서 방향과 속도를 곱한 만큼 이동합니다.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 이동 여부에 따라 walk 애니메이션을 제어합니다.
        if (moveInput != 0f)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        if (Input.GetButtonDown("Jump")) // 예를 들어 스페이스바를 점프 버튼으로 설정
        {
            animator.SetTrigger("jump1");
            // jump2 애니메이션을 트리거합니다.
            animator.SetTrigger("jump2");
            
            // 플레이어의 y값을 증가시켜 점프 효과를 줍니다.
            Jump();

            animator.SetTrigger("jump3");
            Down();
            
        } // 플레이어 오브젝트에 있는 Animator 컴포넌트 가져오기
    }
    void Jump()
    {
        // 플레이어의 현재 위치에 점프 힘을 추가하여 y값을 증가시킵니다.
        // 여기서는 간단히 예시로 transform.Translate을 사용하겠습니다.
        transform.Translate(Vector3.up*10 * jumpForce * Time.deltaTime);
    }
    void Down(){
        transform.Translate(-Vector3.up*10 * jumpForce * Time.deltaTime);
        animator.SetTrigger("idle");
    }
}
/*using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // 점프에 사용될 힘의 크기
    private Animator animator; // 플레이어 애니메이터 컴포넌트

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump")) // 예를 들어 스페이스바를 점프 버튼으로 설정
        {
            animator.SetTrigger("jump1");
            // jump2 애니메이션을 트리거합니다.
            animator.SetTrigger("jump2");
            
            // 플레이어의 y값을 증가시켜 점프 효과를 줍니다.
            Jump();

            animator.SetTrigger("jump3");
            Down();
            
        } // 플레이어 오브젝트에 있는 Animator 컴포넌트 가져오기
    }
    void Jump()
    {
        // 플레이어의 현재 위치에 점프 힘을 추가하여 y값을 증가시킵니다.
        // 여기서는 간단히 예시로 transform.Translate을 사용하겠습니다.
        transform.Translate(Vector3.up*10 * jumpForce * Time.deltaTime);
    }
    void Down(){
        transform.Translate(-Vector3.up*10 * jumpForce * Time.deltaTime);
        animator.SetTrigger("idle");
    }
}*/


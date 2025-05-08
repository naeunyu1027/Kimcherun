using System;
using Unity.VisualScripting;
using UnityEngine;
    public class Player : MonoBehaviour
{
    public float JumpForce;
    private bool IsGround = true;
    public Animator PlayerAnimator; 
    public Rigidbody2D rigid;
    public CapsuleCollider2D coll;
    public Gamecontroller gamecontroller;
    private float count = 2;

    private bool isInvincible = false;
    void Start()
    {
        {
            rigid = GetComponent<Rigidbody2D>();
            PlayerAnimator = GetComponent<Animator>();
            coll = GetComponent<CapsuleCollider2D>();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && count > 0){
            rigid.AddForceY(JumpForce, ForceMode2D.Impulse);
            PlayerAnimator.SetInteger("state", 1);
            count -= 1;
        }                                                                                                                                                                                                                                                                                                  
    }

    void OnCollisionEnter2D(Collision2D collision)  {  //  땅에 닿았을 때만 점프 가능하도록 설정
        if(collision.gameObject.name == "Platform") {  //  Platform이라는 이름의 GameObject와 충돌했을 때
            count = 2;
            PlayerAnimator.SetInteger("state",2);  //  Animator의 state를 2로 변경
        }
    } 

    void Hit(){
        Gamecontroller.Instance.live -= 1;
    }

    void Heal(){
        Gamecontroller.Instance.live = Math.Min(3, Gamecontroller.Instance.live + 1);
    }

    void StartInvincible(){
        isInvincible = true;
        Invoke("StopInvincible", 5f);
    }

    void StopInvincible(){
        isInvincible = false;
    }

    public void killPlayer(){
        coll.enabled = false;
        PlayerAnimator.enabled = false;
        rigid.AddForceY(JumpForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "enemy"){
            if(!isInvincible){
            Destroy(collider.gameObject);}
            Hit();
        }
        else if(collider.gameObject.tag == "food"){
            Destroy(collider.gameObject);
            Heal();
        }
        else if(collider.gameObject.tag == "golden"){
            Destroy(collider.gameObject);
        }
        
    }
}

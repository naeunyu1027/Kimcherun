    using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite OnHeart;
    public Sprite OffHeart;
    public SpriteRenderer spriteRenderer;
    public int liveNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamecontroller.Instance.live >= liveNumber){
            spriteRenderer.sprite = OnHeart;
        }
        else{
            spriteRenderer.sprite = OffHeart;
        }
    }
}

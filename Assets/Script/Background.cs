using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("setting")]
    [Tooltip("good")]
    public float scrollSpeed;
    public MeshRenderer meshRenderer;
    // [Header("References")]
    void Start()
    {
        
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}

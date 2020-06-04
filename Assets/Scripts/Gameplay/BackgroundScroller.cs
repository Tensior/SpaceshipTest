using UnityEngine;

// Makes background seem moving
public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private float _scrollSpeed; //speed of background

    private Material _material; //material of the background

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        //just offset texture by Y
        _material.mainTextureOffset += new Vector2( 0f, _scrollSpeed * Time.deltaTime );
    }

    private void OnDestroy()
    {
        Destroy( _material );
    }
}

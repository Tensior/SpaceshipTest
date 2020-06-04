using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]
    private float _scrollSpeed;

    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _material.mainTextureOffset += new Vector2( 0f, _scrollSpeed * Time.deltaTime );
    }

    private void OnDestroy()
    {
        Destroy( _material );
    }
}

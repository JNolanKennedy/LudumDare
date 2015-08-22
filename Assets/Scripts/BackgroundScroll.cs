using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
		gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2 (-(Time.time * scrollSpeed)%1, 0f);
    }
}

using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    void Update()
    {
		gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2 (-(Time.time * scrollSpeed)%1, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    // 씨네마에서 바닥 움직일때 쓰는거 (씨네마용)

    Material material;
    [SerializeField] float moveSpeed;
    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = material.mainTextureOffset;
        offset.y -= Time.deltaTime * moveSpeed;
        material.mainTextureOffset = offset;
    }
}

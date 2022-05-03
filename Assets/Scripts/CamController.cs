using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    [Header("Framing")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform followTransform; 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position * 1.5f - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

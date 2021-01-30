using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    private Vector3 InitialPosition;

    private void Awake()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.5f);
    }

    private void OnDisable()
    {
        transform.position = InitialPosition;
    }
}

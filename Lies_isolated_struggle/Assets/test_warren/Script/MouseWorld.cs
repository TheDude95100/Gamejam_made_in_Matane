using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld _instance;

    [SerializeField]
    private LayerMask groundLayerMask;

    private void Awake()
    {
        _instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = MouseWorld.GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _instance.groundLayerMask);

        return raycastHit.point;
    }
}

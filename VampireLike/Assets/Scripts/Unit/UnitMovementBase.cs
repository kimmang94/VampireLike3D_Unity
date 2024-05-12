using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementBase : MonoBehaviour
{
    public float mSpeed = 5.0f;
    public Transform mRotationTransform;
    public float mRotationSpeed = 400.0f;
    public Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Height °è»ê
        Vector3 INowPosition = transform.position + new Vector3(0, 100, 0);
        Vector3 iDirection = new Vector3 (0, -1, 0);
        RaycastHit IHit;
        int layerMask = 1 << LayerMask.NameToLayer("Terrain");
        if (Physics.Raycast(INowPosition, iDirection, out IHit, 200, layerMask))
        {
            float IHeight = IHit.point.y;
            Vector3 INewPos = transform.position;
            INewPos.y = IHeight;
            transform.position = INewPos;
        }
    }
}

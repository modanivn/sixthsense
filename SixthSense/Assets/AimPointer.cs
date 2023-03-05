using UnityEngine;

public class AimPointer : MonoBehaviour
{
    public RectTransform aimPointerTransform;

    void Update()
    {
        // Convert screen position to world position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Update aim pointer position
        aimPointerTransform.position = worldPosition;
    }
}


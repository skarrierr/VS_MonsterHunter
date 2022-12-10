using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform Player;
    public bool IsCamera = false;

    private void LateUpdate()
    {
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        if(IsCamera == false)
        {
            transform.rotation = new Quaternion(0,Player.rotation.y,0,Player.rotation.w);
        }
    }
}

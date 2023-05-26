using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform Player;
    public bool IsCamera = false;

    private void LateUpdate()
    {
        if (Player != null)
        {
            Vector3 newPosition = Player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
        else
        {
            Destroy(this.gameObject);
        }
        if(IsCamera == false)
        {
            transform.rotation = new Quaternion(0,Player.rotation.y,0,Player.rotation.w);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* this code will lock the camera to the player and make it follow the player 
 * whatever direction the player goes by using Vector3 movement
 */

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject whereDoILook;
    public Vector3 offset = new Vector3(0, 0, 1);

    
    void FixedUpdate()
    {
        if(whereDoILook)
        {
            transform.position = new Vector3(
                whereDoILook.transform.position.x + offset.x,
                whereDoILook.transform.position.y + offset.y,
                whereDoILook.transform.position.z + offset.z);
        }
    }
}

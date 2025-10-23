using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerRotation : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1f;



    void Update()
    {
        float rotate = 0f;
        
        if(Keyboard.current.aKey.isPressed)
        {
            rotate = -1f;
        
        }   
        else if (Keyboard.current.dKey.isPressed)
        {
            rotate= 1f;
        
        }
        transform.Rotate(0, 0, rotate * rotateSpeed);


    }
    
   
}

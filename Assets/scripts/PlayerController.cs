using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    
    [SerializeField] float Torque=1f;
    InputAction moveAction;
    Rigidbody2D myRigidbody2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] scoreManager scoreManager;
    [SerializeField] ParticleSystem powerupParticles;
    
    bool canControlPlayer = true;

    Vector2 moveVector;
    [SerializeField] float baseSpeed = 1f;
    [SerializeField] float boostSpeed = 5f;
    float currentRotation;
    float previousRotation;
    float totalRotation;
    int activePowerupCount;
    

     


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody2d= GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        
    }

    void Update()
    {
        if(canControlPlayer)
        {
            rotatePlayer();
            boostPlayer();
            calculateRotation();          
        }
       
    }

    void rotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x > 0)
        {
            myRigidbody2d.AddTorque(Torque);
        }

        else if (moveVector.x < 0)
        {
            myRigidbody2d.AddTorque(-Torque);
        }

    }


    void boostPlayer()
    {
        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;

        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }
    public void disableControls()
    {
        canControlPlayer = false;
    }

    void calculateRotation()
    {
        currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        previousRotation = currentRotation;

        if (totalRotation > 330 || totalRotation < -330)
        {
            totalRotation = 0;
            scoreManager.updateScore(100);

        }


    }

    public void ActivatePowerup(Powerup powerup)
    {
        powerupParticles.Play();
        activePowerupCount += 1;
        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetvalueChange();
            boostSpeed += powerup.GetvalueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            Torque += powerup.GetvalueChange();
        }

    }
    
    public void DeactivatePowerup(Powerup powerup)
    {
        activePowerupCount -= 1;
        if (activePowerupCount == 0)
        {
            powerupParticles.Stop();

        }
        
        if (powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetvalueChange();
            boostSpeed -= powerup.GetvalueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            Torque -= powerup.GetvalueChange();
        }

        
    }
}

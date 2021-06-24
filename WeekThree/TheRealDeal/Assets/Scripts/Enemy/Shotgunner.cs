using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgunner : Enemy
{
    public int numberOfShots;
    public float exitSpeed;
    public override void Move()
    {
        if (transform.position.x < mainCamera.transform.position.x + main.cameraDimensions.x /2)
        {
            if (numberOfShots >= 2 && this.transform.position.y > 0)
            {
                transform.position += new Vector3(main.cameraSpeed * main.deltatime, exitSpeed * main.deltatime, 0);
            } 
            else if (numberOfShots >= 3 && this.transform.position.y < 0)
            {
                transform.position += new Vector3(main.cameraSpeed * main.deltatime, -exitSpeed * main.deltatime, 0);
            }
            else
            {
                transform.position += new Vector3(main.cameraSpeed * main.deltatime, 0, 0);
            }

        }
    }

    public override float[] ShootingPattern()
    {
        if (transform.position.x < mainCamera.transform.position.x + main.cameraDimensions.x / 2 + 1)
        {
            numberOfShots++;
        }    
        return new float[] { -5, 5, -15, 15, -25, 25, -35, 35 };
    }

}

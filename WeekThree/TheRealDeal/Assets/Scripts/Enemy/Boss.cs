using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public Slider healtbar;
    public override void Move()
    {
        healtbar.value = health;
        if (transform.position.x < mainCamera.transform.position.x + main.cameraDimensions.x / 2)
        {
            transform.position += new Vector3(main.cameraSpeed * main.deltatime, 0, 0);
        }
            
    }

    public override float[] ShootingPattern()
    {
        float[] output = new float[] { };
        return output;
    }
}

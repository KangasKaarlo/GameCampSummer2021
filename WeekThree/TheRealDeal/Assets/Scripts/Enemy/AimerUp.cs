using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimerUp : Enemy
{
    public int numberOfShots;
    public float exitSpeed;

    public override void Move()
    {
        {
            if (transform.position.x < mainCamera.transform.position.x + main.cameraDimensions.x / 2 -2)
            {
                if (numberOfShots >= 1)
                {
                    transform.position += new Vector3(main.cameraSpeed * main.deltatime, exitSpeed * main.deltatime, 0);
                }
                else
                {
                    transform.position += new Vector3(main.cameraSpeed * main.deltatime, 0, 0);
                }

            }
        }
    }

    override public void Shoot(float[] angles)
    {
        for (int i = 0; i < angles.Length; i++)
        {
            GameObject newBullet = Instantiate(bullet, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0), Quaternion.identity);
            newBullet.GetComponent<Bullet>().playerBullet = false;
            newBullet.GetComponent<Bullet>().bulletBaseSpeed = -newBullet.GetComponent<Bullet>().bulletBaseSpeed;
            newBullet.GetComponent<Bullet>().angle = angles[i];

        }
    }
    public override float[] ShootingPattern()
    {
        
        if (numberOfShots == 0 && transform.position.x < mainCamera.transform.position.x + main.cameraDimensions.x / 2 -1.9f)
        {
            numberOfShots++;
            return new float[] { AngleInDeg(this.transform.position, player.transform.position) };
        }
        else
        {
            return new float[] {};
        }

    }
    public static float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }
    public static float AngleInRad(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }
}

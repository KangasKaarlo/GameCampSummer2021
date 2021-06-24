using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : Enemy
{


    public override void Move()
    {

    }

    override public void Shoot(float[] angles)
    {
        for (int i = 0; i < angles.Length; i++)
        {
            GameObject newBullet = Instantiate(bullet, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0), Quaternion.identity);
            newBullet.GetComponent<Bullet>().playerBullet = false;
            newBullet.GetComponent<Bullet>().bulletBaseSpeed = -newBullet.GetComponent<Bullet>().bulletBaseSpeed;
            newBullet.GetComponent<Bullet>().angle = angles[i];
            Debug.Log(angles[i]);

        }
    }
    public override float[] ShootingPattern()
    {
        //return new float[] { AngleBetweenVector2(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)) };
        return new float[] { AngleInDeg(this.transform.position, player.transform.position) };
    }
    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, diference) * sign;
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

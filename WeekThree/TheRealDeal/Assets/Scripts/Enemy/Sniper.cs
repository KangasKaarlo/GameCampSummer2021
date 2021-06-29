using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Enemy
{
    public float deltatime;
    public bool burst;
    public float ArrayList ;
    public override void Move()
    {

    }

    override public void Shoot(float[] angles)
    {
        deltatime = main.deltatime;
        burst = true;
        
        if (timeFromLastShot > 2f)
        {    
            burst = true;
            timeFromLastShot += deltatime;
        }
        else 
        {
            burst = false;
            
            
        } 
        if (burst == true)
        {
            for (int i = 0; i < angles.Length; i++)
            {        
            
            GameObject newBullet = Instantiate(bullet, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0), Quaternion.identity);
            newBullet.GetComponent<Bullet>().playerBullet = false;
            newBullet.GetComponent<Bullet>().bulletBaseSpeed = -newBullet.GetComponent<Bullet>().bulletBaseSpeed;
            newBullet.GetComponent<Bullet>().angle = angles[i];
            Debug.Log(angles[i]);
            timeFromLastShot = 0;

            }
            
            
        }
    }
    public override float[] ShootingPattern()
    {
        
        //return new float[] { AngleBetweenVector2(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)) };
            return new float[] { AngleInDeg(this.transform.position, player.transform.position) };


        
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

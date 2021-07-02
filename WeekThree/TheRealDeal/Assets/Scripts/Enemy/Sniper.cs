using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Enemy
{
    public float deltatime;
    public bool burst = true;
    public float timer = 0f;
    public float fireRate2 = 1f;
    public override void Move()
    {
        deltatime = Time.deltaTime;
        
        if (timer <= fireRate2)
        {
            burst = true;
            
        }
        else
        {
            
            burst = false;
        }
        if (timer >= 3f)
        {
            timer = 0;
        }
        timer += deltatime;

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
        if (burst == true){
            return new float[] { AngleInDeg(this.transform.position, player.transform.position) };
        }
        //return new float[] { AngleBetweenVector2(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)) };
        else {
            return new float[] {  };
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

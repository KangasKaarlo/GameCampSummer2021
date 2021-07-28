using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public Slider healtbar;
    public Canvas healthCanvas;
    public int numberOfShots;
    bool homing;
    int attackPattern;
    public bool moving;
    public float speed;
    float currentSpeed;
    bool hasEnteredTheSceen;
    public WinScreenScript winScreenScript;
    public void GameWon(){
        if (health == 0) {
           
        }
    }

    public override void Move()
    {
        healtbar.value = health;
        if (this.transform.position.x < mainCamera.transform.position.x + main.cameraDimensions.x / 2)
        {
            transform.position += new Vector3(main.cameraSpeed * main.deltatime, 0, 0);
            if (!hasEnteredTheSceen)
            {
                moving = false;
                hasEnteredTheSceen = true;
                //Enable();
            }

        }
        if (moving)
        {
            transform.position += new Vector3(0, currentSpeed * main.deltatime, 0);
            if ((currentSpeed > 0 && this.transform.position.y > 4) || (currentSpeed < 0 && this.transform.position.y < -4))
            {
                moving = false;
            } 
        }

    }

    public override float[] ShootingPattern()
    {
        float[] output = { };
        float dirToPlayer = AngleInDeg(this.transform.position, player.transform.position) + 180;
        if (!moving)
        {
            switch (attackPattern)
            {
                case 0:
                    switch (numberOfShots)
                    {
                        case 0:
                        case 1:
                            output = new float[] { 0, 20, 40, 60, 80, 100, 120, 140, 160, 180, -20, -40, -60, -80, -100, -120, -140, -160 };
                            homing = true;
                            numberOfShots++;
                            break;
                        case 2:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 3:
                            output = new float[] { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50, 60, -60 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 4:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 5:
                            moving = true;
                            if (this.transform.position.y > 0)
                            {
                                currentSpeed = -speed;
                            }
                            else
                            {
                                currentSpeed = speed;
                            }
                            numberOfShots = 0;
                            attackPattern++;
                            break;
                    }
                    break;
                case 1:
                    switch (numberOfShots)
                    {

                        case 0:
                            output = new float[] { dirToPlayer, dirToPlayer + 5, dirToPlayer + 10, dirToPlayer + 15 };
                            homing = false;
                            numberOfShots++;
                            fireRate = fireRate / 2;
                            break;
                        case 1:
                            output = new float[] { dirToPlayer, dirToPlayer - 5, dirToPlayer - 10, dirToPlayer - 15 };
                            homing = false;
                            numberOfShots++;
                            break;
                        case 2:
                            output = new float[] { dirToPlayer, dirToPlayer + 5, dirToPlayer + 10, dirToPlayer + 15 };
                            homing = false;
                            numberOfShots++;
                            break;
                        case 3:
                            output = new float[] { dirToPlayer, dirToPlayer - 5, dirToPlayer - 10, dirToPlayer - 15 };
                            homing = false;
                            numberOfShots++;
                            break;
                        case 4:
                            output = new float[] { dirToPlayer, dirToPlayer + 5, dirToPlayer + 10, dirToPlayer + 15 };
                            homing = false;
                            numberOfShots++;
                            break;
                        case 5:
                            moving = true;
                            if (this.transform.position.y > 0)
                            {
                                currentSpeed = -speed;
                            }
                            else
                            {
                                currentSpeed = speed;
                            }
                            fireRate = fireRate * 2;
                            numberOfShots = 0;
                            attackPattern++;
                            break;
                    }
                    break;
                case 2:
                    switch (numberOfShots)
                    {
                        case 0:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 1:
                            output = new float[] { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50, 60, -60 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 2:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 3:
                            output = new float[] { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50, 60, -60 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 4:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 5:
                            output = new float[] { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50, 60, -60 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 6:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 7:
                            output = new float[] { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50, 60, -60 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 8:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 9:
                            output = new float[] { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50, 60, -60 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 10:
                            output = new float[] { -5, 5, -15, 15, -25, 25, -35, 35, -45, 45, 55, -55 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 11:
                            output = new float[] { 0, -10, 10, -20, 20, -30, 30, -40, 40, -50, 50, 60, -60 };
                            numberOfShots++;
                            homing = false;
                            break;
                        case 12:
                            moving = true;
                            if (this.transform.position.y > 0)
                            {
                                currentSpeed = -speed;
                            }
                            else
                            {
                                currentSpeed = speed;
                            }
                            numberOfShots = 0;
                            attackPattern++;
                            break;
                    }
                    break;
            }
        }
        if (attackPattern > 2)
        {
            attackPattern = 0;
        }
        return output;
    }
    override public void Shoot(float[] angles)
    {
        for (int i = 0; i < angles.Length; i++)
        {
            GameObject newBullet = Instantiate(bullet, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0), Quaternion.identity);
            newBullet.GetComponent<Bullet>().playerBullet = false;

            newBullet.GetComponent<Bullet>().angle = angles[i];
            if (attackPattern == 1)
            {
                newBullet.GetComponent<Bullet>().bulletBaseSpeed = 15;
            } else if (attackPattern == 2)
            {
                newBullet.GetComponent<Bullet>().bulletBaseSpeed = 5;
            }
            
            if (homing)
            {
                newBullet.GetComponent<Bullet>().homing = true;
            } else
            {
                newBullet.GetComponent<Bullet>().homing = false;
            }
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
    public void Enable()
    {
        healthCanvas.GetComponent<CanvasGroup>().alpha = 1.0f;
        healthCanvas.GetComponent<CanvasGroup>().interactable = true;
        healthCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void Disable()
    {
        healthCanvas.GetComponent<CanvasGroup>().alpha = 0.0f;
        StartCoroutine(DelayedDisable());
    }

    //Work around button highlighting bug
    private IEnumerator DelayedDisable()
    {
        healthCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        yield return new WaitForSeconds(0.01f);
        healthCanvas.GetComponent<CanvasGroup>().interactable = false;
    }
}

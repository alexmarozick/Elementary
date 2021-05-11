using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

/* 
Citing the roll a cube tutorial as a source 
https://www.youtube.com/watch?v=TVFGgjRZkSs
*/

public class MovePlayer : MonoBehaviour
{
    public float InputThreshold;
    public float duration; //define how long the cube takes to roll
    bool isRolling = false;
    float scale;
    string current, previous;
    bool newsquare;

    public GameObject face1, face2, face3, face4, face5, face6;
    CreateFace script1, script2, script3, script4, script5, script6;
    CreateTerrain scriptX;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x / 2;
        current = "down";
        script1 = (CreateFace)face1.GetComponent(typeof(CreateFace));
        script2 = (CreateFace)face2.GetComponent(typeof(CreateFace));
        script3 = (CreateFace)face3.GetComponent(typeof(CreateFace));
        script4 = (CreateFace)face4.GetComponent(typeof(CreateFace));
        script5 = (CreateFace)face5.GetComponent(typeof(CreateFace));
        script6 = (CreateFace)face6.GetComponent(typeof(CreateFace));
        newsquare = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (newsquare)
        {
            //CheckSquare();
            newsquare = false;
        }

        if (!isRolling && ((x > InputThreshold || x < -InputThreshold) || (y > InputThreshold || y < -InputThreshold)))
        {
            // the translate is for sliding the cube
            // transform.Translate(Vector3.left * x * 10 * Time.deltaTime);
            isRolling = true;
            StartCoroutine(RollingCube(x, y));
        }
    }

    //make tile colors unreadable when moving
    public void Close()
    {
        script1.Close();
        script2.Close();
        script3.Close();
        script4.Close();
        script5.Close();
        script6.Close();
    }

    //make tile colors readable after moving
    public void Open()
    {
        script1.Open();
        script2.Open();
        script3.Open();
        script4.Open();
        script5.Open();
        script6.Open();
    }

    //idea is we use this to check the square beneath the tile the cube is one
    public void CheckSquare()
    {
        newsquare = false;

        //this method only works on occassion? I'm not sure why as it seems to be sending it in the correct direction
        //alternatively we could try a collider of some sort but that requires changing it's orientation as the cube does shenanigans

        //Vector3 direction = player.position - transform.position + Vector3.up;
        Vector3 direction = Vector3.down;
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            Debug.Log(direction);
            Debug.Log(transform.position);
            //if ((raycastHit.collider.transform.parent != null) && raycastHit.collider.transform.CompareTag("Tile"))
            if (raycastHit.collider.transform.CompareTag("Tile"))
            {
                //terrain.GetComponent<CreateTerrain>().trying("red");

                //scriptX = (Terrain2)raycastHit.collider.transform.GetComponentInParent(typeof(Terrain2));
                Debug.Log("it hit");
            }
        }
    }

    //Method is used to make tile color consistent
    public void AngleFix()
    {
        if (current == "down")
        {
            if (previous == "down")
            {
                string hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);
            }

            else if (previous == "up")
            {
                string hold = script2.GetColor();
                script2.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);


                hold = script3.GetColor();
                script3.SetColor(script4.GetColor());
                script4.SetColor(hold);
            }

            else if (previous == "right")
            {
                string hold = script1.GetColor();
                script1.SetColor(script2.GetColor());
                script2.SetColor(hold);

                hold = script6.GetColor();
                script6.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script2.GetColor();
                script2.SetColor(script5.GetColor());
                script5.SetColor(hold);
            }
            
            else if (previous == "left")
            {
                string hold = script3.GetColor();
                script3.SetColor(script4.GetColor());
                script4.SetColor(hold);

                hold = script6.GetColor();
                script6.SetColor(script2.GetColor());
                script2.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script5.GetColor());
                script5.SetColor(hold);
            }
        }

        else if (current == "up")
        {
            if (previous == "up")
            {
                string hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);
            }

            else if (previous == "down")
            {
                string hold = script2.GetColor();
                script2.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);

                hold = script3.GetColor();
                script3.SetColor(script4.GetColor());
                script4.SetColor(hold);
            }

            else if (previous == "right")
            {
                
                string hold = script3.GetColor();
                script3.SetColor(script4.GetColor());
                script4.SetColor(hold);

                hold = script6.GetColor();
                script6.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script2.GetColor());
                script2.SetColor(hold);
            }

            else if (previous == "left")
            {
                Debug.Log("trying");
                string hold = script1.GetColor();
                script1.SetColor(script2.GetColor());
                script2.SetColor(hold);

                hold = script6.GetColor();
                script6.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script6.GetColor();
                script6.SetColor(script1.GetColor());
                script1.SetColor(hold);
            }
        }

        else if (current == "right")
        {
            if (previous == "right")
            {
                string hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);
            }

            else if (previous == "left")
            {
                string hold = script2.GetColor();
                script2.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script6.GetColor());
                script6.SetColor(hold);
            }

            else if (previous == "down")
            {
                
                string hold = script1.GetColor();
                script1.SetColor(script6.GetColor());
                script6.SetColor(hold);

                hold = script3.GetColor();
                script3.SetColor(script2.GetColor());
                script2.SetColor(hold);

                hold = script4.GetColor();
                script4.SetColor(script5.GetColor());
                script5.SetColor(hold); 
            }
            
            else if (previous == "up")
            {
                string hold = script3.GetColor();
                script3.SetColor(script2.GetColor());
                script2.SetColor(hold);

                hold = script4.GetColor();
                script4.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script3.GetColor();
                script3.SetColor(script4.GetColor());
                script4.SetColor(hold);
            }
        }

        else if (current == "left")
        {
            if (previous == "left")
            {
                string hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);
            }

            else if (previous == "right")
            {
                string hold = script2.GetColor();
                script2.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script3.GetColor());
                script3.SetColor(script6.GetColor());
                script6.SetColor(script4.GetColor());
                script4.SetColor(hold);

                hold = script1.GetColor();
                script1.SetColor(script6.GetColor());
                script6.SetColor(hold);
            }

            else if (previous == "down")
            {
                Debug.Log("trying");
                string hold = script3.GetColor();
                script3.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script2.GetColor();
                script2.SetColor(script3.GetColor());
                script3.SetColor(hold);

                hold = script2.GetColor();
                script2.SetColor(script4.GetColor());
                script4.SetColor(hold);

            }

            else if (previous == "up")
            {
                string hold = script1.GetColor();
                script1.SetColor(script6.GetColor());
                script6.SetColor(hold);

                hold = script3.GetColor();
                script3.SetColor(script5.GetColor());
                script5.SetColor(hold);

                hold = script2.GetColor();
                script2.SetColor(script4.GetColor());
                script4.SetColor(hold);   
            }
        }
    }

    IEnumerator RollingCube(float x, float y)
    {
        Close();
        previous = current;
        float elapsed = 0.0f;
        Vector3 point = Vector3.zero;
        Vector3 axis = Vector3.zero;
        float angle = 0.0f;
        Vector3 direction = Vector3.zero;

        if (x != 0)
        { //left or right key
            axis = Vector3.forward;
            point = x > 0 ?
                transform.position + (Vector3.right * scale) :
                transform.position + (Vector3.left * scale);
            
            angle = x > 0 ? -90 : 90;
            direction = x > 0 ? Vector3.right : Vector3.left;

            if (direction== Vector3.right)
            {
                current = "right";
            }

            else
            {
                current = "left";
            }
        }

        else if (y != 0)
        { //forward or backward key
            axis = Vector3.right;
            point = y > 0 ?
                transform.position + (Vector3.forward * scale) :
                transform.position + (Vector3.back * scale);
            
            angle = y > 0 ? 90 : -90;
            direction = y > 0 ? Vector3.forward : Vector3.back;

            if (direction == Vector3.forward)
            {
                current = "up";
            }

            else
            {
                current = "down";
            }
        }
        //Debug.Log(current);

        point += new Vector3(0, -scale, 0);
        Vector3 adjustPos = point + direction * scale - new Vector3(0, -0.5f, 0);
        Quaternion adjustRotation = Quaternion.Euler(direction * 90f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            transform.RotateAround(point, axis, angle / duration * Time.deltaTime);

            yield return null;
        }

        transform.position = adjustPos;
        
        transform.rotation = adjustRotation;
        AngleFix();
        isRolling = false;
        Open();
        newsquare = true;
    }
}


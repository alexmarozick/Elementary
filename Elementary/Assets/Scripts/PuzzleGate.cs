using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PuzzleGate : MonoBehaviour
{
    //meant as a parent class
    protected bool locked;

    public int amount;
    public string color;

    protected int time;
    public int countdown;

    public GameObject square1, square2, square3, square4, square5, square6, square7, square8;
    protected TerrainSystem script1, script2, script3, script4, script5, script6, script7, script8;
    public GameObject tracker;
    protected ColorTracker basecolor;
    public GameObject master;
    protected PuzzleSystem puzzleboss;

    protected Animator m_Animator;


    public virtual void Start()
    {
        time = 0;
        locked = true;

        m_Animator = gameObject.GetComponent<Animator>();


        if (tracker != null)
        {
            
            basecolor = (ColorTracker)tracker.GetComponent(typeof(ColorTracker));
            if(basecolor == null)
            {
                Debug.Log("not in color");
            }
        }

        if (master != null)
        {
            puzzleboss = (PuzzleSystem)master.GetComponent(typeof(PuzzleSystem));
            if(puzzleboss == null)
            {
                Debug.Log("why though");
            }
        }



        if (square1 != null)
        {
            script1 = (TerrainSystem)square1.GetComponent(typeof(TerrainSystem));
        }
        if (square2!= null)
        {
            script2 = (TerrainSystem)square2.GetComponent(typeof(TerrainSystem));
        }
        if (square3 != null)
        {
            script3 = (TerrainSystem)square3.GetComponent(typeof(TerrainSystem));
        }
        if (square4 != null)
        {
            script4 = (TerrainSystem)square4.GetComponent(typeof(TerrainSystem));
        }
        if (square5 != null)
        {
            script5 = (TerrainSystem)square5.GetComponent(typeof(TerrainSystem));
        }
        if (square6 != null)
        {
            script6 = (TerrainSystem)square6.GetComponent(typeof(TerrainSystem));
        }
        if (square7 != null)
        {
            script7 = (TerrainSystem)square7.GetComponent(typeof(TerrainSystem));
        }
        if (square8 != null)
        {
            script8 = (TerrainSystem)square8.GetComponent(typeof(TerrainSystem));
        }

        //Additional();
    }
    
    public float GetX()
    {
        return transform.position.x;
    }
    public float GetY()
    {
        return transform.position.y;
    }
    public float GetZ()
    {
        return transform.position.z;
    }


    protected void Repair()
    {
        if(puzzleboss != null)
        {
            
            puzzleboss.Repair(transform.position.x, transform.position.z, transform.position.y - 1.0f);
        }
    }



    protected void  Additional()
    {

    }

    protected int MatchColor(string a)
    {
        
        
        if(a == color)
        {
            
            return 1;
        }
        else
        {
            return 0;
        }
    }

    //for puzzle effects that keep occurring constantly
    protected virtual void AmbientPuzzleOn()
    {
        
    }
    protected void AmbientPuzzleOff()
    {

    }

    //for puzzle effects that occur more often and are fancier
    protected void TriggerPuzzle()
    {

    }

    protected void Update()
    {
        if (locked)
        {
            if (CheckLock())
            {
                AmbientPuzzleOn();
                locked = false;
                if(countdown > 0)
                {
                    time = time + 1;
                    if (time >= countdown)
                    {
                        time = 0;
                        TriggerPuzzle();
                    }
                }
                
            }
        }
        else
        {
            if (!CheckLock())
            {
                AmbientPuzzleOff();
                locked = true;
            }
            else
            {
                
                if (countdown > 0)
                {
                    time = time + 1;
                    if (time >= countdown)
                    {
                        time = 0;
                        TriggerPuzzle();
                    }
                }
            }
            
        }
    }


    protected bool CheckLock()
    {
        int count = 0;
        if (square1 != null)
        {
            count += MatchColor(script1.GetColor());
        }
        if (square2 != null)
        {
            count += MatchColor(script2.GetColor());
        }
        if (square3 != null)
        {
            count += MatchColor(script3.GetColor());
        }
        if (square4 != null)
        {
            count += MatchColor(script4.GetColor());
        }
        if (square5 != null)
        {
            count += MatchColor(script5.GetColor());
        }
        if (square6 != null)
        {
            count += MatchColor(script6.GetColor());
        }
        if (square7 != null)
        {
            count += MatchColor(script7.GetColor());
        }
        if (square8 != null)
        {
            count += MatchColor(script8.GetColor());
        } 

        if(count >= amount)
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }


}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningGate : PuzzleGate
{

    private ParticleSystem r;

    public override void Start()
    {

        base.Start();

        

        
        r = GetComponent<ParticleSystem>();

        var ps = r.main;
        

        basecolor.GetColor("red");

        ps.startColor = basecolor.GetColor(color);
    }

  

    new void Additional()
    {
        r = GetComponent<ParticleSystem>();

        var ps = r.main;
        

        ps.startColor = basecolor.GetColor(color);
    }
    
    // Update is called once per frame
    protected override void AmbientPuzzleOn()
    {
        

        r = GetComponent<ParticleSystem>();
        r.Stop();
        Repair();

        
        m_Animator.SetTrigger("Finished");
    }
}

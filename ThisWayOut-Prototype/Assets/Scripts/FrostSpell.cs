using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSpell : Spellcaster
{
    public GameObject spell;

    public override void Start()
    {
        base.Start();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
    }

    public override void CastSpell(int frame)
    {
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(0, 0, frame);
        Instantiate(spell, player.position, rotation);
    }
}

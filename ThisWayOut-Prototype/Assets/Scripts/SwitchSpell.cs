using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpell : MonoBehaviour
{
    enum Spells {
        FROST,
        FIRE
    }
    public GameObject[] spellBindings;
    public Transform player;
    public int maxSelections;
    private FireSpell _fireSpell;
    private FrostSpell _frostSpell;
    private int selection;
    private GameObject currentSpell;
    // Start is called before the first frame update
    void Start()
    {
        _fireSpell = GetComponent<FireSpell>();
        _frostSpell = GetComponent<FrostSpell>();
        selection = 0;
        currentSpell = Instantiate(spellBindings[selection], player.position, Quaternion.identity);
        _frostSpell.enabled = true;
         _fireSpell.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            selection++;
            if (selection > maxSelections)
            {
                selection = 0;
            }
            Destroy(currentSpell);
            Instantiate(spellBindings[selection], player.position, Quaternion.identity);
            switch (selection) 
            {
                case (int)Spells.FROST:
                    _frostSpell.enabled = true;
                    _fireSpell.enabled = false;
                    break;
                case (int)Spells.FIRE:
                    _frostSpell.enabled = false;
                    _fireSpell.enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}

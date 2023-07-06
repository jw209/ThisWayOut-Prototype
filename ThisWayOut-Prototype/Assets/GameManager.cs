using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    Enemy data
    */
    public struct Enemy
    {
        int hp;
        int attackPower;
        int type;
    }

    /*
        Player data
    */
    public struct Player
    {
        public int maxHP;
        public int hp;
        public int maxMana;
        public int mana;
        public int xp;
        public int level;
        public int attackPower;
        public int manaRegenAmount;
        public int storage;
    }

    // GLOBAL VARIABLES
    public static GameManager instance;
    public bool isNewSave = false;
    public const int maxNumEnemies = 32;
    public const int manaRegenAmount = 2;
    public const int storageCapacity = 10;
    public const int startingAttackPower = 10;
    public const int maxHP = 50;
    public const int maxMana = 50;
    private int gameState = 0;

    // Declare enemy data
    private Enemy[] enemies;
    private int numEnemies;

    // Declare player data
    public Player player;

    // Initialize storage container
    private int[] storage;

    /*
        Initialize Game Manager
    */
    private void Awake()
    {
        // Begin instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gameState = 0; 
    }

    private void Update()
    {
        switch (gameState)
        {
            case 0: // main menu
                MainMenu();
                break;
            case 1: // in game
                InGame();
                break;
            case 2: // result screen
                ResultScreen();
                break;
            case 3: // save screen
                Save();
                break;
            case 4: // exit
                ExitGame();
                break;
            default:
                break;

        }
    }

    /*
        GAME STATES
    */
    public void MainMenu()
    {
        // @TODO
        // Init player
        if (isNewSave)
        {
            // Init array of enemies
            this.enemies = new Enemy[maxNumEnemies];
            this.player.maxHP = maxHP;
            this.player.hp = 0; 
            this.player.maxMana = maxMana;
            this.player.mana = 0;
            this.player.xp = 0;
            this.player.level = 0;
            this.player.attackPower = startingAttackPower;
            this.player.manaRegenAmount = manaRegenAmount;
            this.player.storage = storageCapacity;
        }
        else
        {
            // load from a save file here
        }
    }

    public void InGame()
    {
        // start automatic mana regeration
        StartCoroutine(RefillMana());
    }

    public void ResultScreen()
    {
        // @TODO
    }

    public void Save()
    {
        // @TODO
    }

    public void ExitGame()
    {
        // @TODO
    }

    /*
        GETTERS AND SETTERS
    */
    public void ChangeHP(int amount)
    {
        this.player.hp += amount;
    }

    public void ChangeMana(int amount)
    {
        this.player.mana += amount;
    }

    public void ChangeXP(int amount)
    {
        this.player.xp += amount;
    }

    public void ChangeLevel(int amount)
    {
        this.player.level += amount;
    }

    public void SetAttackPower(int amount)
    {
        this.player.attackPower = amount;
    }

    public int GetHP() 
    {
        return this.player.hp;
    }

    public int GetMana() 
    {
        return this.player.mana;
    }

    public int GetXP() 
    {
        return this.player.xp;
    }

    public int GetLevel()
    {
        return this.player.level;
    }

    public int GetAttackPower()
    {
        return this.player.attackPower;
    }

    private IEnumerator RefillMana()
    {
        if (this.player.mana != this.player.maxMana) ChangeMana(manaRegenAmount);
        yield return new WaitForSeconds(2.0f);
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Container class that handles combat state information.
/// </summary>

public class CombatEngine
{
    #region Class Data Members

    public enum CombatStates { InCombat, Fled, Dead, Victory };
    public enum CombatTurns { Player, Computer };

    private List<string> combatResults = new List<string>();
    private CombatStates currentState;
    private CombatTurns currentTurn;
    private CombatTurns firstTurn;
    private PlayerCharacter pc;
    private Enemy enemy;

    #endregion

    #region Class Methods

    public CombatEngine(PlayerCharacter PC, Enemy enemy)
    {
        this.init(PC, enemy);
    }

    private void init(PlayerCharacter PC, Enemy enemy)
    {
        this.pc = PC;
        this.enemy = enemy;
        this.currentState = CombatStates.InCombat;

        Random random = new Random();

        if (random.Next(0, 101) <= 50)
        {
            this.currentTurn = CombatTurns.Player;
            this.firstTurn = CombatTurns.Player;
        }
        else
        {
            this.currentTurn = CombatTurns.Computer;
            this.firstTurn = CombatTurns.Computer;
            this.ProcessComputerTurn();
        }
    }

    public void ProcessComputerTurn() 
    {
        Attack enemyAttack = this.enemy.Attacks.FindLast(att => att.TPCost <= this.enemy.CurrentTP);
        this.enemy.Attack(enemyAttack.Name, this.pc, this);

        if (this.pc.CurrentHP <= 0)
        {
            this.currentState = CombatStates.Dead;
        }

        this.currentTurn = CombatTurns.Player;
    }

    public void ProcessPlayerTurn(string attackName)
    {
        this.pc.Attack(attackName, this.enemy, this);

        if (this.enemy.CurrentHP <= 0)
        {
            this.currentState = CombatStates.Victory;
        }

        this.currentTurn = CombatTurns.Computer;
        this.ProcessComputerTurn();
    }

    public void AddCombatResult(string result)
    {
        this.combatResults.Add(result);
    }

    public string DisplayCombatResults()
    {
        string output = "";

        foreach (string s in this.combatResults)
        {
            output += s + "<br />";
        }

        this.combatResults.Clear();

        return output + "<br />";
    }

    public void ProcessEffects()
    {
        if ((this.pc != null) && (this.enemy != null))
        {
            this.pc.Notify();
            this.enemy.Notify();
        }
    }

    public string DisplayEffectsResults()
    {
        string output = "";

        if (this.firstTurn == CombatTurns.Player)
        {
            output += this.pc.StatusEffectReport() + this.enemy.StatusEffectReport();
        }
        else
        {
            output += this.enemy.StatusEffectReport() + this.pc.StatusEffectReport();
        }

        return output + "<br />";
    }

    public void AttemptToFlee()
    {
        Random percentageSeed = new Random(6854);
        Random escapeChance = new Random();
        double percentage = ((this.pc.Level * this.enemy.Level) * percentageSeed.NextDouble()) + 50.0d;

        if ((percentage + pc.Level) >= escapeChance.Next(0, 101))
        {
            this.currentState = CombatStates.Fled;
        }
    }

    #endregion

    #region Class Properties

    public CombatStates CombatState
    {
        get { return this.currentState; }
    }

    public CombatTurns CurrentTurn
    {
        get { return this.currentTurn; }
    }

    public CombatTurns FirstTurn
    {
        get { return this.firstTurn; }
    }

    public PlayerCharacter PC
    {
        get { return this.pc; }
    }

    public Enemy Enemy
    {
        get { return this.enemy; }
    }

    #endregion
}
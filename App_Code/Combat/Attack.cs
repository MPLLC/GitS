using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Class for each special attack.  Each attack is its own 
/// object, added to each player character when they advance to a certain level.
/// </summary>

public class Attack
{
    #region Class Data Members

    private string name;
    private int level;
    private int tpCost;
    private double dmgModifier;
    private double hitPenalty;
    private StatusEffect effect;

    #endregion

    #region Class Methods

    public Attack()
    {
        this.name = null;
        this.level = 0;
        this.tpCost = 0;
        this.dmgModifier = 0.0;
        this.hitPenalty = 0.0;
        this.effect = null;
    }


    public Attack(string name, int level, int tpCost, double dmgModifier, double hitPenalty, StatusEffect effect)
    {
        this.name = name;
        this.level = level;
        this.tpCost = tpCost;
        this.dmgModifier = dmgModifier;
        this.hitPenalty = hitPenalty;
        this.effect = effect;
    }

    public void ExecuteAttack(Character attacker, Character target, CombatEngine engine)
    {
        if (attacker.CurrentTP - this.tpCost < 0)
        {
            attacker.CurrentTP = 0;
        }
        else
        {
            attacker.CurrentTP -= this.tpCost;
        }

        double chanceToHit = attacker.ChanceToHit - this.hitPenalty;
        int damage = (int)((this.dmgModifier * (1 + attacker.DMGModifier)) * attacker.DMG);

        Random random = new Random();

        if (chanceToHit >= random.NextDouble())
        {
            target.CurrentHP -= damage;
            string result = attacker.Name + " hit " + target.Name + " for " + damage + " damage!";
            engine.AddCombatResult(result);

            if (this.effect != null)
            {
                target.Attach(this.effect);
            }
        }
        else
        {
            string result = attacker.Name + " missed " + target.Name + "!";
            engine.AddCombatResult(result);
        }
    }

    #endregion

    #region Class Properties

    public int Level
    {
        get { return this.level; }
        set { this.level = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int TPCost
    {
        get { return this.tpCost; }
        set { this.tpCost = value; }
    }

    public double DMGModifier
    {
        get { return this.dmgModifier; }
        set { this.dmgModifier = value; }
    }

    public double HitPenalty
    {
        get { return this.hitPenalty; }
        set { this.hitPenalty = value; }
    }

    public StatusEffect Effect
    {
        get { return this.effect; }
        set { this.effect = value; }
    }

    #endregion
}
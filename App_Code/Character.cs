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
using System.Collections.Generic;

/// <summary>
/// Abstract base class for both PlayerCharacters and Enemies.
/// </summary>

public abstract class Character : IObservable
{
    #region Class Data Members

    protected CharAttacks attacks;
    protected CharBio bio;
    protected CharInv inv;
    protected CharStats stats;
    protected List<IObserver> StatusEffects = new List<IObserver>();

    #endregion

    #region Class Methods

    public Character(CharAttacks attacks, CharBio bio, CharInv inv, CharStats stats)
    {
        this.attacks = attacks;
        this.bio = bio;
        this.inv = inv;
        this.stats = stats;
    }

    public void Attack(string attackName, Character target, CombatEngine engine)
    {
        this.attacks.Attack(attackName, this, target, engine);
    }

    #endregion

    #region Observer Pattern Methods

    public void Attach(IObserver observer)
    {
        this.StatusEffects.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        this.StatusEffects.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in this.StatusEffects)
        {
            observer.Update(this);
        }
    }

    public string StatusEffectReport()
    {
        string output = "";

        foreach (StatusEffect effect in this.StatusEffects)
        {
            output += effect.Display();
        }

        return output + "<br />";
    }

    #endregion

    #region Class Properties

    public string Name
    {
        get { return this.bio.Name; }
        set { this.bio.Name = value; }
    }

    public string Desc
    {
        get { return this.bio.Desc; }
        set { this.bio.Desc = value; }
    }

    public string Gender
    {
        get { return this.bio.Gender; }
        set { this.bio.Gender = value; }
    }

    public int Level
    {
        get { return this.stats.Level; }
        set { this.stats.Level = value; }
    }

    public int TotalHP
    {
        get { return this.stats.TotalHP; }
        set { this.stats.TotalHP = value; }
    }

    public int TotalTP
    {
        get { return this.stats.TotalTP; }
        set { this.stats.TotalTP = value; }
    }

    public int CurrentHP
    {
        get { return this.stats.CurrentHP; }
        set { this.stats.CurrentHP = value; }
    }

    public int CurrentTP
    {
        get { return this.stats.CurrentTP; }
        set { this.stats.CurrentTP = value; }
    }

    public int Defense
    {
        get { return this.stats.Defense; }
        set { this.stats.Defense = value; }
    }

    public int DMG
    {
        get { return this.stats.DMG; }
        set { this.stats.DMG = value; }
    }

    public float DMGModifier
    {
        get { return this.stats.DMGModifier; }
        set { this.stats.DMGModifier = value; }
    }

    public float ChanceToHit
    {
        get { return this.stats.ChanceToHit; }
        set { this.stats.ChanceToHit = value; }
    }

    public ICharacterClass Class
    {
        get { return this.stats.CharClass; }
    }

    public List<Attack> Attacks
    {
        get { return this.attacks.Attacks; }
    }

    public List<Loot> Inventory
    {
        get { return this.inv.Loot; }
        set { this.inv.Loot = value; }
    }

    public int EXP
    {
        get { return this.stats.EXP; }
        set { this.stats.EXP = value; }
    }

    public float Money
    {
        get { return this.inv.Money; }
        set { this.inv.Money = value; }
    }

    #endregion
}
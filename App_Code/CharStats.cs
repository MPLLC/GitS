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
/// Summary description for PlayerStats
/// </summary>

public class CharStats
{
    private static int maxLevel = 27;

    private int level;
    private int totalHP;
    private int totalTP;
    private int currentHP;
    private int currentTP;
    private int exp;
    private int defense;
    private int dmg;
    private float dmgModifier;
    private float chanceToHit;
    private ICharacterClass charClass;

    public CharStats(int level, int totalHP, int totalTP, int currentHP, int currentTP, int exp, int defense, int dmg, float dmgModifier, float chanceToHit, ICharacterClass charClass)
    {
        this.level = level;
        this.totalHP = totalHP;
        this.totalTP = totalTP;
        this.currentHP = currentHP;
        this.currentTP = currentTP;
        this.exp = exp;
        this.defense = defense;
        this.dmg = dmg;
        this.dmgModifier = dmgModifier;
        this.chanceToHit = chanceToHit;
        this.charClass = charClass;
    }

    public int Level
    {
        get { return this.level; }
        set { this.level = value; }
    }

    public int TotalHP
    {
        get { return this.totalHP; }
        set { this.totalHP = value; }
    }

    public int TotalTP
    {
        get { return this.totalTP; }
        set { this.totalTP = value; }
    }

    public int CurrentHP
    {
        get { return this.currentHP; }
        set { this.currentHP = value; }
    }

    public int CurrentTP
    {
        get { return this.currentTP; }
        set { this.currentTP = value; }
    }

    public int EXP
    {
        get { return this.exp; }
        set { this.exp = value; }
    }

    public int Defense
    {
        get { return this.defense; }
        set { this.defense = value; }
    }

    public int DMG
    {
        get { return this.dmg; }
        set { this.dmg = value; }
    }

    public float DMGModifier
    {
        get { return this.dmgModifier; }
        set { this.dmgModifier = value; }
    }

    public float ChanceToHit
    {
        get { return this.chanceToHit; }
        set { this.chanceToHit = value; }
    }

    public ICharacterClass CharClass
    {
        get { return this.charClass; }
    }
}
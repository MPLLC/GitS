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
/// A registry of all possible special attacks.  When a PlayerCharacter is eligble 
/// to gain a new special attack, they will access this object and the appropriate attack will be returned.  
/// </summary>

public class AttackRegistry
{
    private Attacks hackerAttacks;
    private Attacks shillAttacks;
    private Attacks soldierAttacks;

	public AttackRegistry()
	{
        this.hackerAttacks = new Attacks("Hacker");
        this.shillAttacks = new Attacks("Shill");
        this.soldierAttacks = new Attacks("Soldier");
	}

    public Attack GetAttack(Character character)
    {
        if (character.Class.GetType().ToString() == @"Hacker")
        {
            return this.hackerAttacks.Retrieve(character.Level);
        }
        else if (character.Class.GetType().ToString() == @"Shill")
        {
            return this.shillAttacks.Retrieve(character.Level);
        }
        else if (character.Class.GetType().ToString() == @"Soldier")
        {
            return this.soldierAttacks.Retrieve(character.Level);
        }
        else
        {
            throw new Exception("Bad character class");
        }
    }
}
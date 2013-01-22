using System;
using System.Data;
using System.Collections.Generic;
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
/// Summary description for CharAttacks
/// </summary>

public class CharAttacks
{
    private List<Attack> attacks;

	public CharAttacks(List<Attack> attacks)
	{
        this.attacks = attacks;
	}

    public void AddAttack(Attack attack)
    {
        this.attacks.Add(attack);
    }

    private void Populate(Character character)
    {
        this.attacks = (from a in XElement.Load("CharacterClasses/" + character.Class.ToString() + ".xml").Element("Attacks").Elements("Attack")
                        where (int)a.Element("AttackLevel") <= character.Level
                        select new Attack
                        (
                            (string)a.Element("AttackName"),
                            (int)a.Element("AttackLevel"),
                            (int)a.Element("TPCost"),
                            (double)a.Element("DMGModifier"),
                            (double)a.Element("HitPenalty"),
                            new Poison()
                        )).ToList();
    }

    public void Attack(string attackName, Character attacker, Character target, CombatEngine engine)
    {
        Attack current = this.attacks.Find(delegate(Attack att) { return att.Name == attackName; });
        current.ExecuteAttack(attacker, target, engine);
    }

    public List<Attack> Attacks
    {
        get { return this.attacks; }
    }
}
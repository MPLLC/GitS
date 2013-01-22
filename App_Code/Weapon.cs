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
/// Summary description for Weapon
/// </summary>

public class Weapon : Loot, IEquippable
{
    private int attackBonus;

	public Weapon(string name, float buyValue, float sellValue) : base(name, buyValue, sellValue){ }

    public void Equip(PlayerCharacter PC)
    {
        try
        {
            if (PC.LeftHand != null)
            {
                if (PC.RightHand != null)
                {
                    PC.Inventory.Add(this);
                }
                else
                {
                    PC.RightHand = this;
                }
            }
            else
            {
                PC.LeftHand = this;
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
    }

    public int AttackBonus
    {
        get { return this.attackBonus; }
        set { this.attackBonus = value; }
    }
}
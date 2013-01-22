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
/// Base armor class.
/// </summary>

public class Armor : Loot, IEquippable
{
    private int defenseBonus;

    public Armor(string name, float buyValue, float sellValue) : base(name, buyValue, sellValue){ }

    public void Equip(PlayerCharacter PC)
    {
        try
        {
            if (PC.Armor != null)
            {
                PC.Inventory.Add(this);
            }
            else
            {
                PC.Armor = this;
            }
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }
    }

    public int Defense
    {
        get { return this.defenseBonus; }
        set { this.defenseBonus = value; }
    }
}
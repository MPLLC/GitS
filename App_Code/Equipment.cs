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
/// Summary description for PlayerInv
/// </summary>

public class Equipment
{
    private Weapon leftHand;
    private Weapon rightHand;
    private Armor armor;

	public Equipment(Weapon left, Weapon right, Armor armor)
	{
        this.leftHand = left;
        this.rightHand = right;
        this.armor = armor;
	}

    public Weapon LeftHand
    {
        get { return this.leftHand; }
        set
        {
            if (value.GetType().ToString() == "Weapon" && this.leftHand != null)
            {
                this.leftHand = value;
            }
            else
            {
                throw new Exception("Only a Weapon can be equipped in this slot");
            }
        }
    }

    public Weapon RightHand
    {
        get { return this.rightHand; }
        set
        {
            if (value.GetType().ToString() == "Weapon" && this.rightHand != null)
            {
                this.rightHand = value;
            }
            else
            {
                throw new Exception("Only a Weapon can be equipped in this slot");
            }
        }
    }

    public Armor Armor
    {
        get { return this.armor; }
        set
        {
            if (value.GetType().ToString() == "Armor" && this.armor != null)
            {
                this.armor = value;
            }
            else
            {
                throw new Exception("Only Armor items can be equipped in this slot");
            }
        }
    }
}
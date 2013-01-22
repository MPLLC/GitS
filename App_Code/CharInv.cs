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
/// Summary description for CharInv
/// </summary>
/// 
public class CharInv
{
    private static int maxItems = 30;

    private List<Loot> loot;
    private float money;

	public CharInv(List<Loot> loot, float money)
	{
        this.loot = loot;
        this.money = money;
	}

    public List<Loot> Loot
    {
        get { return this.loot; }
        set 
        {
            if (this.loot.Count() < maxItems)
            {
                this.loot.Add(value[0]);
            }
        }
    }

    public float Money
    {
        get { return this.money; }
        set { this.money = value; }
    }
}
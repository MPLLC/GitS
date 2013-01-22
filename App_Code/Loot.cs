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
/// Abstract base class for all Loot in the game.
/// </summary>

public abstract class Loot
{
    private string name;
    private float buyValue;
    private float sellValue;

    public Loot(string name, float buyValue, float sellValue)
    {
        this.name = name;
        this.buyValue = buyValue;
        this.sellValue = sellValue;
    }
}
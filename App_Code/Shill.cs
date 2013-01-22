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
/// This file defines the Corporate Shill class.  They are the hybrid class of the game.
/// </summary>

public class Shill : ICharacterClass
{
    #region Class Data Members

    private static int hitPoints = 16;
    private static int techPoints = 16;
    private static int baseDmg = 4;
    private static int hpMultiplier = 3;
    private static int tpMultiplier = 3;
    private static int baseDmgMultiplier = 3;
    private static int baseDefense = 16;

    #endregion

    #region Class Methods

    public Shill() { }

    #endregion

    #region Class Properties

    public int HP
    {
        get { return hitPoints; }
    }

    public int TP
    {
        get { return techPoints; }
    }

    public int BaseDMG
    {
        get { return baseDmg; }
    }

    public int HPMultiplier
    {
        get { return hpMultiplier; }
    }

    public int TPMultiplier
    {
        get { return tpMultiplier; }
    }

    public int BaseDMGMultiplier
    {
        get { return baseDmgMultiplier; }
    }

    public int BaseDefense
    {
        get { return baseDefense; }
    }

    #endregion
}
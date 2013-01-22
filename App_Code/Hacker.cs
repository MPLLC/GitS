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
/// This file defines the Hacker class, which implements the ICharacterClass interface.
/// The Hacker is a strong 'magic'/weak physical class.
/// </summary>
 
public class Hacker : ICharacterClass
{
    #region Class Data Members

    private static int hitPoints = 10;
    private static int techPoints = 25;
    private static int baseDmg = 2;
    private static int hpMultiplier = 2;
    private static int tpMultiplier = 4;
    private static int baseDmgMultiplier = 2;
    private static int baseDefense = 25;

    #endregion

    #region Class Methods

    public Hacker() { }

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
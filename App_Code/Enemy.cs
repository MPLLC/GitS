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
using System.Collections.Generic;

/// <summary>
/// This class defines the enemies a player character can encounter.  All enemies have the same 
/// attributes, so only one class is needed.  Each individual object will be created from data 
/// stored in the db.
/// </summary>

public class Enemy : Character
{
    public Enemy(CharAttacks attacks, CharBio bio, CharInv inv, CharStats stats) : 
        base(attacks, bio, inv, stats) { }
}
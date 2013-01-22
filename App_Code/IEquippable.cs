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
/// This interface defines what actions/abilities an equippable Loot item should have.  
/// It also creates separation between Loot that can be equipped by the player character, 
/// and Loot which cannot be equipped.
/// </summary>

public interface IEquippable 
{
    void Equip(PlayerCharacter PC);
}
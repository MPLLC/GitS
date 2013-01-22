using System;
using System.Collections.Generic;
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
/// This file defines the PlayerCharacter class.  It is one of the core types of the game,
/// representing the user's character.  It is primarily a container class, as it mostly stores 
/// and displays the current player character information.
/// </summary>
 
public class PlayerCharacter : Character
{
    #region Class Data Members

    private Equipment equipment;

    #endregion

    #region Class Methods

    public PlayerCharacter(CharAttacks attacks, CharBio bio, CharInv inv, CharStats stats, Equipment equipment) :
        base(attacks, bio, inv, stats)
    {
        this.equipment = equipment;
    }

    public void LevelUp()
    {
        this.stats.TotalHP += (this.stats.TotalHP / 10) * this.stats.CharClass.HPMultiplier;
        this.stats.TotalTP += (this.stats.TotalTP / 10) * this.stats.CharClass.TPMultiplier;
        this.stats.DMGModifier += 0.10f;
        this.stats.ChanceToHit += 0.05f;
        this.stats.DMG += (this.stats.DMG / 10) * this.stats.CharClass.BaseDMGMultiplier;

        if ((this.stats.Level % 3) == 0)
        {
            try
            {
                AttackRegistry attackReg = new AttackRegistry();
                Attack newAttack = attackReg.GetAttack(this);
                this.attacks.AddAttack(newAttack);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }

    #endregion

    #region Class Properties

    public Weapon LeftHand
    {
        get { return this.equipment.LeftHand; }
        set { this.equipment.LeftHand = value; }
    }

    public Weapon RightHand
    {
        get { return this.equipment.RightHand; }
        set { this.equipment.RightHand = value; }
    }

    public Armor Armor
    {
        get { return this.equipment.Armor; }
        set { this.equipment.Armor = value; }
    }

    #endregion
}
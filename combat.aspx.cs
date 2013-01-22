using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class combat : System.Web.UI.Page
{
    private CombatEngine combatEngine;

    protected void AttackButtonClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string attackName = button.CommandName;
        this.combatEngine.ProcessPlayerTurn(attackName);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PlayerCharacter PC = (PlayerCharacter)System.Web.HttpContext.Current.Session["attacker"];
            Enemy enemy = (Enemy)System.Web.HttpContext.Current.Session["target"];
            this.combatEngine = new CombatEngine(PC, enemy);
        }
        else
        {
            this.combatEngine = (CombatEngine)System.Web.HttpContext.Current.Session["combatEngine"];
        }

        int attackCount = this.combatEngine.PC.Attacks.Count;

        for (int i = 0; i < attackCount; i++)
        {
            Button attackButton = (Button)attackGrid.FindControl("Button" + (i + 1).ToString());
            attackButton.CommandName = this.combatEngine.PC.Attacks.ElementAt(i).Name;
            attackButton.Text = attackButton.CommandName;
            attackButton.Click += new EventHandler(this.AttackButtonClick);
            attackButton.Visible = true;
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        switch (this.combatEngine.CombatState)
        {
            case CombatEngine.CombatStates.InCombat:
                attackGrid.Visible = true;
                break;

            case CombatEngine.CombatStates.Dead:
                attackGrid.Visible = false;
                /* logic for dead buttons */
                break;

            case CombatEngine.CombatStates.Victory:
                attackGrid.Visible = false;
                /* logic for victory buttons */
                break;

            case CombatEngine.CombatStates.Fled:
                attackGrid.Visible = false;
                /* logic for fled buttons */
                break;
        }

        //this.combatEngine.WriteResults();

        this.combatEngine.ProcessEffects();

        if (ViewState["test"] == null)
        {
            combatScreen.InnerHtml = this.combatEngine.DisplayCombatResults();
        }
        else
        {
            combatScreen.InnerHtml = (string)ViewState["test"];
            combatScreen.InnerHtml = this.combatEngine.DisplayCombatResults();
        }

        ViewState["test"] = combatScreen.InnerHtml;


        System.Web.HttpContext.Current.Session["combatEngine"] = this.combatEngine;
    }

    protected void Page_Load(object sender, EventArgs e) { }
}
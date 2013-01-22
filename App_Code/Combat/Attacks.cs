using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
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
/// Class for each type of special attack map.
/// Every character class' special attack will be mapped to the appropriate Attacks subclass.
/// </summary>

public class Attacks : Dictionary<int, Attack>
{
    protected Dictionary<int, Attack> attacks = new Dictionary<int, Attack>();

	public Attacks(string className)
    {
        string query = "Select level, name, tpCost, dmgModifier, hitPenalty from DB" + className + "Attacks";

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GitSConnectionString1"].ConnectionString))
        {
            SqlCommand cmd;
            SqlDataReader reader;

            cmd = new SqlCommand(query, conn);
            conn.Open();

            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Attack attack = new Attack(reader.GetString(1), reader.GetInt32(0), reader.GetInt32(2), reader.GetDouble(3), reader.GetDouble(4), new Poison());
                this.attacks.Add(attack.Level, attack);
            }
        }
    }

    public void Add(Attack attack)
    {
        this.attacks.Add(attack.Level, attack);
    }

    public Attack Retrieve(int key)
    {
        return this.attacks[key];
    }
}
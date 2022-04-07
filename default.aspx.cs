using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;

namespace Proj3Game
{
    public partial class _default : System.Web.UI.Page
    {
        void MakeNewTeams()
        {
            SQLDatabase.DatabaseTable team1_table = new SQLDatabase.DatabaseTable("Team1");
            SQLDatabase.DatabaseTable defaultTeam1_table = new SQLDatabase.DatabaseTable("PreTeam1");

            int p1TeamSize = 4;

            for (int i = 0; i < p1TeamSize; ++i)
            {
                SQLDatabase.DatabaseRow gameRow = team1_table.GetRow(i);
                SQLDatabase.DatabaseRow defaultRow = defaultTeam1_table.GetRow(i);

                gameRow["Health"] = defaultRow["Health"];
                gameRow["Attack"] = defaultRow["Attack"];
                gameRow["Defense"] = defaultRow["Defense"];
                gameRow["SpellPower"] = defaultRow["SpellPower"];
                gameRow["Alive"] = defaultRow["Alive"];
                gameRow["Image"] = defaultRow["Image"];

                team1_table.Update(gameRow);
            }

            SQLDatabase.DatabaseTable team2_table = new SQLDatabase.DatabaseTable("Team2");
            SQLDatabase.DatabaseTable defaultTeam2_table = new SQLDatabase.DatabaseTable("PreTeam2");

            int p2TeamSize = 4;

            for (int i = 0; i < p2TeamSize; ++i)
            {
                SQLDatabase.DatabaseRow gameRow = team2_table.GetRow(i);
                SQLDatabase.DatabaseRow defaultRow = defaultTeam2_table.GetRow(i);


                gameRow["Health"] = defaultRow["Health"];
                gameRow["Attack"] = defaultRow["Attack"];
                gameRow["Defense"] = defaultRow["Defense"];
                gameRow["SpellPower"] = defaultRow["SpellPower"];
                gameRow["Alive"] = defaultRow["Alive"];
                gameRow["Image"] = defaultRow["Image"];

                team2_table.Update(gameRow);
            }            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidRoundNum.Value = 1.ToString();
                RoundText.Text = "Round " + hidRoundNum.Value;

                MakeNewTeams();
            }

            SQLDatabase.DatabaseTable preteam1_table = new SQLDatabase.DatabaseTable("PreTeam1");
            SQLDatabase.DatabaseTable preteam2_table = new SQLDatabase.DatabaseTable("PreTeam2");

            hidP1ConfirmClicked.Value = "False";
            hidP2ConfirmClicked.Value = "False";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                SQLDatabase.DatabaseTable team1_table = new SQLDatabase.DatabaseTable("Team1");
                SQLDatabase.DatabaseRow team1Row = team1_table.GetRow(0);
                if (hidP1ActiveCharacter.Value != "")
                {
                    switch (hidP1ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            team1Row = team1_table.GetRow(0);
                            break;
                        case ("Water"):
                            team1Row = team1_table.GetRow(1);
                            break;
                        case ("Earth"):
                            team1Row = team1_table.GetRow(2);
                            break;
                        case ("Wind"):
                            team1Row = team1_table.GetRow(3);
                            break;
                    }
                    P1ActiveHealth.Text = "Health - " + team1Row["Health"];
                    P1ActiveAttack.Text = "Attack - " + team1Row["Attack"];
                    P1ActiveDefense.Text = "Defense - " + team1Row["Defense"];
                    P1ActiveSpellPower.Text = "Spell power - " + team1Row["SpellPower"];
                }
                else
                {
                    P1ActiveHealth.Text = "Health - ";
                    P1ActiveAttack.Text = "Attack - ";
                    P1ActiveDefense.Text = "Defense - ";
                    P1ActiveSpellPower.Text = "Spell power - ";
                }

                SQLDatabase.DatabaseTable team2_table = new SQLDatabase.DatabaseTable("Team2");
                SQLDatabase.DatabaseRow team2Row = team2_table.GetRow(0);
                if (hidP2ActiveCharacter.Value != "")
                {
                    switch (hidP2ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            team2Row = team2_table.GetRow(0);
                            break;
                        case ("Water"):
                            team2Row = team2_table.GetRow(1);
                            break;
                        case ("Earth"):
                            team2Row = team2_table.GetRow(2);
                            break;
                        case ("Wind"):
                            team2Row = team2_table.GetRow(3);
                            break;
                    }
                    P2ActiveHealth.Text = "Health - " + team2Row["Health"];
                    P2ActiveAttack.Text = "Attack - " + team2Row["Attack"];
                    P2ActiveDefense.Text = "Defense - " + team2Row["Defense"];
                    P2ActiveSpellPower.Text = "Spell power - " + team2Row["SpellPower"];
                }
                else
                {
                    P2ActiveHealth.Text = "Health - ";
                    P2ActiveAttack.Text = "Attack - ";
                    P2ActiveDefense.Text = "Defense - ";
                    P2ActiveSpellPower.Text = "Spell power - ";
                }
            }


            CheckIfDead();
        }

        void CheckIfDead()
        {
            SQLDatabase.DatabaseTable team1_table = new SQLDatabase.DatabaseTable("Team1");
            SQLDatabase.DatabaseTable team2_table = new SQLDatabase.DatabaseTable("Team2");

            int p1MembersDead = 0;
            for (int i = 0; i < 4; ++i)
            {
                SQLDatabase.DatabaseRow team1Row = team1_table.GetRow(i);

                if (Int32.Parse(team1Row["Health"]) <= 0)
                {
                    switch (team1Row["Type"])
                    {
                        case ("Fire"):
                            P1Member1Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team1Row["Alive"] = "False";
                            team1_table.Update(team1Row);
                            P1ActiveChar.ImageUrl = "";
                            hidP1ActiveCharacter.Value = "";
                            break;
                        case ("Water"):
                            P1Member2Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team1Row["Alive"] = "False";
                            team1_table.Update(team1Row);
                            P1ActiveChar.ImageUrl = "";
                            hidP1ActiveCharacter.Value = "";
                            break;
                        case ("Earth"):
                            P1Member3Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team1Row["Alive"] = "False";
                            team1_table.Update(team1Row);
                            P1ActiveChar.ImageUrl = "";
                            hidP1ActiveCharacter.Value = "";
                            break;
                        case ("Wind"):
                            P1Member4Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team1Row["Alive"] = "False";
                            team1_table.Update(team1Row);
                            P1ActiveChar.ImageUrl = "";
                            hidP1ActiveCharacter.Value = "";
                            break;
                    }

                    if (team1Row["Alive"] == "False")
                    {
                        p1MembersDead++;
                    }
                    if(p1MembersDead == 4)
                    {
                        Response.Redirect("P2WinScreen.aspx");
                    }
                }
            }

            int p2MembersDead = 0;
            for (int i = 0; i < 4; ++i)
            {
                SQLDatabase.DatabaseRow team2Row = team2_table.GetRow(i);

                if (Int32.Parse(team2Row["Health"]) <= 0)
                {
                    switch (team2Row["Type"])
                    {
                        case ("Fire"):
                            P2Member1Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team2Row["Alive"] = "False";
                            team2_table.Update(team2Row);
                            P2ActiveChar.ImageUrl = "";
                            hidP2ActiveCharacter.Value = "";
                            break;
                        case ("Water"):
                            P2Member2Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team2Row["Alive"] = "False";
                            team2_table.Update(team2Row);
                            P2ActiveChar.ImageUrl = "";
                            hidP2ActiveCharacter.Value = "";
                            break;
                        case ("Earth"):
                            P2Member3Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team2Row["Alive"] = "False";
                            team2_table.Update(team2Row);
                            P2ActiveChar.ImageUrl = "";
                            hidP2ActiveCharacter.Value = "";
                            break;
                        case ("Wind"):
                            P2Member4Image.ImageUrl = "~/Images/Characters/DeadCard.png";
                            team2Row["Alive"] = "False";
                            team2_table.Update(team2Row);
                            P2ActiveChar.ImageUrl = "";
                            hidP2ActiveCharacter.Value = "";
                            break;
                    }

                    if (team2Row["Alive"] == "False")
                    {
                        p2MembersDead++;
                    }
                    if (p2MembersDead == 4)
                    {
                        Response.Redirect("P1WinScreen.aspx");
                    }
                }
            }
        }

        void P1DeselectCards(int charNum)
        {
            switch (charNum)
            {
                case (0):
                    P1Member1Image.ImageUrl = "~/Images/Characters/Clicked_Fire_Wizard.png";
                    P1Member2Image.ImageUrl = "~/Images/Characters/Water_Wizard.png";
                    P1Member3Image.ImageUrl = "~/Images/Characters/Earth_Wizard.png";
                    P1Member4Image.ImageUrl = "~/Images/Characters/Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
                case (1):
                    P1Member1Image.ImageUrl = "~/Images/Characters/Fire_Wizard.png";
                    P1Member2Image.ImageUrl = "~/Images/Characters/Clicked_Water_Wizard.png";
                    P1Member3Image.ImageUrl = "~/Images/Characters/Earth_Wizard.png";
                    P1Member4Image.ImageUrl = "~/Images/Characters/Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
                case (2):
                    P1Member1Image.ImageUrl = "~/Images/Characters/Fire_Wizard.png";
                    P1Member2Image.ImageUrl = "~/Images/Characters/Water_Wizard.png";
                    P1Member3Image.ImageUrl = "~/Images/Characters/Clicked_Earth_Wizard.png";
                    P1Member4Image.ImageUrl = "~/Images/Characters/Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
                case (3):
                    P1Member1Image.ImageUrl = "~/Images/Characters/Fire_Wizard.png";
                    P1Member2Image.ImageUrl = "~/Images/Characters/Water_Wizard.png";
                    P1Member3Image.ImageUrl = "~/Images/Characters/Earth_Wizard.png";
                    P1Member4Image.ImageUrl = "~/Images/Characters/Clicked_Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
            }
        }

        protected void P1ClickMember(object sender, ImageMapEventArgs e)
        {
            SQLDatabase.DatabaseTable team1_table = new SQLDatabase.DatabaseTable("Team1");
            SQLDatabase.DatabaseRow row;

            switch ((sender as ImageMap).ID)
            {
                case ("P1Member1Image"):
                    row = team1_table.GetRow(0);

                    if (row["Alive"] == "True")
                    {
                        P1ActiveChar.ImageUrl = "~/Images/Characters/Fire_Wizard.png";

                        P1DeselectCards(0);

                        hidP1ActiveCharacter.Value = "Fire";


                        P1ActiveHealth.Text = "Health - " + row["Health"];
                        P1ActiveAttack.Text = "Attack - " + row["Attack"];
                        P1ActiveDefense.Text = "Defense - " + row["Defense"];
                        P1ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;

                case ("P1Member2Image"):
                    row = team1_table.GetRow(1);

                    if (row["Alive"] == "True")
                    {
                        P1ActiveChar.ImageUrl = "~/Images/Characters/Water_Wizard.png";

                        P1DeselectCards(1);

                        hidP1ActiveCharacter.Value = "Water";

                        P1ActiveHealth.Text = "Health - " + row["Health"];
                        P1ActiveAttack.Text = "Attack - " + row["Attack"];
                        P1ActiveDefense.Text = "Defense - " + row["Defense"];
                        P1ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;

                case ("P1Member3Image"):
                    row = team1_table.GetRow(2);
                    if (row["Alive"] == "True")
                    {
                        P1ActiveChar.ImageUrl = "~/Images/Characters/Earth_Wizard.png";

                        P1DeselectCards(2);

                        hidP1ActiveCharacter.Value = "Earth";

                        P1ActiveHealth.Text = "Health - " + row["Health"];
                        P1ActiveAttack.Text = "Attack - " + row["Attack"];
                        P1ActiveDefense.Text = "Defense - " + row["Defense"];
                        P1ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;

                case ("P1Member4Image"):
                    row = team1_table.GetRow(3);
                    if (row["Alive"] == "True")
                    {
                        P1ActiveChar.ImageUrl = "~/Images/Characters/Wind_Wizard.png";

                        P1DeselectCards(3);

                        hidP1ActiveCharacter.Value = "Wind";

                        P1ActiveHealth.Text = "Health - " + row["Health"];
                        P1ActiveAttack.Text = "Attack - " + row["Attack"];
                        P1ActiveDefense.Text = "Defense - " + row["Defense"];
                        P1ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;
            }
        }



        //// Player 2 stuff

        void P2DeselectCards(int charNum)
        {
            switch (charNum)
            {
                case (0):
                    P2Member1Image.ImageUrl = "~/Images/Characters/Clicked_Fire_Wizard.png";
                    P2Member2Image.ImageUrl = "~/Images/Characters/Water_Wizard.png";
                    P2Member3Image.ImageUrl = "~/Images/Characters/Earth_Wizard.png";
                    P2Member4Image.ImageUrl = "~/Images/Characters/Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
                case (1):
                    P2Member1Image.ImageUrl = "~/Images/Characters/Fire_Wizard.png";
                    P2Member2Image.ImageUrl = "~/Images/Characters/Clicked_Water_Wizard.png";
                    P2Member3Image.ImageUrl = "~/Images/Characters/Earth_Wizard.png";
                    P2Member4Image.ImageUrl = "~/Images/Characters/Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
                case (2):
                    P2Member1Image.ImageUrl = "~/Images/Characters/Fire_Wizard.png";
                    P2Member2Image.ImageUrl = "~/Images/Characters/Water_Wizard.png";
                    P2Member3Image.ImageUrl = "~/Images/Characters/Clicked_Earth_Wizard.png";
                    P2Member4Image.ImageUrl = "~/Images/Characters/Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
                case (3):
                    P2Member1Image.ImageUrl = "~/Images/Characters/Fire_Wizard.png";
                    P2Member2Image.ImageUrl = "~/Images/Characters/Water_Wizard.png";
                    P2Member3Image.ImageUrl = "~/Images/Characters/Earth_Wizard.png";
                    P2Member4Image.ImageUrl = "~/Images/Characters/Clicked_Wind_Wizard.png";
                    Page_Load(this, null);
                    break;
            }
        }

        protected void P2ClickMember(object sender, ImageMapEventArgs e)
        {
            SQLDatabase.DatabaseTable team2_table = new SQLDatabase.DatabaseTable("Team2");
            SQLDatabase.DatabaseRow row;

            switch ((sender as ImageMap).ID)
            {
                case ("P2Member1Image"):
                    row = team2_table.GetRow(0);
                    if (row["Alive"] == "True")
                    {
                        P2ActiveChar.ImageUrl = "~/Images/Characters/Fire_Wizard.png";

                        P2DeselectCards(0);

                        hidP2ActiveCharacter.Value = "Fire";

                        P2ActiveHealth.Text = "Health - " + row["Health"];
                        P2ActiveAttack.Text = "Attack - " + row["Attack"];
                        P2ActiveDefense.Text = "Defense - " + row["Defense"];
                        P2ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;

                case ("P2Member2Image"):
                    row = team2_table.GetRow(1);
                    if (row["Alive"] == "True")
                    {
                        P2ActiveChar.ImageUrl = "~/Images/Characters/Water_Wizard.png";

                        P2DeselectCards(1);

                        hidP2ActiveCharacter.Value = "Water";

                        P2ActiveHealth.Text = "Health - " + row["Health"];
                        P2ActiveAttack.Text = "Attack - " + row["Attack"];
                        P2ActiveDefense.Text = "Defense - " + row["Defense"];
                        P2ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;

                case ("P2Member3Image"):
                    row = team2_table.GetRow(2);
                    if (row["Alive"] == "True")
                    {
                        P2ActiveChar.ImageUrl = "~/Images/Characters/Earth_Wizard.png";

                        P2DeselectCards(2);

                        hidP2ActiveCharacter.Value = "Earth";

                        P2ActiveHealth.Text = "Health - " + row["Health"];
                        P2ActiveAttack.Text = "Attack - " + row["Attack"];
                        P2ActiveDefense.Text = "Defense - " + row["Defense"];
                        P2ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;

                case ("P2Member4Image"):
                    row = team2_table.GetRow(3);
                    if (row["Alive"] == "True")
                    {
                        P2ActiveChar.ImageUrl = "~/Images/Characters/Wind_Wizard.png";

                        P2DeselectCards(3);

                        hidP2ActiveCharacter.Value = "Wind";

                        P2ActiveHealth.Text = "Health - " + row["Health"];
                        P2ActiveAttack.Text = "Attack - " + row["Attack"];
                        P2ActiveDefense.Text = "Defense - " + row["Defense"];
                        P2ActiveSpellPower.Text = "Spell power - " + row["SpellPower"];
                    }
                    break;
            }
        }

        string PickSpell()
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(0, 6);

            switch (rndNum)
            {
                case (0):
                    return "Fireball";
                case (1):
                    return "Regrowth";
                case (2):
                    return "Storm";
                case (3):
                    return "Gust";
                case (4):
                    return "MagicShot";
                case (5):
                    return "MagicExplosion";
                default:
                    return "MagicShot";
            }
        }

        void SetSpellCardImage(string spell)
        {
            switch (spell)
            {
                case ("Fireball"):
                    SpellCardImage.ImageUrl = "~/Images/Actions/Fireball.png";
                    break;
                case ("Storm"):
                    SpellCardImage.ImageUrl = "~/Images/Actions/Storm.png";
                    break;
                case ("Regrowth"):
                    SpellCardImage.ImageUrl = "~/Images/Actions/Regrowth.png";
                    break;
                case ("Gust"):
                    SpellCardImage.ImageUrl = "~/Images/Actions/Gust.png";
                    break;
                case ("MagicShot"):
                    SpellCardImage.ImageUrl = "~/Images/Actions/MagicShot.png";
                    break;
                case ("MagicExplosion"):
                    SpellCardImage.ImageUrl = "~/Images/Actions/MagicExplosion.png";
                    break;
            }
        }

        public void P1UseSpell(string spell, string casterType, int casterRow, int targetRow, int casterTeam)
        {
            // Initialising "random" values so it can be used
            SQLDatabase.DatabaseTable casterTable = new SQLDatabase.DatabaseTable("Team1");
            SQLDatabase.DatabaseRow cRow = casterTable.GetRow(0);
            SQLDatabase.DatabaseTable targetTable = new SQLDatabase.DatabaseTable("Team2");
            SQLDatabase.DatabaseRow tRow = targetTable.GetRow(0);

            int casterHealth = 0;
            int casterAttack = 0;
            int casterDefense = 0;
            int casterSpellPower = 0;

            int targetHealth = 0;
            int targetAttack = 0;
            int targetDefense = 0;
            int targetSpellPower = 0;

            if (casterTeam == 1)
            {
                casterTable = new SQLDatabase.DatabaseTable("Team1");
                cRow = casterTable.GetRow(casterRow);
                casterHealth = Int32.Parse(cRow["Health"]);
                casterAttack = Int32.Parse(cRow["Attack"]);
                casterDefense = Int32.Parse(cRow["Defense"]);
                casterSpellPower = Int32.Parse(cRow["SpellPower"]);

                targetTable = new SQLDatabase.DatabaseTable("Team2");
                tRow = targetTable.GetRow(targetRow);
                targetHealth = Int32.Parse(tRow["Health"]);
                targetAttack = Int32.Parse(tRow["Attack"]);
                targetDefense = Int32.Parse(tRow["Defense"]);
                targetSpellPower = Int32.Parse(tRow["SpellPower"]);
            }
            else if(casterTeam == 2)
            {
                targetTable = new SQLDatabase.DatabaseTable("Team1");
                tRow = targetTable.GetRow(targetRow);
                targetHealth = Int32.Parse(tRow["Health"]);
                targetAttack = Int32.Parse(tRow["Attack"]);
                targetDefense = Int32.Parse(tRow["Defense"]);
                targetSpellPower = Int32.Parse(tRow["SpellPower"]);

                casterTable = new SQLDatabase.DatabaseTable("Team2");
                cRow = casterTable.GetRow(casterRow);
                casterHealth = Int32.Parse(cRow["Health"]);
                casterAttack = Int32.Parse(cRow["Attack"]);
                casterDefense = Int32.Parse(cRow["Defense"]);
                casterSpellPower = Int32.Parse(cRow["SpellPower"]);
            }


            switch (spell)
            {
                case ("Fireball"):
                    if(casterType == "Fire")
                    {
                        targetHealth -= (((casterAttack + 20) * casterSpellPower) / 6) / targetDefense;
                    }
                    else
                    {
                        targetHealth -= ((casterAttack * casterSpellPower) / 6) / targetDefense;
                    }
                    casterSpellPower -= (int)(casterSpellPower * 0.1);

                    cRow["SpellPower"] = casterSpellPower.ToString();
                    casterTable.Update(cRow);

                    tRow["Health"] = targetHealth.ToString();
                    targetTable.Update(tRow);
                    break;
                case ("Regrowth"):
                    if(casterType == "Earth")
                    {
                        casterHealth += (int)(casterHealth * 0.4);
                    }
                    else
                    {
                        casterHealth += (int)(casterHealth * 0.2);
                    }
                    casterSpellPower -= (int)(casterSpellPower * 0.1);

                    cRow["Health"] = casterHealth.ToString();
                    cRow["SpellPower"] = casterSpellPower.ToString();
                    casterTable.Update(cRow);
                    break;
                case ("Storm"):
                    if(casterType == "Water")
                    {
                        targetHealth -= (((casterAttack + 10) * casterSpellPower) / 6) / targetDefense;
                    }
                    else
                    {
                        targetHealth -= ((casterAttack * casterSpellPower) / 6) / targetDefense;
                    }
                    if (casterType == "Water")
                    {
                        targetSpellPower -= 20;
                    }
                    casterSpellPower -= (int)(casterSpellPower * 0.1);

                    cRow["SpellPower"] = casterSpellPower.ToString();
                    casterTable.Update(cRow);

                    tRow["Health"] = targetHealth.ToString();
                    tRow["SpellPower"] = targetSpellPower.ToString();
                    targetTable.Update(tRow);
                    break;
                case ("Gust"):
                    if (casterType == "Wind")
                    {
                        targetHealth -= (((casterAttack + 10) * casterSpellPower) / 6) / targetDefense;
                    }
                    else
                    {
                        targetHealth -= ((casterAttack * casterSpellPower) / 6) / targetDefense;
                    }
                    if(casterType == "Wind")
                    {
                        targetDefense -= 10;
                    }
                    casterSpellPower -= (int)(casterSpellPower * 0.1);

                    cRow["SpellPower"] = casterSpellPower.ToString();
                    casterTable.Update(cRow);

                    tRow["Health"] = targetHealth.ToString();
                    tRow["Defense"] = targetDefense.ToString();
                    targetTable.Update(tRow);
                    break;
                case ("MagicShot"):
                    targetHealth -= 30;
                    casterSpellPower -= (int)(casterSpellPower * 0.25);

                    cRow["SpellPower"] = casterSpellPower.ToString();
                    casterTable.Update(cRow);

                    tRow["Health"] = targetHealth.ToString();
                    targetTable.Update(tRow);
                    break;
                case ("MagicExplosion"):
                    for (int i = 0; i < 4; ++i)
                    {
                        tRow = targetTable.GetRow(i);
                        targetHealth = Int32.Parse(tRow["Health"]);
                        targetHealth -= 10;

                        tRow["Health"] = targetHealth.ToString();
                        targetTable.Update(tRow);
                    }
                    casterSpellPower -= (int)(casterSpellPower * 0.25);
                    cRow["SpellPower"] = casterSpellPower.ToString();
                    casterTable.Update(cRow);
                    break;
            }
        }

        protected void P1Confirm_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(hidRoundNum.Value) % 2 == 1)
            {
                if ((P1ActiveChar.ImageUrl != "") && (hidP1ConfirmClicked.Value == "False"))
                {
                    hidP1ConfirmClicked.Value = "True";
                    string chosenSpell = PickSpell();
                    SQLDatabase.DatabaseTable team1_table = new SQLDatabase.DatabaseTable("Team1");
                    SQLDatabase.DatabaseTable team2_table = new SQLDatabase.DatabaseTable("Team2");
                    SQLDatabase.DatabaseRow row;

                    int p1Active = 0;
                    switch (hidP1ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            p1Active = 0;
                            break;
                        case ("Water"):
                            p1Active = 1;
                            break;
                        case ("Earth"):
                            p1Active = 2;
                            break;
                        case ("Wind"):
                            p1Active = 3;
                            break;
                    }
                    int p2Active = 0;
                    switch (hidP2ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            p2Active = 0;
                            break;
                        case ("Water"):
                            p2Active = 1;
                            break;
                        case ("Earth"):
                            p2Active = 2;
                            break;
                        case ("Wind"):
                            p2Active = 3;
                            break;
                    }

                    switch (hidP1ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            P1UseSpell(chosenSpell, hidP1ActiveCharacter.Value, p1Active, p2Active, 1);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                        case ("Water"):
                            P1UseSpell(chosenSpell, hidP1ActiveCharacter.Value, p1Active, p2Active, 1);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                        case ("Earth"):
                            P1UseSpell(chosenSpell, hidP1ActiveCharacter.Value, p1Active, p2Active, 1);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                        case ("Wind"):
                            P1UseSpell(chosenSpell, hidP1ActiveCharacter.Value, p1Active, p2Active, 1);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                    }
                }

                Page_Load(this, null);
            }
        }

        protected void P2Confirm_Click(object sender, EventArgs e)
        {
            if(Int32.Parse(hidRoundNum.Value) % 2 == 0)
            {
                if ((P2ActiveChar.ImageUrl != "") && (hidP2ConfirmClicked.Value == "False"))
                {
                    hidP2ConfirmClicked.Value = "True";
                    string chosenSpell = PickSpell();
                    SQLDatabase.DatabaseTable team1_table = new SQLDatabase.DatabaseTable("Team1");
                    SQLDatabase.DatabaseTable team2_table = new SQLDatabase.DatabaseTable("Team2");
                    SQLDatabase.DatabaseRow row;

                    int p1Active = 0;
                    switch (hidP1ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            p1Active = 0;
                            break;
                        case ("Water"):
                            p1Active = 1;
                            break;
                        case ("Earth"):
                            p1Active = 2;
                            break;
                        case ("Wind"):
                            p1Active = 3;
                            break;
                    }
                    int p2Active = 0;
                    switch (hidP2ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            p2Active = 0;
                            break;
                        case ("Water"):
                            p2Active = 1;
                            break;
                        case ("Earth"):
                            p2Active = 2;
                            break;
                        case ("Wind"):
                            p2Active = 3;
                            break;
                    }

                    switch (hidP2ActiveCharacter.Value)
                    {
                        case ("Fire"):
                            P1UseSpell(chosenSpell, hidP2ActiveCharacter.Value, p2Active, p1Active, 2);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                        case ("Water"):
                            P1UseSpell(chosenSpell, hidP2ActiveCharacter.Value, p2Active, p1Active, 2);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                        case ("Earth"):
                            P1UseSpell(chosenSpell, hidP2ActiveCharacter.Value, p2Active, p1Active, 2);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                        case ("Wind"):
                            P1UseSpell(chosenSpell, hidP2ActiveCharacter.Value, p2Active, p1Active, 2);
                            SetSpellCardImage(chosenSpell);

                            row = team1_table.GetRow(p1Active);

                            P1ActiveHealth.Text = row["Health"];
                            P1ActiveAttack.Text = row["Attack"];
                            P1ActiveDefense.Text = row["Defense"];
                            P1ActiveSpellPower.Text = row["SpellPower"];

                            row = team2_table.GetRow(p2Active);

                            P2ActiveHealth.Text = row["Health"];
                            P2ActiveAttack.Text = row["Attack"];
                            P2ActiveDefense.Text = row["Defense"];
                            P2ActiveSpellPower.Text = row["SpellPower"];
                            break;
                    }
                }

                Page_Load(this, null);
            }
        }

        protected void NextRound_Click(object sender, EventArgs e)
        {
            P1ActiveChar.ImageUrl = "";
            hidP1ActiveCharacter.Value = "";
            P2ActiveChar.ImageUrl = "";
            hidP2ActiveCharacter.Value = "";

            SpellCardImage.ImageUrl = "";

            hidRoundNum.Value = (Int32.Parse(hidRoundNum.Value) + 1).ToString();

            RoundText.Text = "Round " + hidRoundNum.Value;

            if(Int32.Parse(hidRoundNum.Value) % 2 == 1)
            {
                P1Confirm.BackColor = System.Drawing.Color.White;
                P1Confirm.BorderColor = System.Drawing.Color.Silver;

                P2Confirm.BackColor = System.Drawing.Color.Red;
                P2Confirm.BorderColor = System.Drawing.Color.Maroon;
            }
            else if(Int32.Parse(hidRoundNum.Value) % 2 == 0)
            {
                P1Confirm.BackColor = System.Drawing.Color.Red;
                P1Confirm.BorderColor = System.Drawing.Color.Maroon;

                P2Confirm.BackColor = System.Drawing.Color.White;
                P2Confirm.BorderColor = System.Drawing.Color.Silver;
            }
            hidP1ConfirmClicked.Value = "False";
            hidP2ConfirmClicked.Value = "False";

            Page_Load(this, null);
        }
    }
}
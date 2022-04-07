<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Proj3Game._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <div style="position:absolute; top: 0px; left: 0px;">
        <asp:Image ID="BgndImg" runat="server" ImageUrl="~/Images/Cardholdertings.png" style="position:absolute;height:937px; width:1920px; top: -1px; left: 0px;"/>
    </div>

    <form id="form1" runat="server">

        <div style="position:relative;">
            <asp:Label ID="RoundText" runat="server" Text="Label" style="position:absolute;top:0px;left:960px;" Font-Bold="True" Font-Names="Bahnschrift SemiBold Condensed"></asp:Label>
        </div>

        <asp:ImageMap ID="SpellCardImage" runat="server" style="position:absolute; height:300px; width:200px; top:200px; left:860px;"></asp:ImageMap>

        <%--Player 1 stuff--%>
        <asp:Label ID="P1ActiveHealth" runat="server" Text="Health" style="position:absolute; top:100px; left:200px;" EnableTheming="True"></asp:Label> 

        <asp:Label ID="P1ActiveAttack" runat="server" Text="Attack" style="position:absolute; top:200px; left:200px;"></asp:Label>

        <asp:Label ID="P1ActiveDefense" runat="server" Text="Defense" style="position:absolute; top:300px; left:200px;"></asp:Label>

        <asp:Label ID="P1ActiveSpellPower" runat="server" Text="Spell power" style="position:absolute; top:400px; left:200px;"></asp:Label>

        <asp:Image ID="P1ActiveChar" runat="server" style="position:absolute; height:562px; width:375px; top:50px; left:400px;"/>
        <input type ="hidden" name="hidP1ActiveCharacter" id ="hidP1ActiveCharacter" runat="server" enableviewstate="true" />
        <input type ="hidden" name="hidP1ConfirmClicked" id ="hidP1ConfirmClicked" runat="server" enableviewstate="true" />

        <asp:ImageMap ID="P1Member1Image" runat="server" imageurl="~/Images/Characters/Fire_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px" OnClick="P1ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline" BackColor="#CC0000">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>
        <asp:ImageMap ID="P1Member2Image" runat="server" imageurl="~/Images/Characters/Water_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px; left:220px;" OnClick="P1ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>
                <asp:ImageMap ID="P1Member3Image" runat="server" imageurl="~/Images/Characters/Earth_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px; left:430px;" OnClick="P1ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>
        <asp:ImageMap ID="P1Member4Image" runat="server" imageurl="~/Images/Characters/Wind_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px; left:640px;" OnClick="P1ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>


        <%--Player 2 stuff--%>
        <asp:Label ID="P2ActiveHealth" runat="server" Text="Heath" style="position:absolute; top:100px; right:200px;"></asp:Label>

        <asp:Label ID="P2ActiveAttack" runat="server" Text="Attack" style="position:absolute; top:200px; right:200px;"></asp:Label>

        <asp:Label ID="P2ActiveDefense" runat="server" Text="Defense" style="position:absolute; top:300px; right:200px;"></asp:Label>

        <asp:Label ID="P2ActiveSpellPower" runat="server" Text="Spell power" style="position:absolute; top:400px; right:200px;"></asp:Label>


        <asp:Image ID="P2ActiveChar" runat="server" style="position:absolute; height:562px; width:375px; top:50px; right:400px;"/>
        <input type ="hidden" name="hidP2ActiveCharacter" id ="hidP2ActiveCharacter" runat="server" enableviewstate="true" />
        <input type ="hidden" name="hidP2ConfirmClicked" id ="hidP2ConfirmClicked" runat="server" enableviewstate="true" />

        <asp:ImageMap ID="P2Member1Image" runat="server" imageurl="~/Images/Characters/Fire_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px; right:10px;" OnClick="P2ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>
        <asp:ImageMap ID="P2Member2Image" runat="server" imageurl="~/Images/Characters/Water_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px; right:220px;" OnClick="P2ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>
                <asp:ImageMap ID="P2Member3Image" runat="server" imageurl="~/Images/Characters/Earth_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px; right:430px;" OnClick="P2ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>
        <asp:ImageMap ID="P2Member4Image" runat="server" imageurl="~/Images/Characters/Wind_Wizard.png" Height="300px" Width="200px" style="position:absolute; top:630px; right:640px;" OnClick="P2ClickMember" HotSpotMode="PostBack" BorderColor="#0000CC" ImageAlign="Baseline">
            <asp:RectangleHotSpot
                top="0"
                left="0"
                bottom="549"
                right="365" 
                HotSpotMode="PostBack">
            </asp:RectangleHotSpot>    
        </asp:ImageMap>

        <asp:Button ID="P1Confirm" runat="server" Text="Confirm" style="position:absolute; top:590px; left:300px;" OnClick="P1Confirm_Click" BackColor="White" BorderColor="Silver" />
        <asp:Button ID="P2Confirm" runat="server" Text="Confirm" style="position:absolute; top:590px; right:300px;" OnClick="P2Confirm_Click" BackColor="Red" BorderColor="Maroon" />
        <center> <asp:Button ID="NextRound" runat="server" Text="Next Round" style="position:absolute; top:590px;" OnClick="NextRound_Click" /> </center>
        <input type ="hidden" name="hidRoundNum" id ="hidRoundNum" runat="server" enableviewstate="true" />

    </form>
    </body>
</html>

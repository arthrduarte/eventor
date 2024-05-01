<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="EventSystem.EventDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Style/main.css" rel="stylesheet" />
    <link href="App_Themes/Style/stylesheet-eventdetails.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/6290499b5f.js" crossorigin="anonymous"></script>
</head>
<body>
    <nav>
        <div id="navLeftSide">
            <h1><a href="AllEvents.aspx">eventor</a></h1>
        </div>
        <div id="navRightSide">
            <ul>
                <li><a>My Tickets</a></li>
                <li><a>Sign Up</a></li>
                <li><a>Log In</a></li>
            </ul>
        </div>
    </nav>
    <main>
        <div id="ContentEventDetails">
            <div id="ContentEventImage">
                <asp:Literal ID="EventImage" runat="server"></asp:Literal>
            </div>
            <div id="ContentEventInfo">
                <div id="ContentEventHeader">
                    <asp:Literal ID="EventTitle" runat="server"></asp:Literal>
                    <div class="hasIcon">
                        <i class="fa-solid fa-calendar" style="color: #F45B69;"></i>
                        <asp:Literal ID="EventDate" runat="server"></asp:Literal>
                    </div>
                    <div class="hasIcon">
                        <i class="fa-solid fa-location-dot" style="color: #F45B69;"></i>
                        <asp:Literal ID="EventLocation" runat="server"></asp:Literal>
                    </div>
                    <div id="ContentEventAbout">
                        <h2>About</h2>
                        <asp:Label ID="EventDescription" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="ContentEventTicket">
                    <form runat="server">
                        <asp:HiddenField runat="server" ID="HiddenPrice" />
                        <div id="BuyTicketCard">
                            <div id="BuyTicketCardHeader">
                                <p>Tickets</p>
                            </div>
                            <div id="BuyTicketCardContent">
                                <div>
                                    <p>General regular ticket</p>
                                    <asp:Literal ID="TicketPrice" runat="server"></asp:Literal>
                                </div>
                                <div>
                                    <i id="minusIcon" class="fa-solid fa-minus" onclick="changeLabel(false)"></i>
                                    <asp:Label runat="server" ID="QuantityOfTickets" Text="1"></asp:Label>
                                    <i id="plusIcon" class="fa-solid fa-plus" onclick="changeLabel(true)"></i>
                                </div>
                            </div>
                            <hr />
                            <div id="BuyTicketCardBottom">
                                <asp:Button id="CheckoutButton" runat="server"></asp:Button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </main>
    <footer>
        <ul>
            <li><a href="#">Home</a></li>
            <li><a href="#">Events</a></li>
            <li><a href="#">Contact</a></li>
            <li><a href="#">Blog</a></li>
            <li><a href="#">About</a></li>
        </ul>
        <hr />
        <p>© 2024 Eventor </p>
    </footer>


    <script type="text/javascript"> 
        const checkoutButton = document.getElementById('<%= CheckoutButton.ClientID %>');
        const quantityLabel = document.getElementById('<%= QuantityOfTickets.ClientID %>');
        let currentQuantity = parseInt(quantityLabel.innerText);
        const pricePerTicket = parseFloat(document.getElementById('<%= HiddenPrice.ClientID %>').value);

        function changeLabel(isIncrement) {
            if (isIncrement) {
                currentQuantity++;
            } else {
                if (currentQuantity > 1) {
                    currentQuantity--;
                }
            }
            quantityLabel.innerText = currentQuantity;

            updateCheckoutButton(currentQuantity);
        }

        function updateCheckoutButton(quantity) {
            const totalPrice = quantity * pricePerTicket;
            checkoutButton.value = 'Check out for CA$' + totalPrice.toFixed(2);
        }  

        updateCheckoutButton(currentQuantity);
    </script>
</body>
</html>

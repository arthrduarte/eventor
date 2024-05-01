<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllEvents.aspx.cs" Inherits="EventSystem.AllEvents"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event System</title>
    <link href="App_Themes/Style/main.css" rel="stylesheet" />
    <link href="App_Themes/Style/stylesheet.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
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
        <div id="MainContainer">
            <div id="LeftSideContainer">
                <form id="form1" runat="server">
                    <h1>Create your event:</h1>
                    <p>Answer a few questions about your event</p>
            
                    <%-- Name --%>
                    <div id="eventNameContainer">
                        <h3 class="event-question-label">What's the name of your event?</h3>
                        <p>This will be your event’s title. Your title will be used to create your event’s post, so be specific!</p>
                        <asp:TextBox runat="server" ID="eventNameInput" Placeholder="Event title:*" CssClass="text-box"></asp:TextBox>
                        <asp:Label ID="eventNameError" CssClass="error" runat="server" Text="Type the event's name"></asp:Label>
                    </div>
                    <%-- Description --%>
                    <div id="eventDescriptionContainer">
                        <h3 class="event-question-label">Describe your event</h3>
                        <asp:TextBox runat="server" ID="eventDescriptionInput" Placeholder="Event description:*" CssClass="text-box" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
                        <asp:Label ID="eventDescriptionError" CssClass="error" runat="server" Text="Describe your event"></asp:Label>
                    </div>
                    <%-- Date --%>
                    <div id="eventDateContainer">
                        <h3 class="event-question-label">When is your event?</h3>
                        <asp:TextBox runat="server" ID="eventDateInput" type="date" CssClass="text-box"></asp:TextBox>
                        <asp:Label ID="eventDateError" CssClass="error" runat="server" Text="Select the date"></asp:Label>
                    </div>
                    <%-- Location --%>
                    <div id="eventLocationContainer">
                        <h3 class="event-question-label">Where is it located?</h3>
                        <asp:Button runat="server" ID="eventLocationVenueButton" Text="Venue" OnClick="CheckVenueLocation" />
                        <asp:Button runat="server" ID="eventLocationOnlineButton" Text="Online" OnClick="CheckVenueLocation" /><br />
                        <asp:TextBox runat="server" ID="eventLocationAddressInput" Placeholder="Event location:*" CssClass="text-box"></asp:TextBox>
                        <asp:Label ID="eventLocationAddressError" CssClass="error" runat="server" Text="Type the address"></asp:Label>
                    </div>
                    <%-- Price --%>
                    <div id="eventPriceContainer">
                        <h3 class="event-question-label">How much do you want to charge?</h3>
                        <asp:TextBox runat="server" ID="eventPriceInput" CssClass="text-box" Placeholder="0.00"></asp:TextBox>
                        <asp:Label ID="eventPriceError" CssClass="error" runat="server" Text="Put a price or check the box"></asp:Label>
                        <asp:CheckBox runat="server" ID="eventPriceFreeCheckbox" OnCheckedChanged="EventPriceFreeCheckbox_CheckedChanged" AutoPostBack="true"/>
                        <asp:Label runat="server" ID="eventPriceFree" text="Free tickets"></asp:Label>
                    </div>
                    <div>
                        <asp:Button runat="server" ID="submitButton" OnClick="CheckCreateEvent" Text="Submit Event" />
                    </div>
                </form>
            </div>
    
        <div id="RightSideContainer">

            <h1>Available Events:</h1>
            <%-- Cards Containers --%>
            <div id="availableEventsContainer">
                <asp:PlaceHolder ID="cardPlaceholder" runat="server"></asp:PlaceHolder>
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


</body>
</html>

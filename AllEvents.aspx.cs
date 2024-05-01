using EventSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventSystem
{
    public partial class AllEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["eventList"] == null)
                {
                    Session["eventList"] = Helper.AvailableEvents();
                }
                eventNameError.Visible = false;
                eventDescriptionError.Visible = false;
                eventDateError.Visible = false;
                eventLocationAddressError.Visible = false;
                eventPriceError.Visible = false;
                eventLocationAddressInput.Visible = true;

                List<Event> eventList = Helper.AvailableEvents();

            }
                PublishEvents();
        }

        public void CheckCreateEvent(object sender, EventArgs e)
        {
            bool eventName = true, eventDesc = true, eventDate = true, eventAddress = true, eventCity = true, eventPrice = true;
            string eventLocation = string.Empty;
            List<Event> eventList = (List<Event>)Session["eventList"];

            if (string.IsNullOrEmpty(eventNameInput.Text))
            {
                eventNameError.Visible = true;
                eventName = false;
            } 
            
            if (string.IsNullOrEmpty(eventDescriptionInput.Text))
            {
                eventDescriptionError.Visible = true;
                eventDesc = false;

            } 
            
            if (string.IsNullOrEmpty(eventDateInput.Text))
            {
                eventDateError.Visible = true;
                eventDate = false;

            } 
            
            if (!eventLocationAddressInput.Visible) 
            {
                eventLocation = "Online";

            } else if (string.IsNullOrEmpty(eventLocationAddressInput.Text))
            {
                eventLocationAddressError.Visible = true;
                eventAddress = false;

            } else
            {
                eventLocation = eventLocationAddressInput.Text;
            } 
            
            if (string.IsNullOrEmpty(eventPriceInput.Text) && !eventPriceFreeCheckbox.Checked)
            {
                eventPriceError.Visible = true;
                eventPrice = false;

            }


            double eventChosenPrice = 0;
            if (!eventPriceFreeCheckbox.Checked && !double.TryParse(eventPriceInput.Text, out eventChosenPrice))
            {
                eventPriceError.Visible = true;
                eventPrice = false;
            }

            if (eventName && eventDesc && eventDate && eventAddress && eventCity && eventPrice)
            {
                string eventLink = ReturnImageLink();
                Event newEvent = new Event(eventNameInput.Text, eventDescriptionInput.Text, eventDateInput.Text, eventLocation, eventChosenPrice, eventLink);
                eventList.Insert(0, newEvent);

                eventNameInput.Text = "";
                eventDescriptionInput.Text = "";
                eventDateInput.Text = "";
                eventLocationAddressInput.Text = "";
                eventPriceInput.Text = "";
            }

            PublishEvents();
        }

        public string ReturnImageLink()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 100);
            string link = $"https://picsum.photos/seed/{randomNumber}/1000/550";

            return link;
        }

        public void CheckVenueLocation(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if(clickedButton != null)
            {
                if(clickedButton.ID == "eventLocationVenueButton")
                {
                    eventLocationAddressInput.Visible = true;
                }
                else if (clickedButton.ID == "eventLocationOnlineButton")
                {
                    eventLocationAddressInput.Visible = false;
                }
            }
        }

        public string ChangeDateDisplay(string originalDate)
        {
            string date = originalDate;

            DateTime parsedDate;

            if(DateTime.TryParse(date, out parsedDate))
            {
                date = parsedDate.ToString("MMM d").ToUpper();
            }

            return date;
        }
        public void EventPriceFreeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (eventPriceFreeCheckbox.Checked)
            {
                eventPriceInput.Text = "0.00";
                eventPriceInput.Enabled = false; // Optionally make it read-only
            }
            else
            {
                eventPriceInput.Text = ""; // Clear the text or set it to some default value
                eventPriceInput.Enabled = true; // Make it editable again
            }
        }
        public void PublishEvents()
        {
            cardPlaceholder.Controls.Clear();
            List<Event> eventList = (List<Event>)Session["eventList"];
            foreach (Event eventItem in eventList)
            {
                Panel card = CreateCard(eventItem);
                cardPlaceholder.Controls.Add(card);
            }
        }

        public Panel CreateCard(Event eventItem)
        {
            string navigateUrl = ResolveUrl($"~/EventDetails.aspx?eventId={eventItem.Id}");

            Panel bottomCard = new Panel();
            bottomCard.CssClass = "event-card-bottom";

            Panel card = new Panel { CssClass = "event-card" };
            card.Attributes["role"] = "button";
            card.Attributes["onclick"] = $"location.href='{navigateUrl}';";

            LiteralControl imageSpan = new LiteralControl($"<img class='event-card-image' src='{eventItem.ImageURL}'></img>");
            card.Controls.Add(imageSpan);

            string parsedDate = ChangeDateDisplay(eventItem.Date);
            LiteralControl dateParagraph = new LiteralControl($"<p class='event-card-date'>{HttpUtility.HtmlEncode(parsedDate)}</p>");
            bottomCard.Controls.Add(dateParagraph);

            // Event name/title
            LiteralControl nameHeader = new LiteralControl($"<h3 class='event-card-title'>{HttpUtility.HtmlEncode(eventItem.Name)}</h3>");
            bottomCard.Controls.Add(nameHeader);

            // Event location
            LiteralControl locationParagraph = new LiteralControl($"<p class='event-card-location'>{HttpUtility.HtmlEncode(eventItem.Location)}</p>");
            bottomCard.Controls.Add(locationParagraph);

            card.Controls.Add(bottomCard);

            return card;
        }
    }   

}
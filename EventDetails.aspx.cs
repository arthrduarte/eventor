using EventSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventSystem
{
    public partial class EventDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["eventId"] != null)
                {
                    int eventId = int.Parse(Request.QueryString["eventId"]);
                    Event eventDetails = Helper.GetEventById(eventId);
                    if (eventDetails != null)
                    {
                        EventImage.Text = $"<img class='event-image' src='{eventDetails.ImageURL}'></img>";
                        EventTitle.Text = $"<h1>{HttpUtility.HtmlEncode(eventDetails.Name)}</h1>";
                        EventDate.Text = $"<p>{eventDetails.Date}</p>";
                        EventLocation.Text = $"<p>{eventDetails.Location}</p>";
                        EventDescription.Text = $"<p>{eventDetails.Description}</p>";
                        TicketPrice.Text = $"<p class='event-price'>CA${eventDetails.Price.ToString()}</p>";
                        CheckoutButton.Text = $"Check out for CA${eventDetails.Price}";
                        HiddenPrice.Value = eventDetails.Price.ToString();
                    }
                }
            }
        }
    }
}
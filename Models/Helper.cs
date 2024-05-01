using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace EventSystem.Models
{
    public class Helper
    {
        public static List<Event> AvailableEvents()
        {
            List<Event> eventList= new List<Event>();

            Event eventItem = new Event("Technata Career Fair", "Come meet professionals in the IT world and network with them", "11/08/2024", "85 Bogly Road", 0, "https://picsum.photos/seed/o3/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Winter Wonderland Fair", "Experience a magical winter fair filled with sparkling lights, festive decorations, and seasonal treats. Perfect for families, this event features ice skating, holiday markets, and live performances by local choirs and bands. Explore artisan crafts, enjoy hot chocolate stands, and capture memories with Santa Claus. It's an enchanting experience for all ages, promising to bring the joy and spirit of the holiday season.", "15/12/2024", "100 Snowflake Blvd", 10.00, "https://picsum.photos/seed/w1/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Urban Art and Jazz Festival", "Join us for an eclectic mix of art and music at the Urban Art and Jazz Festival. Stroll through outdoor galleries showcasing works from emerging artists and enjoy live jazz ensembles performing throughout the day. The event also features interactive art installations, street performers, and food trucks offering a variety of local and international cuisine. This vibrant festival celebrates the cultural diversity of our city and provides a platform for artists and musicians to connect with the community.", "22/05/2024", "200 Culture St", 15.00, "https://picsum.photos/seed/u2/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Digital Marketing Summit", "This annual summit brings together the brightest minds in digital marketing to discuss the future of advertising, content creation, and brand strategy. Attend workshops, panel discussions, and keynote speeches by industry leaders. Learn about the latest tools and trends, network with professionals, and gain insights into leveraging digital technologies to drive business growth. Whether you're a seasoned marketer or new to the field, this event is an invaluable resource for staying ahead in the rapidly evolving digital landscape.", "14/06/2024", "350 Digital Way", 250.00, "https://picsum.photos/seed/d3/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Global Film Festival", "Celebrate the art of cinema at the Global Film Festival, featuring a selection of international films, documentaries, and shorts. This week-long festival includes screenings, Q&A sessions with directors and actors, and workshops focused on filmmaking techniques and storytelling. Discover unique perspectives and stories from around the world that challenge, entertain, and inspire. The festival also offers a competitive section with awards for best film, best director, and audience favorite, highlighting exceptional talent and creativity in the film industry.", "09/11/2024", "500 Cinema Ave", 20.00, "https://picsum.photos/seed/g4/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Health and Wellness Expo", "Explore a holistic approach to health and well-being at the Health and Wellness Expo. This event features exhibitors from various health sectors, including nutrition, fitness, mental health, and alternative medicine. Participate in yoga and meditation sessions, attend seminars by health experts, and discover the latest health products and services. It's an ideal opportunity for anyone looking to improve their health, find new wellness practices, or connect with health professionals. Come and be inspired to lead a healthier, more balanced life.", "30/08/2024", "75 Wellness Ln", 5.00, "https://picsum.photos/seed/h5/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Retro Gaming Expo", "Step back in time at the Retro Gaming Expo where classic video games come to life. This nostalgic event features arcade machines, vintage console play areas, and retro gaming tournaments. Attend panels discussing the evolution of video gaming technology and meet legendary game designers. Whether you're a hardcore gamer or just looking to relive your childhood memories, this expo promises a fun-filled day for all ages. Don't miss out on exclusive merchandise and the chance to add rare games to your collection!", "01/10/2024", "300 Game Park Ave", 20.00, "https://picsum.photos/seed/r1/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Eco Living Fair", "Discover sustainable living at the Eco Living Fair, a dynamic event promoting environmental awareness and green technologies. Explore eco-friendly products, green energy solutions, and organic food options from hundreds of exhibitors. Participate in workshops on sustainable gardening, waste reduction, and eco-conscious living. This fair is a great opportunity for individuals and families to learn how to minimize their environmental footprint while enjoying interactive displays and live demonstrations that inspire a greener lifestyle.", "18/04/2024", "77 Greenleaf Blvd", 10.00, "https://picsum.photos/seed/e2/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Craft Beer Festival", "Join us at the annual Craft Beer Festival, where local and international breweries showcase their finest brews. Sample a wide variety of unique blends, from hoppy IPAs to rich stouts, and participate in beer-making workshops led by master brewers. This festival isn't just about beer; enjoy live music, food trucks serving gourmet street food, and interactive games that guarantee a fun day out for beer enthusiasts and casual drinkers alike. A perfect event to discover new flavors and enjoy the community spirit.", "22/07/2024", "859 Brewer St", 15.00, "https://picsum.photos/seed/c3/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Literary Arts Festival", "Celebrate the written word at the Literary Arts Festival, where authors, poets, and literary critics converge. Attend book readings, author signings, and panel discussions on current literary trends. The festival features sessions for budding writers, including workshops on creative writing, publishing, and marketing your work. Whether you're an aspiring writer or a book lover, this festival offers a deep dive into the literary world, providing networking opportunities and the inspiration to embark on your own writing journey.", "15/09/2024", "202 Booker Rd", 25.00, "https://picsum.photos/seed/l4/1000/550");
            eventList.Add(eventItem);

            eventItem = new Event("Outdoor Adventure Expo", "Gear up for the great outdoors at the Outdoor Adventure Expo, where adventure meets innovation. This expo is the ultimate destination for outdoor enthusiasts and nature lovers. Explore the latest in camping gear, outdoor clothing, and adventure sports equipment. Attend seminars on survival skills, wildlife photography, and eco-tourism. Test your limits with outdoor challenges or plan your next expedition with experts. Perfect for families and adrenaline seekers looking to enhance their outdoor experiences.", "03/12/2024", "101 Adventure Ln", 30.00, "https://picsum.photos/seed/o5/1000/550");
            eventList.Add(eventItem);


            return eventList;
        }
        public static Event GetEventById(int eventId)
        {
            var events = HttpContext.Current.Session["eventList"] as List<Event>;
            if (events != null)
            {
                return events.FirstOrDefault(e => e.Id == eventId);
            }
            return null;
            
        }
    }
}
using Models.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMe.ViewModels
{ 
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            BirthDate = DateTime.Now;
            Cities = new List<SelectListItem>();

            foreach(var city in _cities)
            {
                Cities.Add(new SelectListItem
                {
                    Text = city,
                    Value = city
                });
            }

            Genders = new List<SelectListItem>
            {
                new SelectListItem { Value = "Male", Text = "Male" },
                new SelectListItem { Value = "Female", Text = "Female" },
                new SelectListItem { Value = "Other", Text = "Other" }
            };
        }
        List<String> _cities = new List<String>
            {
                "Ale","Alingsås","Älmhult","Älvdalen","Alvesta","Arboga","Arjeplog",
                "Arvidsjaur","Arvika","Avesta","Båstad","Bengtsfors","Berg","Bjurholm","Bjuv",
                "Bollebygd","Bollnäs","Borås","Borlänge","Botkyrka","Boxholm","Bräcke",
                "Bromölla","Burlöv","Dals-Ed","Danderyd","Degerfors","Dorotea","Eda","Ekerö",
                "Eksjö","Enköping","Eskilstuna","Eslöv","Essunga","Fagersta","Falkenberg",
                "Falköping","Falun","Färgelanda","Filipstad","Finspång","Flen","Forshaga",
                "Gagnef","Gävle","Gislaved","Gnesta","Gnosjö","Göteborg","Götene","Grästorp",
                "Grums","Gullspång","Habo","Håbo","Hagfors","Hällefors","Hallsberg",
                "Hallstahammar","Halmstad","Hammarö","Haninge","Härjedalen","Härnösand",
                "Härryda","Hässleholm","Heby","Hedemora","Helsingborg","Herrljunga","Hjo",
                "Hofors","Höganäs","Höör","Hörby","Huddinge","Hudiksvall","Hylte","Järfälla",
                "Jokkmokk","Jönköping","Kalmar","Karlsborg","Karlshamn","Karlskoga",
                "Karlskrona","Karlstad","Katrineholm","Kävlinge","Kil","Kinda","Klippan",
                "Knivsta","Köping","Kramfors","Kristianstad","Kristinehamn","Krokom","Kumla",
                "Kungälv","Kungsbacka","Kungsör","Laholm","Landskrona","Laxå","Lekeberg",
                "Leksand","Lerum","Lessebo","Lidingö","Lidköping","Lilla Edet","Lindesberg",
                "Linköping","Ljungby","Ljusdal","Ljusnarsberg","Lomma","Ludvika","Lund",
                "Lycksele","Lysekil","Malå","Malmö","Malung-Sälen","Mariestad","Mark",
                "Markaryd","Mellerud","Mjölby","Mölndal","Mora","Motala","Mullsjö",
                "Munkedal","Munkfors","Nacka","Nässjö","Nora","Norberg","Nordanstig",
                "Nordmaling","Norrköping","Norrtälje","Norsjö","Nybro","Nyköping","Nykvarn",
                "Nynäshamn","Ockelbo","Olofström","Orsa","Orust","Osby","Oskarshamn","Ovanåker",
                "Oxelösund","Partille","Perstorp","Ragunda","Rättvik","Robertsfors","Ronneby",
                "Säffle","Sala","Salem","Sandviken","Säter","Sävsjö","Sigtuna","Simrishamn",
                "Sjöbo","Skara","Skellefteå","Skinnskatteberg","Skövde","Skurup","Smedjebacken",
                "Söderhamn","Söderköping","Södertälje","Sollefteå","Sollentuna","Solna",
                "Sölvesborg","Sorsele","Sotenäs","Staffanstorp","Stenungsund","Stockholm",
                "Storfors","Storuman","Strängnäs","Strömstad","Strömsund","Sundbyberg",
                "Sundsvall","Sunne","Surahammar","Svalöv","Svedala","Svenljunga","Täby","Tanum",
                "Tibro","Tidaholm","Tierp","Timrå","Tingsryd","Tjörn","Tomelilla","Töreboda",
                "Torsby","Tranås","Tranemo","Trelleborg","Trollhättan","Trosa","Tyresö",
                "Uddevalla","Ulricehamn","Umeå","Upplands Väsby","Upplands-Bro","Uppsala",
                "Uppvidinge","Vadstena","Vaggeryd","Valdemarsvik","Vallentuna","Vänersborg",
                "Vännäs","Vansbro","Vara","Varberg","Vårgårda","Värmdö","Värnamo","Västerås",
                "Västervik","Vaxholm","Växjö","Vellinge","Vetlanda","Vilhelmina","Vimmerby",
                "Vindeln","Vingåker","Visby","Ydre","Ystad","Åre","Årjäng","Åsele","Askersund",
                "Åstorp","Åtvidaberg","Åmål","Aneby","Ånge","Ängelholm","Älvkarleby","Öckerö",
                "Ödeshög","Örebro","Örkelljunga","Örnsköldsvik","Österåker","Östersund",
                "Östhammar","Östra Göinge"
            };
        private string _city;
        private string _gender;
        private string _lookingFor;

        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Genders { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression("^([a-zA-ZåäöÅÄÖ0-9_-])+$")]
        public string Nickname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Lastname { get; set; }

        [Required]
        public string City
        {
            get { return _city; }
            set
            {
                if(_cities.Find(c => c == value) != null)
                {
                    _city = value;
                } else
                {
                    _city = "Okänt";
                }
            }
        }

        [Required]
        public string Gender
        {
            get { return _gender; }
            set
            {
                switch(value)
                {
                    case GenderType.Male:
                        _gender = GenderType.Male;
                        break;
                    case GenderType.Female:
                        _gender = GenderType.Female;
                        break;
                    default:
                        _gender = GenderType.Other;
                        break;
                }
            }
        }

        [Required]
        public string LookingFor
        {
            get { return _lookingFor; }
            set
            {
                switch (value)
                {
                    case GenderType.Male:
                        _lookingFor = GenderType.Male;
                        break;
                    case GenderType.Female:
                        _lookingFor = GenderType.Female;
                        break;
                    default:
                        _lookingFor = GenderType.Other;
                        break;
                }
            }
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public virtual string Password { get; set; }

    }
}
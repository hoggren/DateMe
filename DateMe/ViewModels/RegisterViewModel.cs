using Models.Models.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DateMe.ViewModels
{ 
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
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
                "Katrineholm", "Eskilstuna", "Strängnäs", "Trosa",
                "Ödeshög", "Ydre", "Kinda", "Boxholm", "Åtvidaberg", "Finspång", "Valdemarsvik", "Linköping", "Norrköping", "Söderköping", "Motala", "Vadstena", "Mjölby",
                "Aneby", "Gnosjö", "Mullsjö", "Habo", "Gislaved", "Vaggeryd", "Jönköping", "Nässjö", "Värnamo", "Sävsjö", "Vetlanda", "Eksjö", "Tranås",
                "Uppvidinge","Lessebo","Tingsryd","Alvesta","Älmhult","Markaryd","Växjö","Ljungby",
                "Olofström", "Karlskrona", "Ronneby", "Karlshamn", "Sölvesborg",
                "Svalöv","Staffanstorp","Burlöv","Vellinge","Östra Göinge","Örkelljunga","Bjuv","Kävlinge","Lomma","Svedala","Skurup","Sjöbo","Hörby","Höör","Tomelilla","Bromölla","Osby","Perstorp","Klippan","Åstorp","Båstad","Malmö","Lund","Landskrona","Helsingborg","Höganäs","Eslöv","Ystad","Trelleborg","Kristianstad","Simrishamn","Ängelholm","Hässleholm",
                "Hylte","Halmstad","Laholm","Falkenberg","Varberg","Kungsbacka",
                "Härryda","Partille","Öckerö","Stenungsund","Tjörn","Orust","Sotenäs","Munkedal","Tanum","Dals-Ed","Färgelanda","Ale","Lerum","Vårgårda","Bollebygd","Grästorp","Essunga","Karlsborg","Gullspång","Tranemo","Bengtsfors","Mellerud","Lilla Edet","Mark","Svenljunga","Herrljunga","Vara","Götene","Tibro","Töreboda","Göteborg","Mölndal","Kungälv","Lysekil","Uddevalla","Strömstad","Vänersborg","Trollhättan","Alingsås","Borås","Ulricehamn","Åmål","Mariestad","Lidköping","Skara","Skövde","Hjo","Tidaholm","Falköping",
                "Kil","Eda","Torsby","Storfors","Hammarö","Munkfors","Forshaga","Grums","Årjäng","Sunne","Karlstad","Kristinehamn","Filipstad","Hagfors","Arvika","Säffle",
                "Lekeberg","Laxå","Hallsberg","Degerfors","Hällefors","Ljusnarsberg","Örebro","Kumla","Askersund","Karlskoga","Nora","Lindesberg",
                "Skinnskatteberg", "Surahammar", "Kungsör", "Hallstahammar", "Norberg", "Västerås", "Sala", "Fagersta", "Köping", "Arboga",
                "Vansbro", "Malung-Sälen", "Gagnef", "Leksand", "Rättvik", "Orsa", "Älvdalen", "Smedjebacken", "Mora", "Falun", "Borlänge", "Säter", "Hedemora", "Avesta", "Ludvika",
                "Ockelbo","Hofors","Ovanåker","Nordanstig","Ljusdal","Gävle","Sandviken","Söderhamn","Bollnäs","Hudiksvall",
                "Ånge", "Timrå", "Härnösand", "Sundsvall", "Kramfors", "Sollefteå", "Örnsköldsvik",
                "Ragunda", "Bräcke", "Krokom", "Strömsund", "Åre", "Berg", "Härjedalen", "Östersund",
                "Nordmaling","Bjurholm","Vindeln","Robertsfors","Norsjö","Malå","Storuman","Sorsele","Dorotea","Vännäs","Vilhelmina","Åsele","Umeå","Lycksele","Skellefteå",
                "Arvidsjaur", "Arjeplog", "Jokkmokk",
                "Upplands Väsby", "Vallentuna", "Österåker", "Värmdö", "Järfälla", "Ekerö", "Huddinge", "Botkyrka", "Salem", "Haninge", "Tyresö", "Upplands-Bro", "Nykvarn", "Täby", "Danderyd", "Sollentuna", "Stockholm", "Södertälje", "Nacka", "Sundbyberg", "Solna", "Lidingö", "Vaxholm", "Norrtälje", "Sigtuna", "Nynäshamn",
                "Håbo","Älvkarleby","Knivsta","Heby","Tierp","Uppsala","Enköping","Östhammar",
                "Vingåker" ,"Gnesta" ,"Nyköping" ,"Oxelösund" ,"Flen",
                "Visby",
                "Kalmar","Västervik","Oskarshamn","Nybro","Vimmerby"
            };
        private string _city;
        private string _gender;
        private string _lookingFor;

        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Genders { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
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
        public string Password { get; set; }

    }
}
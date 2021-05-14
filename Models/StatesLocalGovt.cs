using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentProject.Models
{
    public class StatesLocalGovt
    {
        public static List<string> Abia   ;
        public static List<string> Adamawa   ;
        public static List<string> AkwaIbom   ;
        public static List<string> Anambra   ;
        public static List<string> Bauchi   ;
        public static List<string> Bayelsa   ;
        public static List<string> Benue   ;
        public static List<string> Borno   ;
        public static List<string> CrossRiver   ;
        public static List<string> Delta   ;
        public static List<string> Ebonyi   ;
        public static List<string> Edo   ;
        public static List<string> Ekiti   ;
        public static List<string> Enugu   ;
        public static List<string> Gombe   ;
        public static List<string> Imo   ;
        public static List<string> Jigawa   ;
        public static List<string> Kaduna   ;
        public static List<string> Katsina   ;
        public static List<string> Kano   ;
        public static List<string> Kebbi   ;
        public static List<string> Kogi   ;
        public static List<string> Kwara   ;
        public static List<string> Lagos   ;
        public static List<string> Nassarawa;
        public static List<string> Niger;
        public static List<string> Ogun;
        public static List<string> Ondo;
        public static List<string> Osun;
        public static List<string> Oyo;
        public static List<string> Plateu;
        public static List<string> Rivers;
        public static List<string> Sokoto;
        public static List<string> Taraba;
        public static List<string> Yobe;
        public static List<string> Zamfara;


         public static  List<string>[] allstateslocalgovt = new List<string>[36];

        public StatesLocalGovt()
        {
        Abia = new List<string>()
        {
        "Arochukwu", "Ini", "ObiNgwa", "Umuahia South", "Umuahia_North", "Ikwuano", "Isiukwato", "Ukwa West", "Aba South",
        "AbaNorth", "IsialaNgwaNorth", "Obingwa gbo", "Umunneochi Igbo", "Ukwa East"
        };
         Adamawa = new List<string>()
        {
        "Demsa", "Fufore", "Ganye", "Girei", "Gombi", "Guduniya", "Guyuk", "Hong", "Jada",
        "Lamurde", "Madagali", "Maiha", "Mayo ", "Belwa","Michika", "Mubi", "MubiSouth", "Numan",
        "Shelleng", "Song", "Toungo", "Yola	", "Yola North", "Yola South"
        };
        AkwaIbom = new List<string>()
        {
                "Abak", "Eastern Obolo", "Eket", "Esit-Eket", "Essien Udim", "Etim-Ekpo", "Etinan", "Ibeno", "Ibesikpo-Asutan",
                "Ibiono-Ibom", "Ika", "Ikono", "Ikot Abasi", "Ikot Ekpene","Ini", "Itu", "Mbo", "Mkpata-Enin",
                "Nsit-Atai", "Nsit-Ibom", "Obot-Akara", "Okobo	", "Onna", "Oron", "Oruk AnamUkanafun", "Udung-Uko", "Uruan", "Urue-Offong/Oruko", "Uyo"
        };
        Anambra = new List<string>()
        {
                "Aguata", "Awka North", "Awka South", "Anambra East", "Anambra West", "Anaocha", "Ayamelum", "Dunukofia", "Ekwusigo",
                "Idemili North", "Idemili South", "Ihiala", "Njikoka", "Nnewi North","Nnewi South", "Ogbaru", "Onitsha North", "Onitsha South",
                "Orumba North", "Orumba South", "Oyi"
        };

         Bauchi  = new List<string>()
        {
                "Bauchi", "Tafawa Balewa", "Dass", "Toro", "Bogoro", "Ningi", "Warji", "Ganjuwa", "Kirfi",
                "Alkaleri", "Darazo", "Misau", "Giade", "Shira","Jama'are", "Katagum", "Itas/Gadau", "Zaki",
                "Gamawa	-Atai", "Damban	"
        };
         Bayelsa  = new List<string>()
        {
                "Brass	", "Ekeremor", "Kolokuma Opokuma", "Nembe", "Ogbia", "Sagbama", "Southern Ijaw", "Yenagoa"
        };
         Benue  = new List<string>()
        {
                "Ado", "Agatu", "Apa", "Buruku", "Gboko", "Guma", "Gwer East", "Gwer West", "Katsina-Ala",
                "Konshisha", "Kwande", "Logo", "Makurdi", "Obi","Ogbadibo", "Ohimini", "Oju	", "Okpokwu	",
                "Otukpo", "Tarka", "Ukum", "Ushongo", "Ushongo", "Vandeikya"
        };
         Borno  = new List<string>()
        {
                "Askira-Uba	", "Bama", "Biu	", "Chibok	", "Damboa", "Dikwa	", "Gwoza", "Hawul", "Jilbe town",
                "Kaga", "Kala/Balge", "Konduga", "Kukawa", "Kwaya-Kusar","Maiduguri", "Monguno", "Ngala	",
        };
        CrossRiver  = new List<string>()
        {
                "Abi", "Akamkpa", "Apa", "Bekwarra", "Biase", "Boki	", "Calabar", "Ikom", "Obanliku",
                "Obubra	", "Obudu", "Odukpani", "Ogoja", "Yakurr","Yala"
        };
        Delta  = new List<string>()
        {
                "Aniocha North	", "Aniocha South", "Burutu", "Bomadi", "Ethiope East", "Ethiope West", "Ika North", "Ika South", "Isoko North",
                "Isoko South", "Ndokwa East", "LogNdokwa West", "Oshimili North", "Oshimili South","Okpe", "Patani", "Sapele", "Udu	",
                "Ughelli North	", "Ughelli South", "Ukwuani", "Uvwie", "Warri North", "Warri South", "Warri South West"
        };
        Ebonyi  = new List<string>()
        {
                "Abakaliki", "Afikpo", "Afikpo South", "Ebonyi", "Ezza North", "Ezza South", "Ikwo", "Ika South", "Ishielu",
                "Ivo", "Izzi", "Ohaukwu", "OOhaozara", "Onicha"
        };
        Edo  = new List<string>()
        {
                "Akoko-Edo", "Esan Central", "Esan North East", "Esan South", "Esan West", "Etsako", "Etsako Central", "Etsako East	", "Etsako West	",
                "Igueben", "Ikpoba-Okha	", "Oredo", "Orhionmwon", " Ovia North East","Ovia South West", "Owan East", "Owan West	", "Uhunmwonde",
        };
        Ekiti  = new List<string>()
        {
                "Ado-Ekiti", "Aiyekire", "Akoko North East", "Ekiti East", "Emure", "Ikere", "Irepodun-Ifelodun", "Ise-Orun	",
        };
        Enugu  = new List<string>()
        {
                "Aninri", "Awgu", "Enugu East", "Enugu North", "Enugu South", "Ezeagu", "Igbo Etiti", "Igbo Eze North", "Igbo Eze South",
                "Isi Uzo", "Nkanu East", "Nkanu West", "Nsukka", "Oji River","Udenu", "Udi", "Uzo-Uwani",
        };
        Gombe  = new List<string>()
        {
                "Akko", "Balanga", "Billiri", "Dukku", "Funakaye", "Gombe", "Kaltungo", "Kwami", "Nafada",
                "Shongom", "Yamaltu/Deba",
        };
        Imo  = new List<string>()
        {
                "Aboh Mbaise", "Ahiazu Mbaise", "Ehime Mbano", "Ezinihitte Mbaise", "Ideato North", "Ideato South", "Ika North", "Ika South", "Ihitte/Uboma",
                "Ikeduru", "Isiala Mbano", "Isu", "Mbaitoli", "Ngor Okpala", "Njaba","Nkwerre", "Nwangele", "Obowo", "Oguta",
                "Ohaji/Egbema", "Okigwe", "Onuimo", "Orlu", "Orsu", "Oru East", "Oru West", "Owerri Municipal", "Owerrin North", "Oweeri West"
        };
        Jigawa  = new List<string>()
        {
                "Auyo", "Babura", "Biriniwa", "Birnin Kudu", "Buji", "Dutse", "Gagarawa", "Garki", "Gumel",
                "Guri", "Gwaram", "Gwiwa", "Hadejia", "Jahun", "Kafin Hausa","Kaugama", "Kazaure", "Kiri Kasama", "Kiyawa",
                "Maigatari", "Malam Madori", "Miga", "Ringim", "Roni", "Sule Tankarkar", "Taura", "Yankwashi",
        };
        Kaduna  = new List<string>()
        {
                "Birnin Gwari", "Chikun", "Giwa	", "Igabi", "Ikara", "Jaba", "Jema'a", "Kachia", "Kaduna North",
                "Kaduna South", "Kagarko", "Kajuru", "Kaura", "Kauru", "Kubau","Kudan", "Lere", "Makarf", "Sabon Gari",
                "Sanga", "Soba", "Zangon Kataf", "Zaria",
        };
        Katsina  = new List<string>()
        {
                "Bakori", "Batagarawa", "Batsari", "Baure", "Bindawa", "Charanchi", "Dan Musa", "Dandume", "Danja",
                "Daura", "Dutsi", "Dutsin-Ma", "Faskari", "Funtua", "Ingawa","Jibia", "Kafur", "Kaita", "Kankara",
                "Kankia", "Katsina", "Kurfi", "Kusada","Mai'Adua", "Malumfashi", "Mani","Mashi", "Matazu", "Musawa",
                "Rimi", "Sabuwa", "Safana", "Sandamu", "Zango"
        };
        Kano  = new List<string>()
        {
                "Fagge", "Dala", "Gwale	", "Kano Municipal", "Tarauni", "Nassarawa", "Kumbotso", "Ungogo", "Kano Metropolitan Area",
                "Dawakin Tokin", "Tofa", "Rimin Gado", "Bagwai", "Gezawa", "Gabasawa","Minjibir	", "Dambatta", "Makoda", "Kunchi",
                "Bichi", "Tsanyawa", "Shanono", "Gwarzo","Karaye", "Rogo", "Kabo","Bunkure", "Kibiya", "Rano",
                "Tudun Wada", "Doguwa", "Madobi", "Kura","Garun Mallam", "Bebeji", "Kiru","Sumaila", "Garko	", "Takai", "Albasu", "Gaya",
                "Ajingi", "Wundil", "Warawa", "Dawakin Kudu"
        };
        Kebbi  = new List<string>()
        {
                "Aleiro", "Arewa Dandi", "Argungu", "Augie", "Birnin Kebbi", "Bunza", "Dandi", "Fakai", "Gwandu",
                "Jega", "Kalgo", "Koko/Besse", "Maiyama", "Ngaski", "Sakaba","Shanga", "Suru", "Wasagu", "Yauri",
                "Zuru",
        };
        Kogi  = new List<string>()
        {
                "Adavi", "Ajaokuta", "Ankpa", "Bassa", "Dekina", "Ibaji", "Idah", "Igalamela-Odolu", "Ijumu",
                "Kabba/Bunu", "KotonKarfe", "Lokoja", "MopaMuro", "Ofu", "Ogori/Magongo","Okehi", "Okene", "Olamaboro", "Omala",
                "YagbaEast", "YagbaWest"
        };
        Kwara  = new List<string>()
        {
                "Asa", "Baruten", "Edu", "Ekiti", "Ifelodun", "Ilorin East", "IlorinSouth", "IlorinWest", "Isin",
                "Irepodun", "Kaiama", "Moro", "Offa	", "OkeEro", "Oyun","Pategi",
        };
        Lagos  = new List<string>()
        {
                "Agege", "Alimosho", "IfakoIjaye", "Ikeja", "Kosofe", "Mushin", "OshodiIsolo", "Shomolu", "Apapa",
                "Eti-Osa", "Lagos_Island", "Lagos_Mainland", "AjeromiIfelodun", "AmuwoOdofin", "Ojo","Badagry", "Ikorodu", "IbejuLekki", "Epe",

        };
        Nassarawa  = new List<string>()
        {
                "Akwanga", "Awe", "Doma", "Karu", "Keana", "Kokona", "Lafia", "Nasarawa", "Nasarawa-Eggon",
                "Obi", "Toto", "Wamba",
        };
        Niger  = new List<string>()
        {
                "Agaie", "Agwara", "Bida", "Borgu", "Chanchaga", "Edati", "Gbako", "Gurara", "Katcha",
                "Kontagora", "Lapai", "Magama", "Mariga", "Mashegu", "Minna","Mokwa", "Munya", "Paikoro", "Rafi",
                "Rijau	", "Shiroro", "Suleja", "Wushishi"
        };
        Ogun  = new List<string>()
        {
                "Abeokuta North	", "Abeokuta South", "Ado-Odo/Ota", "Egbado North", "Egbado South", "Ewekoro", "Ifo", "Ijebu East", "Ijebu North",
                "Ijebu North East", "Ijebu Ode", "Magama", "Ikenne", "Imeko Afon", "Ipokia","Obafemi-Owode", "Odeda", "Odogbolu", "Ogun Waterside",
                "Remo North	", "Shagamu"
        };
        Ondo  = new List<string>()
        {
                "Akoko North East", "Akoko North West", "Akoko South West", "Ese-Odo", "Ilaje", "okitipupa", "Irele", "Ondo", "Akure",
                "Odigbo", "Ose",
        };
        Osun  = new List<string>()
        {
                "Akoko North East", "Akoko North West", "Akoko South West", "Ese-Odo", "Ilaje", "okitipupa", "Irele", "Ondo", "Akure",
                "Odigbo", "Ose",
        };
        Oyo  = new List<string>()
        {
                "Afijio", "Akinyele", "Atiba", "Atisbo", "Egbeda", "Ibadan North", "Ibadan North-East", "Ibadan North-West", "Ibadan South-East",
                "Ibadan South-West", "Ibarapa Central", "Ibarapa East", "Ibarapa North", "Ido", "Irepo","Iseyin", "Itesiwaju", "Iwajowa", "Kajola",
                "Ogbomosho North", "Ogbomosho South", "Ogo Oluwa", "Olorunsogo", "Oluyole", "Ona Ara", "Orelope", "Ori Ire", "Oyo East", "Oyo West", "Saki East"
                , " Saki West", "Surulere"
        };
        Plateu  = new List<string>()
        {
                "Barkin Ladi", "Bassa", "Bokkos", "Jos East", "Jos North", "Jos South", "Kanam", "Kanke", "Langtang North",
                "Langtang South", "Mangu", "Mikang", "Pankshin", "Qua'an Pan", "Riyom","Shendam", "Wase",
        };
        Rivers  = new List<string>()
        {
                "Abua-Odual", "Ahoada", "Ahoada East", "Ahoada West", "Aku", "Akuku Toru", "Andoni", "Asaritoru	", "Bonny",
                "Degema", "Eleme", "Emuoha", "Gokana", "Ikwerre", "Khana","Obio-Akpor", "Ogba-Egbema-Ndoni", "Ogoni", "Ogu-Bolo",
                "Ohaji-Egbema Ndoni	", "Okrika", "Opobo-Nkoro", "Oyigbo", "Port Harcourt", "Tai"
        };
        Sokoto  = new List<string>()
        {
                "Binji", "Bodinga", "Dange Shuni", "Gada", "Goronyo", "Gudu", "Gwadabawa", "Illela", "Isa",
                "Kebbe", "Kware", "Rabah", "Sabon Birni", "Shagari", "Silame","Sokoto North", "Sokoto South", "Tambuwal", "Tangaza",
                "Tureta	", "Wamako", "Wurno", "Yabo"
        };
        Taraba  = new List<string>()
        {
                "Ardokola", "Bali", "Donga", "Gashaka", "Gassol", "Ibi", "Jalingo", "Karim-Lamido", "Kurmi",
                "Lau", "Takum", "Wukari", "Yorro", "Zing",
        };
        Yobe  = new List<string>()
        {
                "Bade", "Bursari", "Damaturu", "Fika", "Fune", "Geidam", "Gujba", "Jakusko", "Nangere",
                "Nguru", "Potiskum",
        };
        Zamfara  = new List<string>()
        {
                "Anka", "Bakura", "Birnin Magaji/Kiyaw", "Bukkuyum", "Bungudu", "Geidam", "Chafe", "Gummi", "Gusau",
                "KauraNamoda", "Maradun", "Maru", "Shinkafi", "Talata Mafara", "Zurmi"
        };


            allstateslocalgovt [0] = Abia ;
            allstateslocalgovt[1] = Adamawa;
            allstateslocalgovt[2] = AkwaIbom ;
            allstateslocalgovt[3] = Anambra;
            allstateslocalgovt[4] = Bauchi;
            allstateslocalgovt[5] = Bayelsa;
            allstateslocalgovt[6] = Benue;
            allstateslocalgovt[7] = Borno;
            allstateslocalgovt[8] = CrossRiver;
            allstateslocalgovt[9] = Delta;
            allstateslocalgovt[10] = Ebonyi;
            allstateslocalgovt[11] = Edo;
            allstateslocalgovt[12] = Ekiti;
            allstateslocalgovt[13] = Enugu;
            allstateslocalgovt[14] = Gombe;
            allstateslocalgovt[15] = Imo;
            allstateslocalgovt[16] = Jigawa;
            allstateslocalgovt[17] = Kaduna;
            allstateslocalgovt[18] = Katsina;
            allstateslocalgovt[19] = Kano;
            allstateslocalgovt[20] = Kogi;
            allstateslocalgovt[21] = Kebbi;
            allstateslocalgovt[22] = Kwara;
            allstateslocalgovt[23] = Lagos;
            allstateslocalgovt[24] = Nassarawa;
            allstateslocalgovt[25] = Niger;
            allstateslocalgovt[26] = Ogun;
            allstateslocalgovt[27] = Ondo;
            allstateslocalgovt[28] = Osun;
            allstateslocalgovt[29] = Oyo;
            allstateslocalgovt[30] = Plateu;
            allstateslocalgovt[31]= Rivers;
            allstateslocalgovt[32] = Sokoto;
            allstateslocalgovt[33] = Taraba;
            allstateslocalgovt[34] = Yobe;
            allstateslocalgovt[35] = Zamfara;
           
        }
        //public static List<string> allstateslocalgovtLocalGovt = new List<string>()
        //{
        //    allstateslocalgovtLocalGovt.Add(AdamawaLocalGovt.ToList());
        //} 
    }
}

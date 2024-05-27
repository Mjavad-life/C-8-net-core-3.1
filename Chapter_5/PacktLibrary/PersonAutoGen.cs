

namespace Packt.Shared
{   
    // in kelas ba person taghsim shodan , 2 gholo yand
    // baghi code haye fasl 5 inja neveshte mishe
    public partial class Person
    {
        // 3 ta property tarif mikone 
        // 1 - a property defined using c# 1- 5 syntax
        public string origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}.";
            }
        }

        // 2 - do ta propertie dige ke az lambda expression c#6+ estef mikone
        public string Greeting => $"{Name} says 'Hello'.";

        public int Age => System.DateTime.Today.Year - DateOfBirth.Year ;

        // hala 1 properrtie misaze ba get va set
        public string FavoriteIceCream { get; set; } // auto-syntax

          // hala az private esref mikone to store a meghdar for property
          // in ye fildeh
            private string favoritePrimaryColor;

            // in ye propertie ba F bozorg
            public string FavoritePrimaryColor
            {
                get
                {
                    return favoritePrimaryColor;
                }
                set
                {
                    switch (value.ToLower())
                    {
                        case "red":
                        case "green":
                        case "blue":
                            favoritePrimaryColor = value;
                            break;
                        default:
                            throw new System.ArgumentException(
                              $"{value} is not a primary color." +
                              "choose from : red , green , blue."  
                            );
                    }
                }
            }

            // inja indexer haro moarefi mikone
            // inja this az noe person hast
            // indexer ha kam be kar mian
            public Person this[int index]
            {
                get
                {
                    return Children[index];
                }
                set
                {
                    Children[index] = value;
                }
            }
    } // payane kelas partial person
}
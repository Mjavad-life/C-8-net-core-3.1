using System;
using System.Collections.Generic; // mikhahad az list estefade konad baraye children
using static System.Console; // mikhahad void va return ra neshan dahad

namespace Packt.Shared
{   // yek class library hast
    // ke class haye digar mesle peopleapp
    // az in class use mikonand
    // va hala mikhad ke az partial estefade kone ke kelass
    // ro taghsim kone
    public partial class Person: object // yani az kelas object ers mibare 
    {
        // fields
        public string? Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList; // inja vaghti enum ro byte kardim neveshtam
        public List<Person> Children = new List<Person>(); // inja az aggregation use karde

        // constnts (mikhad yek field sabet tarif konr)
        public const string Species = "Homo Sapien";

        // read only field
        public readonly string HomePlanet = "Earth"; // behtare be jaye const az read only kar begirim
        public readonly DateTime Instantiated;

        // constructors
        public Person()
        {
            // set default value baraye field ha
            // read only field haro ham shamel mishe
            Name ="Neidonom";
            Instantiated = DateTime.Now;
        } // payane constroctor aval

        // constructor dovom ke baraye estefade 2 meghdar dar zaman sakht instance migire
        public Person(string initialName , string homePlanet)
        {
            Name =initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        // methods , kar ba method hara aghaz mikonad
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        // method dovom az noe return
        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}.";
        }

        // dare kar ba tuples ro yad mideh
        // dar faze 2 be item ha esm mide
        public (string Name , int Number , string Laghab , int age) GetFruit()
        {
            return (Name:"Apples" ,Number: 5 , Laghab:"kopak" ,age: 22);

        }

        // hala mikhad az parametr ha estefade kone
        // avali parametr nadare
        public string SayHello()
        {
            return $"{Name} deiir 'salam'";
        }
        // dovomi parametr migire be esme (name)
        // dar game 2 method sayhelloto ro override mokonam be sayhello
        public string SayHello(string name)
        {
            return $"{Name} yaghool 'ahlan bek ya {name}'.";
        }

        // hala methodi misaze ke optional parametrs dareh
        public string OptionalParameters(
            string command = "Run!" ,
            double number = 0.0 ,
            bool active = true)
        {
            return string.Format(
                format: "command is {0} , number is {1}, active is {2}",
                arg0: command , arg1:number , arg2:active
            );
        }

        // methodi mineviseh ke az 3 noe in , ref va out baraye parametr
        // estefadeh mikoneh
        public void PassingParameters(int x , ref int y , out int z)
        {
            // out parameters cannot have a default
            // and must be initialized inside the method
            z = 99;
            
            // har parametr ro afzayesh mideh
            x++;
            y++;
            z++;
        }
    } // tahe kelas person
}
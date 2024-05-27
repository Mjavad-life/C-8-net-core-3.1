 // yek console application ast ke
 // mikhahad az packt library estefade konad
 // pas az inke adres packtlibrary.csproj ra
 // da propleapp.csproj vared kardim az dotnet 
 // build estefade mikonim to compile peopleapp
 // and its dependency packtlibrary
 using Packt.Shared; // age omnisharp ro rosh nayaram
 // in namespace ro neshon nemideh
 using static System.Console;
 using System;

 namespace PeopleApp // esmesh ro az khodam zadam
 {
    public class Program // name kelass ro mesle program.cs gozashtam
    {
        static void Main(string[] args)
        {
            var bob = new Person(); // yek nemone ya object az kelass person sakhtam
            // mishod be jaye var az person use konam
            WriteLine(bob.ToString()); // ba inke kelas person hich field 
            // ya method nadare vali bob tostring() dare va javabesh
            // packt.shared.person hast

            bob.Name = " Bob Smith"; // inja meghdar name ro set mikone
            bob.DateOfBirth = new DateTime(1965 , 12 , 22);
            WriteLine(format:"{0} was born on {1:dddd, d MMMM yyyy}" ,
                    arg0: bob.Name , arg1: bob.DateOfBirth);

            var Alice = new Person // inja yek instance dige az kelas person misazim ba raveshe jadid
            {
                Name = "alice Jones",
                DateOfBirth = new DateTime(1988 , 2 , 3)
            };

            WriteLine(format:"{0} was born on {1:dd MMM yy}",
                    arg0: Alice.Name, arg1: Alice.DateOfBirth);

            // inja field zir da kelas person hast , ke az noe wondersofthe ancient world ast va oo az 
            // noe enum ast
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

            WriteLine(format: "{0}'s favorite wonder is {1}. it's integer is {2}.",
                    arg0: bob.Name , arg1: bob.FavoriteAncientWonder ,
                        arg2: (int) bob.FavoriteAncientWonder);

            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon
                | WondersOfTheAncientWorld.MausoleumAtHalicarnassus ; // inja az operator | (ya) use karde
            
            //bob.BucketList = (WondersOfTheAncientWorld)18; az inam mishod estef kard
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            // children yek list hast ke az type person tosh gharar midim
            // toye add bayad new person besazim ve be oon meghdar bedim
            bob.Children.Add(new Person{ Name = "alfered" , DateOfBirth = new DateTime(1978 , 3 ,2)});
            bob.Children.Add(new Person {Name = "Zambolak" , DateOfBirth = new DateTime(1999 , 4 ,23)});
            
            WriteLine($"{bob.Name} has {bob.Children.Count} children.");

            foreach (var child in bob.Children)
            {
                WriteLine($"   {child.Name}");
            }

            BankAccount.InterestRate = 0.012m; // store a shared value va in meghdar baraye tamam instance
            // ha sabet mimanad
            
            // yek nemone az kelas bank acount misazeh
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;

            WriteLine(format:"{0} earned {1:C} interest.",
                    arg0: jonesAccount.AccountName ,
                    arg1: jonesAccount.Balance * BankAccount.InterestRate);

            // yek instance dige az kelas bank acount sakht
            var garrierAccount = new BankAccount();
            garrierAccount.AccountName = "Ms. Gerrier";
            garrierAccount.Balance = 98;

            WriteLine(format: "{0} earned {1:C} interest.",
                    arg0: garrierAccount.AccountName ,
                    arg1: garrierAccount.Balance * BankAccount.InterestRate);

            // estefade az field constanti ke tarif karde
            // dakhele write , bob.species nemigireh
            WriteLine($"{bob.Name} is a {Person.Species}");

            // be kar giri read only field
            
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            // hala ke constructor tarif kardim 
            // azash bahre migirim
            var blankPerson = new Person();

            WriteLine(format:
            "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: blankPerson.Name , arg1: blankPerson.HomePlanet ,
            arg2 : blankPerson.Instantiated);

            // constroctor 2vom ro tarif kardam hala be kar migirim
            var gunny = new Person("Gunny" , "Shams");

            WriteLine(format:"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}." ,
                    arg0: gunny.Name , arg1: gunny.HomePlanet , arg2: gunny.Instantiated);

            // az 2 methodi ke dar person tarif kardim estefade mikonim
            bob.WriteToConsole(); // in method membere person hast
            WriteLine(bob.GetOrigin()); // chon get origin yek string return mikone mishe chapesh kard

            // az tuple ke tarif karde bahre migireh
            var fruit = bob.GetFruit(); // yek tuple misazad // dar faze 2 var mizare
            WriteLine($"{fruit.Name} , {fruit.Number} there are."); // inja be jaye item1 name va item2 number mizare

            // hala tuple ro deconstruct ya be ebarati baz mikonad be ajzash
            (string fruitName , int fruitNumber , string fruitLaghab , int fruitAge) = bob.GetFruit();
            WriteLine($" {fruitName} {fruitNumber} {fruitLaghab} {fruitAge}.");
           
            // az do methodi ke parametr migirand estef karde
            WriteLine(bob.SayHello());
            // pas az overload shodan sayhello shod ghablesh sayhelloto bod
            WriteLine(bob.SayHello("sodabeh"));

            // inja methodi ke optional parametrs dare ro call mikone
            WriteLine(bob.OptionalParameters()); // inja hich parametri nafrestad
            // hala  2 ta parametr mifresteh
            WriteLine(bob.OptionalParameters("Jump" , 98.5));
            // hala parametr haro ba name mifreste ta betone jabeja ersal kone
            WriteLine(bob.OptionalParameters(number:52.7 , command:"Hide!"));
            // mishe az named parametr ha use kard ta az optional parametrs rad beshim
            WriteLine(bob.OptionalParameters("Poke!" , active: false));

            // inja 3 noe variable minevise ta onharo
            // be onvane parametr ersal kone
            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"ghablesh : a = {a} , b = {b} , c = {c}.");

            // hala a b c ra mifrestam
                                            // c ro mitonest nafreste chon khodesh ziad mishe
            bob.PassingParameters(a , ref b , out c);

            WriteLine($"badesh : a = {a} , b= {b} , c = {c}."); // javab a = 10 , b = 21 , c = 100
            // copy a mire na khodesh , b refrencesh mire pas khodes ham ziad mishe 
            // c ham refrencesh mire va onja khodesh meghdar dare va on ziad mishe

            // sade kardan kar ba out
            int d = 10;
            int e = 20;
            WriteLine($"ghable: d = {d} , e = {e} , f hanoz vijod nadarneh.");

            // hala sade shodeye syntax baraye out parametr
            bob.PassingParameters(d , ref e , out int f);

            WriteLine($"badesh : d = {d} , e = {e} , f = {f}."); // d= 10 , e = 21 va f =100

            // karborde property ha ro neshon mide
            // inja az get ha estef mikooneh
            WriteLine(bob.origin);
            WriteLine(bob.Greeting);
            WriteLine(bob.Age);

            WriteLine($"{bob.FavoriteIceCream}"); // in ro khali chap mikone
            // estef az properti haye stable
            // meghdar favorite ice cream ro set kard
            bob.FavoriteIceCream = "Chocolate Fudge";

            WriteLine($" bob's favorite ice cream flavor is {bob.FavoriteIceCream}.");

            bob.FavoritePrimaryColor = "RED"; // Red ro set mikone va javab Red mishe
            // age chiz dige bezanam exception mideh

            // inja get mikone
            WriteLine($"bob's favorite primary color is {bob.FavoritePrimaryColor}.");
            //int bb = bob.Children[0].Age;
            // az indexer ha bahre migireh
            bob.Children.Add(new Person { Name = "goboli"});
            bob.Children.Add(new Person { Name = "magoli"});

            WriteLine($" bob's third child is {bob.Children[2].Name}");
            WriteLine($" bob's forth child is {bob.Children[3].Name}");
            WriteLine($" bob's third child is {bob[2].Name}");
            WriteLine($" bob's forth child is {bob[3].Name}");

           // var p = System.Math.PI;
           // WriteLine(p);
        } // tahe method main
    } // end of class peopleapp
 } // end of namespace 
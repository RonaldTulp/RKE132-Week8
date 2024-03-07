//string[] heroes = {"Jaanus", "Peeter", "Mehis", "Habemik", "Jaana" };
//string[] pahalased = {"Jeesus", "Ali", "Budda", "Juudas" };
//string[] relvad = { "Bazuuka", "Nuga", "Püstol", "Toigas", "Labidas", "King" };

string folderPath = @"\Week8\Dats\";
string heroesFile = "heroes.txt";
string pahalasedFile = "pahalased.txt";
string relvadFile = "relvad.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroesFile));
string[] pahalased = File.ReadAllLines(Path.Combine(folderPath, pahalasedFile));
string[] relvad = File.ReadAllLines(Path.Combine(folderPath, relvadFile));



string hero = GetRandomFromArray(heroes);
string herorelv = GetRandomFromArray(relvad);
int heroHP = GetHP(hero);
int heroSTR = heroHP;
Console.WriteLine($"Täna {hero} ({heroHP}) päästab päeva, kasutades {herorelv}");


string pahalane = GetRandomFromArray(pahalased);
string pahalanerelv = GetRandomFromArray(relvad);
int pahalaneHP = GetHP(pahalane);
int pahalaneSTR = pahalaneHP;
Console.WriteLine($"Täna {pahalane} ({pahalaneHP}) tahab teha paha, kasutades {pahalanerelv}");

while (heroHP > 0 && pahalaneHP > 0)
{
    heroHP = heroHP - kab00m(pahalane, pahalaneSTR);
    pahalaneHP = pahalaneHP - kab00m(hero, heroSTR);
}

Console.WriteLine($"Kangelane {hero}: {heroHP}HP");
Console.WriteLine($"Pahalane {pahalane}: {pahalaneHP}HP");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} tegi seda jälle!");
}
else if (pahalaneHP > 0)
{
    Console.WriteLine($"Maailm on hävitatud {pahalane} poolt");
}
else
{
    Console.WriteLine("Viik");
}


static string GetRandomFromArray(string[] someArray)
{
    Random rng = new Random();
    int rngIndex = rng.Next(0, someArray.Length);
    string randomStringFromArray = someArray[rngIndex];
    return randomStringFromArray;
}

static int GetHP(string name)
{
    if (name.Length < 5)
    {
        return 5;
    }
    else
    {
        return name.Length;
    }
}

static int kab00m(string charName, int charHP)
{
    Random rng = new Random();
    int strike = rng.Next(0, charHP);

    if (strike == 0)
    {
        Console.WriteLine($"{charName} lõi mööda!");
    }
    else if (strike == charHP - 1)
    {
        Console.WriteLine($"{charName} vigastas kriitiliselt");
    }
    else
    {
        Console.WriteLine($"{charName} tegi {strike} dmg");
    }
    return strike;
}
using System.Reflection.Metadata.Ecma335;

string folderPath = @"C:\Users\\Admin\\OneDrive\\Desktop\\Progemine\\Data_Nädal8";
string heroFile = "Heroes.txt";
string VillainFile = "Villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, VillainFile));
string[] weapon = { "Tallinna peenleib", "Sword", "Bow", "Magic wand" };

//string[] heros = { "Superman", "Batman", "Shaggy", "James Bond"};
//string[] villains = { "Harley Quinn", "Loki", "Thanos", "Whiplash", "Toomas" };
//int randomIndex = rnd.Next(0, heros.Length);

string hero = GetRandomValueFromArray(heroes);
string heroweapon = GetRandomValueFromArray(weapon);
int heroHp = GetCharacterHp(hero);
int heroStrikeStrength = heroHp;
Console.WriteLine($"Today {hero} ({heroHp} HP) with {heroweapon} saves the day!");
//randomIndex = rnd.Next(0, heros.Length);

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHp(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainWeapon} tries to take over the world!");

while (heroHp > 0 && villainHP > 0)
{
    heroHp = heroHp - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHp}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if(heroHp > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");        
}
else
{
    Console.WriteLine($"Draw!");        
}
static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHp(string characterName)
{
    if(characterName.Length <10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName,int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;

}


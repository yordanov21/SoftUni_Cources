using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [SetUp]
    public void Setup()
    {  
    }

    [Test]
    public void CreateMethodShouldThrowArgumentNullExceptionIfHeroIsNUll()
    {
        //var data = new List<Hero>();
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = null;
        Assert
            .Throws<ArgumentNullException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodShouldThrowInvalidOperationExceptionIfHeroAlreadyExist()
    {
     
        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan",10);
        heroRepository.Create(hero);
        Assert
            .Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void CreateMethodShouldAddCorectly()
    {

        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 10);

        string expectedResult = string
            .Format("Successfully added hero {0} with level {1}", hero.Name, hero.Level);
        Assert.That(heroRepository.Create(hero), Is.EqualTo(expectedResult));
    }

    [Test]
    public void RemoveMethodShouldThrowArgumentNullExceptionIfHeroAlreadyExistIfNameIsNull()
    {

        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 10);
        heroRepository.Create(hero);
        Assert
            .Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    [Test]
    public void RemoveMethodShouldThrowArgumentNullExceptionIfHeroAlreadyExistIfNameIsWhiteSpace()
    {

        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 10);
        heroRepository.Create(hero);
        Assert
            .Throws<ArgumentNullException>(() => heroRepository.Remove(" "));
    }

    [Test]
    public void RemoveMethodShouldRemoveCorrectly()
    {

        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 10);
        Hero hero2 = new Hero("Ivan2", 10);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        bool expected = true;
        Assert.That(heroRepository.Remove("Ivan"), Is.EqualTo(true));
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnHighestLevel()
    {

        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 10);
        Hero hero2 = new Hero("Ivan2", 20);
        Hero hero3 = new Hero("Ivan3", 10);
        Hero hero4 = new Hero("Ivan4", 50);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        var expectedHero = hero4;
        Assert.That(heroRepository.GetHeroWithHighestLevel(), Is.EqualTo(expectedHero));
    }

    [Test]
    public void GetHeroShouldReturnRigthHero()
    {

        HeroRepository heroRepository = new HeroRepository();
        Hero hero = new Hero("Ivan", 10);
        Hero hero2 = new Hero("Ivan2", 20);
        Hero hero3 = new Hero("Ivan3", 10);
        Hero hero4 = new Hero("Ivan4", 50);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);
        heroRepository.Create(hero4);
        var expectedHero = hero4;
        Assert.That(heroRepository.GetHero("Ivan4"), Is.EqualTo(expectedHero));
    }
    //public Hero GetHero(string name)
    //{
    //    Hero hero = this.data.FirstOrDefault(h => h.Name == name);
    //    return hero;
    //}
}
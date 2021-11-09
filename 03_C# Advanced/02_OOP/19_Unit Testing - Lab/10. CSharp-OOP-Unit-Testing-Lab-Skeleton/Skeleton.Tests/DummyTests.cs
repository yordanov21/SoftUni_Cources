using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealtAfterAttack()
    {
        Dummy dummy = new Dummy(20, 10);
        dummy.TakeAttack(5);


        Assert.That(dummy.Health, Is.EqualTo(15));

    }
    [Test]
    public void ShouldThrowExceptionWhenTakeAtack()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.That(()=>dummy.TakeAttack(5),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }
    [Test]
    [TestCase(0,10)]
    [TestCase(-1,10)]
    [TestCase(-10,10)]
    public void ShouldDunnyGiveXP(int health, int expiriance)
    {
        Dummy dummy = new Dummy(health,expiriance);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
    }

    [Test]
    [TestCase(20, 10)]
    [TestCase(1, 10)]
    [TestCase(10, 10)]
    public void ShouldDunnyCantGiveXP(int health, int expiriance)
    {
        Dummy dummy = new Dummy(health, expiriance);

        
        Assert.That(() => dummy.GiveExperience(),
           Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}


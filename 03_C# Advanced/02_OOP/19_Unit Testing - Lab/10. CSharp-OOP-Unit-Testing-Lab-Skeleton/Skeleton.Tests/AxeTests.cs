using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;  
    private Dummy dummy;

    [SetUp]
    public void TestUnit()
    {
        this.axe = new Axe(2, 2);
        this.dummy = new Dummy(20, 20);
    }

    [Test]
    public void AxeLosesDurabilyAfterAttack()
    {
      
        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(1),
           "Axe Durability doesn't change after attack" );

    }
    [Test]
    public void AxeLosesDurabilyAfterAttack2()
    {
        // Arrange
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);
        // Act
        axe.Attack(dummy);
        // Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9));

    }

    [Test]
    public void BrockenAxeCanAttack()
    {
    
        axe.Attack(dummy);
        axe.Attack(dummy);

        Assert.That(()=>axe.Attack(dummy), 
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));

    }
    [Test]
    public void BrockenAxeCanAttack2()
    {
        // Arrange
        Axe axe = new Axe(1, 1);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}
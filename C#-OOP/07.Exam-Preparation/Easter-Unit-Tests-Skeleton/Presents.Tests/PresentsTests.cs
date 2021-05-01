namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
            present = new Present("Name", 123);
        }

        [Test]
        public void Create_ShouldThrowExceptionWhenPresentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void Create_ShouldThrowExceptionWhenPresentExisting()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Create_ShouldAddPresentToPresentsCollection()
        {
            var present2 = new Present("Present2", 1231);

            bag.Create(present);
            bag.Create(present2);

            Assert.That(bag.GetPresents().Count, Is.EqualTo(2));
            CollectionAssert.Contains(bag.GetPresents(), present);
        }

        [Test]
        public void Create_ShouldReturnMessage()
        {
            string message = bag.Create(present);
            string actualMessage = $"Successfully added present {present.Name}.";

            Assert.That(actualMessage, Is.EqualTo(message));
        }

        [Test]
        public void Remove_ShouldRemovePresentFromCollection()
        {
            var present2 = new Present("Present2", 1231);

            bag.Create(present);
            bag.Create(present2);

            bag.Remove(present2);

            Assert.That(bag.GetPresents().Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ShouldReturnBoolean()
        {
            var present2 = new Present("Present2", 1231);

            bag.Create(present);
            bag.Create(present2);

            var result = bag.Remove(present2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Remove_ShouldReturnFalseWhenFail()
        {
            var present2 = new Present("Present2", 1231);

            bag.Create(present);
            bag.Create(present2);

            var result = bag.Remove(new Present("Name", 987));

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetPresentWithLeastMagic_ShouldReturnPresent()
        {
            var present2 = new Present("Present2", 1231);
            var present3 = new Present("Present3", 12);

            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            var presentWithLastMagic = bag.GetPresentWithLeastMagic();

            Assert.That(presentWithLastMagic.Name, Is.EqualTo(present3.Name));
        }

        [Test]
        public void GetPresent_ShouldReturnPresentWithTheGivenName()
        {

            for (int i = 0; i < 5; i++)
            {
                var present = new Present("Present" + i, 10 + i);
                bag.Create(present);
            }

            var present3 = new Present("Name", 125);

            bag.Create(present3);

            var expectedpresent = bag.GetPresent("Name");

            Assert.That(expectedpresent.Name, Is.EqualTo(present3.Name));
        }
    }
}

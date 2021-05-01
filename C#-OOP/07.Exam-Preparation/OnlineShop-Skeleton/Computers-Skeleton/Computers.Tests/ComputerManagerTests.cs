using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new ComputerManager();
        }

        [Test]
        public void ComputerManagerCtor_ShouldtSetValues()
        {
            manager = new ComputerManager();

            Assert.IsNotNull(manager.Computers);
            Assert.AreEqual(manager.Count, 0);
        }

        [Test]
        public void AddComputer_ShouldAddComputerToCollection()
        {
            Computer pc = new Computer("Asus", "Rog", 3000M);

            manager.AddComputer(pc);

            CollectionAssert.Contains(manager.Computers, pc);
            Assert.AreEqual(manager.Computers.Count, 1);
        }

        [Test]
        public void AddComputer_ShouldAddThrowExceptionWhenIsNull()
        {
            Computer pc = null;

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(pc));
        }

        [Test]
        public void AddComputer_ShouldAddThrowExceptionIfExists()
        {
            Computer pc = new Computer("Asus", "Rog", 3000M);

            manager.AddComputer(pc);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(pc));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "Rog"));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("Asus", null));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(() => manager.GetComputer("Acer", "Aspire"));
        }

        [Test]
        public void GetComputer_ShouldReturnComputer()
        {
            var pc = new Computer("asda", "sasafff", 123M);
            manager.AddComputer(pc);

            var actualComputer = manager.GetComputer("asda", "sasafff");

            Assert.AreEqual(pc, actualComputer);
        }

        [Test]
        public void RemoveComputer_ShouldRemoveComputerFromCollection()
        {
            manager.AddComputer(new Computer("Acer", "Aspire", 12345M));
            manager.AddComputer(new Computer("Acer", "Nitro", 1234665M));

            manager.RemoveComputer("Acer", "Nitro");

            Assert.That(manager.Count == 1);
        }

        [Test]
        public void RemoveComputer_ShouldThrowException()
        {
            manager.AddComputer(new Computer("Acer", "Aspire", 12345M));

            Assert.Throws<ArgumentException>(() => manager.RemoveComputer("dasdas", "Nitdasdro"));
        }

        [Test]
        public void RemoveComputer_ShouldReturnRemovedComputer()
        {
            var pcToAdd = new Computer("Acer", "Nitro", 1234665M);

            manager.AddComputer(new Computer("Acer", "Aspire", 12345M));
            manager.AddComputer(pcToAdd);

            var pc = manager.RemoveComputer("Acer", "Nitro");

            Assert.AreEqual(pc, pcToAdd);
        }

        [Test]
        public void GetComputersByManufacturer_ShouldThrowExceptionWhenManufactorerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ShouldReturnComputers()
        {
            var pcToAdd = new Computer("Acer", "Nitro5", 1234M);
            var pcToAdd2 = new Computer("Acer", "Aspire", 1234M);

            manager.AddComputer(pcToAdd);
            manager.AddComputer(pcToAdd2);

            var computers = manager.GetComputersByManufacturer("Acer");

            Assert.AreEqual(computers.Count, 2);
            CollectionAssert.Contains(computers, pcToAdd);
        }


    }
}
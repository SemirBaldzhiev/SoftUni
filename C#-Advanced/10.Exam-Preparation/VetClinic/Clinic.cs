using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count { get; private set; }

        public void Add(Pet pet)
        {
            if (Capacity > data.Count)
            {
                data.Add(pet);
                Count++;
            }
        }

        public bool Remove(string name)
        {
            Pet pet = data.Find(p => p.Name == name);
            if (pet != null)
            {
                data.Remove(pet);
                Count--;
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.Where(x => x.Name == name && x.Owner == owner).FirstOrDefault();

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = data.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            data.ForEach(p => sb.AppendLine($"Pet {p.Name} with owner: {p.Owner}"));

            return sb.ToString().Trim();
        }


    }
}

using System;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public PetType AnimalType { get; set; }
    public string Name  { get; set; }
    public string Gender  { get; set; }
    public DateTime Date  { get; set; }
    public string Breed  { get; set; }
  }

  public enum PetType
  {
    Dog,
    Cat,
    Rabbit,
    Koala
  }
}
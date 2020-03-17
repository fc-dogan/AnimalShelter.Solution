using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index() 
    {
      //List<Animal> model = _db.Animals.ToList();
      // ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      // ViewBag.TypeSortParm = sortOrder == "Type" ? "type_desc" : "Type";
      var animals = from a in _db.Animals
              select a;
      // switch (sortOrder)
      // {
      //   case "name_desc":
      //     animals = animals.OrderByDescending(a => a.Name);
      //     break;
      //   case "Type":
      //     animals = animals.OrderBy(a => a.Type);
      //     break;
      //   case "type_desc":
      //     animals = animals.OrderByDescending(a => a.Type);
      //     break;    
      //   default:
          animals = animals.OrderBy(a => a.Type);
      //     break;
      // }
      return View(animals.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      return View(thisAnimal);
    }
  }
}
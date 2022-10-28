using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVC_Assignment3.Models;
using AspNetCoreMVC_Assignment3.Services;

namespace AspNetCoreMVC_Assignment3.Controllers;
public class RookiesController : Controller
{
    private readonly IPersonService _personService;

    public RookiesController(IPersonService personService)
    {
        _personService = personService;
    }

    public IActionResult Index()
    {
        var model = _personService.GetAll();
        return View(model);
    }

    public IActionResult Details(int index)
    {
        var person = _personService.GetOne(index);

        if (person != null)
        {
            var model = new PersonDetailsModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
            };
            ViewData["Index"] = index;
            return View(model);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PersonCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                BirthPlace = model.BirthPlace,
                IsGraduated = false
            };

            _personService.Create(person);

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        var person = _personService.GetOne(index);

        if (person != null)
        {
            var model = new PersonUpdateModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
            };
            ViewData["Index"] = index;
            return View(model);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(int index, PersonUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            var person = _personService.GetOne(index);

            if (person != null)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Gender = model.Gender;
                person.DateOfBirth = model.DateOfBirth;
                person.PhoneNumber = model.PhoneNumber;
                person.BirthPlace = model.BirthPlace;

                _personService.Update(index, person);
            }

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int index)
    {
        var result = _personService.Delete(index);
        if (result == null)
        {
            return NotFound();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteRedirectToResultView(int index)
    {
        var result = _personService.Delete(index);
        if (result == null)
        {
            return NotFound();
        }

        //Store deleted person to session
        HttpContext.Session.SetString("DeletedPersonName", result.FullName);

        return RedirectToAction("DeleteResult");
    }

    public IActionResult DeleteResult()
    {
        ViewBag.DeletedPersonName = HttpContext.Session.GetString("DeletedPersonName");

        return View();
    }
}
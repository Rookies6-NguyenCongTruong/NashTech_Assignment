using AspNetCoreMVC_Assignment3.Controllers;
using AspNetCoreMVC_Assignment3.Models;
using AspNetCoreMVC_Assignment3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace RookiesControllerTest;

public class RookiesControllerTest
{
    private RookiesController _rookiesController;
    private Mock<IPersonService> _personService;
    private static List<PersonModel> _people = new List<PersonModel>()
    {
        new PersonModel()
        {
            FirstName = "Truong",
            LastName = "Nguyen Cong",
            Gender = "Male",
            DateOfBirth = new DateTime(2002, 07, 22),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi",
            IsGraduated = true
        },
        new PersonModel()
        {
            FirstName = "Tai",
            LastName = "Pham Tien",
            Gender = "Female",
            DateOfBirth = new DateTime(2000, 02, 15),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi",
            IsGraduated = false
        },
        new PersonModel()
        {
            FirstName = "Than",
            LastName = "Nguyen Van",
            Gender = "Others",
            DateOfBirth = new DateTime(2000, 10, 08),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi",
            IsGraduated = true
            },
        new PersonModel()
        {
            FirstName = "Vinh",
            LastName = "Nguyen",
            Gender = "Male",
            DateOfBirth = new DateTime(2002, 08, 07),
            PhoneNumber = "0123456789",
            BirthPlace = "Ho Chi Minh",
            IsGraduated = false
        },
        new PersonModel()
        {
            FirstName = "Minh",
            LastName = "Do Tran",
            Gender = "Female",
            DateOfBirth = new DateTime(1998, 07, 22),
            PhoneNumber = "0123456789",
            BirthPlace = "Da Nang",
            IsGraduated = true
        },
        new PersonModel()
        {
            FirstName = "Tran Thi",
            LastName = "Thao",
            Gender = "Female",
            DateOfBirth = new DateTime(1998, 05, 17),
            PhoneNumber = "0123456789",
            BirthPlace = "Hai Phong",
            IsGraduated = false
        }
    };

    [SetUp]
    public void Setup()
    {
        _personService = new Mock<IPersonService>();
        _rookiesController = new RookiesController(_personService.Object);
    }

    [Test]
    public void AddHttpPost_Valid_ReturnsRedirectToActionIndex()
    {
        var mockModel = new PersonCreateModel
        {
            FirstName = "Tu",
            LastName = "Nguyen Tuan",
            Gender = "Male",
            DateOfBirth = new DateTime(2002, 07, 22),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi"
        };

        var result = _rookiesController.Create(mockModel);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo(((RedirectToActionResult)result).ActionName));
    }

    [Test]
    public void AddHttpPost_Invalid_ReturnsToViewModel()
    {
        var key = "ERROR";
        var message = "Model is invalid";

        _rookiesController.ModelState.AddModelError(key, message);

        var result = _rookiesController.Create();

        Assert.IsInstanceOf<ViewResult>(result);

        var view = (ViewResult)result;

        var modelState = view.ViewData.ModelState;

        Assert.IsFalse(modelState.IsValid);
        Assert.AreEqual(1, modelState.ErrorCount);
        modelState.TryGetValue(key, out var value);
        var error = value?.Errors.First().ErrorMessage;
        Assert.AreEqual(message, error);
    }

    [Test]
    public void IndexHttpGet_ReturnsToViewWithListOfPerson()
    {
        _personService.Setup(p => p.GetAll()).Returns(_people);

        var result = _rookiesController.Index();

        var model = ((ViewResult)result).Model;

        Assert.That(model, Is.AssignableTo<List<PersonModel>>());

        Assert.That(model as List<PersonModel>, Has.Count.EqualTo(_people.Count));
    }

    [Test]
    public void DetailsHttpGet_InValidIndex_ReturnsToAction()
    {
        _personService.Setup(p => p.GetOne(It.IsAny<int>())).Returns(null as PersonModel);

        var index = -1;

        var result = _rookiesController.Details(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo(((RedirectToActionResult)result).ActionName));
    }

    [Test]
    public void DetailsHttpGet_ValidIndex_ReturnsToView()
    {
        int index = 1;

        _personService.Setup(p => p.GetOne(index)).Returns(_people[index]);

        var result = _rookiesController.Details(index) as ViewResult;

        Assert.IsNotNull(result);

        var returnModel = result?.ViewData.Model as PersonDetailsModel;

        Assert.AreEqual(_people[index].FirstName, returnModel?.FirstName);
        Assert.AreEqual(_people[index].LastName, returnModel?.LastName);
        Assert.AreEqual(_people[index].Gender, returnModel?.Gender);
        Assert.AreEqual(_people[index].DateOfBirth, returnModel?.DateOfBirth);
        Assert.AreEqual(_people[index].PhoneNumber, returnModel?.PhoneNumber);
        Assert.AreEqual(_people[index].BirthPlace, returnModel?.BirthPlace);
    }

    [Test]
    public void EditHttpGet_ValidIndex_ReturnsToView()
    {
        int index = 1;

        _personService.Setup(p => p.GetOne(index)).Returns(_people[index]);

        var result = _rookiesController.Edit(index) as ViewResult;

        Assert.IsNotNull(result);

        var returnModel = result?.ViewData.Model as PersonUpdateModel;

        Assert.AreEqual(_people[index].FirstName, returnModel?.FirstName);
        Assert.AreEqual(_people[index].LastName, returnModel?.LastName);
        Assert.AreEqual(_people[index].Gender, returnModel?.Gender);
        Assert.AreEqual(_people[index].DateOfBirth, returnModel?.DateOfBirth);
        Assert.AreEqual(_people[index].PhoneNumber, returnModel?.PhoneNumber);
        Assert.AreEqual(_people[index].BirthPlace, returnModel?.BirthPlace);
    }

    [Test]
    public void EditHttpGet_InValidIndex_RedirectToActionIndex()
    {
        _personService.Setup(p => p.GetOne(It.IsAny<int>())).Returns(null as PersonModel);

        var index = -1;

        var result = _rookiesController.Edit(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo(((RedirectToActionResult)result).ActionName));
    }

    [Test]
    public void UpdateHttpPost_RedirectToActionIndex()
    {
        int index = 1;

        var updateModel = new PersonUpdateModel
        {
            FirstName = "Tu",
            LastName = "Nguyen Tuan",
            Gender = "Male",
            DateOfBirth = new DateTime(2002, 07, 22),
            PhoneNumber = "0123456789",
            BirthPlace = "Ha Noi"
        };

        var result = _rookiesController.Update(index, updateModel);

        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        Assert.That(((RedirectToActionResult)result).ActionName, Is.EqualTo("Index"));
    }

    [Test]
    public void DeleteHttpPost_ValidIndex_ReturnsRedirectToActionIndex()
    {
        int index = 0;

        _personService.Setup(p => p.Delete(index)).Returns(_people[index]);

        var result = _rookiesController.Delete(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("Index", Is.EqualTo(((RedirectToActionResult)result).ActionName));
    }

    [Test]
    public void DeleteHttpPost_InValidIndex_ReturnNotFound()
    {
        int index = -1;

        _personService.Setup(p => p.Delete(It.IsAny<int>())).Returns(null as PersonModel);

        var result = _rookiesController.Delete(index);

        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void DeleteRedirectToResultView_InValidIndex_ReturnsNotFound()
    {
        _personService.Setup(p => p.Delete(It.IsAny<int>())).Returns(null as PersonModel);

        int index = -1;

        var result = _rookiesController.DeleteRedirectToResultView(index);

        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public void DeleteRedirectToResultView_ValidIndex_ReturnsRedirectToActionDeleteResult()
    {
        var httpContext = new Mock<HttpContext>();
        var session = new Mock<ISession>();

        httpContext.Setup(c => c.Session).Returns(session.Object);

        _rookiesController.ControllerContext.HttpContext = httpContext.Object;

        int index = 0;

        _personService.Setup(p => p.Delete(index)).Returns(_people[index]);

        var result = _rookiesController.DeleteRedirectToResultView(index);

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.That("DeleteResult", Is.EqualTo(((RedirectToActionResult)result).ActionName));
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class TestController : Controller
    {
        // Repository layer to load and save
        private readonly UserRepository _userRepository;
        // Note lack of a default contructor; this assumes dependency injection
        public TestController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // Get: /Test/(id)
        public ActionResult Index(int id)
        {
            var user = _userRepository.GetById(id);
            var viewModel = new UserViewModel(user);
            return View(viewModel);
        }
        // POST: /Test/Save
        public ActionResult Save(UserViewModel viewModel)
        {
            _userRepository.Save(viewModel.User);
            return RedirectToAction("Index");
        }
    }

    public class UserViewModel
    {
        public UserViewModel(object user)
        {
            throw new NotImplementedException();
        }

        public object User { get; set; }
    }

    public class UserRepository
    {
        public object GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(object user)
        {
            throw new NotImplementedException();
        }
    }
}
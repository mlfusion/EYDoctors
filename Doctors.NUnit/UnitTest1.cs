using AutoMapper;
using Doctors.Business;
using Doctors.Models;
using Doctors.SPA.Controllers;
using Doctors.SPA.Dtos;
//using Doctors.SPA.Controllers;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        ILanguageBus _languageBus;
        LanguageDto _languageDto;
        LanguageController _languageController;
        Language _language;
        IMapper _mapper;

        public Tests()
        {
          //  _languageBus = new LanguageBus();
          //  this._languageBus = new LanguageBus(;
            this._languageController = new LanguageController(_languageBus, _mapper);
            
        }

        public Tests(LanguageBus languageBus)
        {
            this._languageBus = languageBus;           
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var res = _languageController.Get();

            Assert.IsNotNull(res);

            // Assert.Pass();
        }

        [Test]
        public void TestPost()
        {
            this._language = new Language() { Name = "Russian" };
           // var res = _languageController.Post(_language);

          //  Assert.IsNotNull(res);

            // Assert.Pass();
        }
    }
}
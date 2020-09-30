using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace userWebApi
{
    public enum Education
    {
        High,
        Partly,
        Middle
    }

    public class UserData
    {
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public string Education { get; set; }
        public bool HasCar { get; set; }

        public RegistrationMessage GetRegisteredMessage()
        {
            var sexData = IsMale ? "Мужской" : "Женский";
            var eduData = MakeEducationString(Education);
            var carData = HasCar ? "Имеется автомобиль" : "Автомобиль отсутствует";
            return
                new RegistrationMessage
                {
                    Message = $"{Name}, спасибо за заполнение анкеты.\r\nВы указали следующие данные:\r\nОбразование: {eduData} пол: {sexData}\r\n{carData}"
                };
        }

        private static string MakeEducationString(string education)
        {
            switch (education)
            {
                case "High":
                    return "Высшее";
                case "Partly":
                    return "Незаконченное высшее";
                case "Middle":
                    return "Среднее";
                default:
                    return "Загадочное";
            }
        }
    }

    public class RegistrationMessage
    {
        public string Message { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "I'm healthy";
        }

        [HttpPost]
        public void Post()
        {
            
        }

        [HttpPost]
        public void Post(JObject json)
        {

        }

        //[HttpPost]
        //public RegistrationMessage Post(UserData userData)
        //{
        //    return userData.GetRegisteredMessage();
        //}

        //// POST api/<UserRegisterController>
        //[HttpPost]
        //public RegistrationMessage Post(string name, bool isMale, string education, bool hasCar)
        //{
        //    return new UserData
        //    {
        //        Name = name,
        //        HasCar = hasCar,
        //        Education = education,
        //        IsMale = isMale
        //    }
        //    .GetRegisteredMessage();
        //}
    }
}

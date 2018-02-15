using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class MyData
    {
        public int Id { get; set; }

        [BindRequired]
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string FirstName { get; set; }
        [BindRequired]
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string LastName { get; set; }
        [BindRequired]
        public int Age { get; set; }

        public IEnumerable<MyDataCategory> MyDataCategory { get; set; }
    }
}

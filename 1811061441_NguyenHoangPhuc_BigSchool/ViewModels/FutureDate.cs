﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace _1811061441_NguyenHoangPhuc_BigSchool.ViewModels
{

    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "dd/M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (isValid && dateTime > DateTime.Now);
        }
    }

}
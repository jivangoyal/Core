using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Views.TestLab.ViewModel
{
    public class ContactModel
    {
        public ContactModel()
        {
            CountryCode = "IN";
            State = "PB";
            Codes = new List<SelectListItem>
            {
                new SelectListItem {Text = "Code 1", Value = "C1"},
                new SelectListItem {Text = "Code 2", Value = "C2"}
            };
            Code = "C2";
        }
        [HiddenInput]
        public int Id { get; set; }

        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Url]
        public string WebLink { get; set; }

        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        public DateTime BestTimeToContact { get; set; }

        public AddressViewModel Address { get; set; }


        public int TestAmount { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        public string CountryCode { get; set; }
        public string State { get; set; }
        public List<SelectListItem> Codes { get; set; }
        public string Code { get; set; }
    }

    public class AddressViewModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class TextValuModel
    {
        public TextValuModel()
        {
            
        }

        public TextValuModel(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}
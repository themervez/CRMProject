﻿using CRM.DTOLayer.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.ValidationRules.ContactValidation
{
    public class ContactAddValidator : AbstractValidator<ContactAddDTO>
    {
        public ContactAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail alanı boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez!");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız!");
            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız!");

            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen en çok 50 karakter veri girişi yapınız!");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen en çok 100 karakter girişi yapınız!");
        }
    }
}

﻿namespace AspNetCoreDemo
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FluentValidation;
    using FluentValidation.Attributes;

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Hobbies { get; set; }
    }

    [Validator(typeof(QueryStudentHobbiesDtoValidator))]
    public class QueryStudentHobbiesDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class QueryStudentHobbiesDtoValidator: AbstractValidator<QueryStudentHobbiesDto>
    {
        public QueryStudentHobbiesDtoValidator()
        {
            RuleSet("all", () => 
            {
                RuleFor(x => x.Id).Must(CheckId).WithMessage("id must greater than 0");
                RuleFor(x => x.Name).NotNull().When(x=>!x.Id.HasValue).WithMessage("name could not be null");
            });

            RuleSet("id", () => 
            {
                RuleFor(x => x.Id).NotNull().WithMessage("id could not be null").GreaterThan(0).WithMessage("id must greater than 0");
            });

            RuleSet("name", () =>
            {
                RuleFor(x => x.Name).NotNull().WithMessage("name could not be null");
            });
        }

        private bool CheckId(int? id)
        {
            return !id.HasValue || id.Value > 0;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using GigHub.Controllers;
using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Lugar")]
        public string Venue { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Hora")]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GigsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return ((MethodCallExpression) action.Body).Method.Name;
            }
        }

        public DateTime GetDateTime() => DateTime.Parse($"{Date} {Time}");
    }
}
﻿using BigSchool3.DTOs;
using BigSchool3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool3.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
            {
                return BadRequest("The Attendance already exists!");
            }
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId  = userId
                //AttendeeId = User.Identity.GetUserId()
            };
            //_dbContext.Attendances.Add(attendance);
            //_dbContext.SaveChanges();
            return Ok();
            
        }
    }
}

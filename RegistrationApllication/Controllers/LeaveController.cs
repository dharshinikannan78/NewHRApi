using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationApllication.Data;
using RegistrationApllication.Modal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistrationApllication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        public readonly UserDbContext dataModel;
        public LeaveController(UserDbContext userData)
        {
            dataModel = userData;

        }

        [HttpPost]
        public IActionResult Get([FromBody] LeaveDetails userObj)
        {

            userObj.StartDate = DateTime.Now;
            userObj.EndDate = DateTime.Now;
            dataModel.LeaveDetail.Add(userObj);
            dataModel.SaveChanges();
            return Ok(userObj);

        }
        [HttpPut("AddNewUser")]
        public IActionResult getEmail([FromBody] LeaveDetails obj)
        {
            var status = dataModel.LeaveDetail.AsNoTracking().FirstOrDefault(x => x.LeaveId == obj.LeaveId);
            if (status == null)
            {
                dataModel.LeaveDetail.Add(obj);
                dataModel.SaveChanges();
                return Ok(obj);
            }
            else
            {
                dataModel.Entry(obj).State = EntityState.Modified;
                dataModel.SaveChanges();
                return Ok(obj);
            }
        }

        [HttpPost("filter")]

        public IActionResult GetFilterData([FromBody] RequestModel requestModel)
        {
            var response = dataModel.LeaveDetail.Where(a => a.StartDate.Date >= requestModel.FromDate.Date && a.DateTime.Date
            <= requestModel.ToDate.Date);

            return Ok(response);

        }

        private List<LeaveDetails> GetFilter(RequestModel requestModel)
        {
            var response = dataModel.LeaveDetail.Where(a => a.StartDate.Date >= requestModel.FromDate.Date && a.DateTime.Date
           <= requestModel.ToDate.Date);
            return response.ToList();
        }
    }
}

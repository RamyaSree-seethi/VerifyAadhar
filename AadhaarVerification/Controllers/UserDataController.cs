using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AadhaarVerification.Models;

namespace AadhaarVerification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {

        private static List<Data> datas = new List<Data>();
        [HttpGet]
        public IActionResult GetData()
        {
            try
            {
                return Ok(datas); // Assuming datas is a collection of Data
            }
            catch (Exception e)
            {
                Console.WriteLine($"Global Exception: {e}");
                return StatusCode(500, "Facing Internal Server Error while fetching the data!!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetData(int id)
        {
            try
            {
                var data = datas.Find(t => t.id == id);
                if (data == null)
                {
                    return NotFound($"Data with ID {id} not found.");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Manual Exception: {ex}");
                return StatusCode(500, "Not able to fetch the data from the internal server!!");
            }
        }

        [HttpPost]
        public IActionResult CreateData([FromBody] Data data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

               
                if (datas.Any(d => d.Email == data.Email))
                {
                    return BadRequest("Email already exists. Please use a different email.");
                }

             
                if (datas.Any(d => d.Aadhar == data.Aadhar))
                {
                    return BadRequest("Aadhar already exists. Please use a different Aadhar number.");
                }
                if (string.IsNullOrEmpty(data.FirstName) || string.IsNullOrEmpty(data.LastName))
                {
                    return BadRequest("First name and last name are required.");
                }

                if (data.Age < 0 || data.Age > 100)
                {
                    return BadRequest("Invalid age. Age must be between 0 and 100.");
                }

                if (string.IsNullOrEmpty(data.Address))
                {
                    return BadRequest("Address is required.");
                }

                if (string.IsNullOrEmpty(data.Phone))
                {
                    return BadRequest("Phone number is required.");
                }

                if (string.IsNullOrEmpty(data.Aadhar))
                {
                    return BadRequest("Aadhar number is required.");
                }

                if (string.IsNullOrEmpty(data.Email))
                {
                    return BadRequest("Email is required.");
                }

              
                data.id = datas.Count + 1;
                datas.Add(data);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Manual Exception: {ex}");
                return StatusCode(500, "Can't fetch the data from the internal Server!!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteData(int id)
        {
            try
            {
                var existingData = datas.Find(t => t.id == id);
                if (existingData == null)
                {
                    return NotFound();
                }

                datas.Remove(existingData);
                return StatusCode(200, "User data is deleted!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Manual Exception: {ex}");
                return StatusCode(500, "Internal Server Error!!");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutData(int id, [FromBody] Data newData)
        {
            try
            {
                var existingData = datas.Find(t => t.id == id);
                if (existingData == null)
                {
                    return NotFound($"Data with ID {id} not found.");
                }

              
                if (string.IsNullOrEmpty(newData.FirstName) || string.IsNullOrEmpty(newData.LastName))
                {
                    return BadRequest("First name and last name are required.");
                }

                if (newData.Age < 0 || newData.Age > 150)
                {
                    return BadRequest("Invalid age. Age must be between 0 and 150.");
                }

                if (string.IsNullOrEmpty(newData.Address))
                {
                    return BadRequest("Address is required.");
                }

                if (string.IsNullOrEmpty(newData.Phone))
                {
                    return BadRequest("Phone number is required.");
                }

                if (string.IsNullOrEmpty(newData.Aadhar))
                {
                    return BadRequest("Aadhar number is required.");
                }

                if (string.IsNullOrEmpty(newData.Email))
                {
                    return BadRequest("Email is required.");
                }

                existingData.FirstName = newData.FirstName;
                existingData.LastName = newData.LastName;
                existingData.Age = newData.Age;

                existingData.Address = newData.Address;
                existingData.Phone = newData.Phone;
                existingData.Aadhar = newData.Aadhar;
                existingData.Email = newData.Email;
                existingData.DocumnetPath = newData.DocumnetPath;

                return Ok(existingData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Manual Exception: {ex}");
                return StatusCode(500, "Internal Server Error!!");
            }
        }
    }
}

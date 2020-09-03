using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebAPIWithSwagger.Controllers
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class PetsController : ApiController
    {

        public static List<string> allPets = new List<string>();


        /// <summary>
        /// Get all pets
        /// </summary>
        /// <remarks>
        ///  Get all pets from the pets list
        /// </remarks>
        /// <returns></returns>
        // GET api/Pets
        public HttpResponseMessage Get()
        {
            try
            {
                if (allPets.Count() == 0)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "No pets found!",
                        all_pets = allPets
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Pets retrieved successfully!",
                        all_pets = allPets
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception)
            {
                var response = new
                {
                    Success = false,
                    Message = "An error occured! Failed to retrieve pets."
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        /// <summary>
        /// Get a particular pet
        /// </summary>
        /// <remarks>
        /// Get a particular pet from the pets list using the id
        /// </remarks>
        /// <returns></returns>
        // GET api/Pets/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                // Validate id - check if a pet with the specified id exists
                if (id < 0 || id > (allPets.Count() - 1))
                {
                    var response = new
                    {
                        Success = false,
                        Message = "Retrieve failed! Pet with id = " + id + " does not exist."
                    };
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Pet retrieved successfully!",
                        pet = allPets[id]
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception)
            {
                var response = new
                {
                    Success = false,
                    Message = "An error occured! Failed to retrieve pet."
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        /// <summary>
        /// Create a new pet
        /// </summary>
        /// <remarks>
        /// Adds a new pet to the pets list
        /// </remarks>
        /// <returns></returns>
        // POST api/Pets
        public HttpResponseMessage Post([FromBody]string pet)
        {
            try
            {
                if (allPets.Contains(pet.ToLower()))
                {
                    var response = new
                    {
                        Success = false,
                        Message = "Failed to create pet! Pet already exists."
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
                else
                {
                    allPets.Add(pet.ToLower());

                    var response = new
                    {
                        Success = true,
                        Message = "Pet created successfully!",
                    };
                    return Request.CreateResponse(HttpStatusCode.Created, response);
                }
            }
            catch (Exception)
            {
                var response = new
                {
                    Success = false,
                    Message = "An error occured! Failed to create pet."
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
            
        }


        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <remarks>
        /// Update an existing pet in the pets list using the id
        /// </remarks>
        /// <returns></returns>
        // PUT api/Pets/5
        public HttpResponseMessage Put(int id, [FromBody]string pet)
        {
            try
            {
                // Validate id - check if a pet with the specified id exists
                if (id < 0 || id > (allPets.Count() - 1))
                {
                    var response = new
                    {
                        Success = false,
                        Message = "Update failed! Pet with id = " + id + " does not exist."
                    };
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }
                // Handle duplicates - check if the pet already exists
                else if (allPets.Contains(pet.ToLower()))
                {
                    var response = new
                    {
                        Success = false,
                        Message = "Update failed! Pet already exists."
                    };
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
                else
                {
                    allPets[id] = pet.ToLower();

                    var response = new
                    {
                        Success = true,
                        Message = "Pet updated successfully!",
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception)
            {              
                var response = new
                {
                    Success = false,
                    Message = "An error occured! Failed to update pet."
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        /// <summary>
        /// Delete an existing pet
        /// </summary>
        /// <remarks>
        /// Delete an existing pet from the pets list using the id
        /// </remarks>
        /// <returns></returns>
        // DELETE api/Pets/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                // Validate id - check if a pet with the specified id exists
                if (id < 0 || id > (allPets.Count() - 1))
                {
                    var response = new
                    {
                        Success = false,
                        Message = "Delete failed! Pet with id = " + id + " does not exist."
                    };
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }
                else
                {
                    allPets.RemoveAt(id);

                    var response = new
                    {
                        Success = true,
                        Message = "Pet deleted successfully!",
                    };
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception)
            {
                var response = new
                {
                    Success = false,
                    Message = "An error occured! Failed to delete pet."
                };
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


    }
}




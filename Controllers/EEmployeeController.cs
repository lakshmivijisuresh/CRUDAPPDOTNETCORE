using CRUDAPPDOTNETCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CRUDAPPDOTNETCORE.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EEmployeeController : ControllerBase
	{
		private readonly IConfiguration _configuratiion;
		//private object _configuration;

		public EEmployeeController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpGet]
		[Route("GetAllEEmployees")]

		public Response GetAllEEmployees()
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
			Response response = new Response();
			DAL dal = new DAL();
			response = dal.GetAllEEmployees(connection);
			return response;
		}

		[HttpGet]
		[Route("GetEEmployeeById/{id}")]

		public Response GetEEmployeeById(int id)
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
			Response response = new Response();
			DAL dal = new DAL();
			response = dal.GetEEmployeeById(connection, id);
			return response;
		}

		[HttpPost]
		[Route("AddEEmployee")]

		public Response AddEEmployee(EEmployee eemployee)
		{
			SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
			Response response = new Response();
			DAL dal = new DAL();
			response = dal.AddEEmployee(connection, eemployee);
			return response;

		}
	}
	[HttpPut]
	[Route("UpdateEEmployee")]

	public Response UpdateEEmployee(EEmployee eemployee)
	{
		SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
		Response response = new Response();
		DAL dal = new DAL();
		response = dal.UpdateEEmployee(connection, eemployee);
		return response;

	}

	[HttpDelete]
	[Route("DeleteEEmployee/{id}")]

	public Response DeleteEEmployee(int id)
	{
		SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
		Response response = new Response();
		DAL dal = new DAL();
		response = dal.DeleteEEmployee(connection, id);
		return response;
	}
}
	




using System.Data;
using System.Data.SqlClient;

namespace CRUDAPPDOTNETCORE.Models
{
	public class DAL
	{
		public Response GetEEmployees(SqlConnection connection)
		{
			Response response = new Response();
			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCrudNetCore", connection);
			DataTable dt = new DataTable();
			List<EEmployee> listEEmployees = new List<EEmployee>();
			da.Fill(dt);
			if (dt.Rows.Count > 0)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					EEmployee eemployee = new EEmployee();
					eemployee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
					eemployee.Name = Convert.ToString(dt.Rows[i]["Name"]);
					eemployee.Email = Convert.ToString(dt.Rows[i]["Email"]);
					eemployee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
					listEEmployees.Add(eemployee);
				}
			}
			if (listEEmployees.Count > 0)
			{
				response.StatusCode = 200;
				response.StatusMessage = "Data found";
				response.listEEmployee = listEEmployees;
			}
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "No Data found";
				response.listEEmployee = null;
			}
			return response;
		}


		public Response GetEEmployeeById(SqlConnection connection, int id)
		{
			Response response = new Response();
			SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCrudNetCore WHERE ID = '" + id + "' AND IsActive = 1", connection);
			DataTable dt = new DataTable();
			EEmployee EEmployees = new EEmployee();
			da.Fill(dt);
			if (dt.Rows.Count > 0)
			{
				EEmployee eemployee = new EEmployee();
				eemployee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
				eemployee.Name = Convert.ToString(dt.Rows[0]["Name"]);
				eemployee.Email = Convert.ToString(dt.Rows[0]["Email"]);
				eemployee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
				response.StatusCode = 200;
				response.StatusMessage = "Data found";
				response.EEmployee = eemployee;
			}
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "No Data found";
				response.EEmployee = null;
			}
			return response;
		}


		public Response AddEEmployee(SqlConnection connection, EEmployee eemployee)
		{
			Response response = new Response();
			SqlCommand cmd = new SqlCommand("INSERT INTO tblCrudNetCore(Name,Email,IsActive,CreatedOn) VALUES('" + eemployee.Name + "','" + eemployee.Email + "','" + eemployee.IsActive + "',GETDATE())", connection);
			connection.Open();
			int i = cmd.ExecuteNonQuery();
			connection.Close();
			if (i > 0)
			{
				response.StatusCode = 200;
				response.StatusMessage = "EEmployee added.";

			}
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "No Data inserted.";

			}
			return response;
		}

		public Response UpdateEEmployee(SqlConnection connection, EEmployee eemployee)
		{
			Response response = new Response();
			SqlCommand cmd = new SqlCommand("UPDATE tblCrudNetCore SET Name = '" + eemployee.Name + "',Email='" + eemployee.Email + "' WHERE  ID = '"+eemployee.Id+"'", connection);
			connection.Open();
			int i = cmd.ExecuteNonQuery();
			connection.Close();
			if (i > 0)
			{
				response.StatusCode = 200;
				response.StatusMessage = "EEmployee updated.";

			}
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = "No Data updated.";

			}
			return response;
		}

		public Response DeleteEEmployee(SqlConnection connection, int id)
		{
			Response response = new Response();
			SqlCommand cmd = new SqlCommand("Delete from tblCrudNetCore WHERE ID ='" + id + "' ", connection);
			connection.Open();
			int i = cmd.ExecuteNonQuery();
			connection.Close();
			if (i > 0)
			{
				response.StatusCode = 200;
				response.StatusMessage = "EEmployee deleted.";
			}
			else
			{
				response.StatusCode = 100;
				response.StatusMessage = " No EEmployee deleted failed.";
			}
			return response;
		}

		internal Response GetAllEEmployees(SqlConnection connection)
		{
			throw new NotImplementedException();
		}
	}
}

namespace CRUDAPPDOTNETCORE.Models
{
	public class Response
	{
		public int StatusCode { get; set; }

		public string StatusMessage { get; set; }

		public EEmployee EEmployee { get; set; }

		public List<EEmployee> listEEmployee { get; set; }
	}
}

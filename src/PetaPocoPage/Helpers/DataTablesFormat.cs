using System.Globalization;
using System.Linq;
using PetaPoco;
using PetaPocoPage.Models;

namespace PetaPocoPage.Helpers
{
	public class DataTablesFormat
	{
		public static object PageResponse(DataTablesPageRequest pageRequest, Page<Customer> report)
		{
			return new
			       	{
			       		sEcho = pageRequest.Echo,
			       		iTotalRecords = report.TotalItems,
			       		iTotalDisplayRecords = report.TotalItems,
			       		sColumns = pageRequest.ColumnNames,
			       		aaData = (from i in report.Items
			       		          select new[]
			       		                 	{
			       		                 		i.Id.ToString(CultureInfo.InvariantCulture),
			       		                 		i.Last,
			       		                 		i.First,
			       		                 		i.Street,
			       		                 		i.City,
			       		                 		i.State,
			       		                 		i.Zip,
			       		                 		i.Phone,
			       		                 		i.Email
			       		                 	}).ToList()
			       	};
		}
	}
}
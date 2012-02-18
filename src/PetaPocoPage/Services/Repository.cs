using System.Collections.Generic;
using PetaPoco;
using PetaPocoPage.Models;

namespace PetaPocoPage.Services
{
	public class Repository
	{
		private readonly Database _database = new Database("PetaPocoPageDb");

		public Page<Customer> GetCustomers(DataTablesPageRequest pageRequest)
		{
			var query = Sql.Builder
				.Select("*")
				.From("Customer");

			if (!string.IsNullOrEmpty(pageRequest.Search))
			{
				var whereClause = string.Join(" OR ", GetSearchClause(pageRequest));

				if (!string.IsNullOrEmpty(whereClause))
					query.Append("WHERE " + whereClause, "%" + pageRequest.Search + "%");
			}

			var orderBy = string.Join(",", GetOrderByClause(pageRequest));

			if (!string.IsNullOrEmpty(orderBy))
			{
				query.Append("ORDER BY " + orderBy);
			}

			var startPage = (pageRequest.DisplayLength == 0) ? 1 : pageRequest.DisplayStart/pageRequest.DisplayLength + 1;

			return _database.Page<Customer>(startPage, pageRequest.DisplayLength, query);
		}

		private static IEnumerable<string> GetSearchClause(DataTablesPageRequest pageRequest)
		{
			var columns = pageRequest.ColumnNames.Split(',');

			for (var idx = 0; idx < pageRequest.Searchable.Count; ++idx)
			{
				if (pageRequest.Searchable[idx])
					yield return string.Format("{0} LIKE @0", columns[idx]);
			}
		}

		private static IEnumerable<string> GetOrderByClause(DataTablesPageRequest pageRequest)
		{
			var columns = pageRequest.ColumnNames.Split(',');

			for (var idx = 0; idx < pageRequest.SortingCols; ++idx)
			{
				yield return string.Format("{0} {1}", columns[pageRequest.SortCol[idx]], pageRequest.SortDir[idx]);
			}
		}
	}
}
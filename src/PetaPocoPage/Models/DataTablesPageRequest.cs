using System.Collections.Generic;

namespace PetaPocoPage.Models
{
	public class DataTablesPageRequest
	{
		/// <summary>
		/// Display start point in the current data set.
		/// </summary>
		public int DisplayStart { get; set; }

		/// <summary>
		/// Number of records that the table can display in the current draw. It is expected that
		/// the number of recordsreturned will be equal to this number, unless the server has fewer records to return.
		/// </summary>
		public int DisplayLength { get; set; }

		/// <summary>
		/// Optional - this is a string of column names, comma separated (used in combination with sName) which will allow DataTables to reorder data on the client-side if required for display.
		/// Note that the number of column names returned must exactly match the number of columns in the table. For a more flexible JSON format, please consider using mDataProp.
		/// </summary>
		public string ColumnNames { get; set; }

		/// <summary>
		/// Number of columns being displayed (useful for getting individual column search info)
		/// </summary>
		public int Columns { get; set; }

		/// <summary>
		/// Global search field
		/// </summary>
		public string Search { get; set; }

		/// <summary>
		/// True if the global filter should be treated as a regular expression for advanced filtering, false if not.
		/// </summary>
		public bool Regex { get; set; }

		/// <summary>
		/// (int) Indicator for if a column is flagged as searchable or not on the client-side
		/// </summary>
		public List<bool> Searchable { get; set; }

		/// <summary>
		/// (int) Individual column filter
		/// </summary>
		public List<string> SearchColumns { get; set; }

		/// <summary>
		/// (int) True if the individual column filter should be treated as a regular expression for advanced filtering, false if not
		/// </summary>
		public List<bool> RegexColumns { get; set; }

		/// <summary>
		/// Indicator for if a column is flagged as sortable or not on the client-side
		/// </summary>
		public List<bool> Sortable { get; set; }

		/// <summary>
		/// Number of columns to sort on
		/// </summary>
		public int SortingCols { get; set; }

		/// <summary>
		/// (int) Column being sorted on (you will need to decode this number for your database)
		/// </summary>
		public List<int> SortCol { get; set; }

		/// <summary>
		/// (int) Direction to be sorted - "desc" or "asc".
		/// </summary>
		public List<string> SortDir { get; set; }

		/// <summary>
		/// (int) The value specified by mDataProp for each column. This can be useful for ensuring that
		/// the processing of data is independent from the order of the columns.
		/// </summary>
		public List<string> DataProp { get; set; }

		/// <summary>
		/// Information for DataTables to use for rendering.
		/// </summary>
		public int Echo { get; set; }
	}
}
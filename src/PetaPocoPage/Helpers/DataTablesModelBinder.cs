using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetaPocoPage.Models;

namespace PetaPocoPage.Helpers
{
	public class DataTablesModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var pageRequest = new DataTablesPageRequest
			{
				Echo          = BindDataTablesRequestParam<Int32>(bindingContext, "sEcho"),
				DisplayStart  = BindDataTablesRequestParam<Int32>(bindingContext, "iDisplayStart"),
				DisplayLength = BindDataTablesRequestParam<Int32>(bindingContext, "iDisplayLength"),
				ColumnNames   = BindDataTablesRequestParam<string>(bindingContext, "sColumns"),
				Columns       = BindDataTablesRequestParam<Int32>(bindingContext, "iColumns"),
				Search        = BindDataTablesRequestParam<string>(bindingContext, "sSearch"),
				Regex         = BindDataTablesRequestParam<bool>(bindingContext, "bRegex"),
				SortingCols   = BindDataTablesRequestParam<Int32>(bindingContext, "iSortingCols"),
				DataProp      = BindDataTablesRequestParam<string>(controllerContext.HttpContext.Request, "mDataProp_"),
				RegexColumns  = BindDataTablesRequestParam<bool>(controllerContext.HttpContext.Request, "bRegex_"),
				Searchable    = BindDataTablesRequestParam<bool>(controllerContext.HttpContext.Request, "bSearchable_"),
				Sortable      = BindDataTablesRequestParam<bool>(controllerContext.HttpContext.Request, "bSortable_"),
				SortCol       = BindDataTablesRequestParam<Int32>(controllerContext.HttpContext.Request, "iSortCol_"),
				SearchColumns = BindDataTablesRequestParam<string>(controllerContext.HttpContext.Request, "sSearch_"),
				SortDir       = BindDataTablesRequestParam<string>(controllerContext.HttpContext.Request, "sSortDir_")
			};

			return pageRequest;
		}

		private static T BindDataTablesRequestParam<T>(ModelBindingContext context, string propertyName)
		{
			return (T)context.ValueProvider.GetValue(propertyName).ConvertTo(typeof(T));
		}

		private static List<T> BindDataTablesRequestParam<T>(HttpRequestBase request, string keyPrefix)
		{
			return (from k in request.Params.AllKeys
					where k.StartsWith(keyPrefix)
					orderby int.Parse(k.Replace(keyPrefix, string.Empty))
					select (T)Convert.ChangeType(request.Params[k], typeof(T))
				   ).ToList();
		}
	}
}

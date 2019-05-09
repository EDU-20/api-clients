using System;
using System.Net;
namespace csharpapiclient
{
	public class ApiException : Exception
	{
		private WebResponse response;

		public ApiException()
		{
		}

		public ApiException(string message)
			: base(message)
		{
		}

		public ApiException(string message, Exception inner)
			: base(message, inner)
		{
			if (inner is WebException)
				response = ((WebException)inner).Response;
		}
		public WebResponse Response {
			get{
				return response;
			}
			protected set{
				response = value;
			}
		}
	}
}


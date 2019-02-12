using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LircSharpAPI.Models
{
	public class Remote 
	{
		[Required]
		private string _name;
		private List<RemoteCode> _remoteCodes;
		
		public Remote()
		{
			_remoteCodes = new List<RemoteCode>();
		}
		public Remote(string name)
		{
			_remoteCodes = new List<RemoteCode>();
			_name = name;
		}
		
		public string Name
		{
			get { return _name; }
			set { _name = value;}
		}
		
		public List<RemoteCode> Codes
		{
			get { return _remoteCodes; }
			set { _remoteCodes = value; }
		}
		public void AddCode(RemoteCode code)
		{
			_remoteCodes.Add(code);
		}
	}
}
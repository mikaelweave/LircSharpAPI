using System.ComponentModel.DataAnnotations;

namespace LircSharpAPI.Models {
	public class RemoteCode
	{
		private	string _name;
		private string _command;
		private string _remoteName;
		
		public RemoteCode()
		{}
		
		public string Name
		{
			get{ return _name; }
			set {_name = value; }
		}
		
		public string Command
		{
			get { return _command; }
			set { _command = value; }
		}
		
		public string RemoteName
		{
			get{ return _remoteName; }
			set {_remoteName = value; }
		}
	}
}
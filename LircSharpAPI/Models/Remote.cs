using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LircSharpAPI.Models
{
	public class Remote
    {
        [Required]
        public string Name { get; set; }

        public List<RemoteCode> Codes { get; set; }

        public Remote()
		{
			Codes = new List<RemoteCode>();
		}

		public Remote(string name)
            : this()
		{
			Name = name;
		}

		public void AddCode(RemoteCode code)
		{
			Codes.Add(code);
		}
	}
}

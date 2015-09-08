using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using LircSharpAPI.Models;

namespace LircSharpAPI.DAL
{
	public class DAL
	{
		
		private static List<Remote> remoteList;
		
		public DAL()
		{}
		
		public Remote GetRemote(string name)
		{
			if (remoteList == null)
			{
				remoteList = GetRemotes();
			}
			
			/* Loop through remotes until we have a match */
			foreach (Remote remote in remoteList)
			{
				if (remote.Name == name)
				{
					return remote;
				}
			}
			return null;
		}
		
		public List<Remote> GetRemotes()
		{
			remoteList = new List<Remote>(); 
			
			/* Build process info to call LIRC */
			ProcessStartInfo procInfo = new ProcessStartInfo();
			procInfo.FileName = "irsend";
			procInfo.UseShellExecute = false;
    		procInfo.RedirectStandardOutput = true;
			
			/* Ask LIRC for a list of remotes */
			procInfo.Arguments = "list \"\" \"\"";
			Process proc = Process.Start(procInfo);
			string strOut = proc.StandardOutput.ReadToEnd();
			proc.WaitForExit();
			
			/* Extract the remote names from the LIRC return*/
			using (StringReader reader = new StringReader(strOut))
			{
				string line = string.Empty;
				Remote remote;
				do
				{
					line = reader.ReadLine();
					if (line != null && line.StartsWith("irsend: ")) {
						remote = new Remote();
						remote.Name = line.Split(' ')[1];
						remote.Codes = GetRemoteCodes(remote);
					}
				} while (line != null);
			}
			
			return remoteList;			
		}
		
		public List<RemoteCode> GetRemoteCodes(Remote remote)
		{
			List<RemoteCode> remoteCodeList = new List<RemoteCode>(); 
			
			/* Build process info to call LIRC */
			ProcessStartInfo procInfo = new ProcessStartInfo();
			procInfo.FileName = "irsend";
			procInfo.UseShellExecute = false;
    		procInfo.RedirectStandardOutput = true;
			
			/* Ask LIRC for a list of remotes */
			procInfo.Arguments = "list " + remote.Name + " \"\"";
			Process proc = Process.Start(procInfo);
			string strOut = proc.StandardOutput.ReadToEnd();
			proc.WaitForExit();
			
			/* Extract the remote names from the LIRC return*/
			using (StringReader reader = new StringReader(strOut))
			{
				string line = string.Empty;
				RemoteCode code;
				do
				{
					line = reader.ReadLine();
					if (line != null && line.StartsWith("irsend: ")) {
						code = new RemoteCode();
						code.Name = line.Split(' ')[2];
						code.Command = line.Split(' ')[1];
						code.RemoteName = remote.Name;
						
					}
				} while (line != null);
			}
			
			return remoteCodeList;
		}
		
		public void SendRemoteCode(RemoteCode code)
		{
			/* Build process info to call LIRC */
			ProcessStartInfo procInfo = new ProcessStartInfo();
			procInfo.FileName = "irsend";
			procInfo.UseShellExecute = false;
    		procInfo.RedirectStandardOutput = true;
			
			/* Ask LIRC for a list of remotes */
			procInfo.Arguments = "SEND_ONCE " + code.RemoteName + " " + code.Name;
			Process proc = Process.Start(procInfo);
		}
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace qcz.Dump.UserGroups
{
	class UserGroupsDumpReader
	{
		private string filePath;
		private StreamReader stream;
		private GZipStream gzStream;
		private List<UserIdRightPair> rights;

		public UserGroupsDumpReader(string filePath) {
			this.filePath = filePath;
			stream = new StreamReader(filePath);
			gzStream = new GZipStream(stream.BaseStream, CompressionMode.Decompress);
			rights = new List<UserIdRightPair>();
			TextReader reader = new StreamReader(gzStream);
			char[] buf = new char[256];
			string bufs = "";
			while(reader.Read(buf, 0, 256) != 0) {
				bufs = bufs + new string(buf);

				while ((bufs.IndexOf("(") != -1 || bufs.IndexOf(")") != -1) && bufs.IndexOf("(") < bufs.IndexOf(")"))
				{
					string curpa = bufs.Substring(
						bufs.IndexOf("(") + 1, bufs.IndexOf(")") - bufs.IndexOf("(") - 1
					);
					Match m = Regex.Match(curpa, @"(\d+),'(\w+)'");
					if (m.Success)
					{
						Right right = Right.None;
						switch (m.Groups[2].Value)
						{
							case "bot":
								right = Right.Bot;
								break;
							case "bureaucrat":
								right = Right.Bureaucrat;
								break;
							case "checkuser":
								right = Right.Checkuser;
								break;
							case "editor":
								right = Right.Editor;
								break;
							case "sysop":
								right = Right.Sysop;
								break;
							case "trusted":
								right = Right.Trusted;
								break;
							default:
								right = Right.Unknown;
								break;
						}
						rights.Add(new UserIdRightPair()
						{
							UserId = Convert.ToInt32(m.Groups[1].Value),
							Right = right
						});
					}
					bufs = bufs.Substring(bufs.IndexOf(")") + 1);
				}
			}

		}

		public List<Right> GetUserRights(int id)
		{
			List<Right> ret = new List<Right>();
			foreach (UserIdRightPair ui in rights)
				if (ui.UserId == id)
					ret.Add(ui.Right);
			return ret;
		}
	}
}

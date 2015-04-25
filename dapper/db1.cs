#r Microsoft.CSharp.dll

using System.Data.SqlClient;
using Dapper;

class Person {
		public int id {get;set;}
		public string name {get;set;}
}
var ConnStr=@"Server=localhost\SQLEXPRESS;Database=test;Trusted_Connection=True;";

using (System.Data.IDbConnection conn = new System.Data.SqlClient.SqlConnection(ConnStr))
{
	var rows=conn.Query<Person>("Select * from People");
	foreach(var row in rows) {
		Console.WriteLine("{0},{1}",row.id,row.name);
	}
	
	IEnumerable<object> rows2=conn.Query("Select * from People");
	foreach(var rowObj in rows2) {
		IDictionary <string,object> fields=(IDictionary <string,object>)rowObj;
		foreach(var kv in fields) {
			Console.WriteLine("{0},{1}",kv.Key,kv.Value);
		}
		
	}
}

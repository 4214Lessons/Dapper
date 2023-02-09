using Dapper;
using System.Data;
using System.Data.SqlClient;
using Z.Dapper.Plus;

var cs = "Server=(localdb)\\ProjectModels;Database=Library;Integrated Security=true;";
using var con = new SqlConnection(cs);
var sql = string.Empty;





//sql = "INSERT INTO Categories VALUES(15, 'C#')";
//sql = "UPDATE Categories SET Name='C++' WHERE Id=15";
//sql = "DELETE FROM Categories WHERE Id=15";


//// with parameters 1
//sql = "INSERT INTO Categories VALUES(15, @name)";
//var name = "C#";
//con.Execute(sql, new { NAME = name });





//// with parameters 2
//sql = "INSERT INTO Categories VALUES(@id, @name)";

//var id = 18;
//var name = "C#";

//con.Execute(sql, new { id, name });





//// with parameters 3 (multiple value insert)
//sql = "INSERT INTO Categories VALUES(@id, @name)";


//con.Execute(sql, new object[] {
//    new{ id = 19, name= "HTML" },
//    new{ id = 20, name= "CSS" },
//    new{ id = 21, name= "JS" },
//});








///////////////////////////////////
//sql = "DELETE FROM Categories WHERE Id=@id";


//con.Execute(sql, new object[] {
//    new{ id = 19 },
//    new{ id = 20 },
//    new{ id = 21 }
//});




//// Stored Procedure

// usp_UpdateBooks


//sql = "usp_UpdateBooks";
//con.Execute(sql, new { pId = 1, pPages = 100 },
//    commandType: CommandType.StoredProcedure);





//// usp_getBooksNumber


//DynamicParameters parameters = new DynamicParameters();
//parameters.Add("AuthorId", 1, DbType.Int32);
//parameters.Add("BookCount", dbType: DbType.Int32, direction: ParameterDirection.Output);


//sql = "usp_getBooksNumber";


//con.Execute(sql, parameters, commandType: CommandType.StoredProcedure);


//var outputValue = parameters.Get<int>("BookCount");
//Console.WriteLine(outputValue);









//sql = "SELECT * FROM Categories";
//var reader = con.ExecuteReader(sql);

//var table = new DataTable();
//table.Load(reader);

//Console.WriteLine(table.Rows.Count);





//sql = "SELECT * FROM Categories";
////var obj = con.ExecuteScalar(sql);
////var obj = con.ExecuteScalar<int>(sql);
//var obj = await con.ExecuteScalarAsync<int>(sql);
//Console.WriteLine(obj.ToString());







//sql = "SELECT * FROM Categories";

//var collection = con.Query(sql);

//foreach (var item in collection)
//{
//    Console.WriteLine($"{item.Id} - {item.Name}");
//}











//sql = "SELECT Id FROM Categories";

//var collection = con.Query<int>(sql);

//foreach (var item in collection)
//{
//    Console.WriteLine(item);
//}






//sql = "SELECT * FROM Categories";

////var collection = con.Query<Category>(sql);
//var collection = await con.QueryAsync<Category>(sql);

//foreach (var item in collection)
//{
//    Console.WriteLine($"{item.Id} - {item.Name}");
//}



//sql = "SELECT * FROM Categories WHERE Id > 5";

//var category = await con.QueryFirstOrDefaultAsync<Category>(sql);

//Console.WriteLine(category.Id + " - " + category.Name);














//await con.OpenAsync();
//var tran = await con.BeginTransactionAsync();

// do something

//await tran.CommitAsync(); // or tran.RollbackAsync();
//await con.CloseAsync();











//// QueryMultipleAsync

//sql = @"
//SELECT * FROM Categories;
//SELECT * FROM Authors;
//";


//using var multi = await con.QueryMultipleAsync(sql);

//var category = await multi.ReadFirstAsync<Category>();
//var authors = await multi.ReadAsync<Author>();


//Console.WriteLine(category.Name);
//Console.WriteLine(authors.Count());








//sql = "SELECT * FROM Books INNER JOIN Categories ON Id_Category = Categories.Id";

//var list = con.Query<Book, Category, JoinResult>(sql, (book, category) =>
//    new JoinResult()
//    {
//        Id = book.Id,
//        BookName = book.Name,
//        CategoryName = category.Name,
//        Pages = book.Pages
//    }
//);


//foreach (var item in list)
//{
//    Console.WriteLine($"{item.Id} - {item.BookName} - {item.Pages} - {item.CategoryName}");
//}


DapperPlusManager.Entity<Category>().Table("Categories");
DapperPlusManager.Entity<Author>().Table("Authors");


//var categories = new List<Category>()
//{
//    new(){ Id = 19, Name = "CSS" },
//    new(){ Id = 20, Name = "HTML" },
//    new(){ Id = 21, Name = "JS" },
//};


//con.BulkInsert(categories);



var authors = new List<Author>()
{
    new(){ Id = 21, FirstName = "Leyla", LastName = "Shefiyeva" },
    new(){ Id = 22, FirstName = "Isa", LastName = "Memmedli" },
    new(){ Id = 23, FirstName = "Resul", LastName = "Qasimov" },
};


con.BulkInsert(authors);


class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
}



class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Pages { get; set; }
    public int YearPress { get; set; }
    public int Id_Themes { get; set; }
    public int Id_Category { get; set; }
    public int Id_Author { get; set; }
    public int Id_Press { get; set; }
    public string? Comment { get; set; }
    public int Quantity { get; set; }
}




class JoinResult
{
    public int Id { get; set; }
    public string? BookName { get; set; }
    public int Pages { get; set; }
    public string? CategoryName { get; set; }
}






class Author
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
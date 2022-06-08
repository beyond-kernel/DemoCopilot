// API Controller for Product CRUD with repository

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    // GET api/product
    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return _repository.GetAll();
    }

    // GET api/product/5
    [HttpGet("{id}")]
    public Product Get(int id)
    {
        return _repository.Get(id);
    }

    // POST api/product
    [HttpPost]
    public void Create(Product product)
    {
        _repository.Add(product);
    }


    // PUT api/product/5
    [HttpPut("{id}")]
    public void Update(int id, Product product)
    {
        _repository.Update(id, product);
    }

    // DELETE api/product/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    // GET api/product/5/name
    [HttpGet("{id}/name")]
    public string GetName(int id)
    {
        return _repository.Get(id).Name;
    }
}

// Interface for Product Repository

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    Product Get(int id);
    void Add(Product product);
    void Update(int id, Product product);
    void Delete(int id);
    string GetName(int id);
}

// Model for Product

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Price { get; set; }
}

//EF dbContext for Product

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Products");
    }
}

//Method Using regex to check if the email is valid

    // public static bool IsValidEmail(string email)
    // {
    //     var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    //     return regex.IsMatch(email);
    // }

//FizzBuzz checker
    // public  static string FizzBuzz(int number)
    // {
    //     if (number % 3 == 0 && number % 5 == 0)
    //     {
    //         return "FizzBuzz";
    //     }
    //     else if (number % 3 == 0)
    //     {
    //         return "Fizz";
    //     }
    //     else if (number % 5 == 0)
    //     {
    //         return "Buzz";
    //     }
    //     else
    //     {
    //         return number.ToString();
    //     }
    // }     

// solving matrix equation
    // public static int Solve(int[][] matrix)
    // {
    //     int n = matrix.Length;
    //     int[][] result = new int[n][];
    //     for (int i = 0; i < n; i++)
    //     {
    //         result[i] = new int[n];
    //     }
    //     for (int i = 0; i < n; i++)
    //     {
    //         for (int j = 0; j < n; j++)
    //         {
    //             if (i == j)
    //             {
    //                 result[i][j] = 1;
    //             }
    //             else
    //             {
    //                 result[i][j] = 0;
    //             }
    //         }
    //     }
    //     for (int k = 0; k < n; k++)
    //     {
    //         for (int i = 0; i < n; i++)
    //         {
    //             for (int j = 0; j < n; j++)
    //             {
    //                 if (i != k && j != k)
    //                 {
    //                     result[i][j] = result[i][j] - result[i][k] * result[k][j] / result[k][k];
    //                 }
    //             }
    //         }
    //         for (int i = 0; i < n; i++)
    //         {
    //             result[i][k] = result[i][k] / result[k][k];
    //         }
    //     }

 //solving honoi tower problem
    // public static int Solve(int[][] matrix)
    // {
    //     int n = matrix.Length;
    //     int[][] result = new int[n][];
    //     for (int i = 0; i < n; i++)
    //     {
    //         result[i] = new int[n];
    //     }
    //     for (int i = 0; i < n; i++)
    //     {
    //         for (int j = 0; j < n; j++)
    //         {
    //             if (i == j)
    //             {
    //                 result[i][j] = 1;
    //             }
    //             else
    //             {
    //                 result[i][j] = 0;
    //             }
    //         }
    //     }
    //     for (int k = 0; k < n; k++)
    //     {
    //         for (int i = 0; i < n; i++)
    //         {
    //             for (int j = 0; j < n; j++)
    //             {
    //                 if (i != k && j != k)
    //                 {
    //                     result[i][j] = result[i][j] - result[i][k] * result[k][j] / result[k][k];
    //                 }
    //             }
    //         }
    //         for (int i = 0; i < n; i++)
    //         {
    //             result[i][k] = result[i][k] / result[k][k];
    //         }
    //     }
    //     return result[0][0];
    // }




 
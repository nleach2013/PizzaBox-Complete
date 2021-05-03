using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storing
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public DbSet<Order> Orders { get; set; }
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Topping> Toppings { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<VeggiePizza>().HasBaseType<APizza>();

      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Topping>().HasKey(e => e.EntityId);

      builder.Entity<Customer>().HasKey(e => e.EntityId);

      builder.Entity<APizza>().HasMany(p => p.Toppings).WithMany(p => p.Pizzas).UsingEntity(j => j.ToTable("PizzaToppings"));


      //builder.Entity<Size>().HasMany<APizza>().WithOne();//.HasForeignKey("SizeEntityID");
      //builder.Entity<APizza>().HasOne<Size>().WithMany();//.HasForeignKey("SizeEntityId");
      //builder.Entity<Crust>().HasMany<APizza>().WithOne();//.HasForeignKey("CrustEntityID");
      //builder.Entity<APizza>().HasOne<Crust>().WithMany();//.HasForeignKey("CrustEntityId");
      //builder.Entity<Topping>().HasMany<APizza>();
      //builder.Entity<APizza>().HasMany<Topping>().WithMany();
      //builder.Entity<APizza>().HasMany(p => p.Toppings).WithMany(p => p.Pizzas).UsingEntity(j => j.ToTable("PostTags"));


      builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);
      builder.Entity<Customer>().HasMany<Order>().WithOne(o => o.Customer);
      builder.Entity<APizza>().HasMany<Order>().WithOne(o => o.Pizza);

      builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
      {
        new ChicagoStore() { EntityId = 1, Name = "Chitown Main Street" }
      });

      builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
      {
        new NewYorkStore() { EntityId = 2, Name = "Big Apple" }
      });

      builder.Entity<Customer>().HasData(new Customer[]
      {
        new Customer() { EntityId = 1, Name = "Uncle John" }
      });

      // builder.Entity<MeatPizza>().HasData(new MeatPizza[]
      // {
      //   new MeatPizza() { EntityId = 1, CrustEntityId = 3, Crust = new Crust(), SizeEntityId = 1, Size = new Size()}
      // });

      // builder.Entity<VeggiePizza>().HasData(new VeggiePizza[]
      // {
      //   new VeggiePizza() { EntityId = 2, CrustEntityId = 2, SizeEntityId = 1}
      // });

      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping() {EntityId = 1, Name = "Mozzarella", Price = 1.00m},
        new Topping() {EntityId = 2, Name = "Marinara", Price = 1.00m},
        new Topping() {EntityId = 3, Name = "Pepperoni", Price = 2.00m}
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() {EntityId = 1, Name = "Small", Price = 4.00m},
        new Size() {EntityId = 2, Name = "Medium", Price = 6.00m},
        new Size() {EntityId = 3, Name = "Large", Price = 8.00m}
      });

      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() {EntityId = 1, Name = "Original", Price = 1.00m},
        new Crust() {EntityId = 2, Name = "Neapolitan", Price = 2.00m},
        new Crust() {EntityId = 3, Name = "Stuffed", Price = 3.00m}
      });
    }
  }
}

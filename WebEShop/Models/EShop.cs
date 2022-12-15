﻿// Licence file C:\Users\George.Pasparakis\Documents\ReversePOCO.txt not found.
// Please obtain your licence file at www.ReversePOCO.co.uk, and place it in your documents folder shown above.
// Defaulting to Trial version.
// <auto-generated>
// ReSharper disable All

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace WebEShop
{
    #region Database context interface

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public interface IMyDbContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; } // Customers
        DbSet<CustomerOrder> CustomerOrders { get; set; } // CustomerOrders
        DbSet<CustomerOrdersDetail> CustomerOrdersDetails { get; set; } // CustomerOrdersDetails
        DbSet<CustomerOrdersMultipleProduct> CustomerOrdersMultipleProducts { get; set; } // CustomerOrdersMultipleProducts
        DbSet<CustomerProduct> CustomerProducts { get; set; } // CustomerProducts
        DbSet<ProductCategory> ProductCategories { get; set; } // ProductCategories
        DbSet<SomeTable> SomeTables { get; set; } // SomeTables

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        Database Database { get; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        string ToString();
    }

    #endregion

    #region Database context

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public class MyDbContext : DbContext, IMyDbContext
    {
        public DbSet<Customer> Customers { get; set; } // Customers
        public DbSet<CustomerOrder> CustomerOrders { get; set; } // CustomerOrders
        public DbSet<CustomerOrdersDetail> CustomerOrdersDetails { get; set; } // CustomerOrdersDetails
        public DbSet<CustomerOrdersMultipleProduct> CustomerOrdersMultipleProducts { get; set; } // CustomerOrdersMultipleProducts
        public DbSet<CustomerProduct> CustomerProducts { get; set; } // CustomerProducts
        public DbSet<ProductCategory> ProductCategories { get; set; } // ProductCategories
        public DbSet<SomeTable> SomeTables { get; set; } // SomeTables

        static MyDbContext()
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(null);
        }

        /// <inheritdoc />
        public MyDbContext()
            : base("Name=EShopConnectionString")
        {
        }

        /// <inheritdoc />
        public MyDbContext(string connectionString)
            : base(connectionString)
        {
        }

        /// <inheritdoc />
        public MyDbContext(string connectionString, DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        /// <inheritdoc />
        public MyDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        /// <inheritdoc />
        public MyDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        /// <inheritdoc />
        public MyDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CustomerOrderConfiguration());
            modelBuilder.Configurations.Add(new CustomerOrdersDetailConfiguration());
            modelBuilder.Configurations.Add(new CustomerOrdersMultipleProductConfiguration());
            modelBuilder.Configurations.Add(new CustomerProductConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new SomeTableConfiguration());

            // Indexes
            modelBuilder.Entity<CustomerOrder>()
                .Property(e => e.CustomerId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Customer_Id", 1))
                );

            modelBuilder.Entity<CustomerOrder>()
                .Property(e => e.ProductId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Product_Id", 1))
                );

            modelBuilder.Entity<CustomerOrdersDetail>()
                .Property(e => e.ProductId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Product_Id", 1))
                );

            modelBuilder.Entity<CustomerOrdersDetail>()
                .Property(e => e.OrderMultipleCustomerOrderId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_OrderMultiple_CustomerOrderId", 1))
                );

            modelBuilder.Entity<CustomerOrdersMultipleProduct>()
                .Property(e => e.CustomerId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Customer_Id", 1))
                );

            modelBuilder.Entity<CustomerProduct>()
                .Property(e => e.CategoryId)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Category_Id", 1))
                );

        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerOrderConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerOrdersDetailConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerOrdersMultipleProductConfiguration(schema));
            modelBuilder.Configurations.Add(new CustomerProductConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new SomeTableConfiguration(schema));

            return modelBuilder;
        }
    }

    #endregion

    #region Database context factory

    public class MyDbContextFactory : IDbContextFactory<MyDbContext>
    {
        public MyDbContext Create()
        {
            return new MyDbContext();
        }
    }

    #endregion

    #region Fake Database context

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public class FakeMyDbContext : IMyDbContext
    {
        public DbSet<Customer> Customers { get; set; } // Customers
        public DbSet<CustomerOrder> CustomerOrders { get; set; } // CustomerOrders
        public DbSet<CustomerOrdersDetail> CustomerOrdersDetails { get; set; } // CustomerOrdersDetails
        public DbSet<CustomerOrdersMultipleProduct> CustomerOrdersMultipleProducts { get; set; } // CustomerOrdersMultipleProducts
        public DbSet<CustomerProduct> CustomerProducts { get; set; } // CustomerProducts
        public DbSet<ProductCategory> ProductCategories { get; set; } // ProductCategories
        public DbSet<SomeTable> SomeTables { get; set; } // SomeTables

        public FakeMyDbContext()
        {
            _changeTracker = null;
            _configuration = null;
            _database = null;

            Customers = new FakeDbSet<Customer>("Id");
            CustomerOrders = new FakeDbSet<CustomerOrder>("CustomerOrderId");
            CustomerOrdersDetails = new FakeDbSet<CustomerOrdersDetail>("Id");
            CustomerOrdersMultipleProducts = new FakeDbSet<CustomerOrdersMultipleProduct>("CustomerOrderId");
            CustomerProducts = new FakeDbSet<CustomerProduct>("Id");
            ProductCategories = new FakeDbSet<ProductCategory>("Id");
            SomeTables = new FakeDbSet<SomeTable>("MyProperty");

        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(() => 1);
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private DbChangeTracker _changeTracker;

        public DbChangeTracker ChangeTracker { get { return _changeTracker; } }

        private DbContextConfiguration _configuration;

        public DbContextConfiguration Configuration { get { return _configuration; } }

        private Database _database;

        public Database Database { get { return _database; } }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            throw new NotImplementedException();
        }

        public DbSet Set(Type entityType)
        {
            throw new NotImplementedException();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Fake DbSet

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    public class FakeDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity> where TEntity : class
    {
        private readonly PropertyInfo[] _primaryKeys;
        private readonly ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken);
        }

        public override Task<TEntity> FindAsync(params object[] keyValues)
        {
            return Task<TEntity>.Factory.StartNew(() => Find(keyValues));
        }

        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Add(entity);
            }
            return items;
        }

        public override TEntity Add(TEntity item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Remove(entity);
            }
            return items;
        }

        public override TEntity Remove(TEntity item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }
    }

    public class FakeDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var m = expression as MethodCallExpression;
            if (m != null)
            {
                var resultType = m.Method.ReturnType; // it should be IQueryable<T>
                var tElement = resultType.GetGenericArguments()[0];
                var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(tElement);
                return (IQueryable) Activator.CreateInstance(queryType, expression);
            }
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            var queryType = typeof(FakeDbAsyncEnumerable<>).MakeGenericType(typeof(TElement));
            return (IQueryable<TElement>) Activator.CreateInstance(queryType, expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public Task<object> ExecuteAsync(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute(expression));
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }
    }

    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public FakeDbAsyncEnumerable(Expression expression)
            : base(expression)
        { }

        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<T>(this); }
        }

    }

    public class FakeDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

    #endregion

    #region POCO classes

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Customers
    public class Customer
    {
        [Key, Column(Order = 1)]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Display(Name = "Name")]
        public string Name { get; set; } // Name

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } // PhoneNumber

        [Display(Name = "Email")]
        public string Email { get; set; } // Email

        // Reverse navigation

        /// <summary>
        /// Child CustomerOrders where [CustomerOrders].[Customer_Id] point to this entity (FK_dbo.CustomerOrders_dbo.Customers_Customer_Id)
        /// </summary>
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } // CustomerOrders.FK_dbo.CustomerOrders_dbo.Customers_Customer_Id

        /// <summary>
        /// Child CustomerOrdersMultipleProducts where [CustomerOrdersMultipleProducts].[Customer_Id] point to this entity (FK_dbo.CustomerOrdersMultipleProducts_dbo.Customers_Customer_Id)
        /// </summary>
        public virtual ICollection<CustomerOrdersMultipleProduct> CustomerOrdersMultipleProducts { get; set; } // CustomerOrdersMultipleProducts.FK_dbo.CustomerOrdersMultipleProducts_dbo.Customers_Customer_Id

        public Customer()
        {
            CustomerOrders = new List<CustomerOrder>();
            CustomerOrdersMultipleProducts = new List<CustomerOrdersMultipleProduct>();
        }
    }

    // CustomerOrders
    public class CustomerOrder
    {
        [Key, Column(Order = 1)]
        [Required]
        [Display(Name = "Customer order ID")]
        public int CustomerOrderId { get; set; } // CustomerOrderId (Primary key)

        [Required]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; } // OrderDate

        [Required]
        [Display(Name = "Total price")]
        public double TotalPrice { get; set; } // TotalPrice

        [Required]
        [Display(Name = "Product quantity")]
        public int ProductQuantity { get; set; } // ProductQuantity

        [Required]
        [Display(Name = "Product price")]
        public double ProductPrice { get; set; } // ProductPrice

        [Display(Name = "Customer ID")]
        public int? CustomerId { get; set; } // Customer_Id

        [Display(Name = "Product ID")]
        public int? ProductId { get; set; } // Product_Id

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [CustomerOrders].([CustomerId]) (FK_dbo.CustomerOrders_dbo.Customers_Customer_Id)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_dbo.CustomerOrders_dbo.Customers_Customer_Id

        /// <summary>
        /// Parent CustomerProduct pointed by [CustomerOrders].([ProductId]) (FK_dbo.CustomerOrders_dbo.CustomerProducts_Product_Id)
        /// </summary>
        public virtual CustomerProduct CustomerProduct { get; set; } // FK_dbo.CustomerOrders_dbo.CustomerProducts_Product_Id
    }

    // CustomerOrdersDetails
    public class CustomerOrdersDetail
    {
        [Key, Column(Order = 1)]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } // Quantity

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; } // Price

        [Display(Name = "Product ID")]
        public int? ProductId { get; set; } // Product_Id

        [Display(Name = "Order multiple customer order ID")]
        public int? OrderMultipleCustomerOrderId { get; set; } // OrderMultiple_CustomerOrderId

        // Foreign keys

        /// <summary>
        /// Parent CustomerOrdersMultipleProduct pointed by [CustomerOrdersDetails].([OrderMultipleCustomerOrderId]) (FK_dbo.ProductDatas_dbo.CustomerOrdersMultipleProducts_OrderMultiple_CustomerOrderId)
        /// </summary>
        public virtual CustomerOrdersMultipleProduct CustomerOrdersMultipleProduct { get; set; } // FK_dbo.ProductDatas_dbo.CustomerOrdersMultipleProducts_OrderMultiple_CustomerOrderId

        /// <summary>
        /// Parent CustomerProduct pointed by [CustomerOrdersDetails].([ProductId]) (FK_dbo.ProductDatas_dbo.CustomerProducts_Product_Id)
        /// </summary>
        public virtual CustomerProduct CustomerProduct { get; set; } // FK_dbo.ProductDatas_dbo.CustomerProducts_Product_Id
    }

    // CustomerOrdersMultipleProducts
    public class CustomerOrdersMultipleProduct
    {
        [Key, Column(Order = 1)]
        [Required]
        [Display(Name = "Customer order ID")]
        public int CustomerOrderId { get; set; } // CustomerOrderId (Primary key)

        [Required]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; } // OrderDate

        [Required]
        [Display(Name = "Total price")]
        public double TotalPrice { get; set; } // TotalPrice

        [Display(Name = "Customer ID")]
        public int? CustomerId { get; set; } // Customer_Id

        // Reverse navigation

        /// <summary>
        /// Child CustomerOrdersDetails where [CustomerOrdersDetails].[OrderMultiple_CustomerOrderId] point to this entity (FK_dbo.ProductDatas_dbo.CustomerOrdersMultipleProducts_OrderMultiple_CustomerOrderId)
        /// </summary>
        public virtual ICollection<CustomerOrdersDetail> CustomerOrdersDetails { get; set; } // CustomerOrdersDetails.FK_dbo.ProductDatas_dbo.CustomerOrdersMultipleProducts_OrderMultiple_CustomerOrderId

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [CustomerOrdersMultipleProducts].([CustomerId]) (FK_dbo.CustomerOrdersMultipleProducts_dbo.Customers_Customer_Id)
        /// </summary>
        public virtual Customer Customer { get; set; } // FK_dbo.CustomerOrdersMultipleProducts_dbo.Customers_Customer_Id

        public CustomerOrdersMultipleProduct()
        {
            CustomerOrdersDetails = new List<CustomerOrdersDetail>();
        }
    }

    // CustomerProducts
    public class CustomerProduct
    {
        [Key, Column(Order = 1)]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Title")]
        public string Title { get; set; } // Title

        [Display(Name = "Description")]
        public string Description { get; set; } // Description

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; } // Price

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; } // Category_Id

        // Reverse navigation

        /// <summary>
        /// Child CustomerOrders where [CustomerOrders].[Product_Id] point to this entity (FK_dbo.CustomerOrders_dbo.CustomerProducts_Product_Id)
        /// </summary>
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; } // CustomerOrders.FK_dbo.CustomerOrders_dbo.CustomerProducts_Product_Id

        /// <summary>
        /// Child CustomerOrdersDetails where [CustomerOrdersDetails].[Product_Id] point to this entity (FK_dbo.ProductDatas_dbo.CustomerProducts_Product_Id)
        /// </summary>
        public virtual ICollection<CustomerOrdersDetail> CustomerOrdersDetails { get; set; } // CustomerOrdersDetails.FK_dbo.ProductDatas_dbo.CustomerProducts_Product_Id

        // Foreign keys

        /// <summary>
        /// Parent ProductCategory pointed by [CustomerProducts].([CategoryId]) (FK_dbo.CustomerProducts_dbo.ProductCategories_Category_Id)
        /// </summary>
        public virtual ProductCategory ProductCategory { get; set; } // FK_dbo.CustomerProducts_dbo.ProductCategories_Category_Id

        public CustomerProduct()
        {
            CustomerOrders = new List<CustomerOrder>();
            CustomerOrdersDetails = new List<CustomerOrdersDetail>();
        }
    }

    // ProductCategories
    public class ProductCategory
    {
        [Key, Column(Order = 1)]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        [Display(Name = "Title")]
        public string Title { get; set; } // Title

        [Display(Name = "Description")]
        public string Description { get; set; } // Description

        // Reverse navigation

        /// <summary>
        /// Child CustomerProducts where [CustomerProducts].[Category_Id] point to this entity (FK_dbo.CustomerProducts_dbo.ProductCategories_Category_Id)
        /// </summary>
        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; } // CustomerProducts.FK_dbo.CustomerProducts_dbo.ProductCategories_Category_Id

        public ProductCategory()
        {
            CustomerProducts = new List<CustomerProduct>();
        }
    }

    // SomeTables
    public class SomeTable
    {
        [Key, Column(Order = 1)]
        [Required]
        [Display(Name = "My property")]
        public int MyProperty { get; set; } // MyProperty (Primary key)

        [Display(Name = "My date")]
        public DateTime? MyDate { get; set; } // MyDate

        [Display(Name = "My bool property")]
        public bool? MyBoolProperty { get; set; } // MyBoolProperty

        [Display(Name = "My string property")]
        public string MyStringProperty { get; set; } // MyStringProperty
    }


    #endregion

    #region POCO Configuration

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // Customers
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
            : this("dbo")
        {
        }

        public CustomerConfiguration(string schema)
        {
            ToTable("Customers", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.PhoneNumber).HasColumnName(@"PhoneNumber").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar(max)").IsOptional();
        }
    }

    // CustomerOrders
    public class CustomerOrderConfiguration : EntityTypeConfiguration<CustomerOrder>
    {
        public CustomerOrderConfiguration()
            : this("dbo")
        {
        }

        public CustomerOrderConfiguration(string schema)
        {
            ToTable("CustomerOrders", schema);
            HasKey(x => x.CustomerOrderId);

            Property(x => x.CustomerOrderId).HasColumnName(@"CustomerOrderId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderDate).HasColumnName(@"OrderDate").HasColumnType("datetime").IsRequired();
            Property(x => x.TotalPrice).HasColumnName(@"TotalPrice").HasColumnType("float").IsRequired();
            Property(x => x.ProductQuantity).HasColumnName(@"ProductQuantity").HasColumnType("int").IsRequired();
            Property(x => x.ProductPrice).HasColumnName(@"ProductPrice").HasColumnType("float").IsRequired();
            Property(x => x.CustomerId).HasColumnName(@"Customer_Id").HasColumnType("int").IsOptional();
            Property(x => x.ProductId).HasColumnName(@"Product_Id").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.Customer).WithMany(b => b.CustomerOrders).HasForeignKey(c => c.CustomerId).WillCascadeOnDelete(false); // FK_dbo.CustomerOrders_dbo.Customers_Customer_Id
            HasOptional(a => a.CustomerProduct).WithMany(b => b.CustomerOrders).HasForeignKey(c => c.ProductId).WillCascadeOnDelete(false); // FK_dbo.CustomerOrders_dbo.CustomerProducts_Product_Id
        }
    }

    // CustomerOrdersDetails
    public class CustomerOrdersDetailConfiguration : EntityTypeConfiguration<CustomerOrdersDetail>
    {
        public CustomerOrdersDetailConfiguration()
            : this("dbo")
        {
        }

        public CustomerOrdersDetailConfiguration(string schema)
        {
            ToTable("CustomerOrdersDetails", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Quantity).HasColumnName(@"Quantity").HasColumnType("int").IsRequired();
            Property(x => x.Price).HasColumnName(@"Price").HasColumnType("float").IsRequired();
            Property(x => x.ProductId).HasColumnName(@"Product_Id").HasColumnType("int").IsOptional();
            Property(x => x.OrderMultipleCustomerOrderId).HasColumnName(@"OrderMultiple_CustomerOrderId").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.CustomerOrdersMultipleProduct).WithMany(b => b.CustomerOrdersDetails).HasForeignKey(c => c.OrderMultipleCustomerOrderId).WillCascadeOnDelete(false); // FK_dbo.ProductDatas_dbo.CustomerOrdersMultipleProducts_OrderMultiple_CustomerOrderId
            HasOptional(a => a.CustomerProduct).WithMany(b => b.CustomerOrdersDetails).HasForeignKey(c => c.ProductId).WillCascadeOnDelete(false); // FK_dbo.ProductDatas_dbo.CustomerProducts_Product_Id
        }
    }

    // CustomerOrdersMultipleProducts
    public class CustomerOrdersMultipleProductConfiguration : EntityTypeConfiguration<CustomerOrdersMultipleProduct>
    {
        public CustomerOrdersMultipleProductConfiguration()
            : this("dbo")
        {
        }

        public CustomerOrdersMultipleProductConfiguration(string schema)
        {
            ToTable("CustomerOrdersMultipleProducts", schema);
            HasKey(x => x.CustomerOrderId);

            Property(x => x.CustomerOrderId).HasColumnName(@"CustomerOrderId").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrderDate).HasColumnName(@"OrderDate").HasColumnType("datetime").IsRequired();
            Property(x => x.TotalPrice).HasColumnName(@"TotalPrice").HasColumnType("float").IsRequired();
            Property(x => x.CustomerId).HasColumnName(@"Customer_Id").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.Customer).WithMany(b => b.CustomerOrdersMultipleProducts).HasForeignKey(c => c.CustomerId).WillCascadeOnDelete(false); // FK_dbo.CustomerOrdersMultipleProducts_dbo.Customers_Customer_Id
        }
    }

    // CustomerProducts
    public class CustomerProductConfiguration : EntityTypeConfiguration<CustomerProduct>
    {
        public CustomerProductConfiguration()
            : this("dbo")
        {
        }

        public CustomerProductConfiguration(string schema)
        {
            ToTable("CustomerProducts", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(max)").IsRequired();
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Price).HasColumnName(@"Price").HasColumnType("float").IsRequired();
            Property(x => x.CategoryId).HasColumnName(@"Category_Id").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.ProductCategory).WithMany(b => b.CustomerProducts).HasForeignKey(c => c.CategoryId); // FK_dbo.CustomerProducts_dbo.ProductCategories_Category_Id
        }
    }

    // ProductCategories
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
            : this("dbo")
        {
        }

        public ProductCategoryConfiguration(string schema)
        {
            ToTable("ProductCategories", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName(@"Title").HasColumnType("nvarchar(max)").IsOptional();
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar(max)").IsOptional();
        }
    }

    // SomeTables
    public class SomeTableConfiguration : EntityTypeConfiguration<SomeTable>
    {
        public SomeTableConfiguration()
            : this("dbo")
        {
        }

        public SomeTableConfiguration(string schema)
        {
            ToTable("SomeTables", schema);
            HasKey(x => x.MyProperty);

            Property(x => x.MyProperty).HasColumnName(@"MyProperty").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.MyDate).HasColumnName(@"MyDate").HasColumnType("datetime").IsOptional();
            Property(x => x.MyBoolProperty).HasColumnName(@"MyBoolProperty").HasColumnType("bit").IsOptional();
            Property(x => x.MyStringProperty).HasColumnName(@"MyStringProperty").HasColumnType("nvarchar(max)").IsOptional();
        }
    }


    #endregion

}
// </auto-generated>